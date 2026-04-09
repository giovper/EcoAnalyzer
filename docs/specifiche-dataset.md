# Specifiche del Dataset — EcoAnalyzer

## 1. Origine dei dati

EcoAnalyzer utilizza i dati forniti da **Open-Meteo** (https://open-meteo.com), un servizio meteorologico open-source e gratuito che non richiede registrazione né chiave API.

I dati vengono scaricati in tempo reale tramite due API REST distinte:

| API | Endpoint base | Scopo |
|-----|---------------|-------|
| Historical Weather API | `https://archive-api.open-meteo.com/v1/archive` | Dati meteorologici storici |
| Air Quality API | `https://air-quality-api.open-meteo.com/v1/air-quality` | Indice di qualità dell'aria storico |

---

## 2. Dati che raccogliamo

L'applicazione recupera **7 variabili orarie** suddivise nelle due API:

### 2.1 Variabili meteorologiche (Historical Weather API)

| Variabile interna | Parametro API | Descrizione | Unità di misura |
|-------------------|---------------|-------------|-----------------|
| `Temperature` | `temperature_2m` | Temperatura dell'aria a 2 m dal suolo | °C |
| `RelativeHumidity` | `relativehumidity_2m` | Umidità relativa a 2 m dal suolo | % |
| `ApparentTemperature` | `apparent_temperature` | Temperatura percepita (wind chill / heat index) | °C |
| `PrecipitationProbability` | `precipitation` | Precipitazioni cumulate nell'ora | mm |
| `WindSpeed` | `windspeed_10m` | Velocità del vento a 10 m dal suolo | km/h |
| `SurfacePressure` | `surface_pressure` | Pressione atmosferica al suolo | hPa |

### 2.2 Variabili sulla qualità dell'aria (Air Quality API)

| Variabile interna | Parametro API | Descrizione | Unità di misura |
|-------------------|---------------|-------------|-----------------|
| `AirQuality` | `european_aqi` | Indice europeo di qualità dell'aria (EEA) | AQI (0–500) |

---

## 3. Dati offerti da Open-Meteo (non tutti utilizzati)

Open-Meteo mette a disposizione un catalogo molto più ampio. Di seguito un riepilogo delle principali categorie disponibili, a titolo informativo:

**Historical Weather API** offre, tra l'altro:
- Temperature (2 m, suolo, pressione)
- Umidità, punto di rugiada
- Precipitazioni, neve, pioggia
- Copertura nuvolosa
- Radiazione solare (globale, diretta, diffusa)
- Velocità e direzione del vento a varie quote
- Evapotraspirazione
- Dati del suolo (temperatura e umidità a varie profondità)

**Air Quality API** offre, tra l'altro:
- Indici AQI europeo e americano (EPA)
- Concentrazioni di PM2.5, PM10
- NO₂, CO, SO₂, O₃
- Polveri da deserto, fumo da incendi

EcoAnalyzer usa solo le 7 variabili descritte nella sezione 2.

---

## 4. Copertura temporale e geografica

### Periodo storico disponibile
- **Historical Weather API**: a partire dal **1940** fino a pochi giorni prima della data corrente.
- **Air Quality API**: a partire dal **2022** circa, con aggiornamenti quasi in tempo reale.

### Copertura geografica
- **Globale**: entrambe le API coprono qualsiasi punto del pianeta specificando latitudine e longitudine.
- Non esistono restrizioni geografiche; la risoluzione spaziale varia in base al modello climatico scelto (di default ERA5 per i dati storici, con griglia ~25 km).

### Risoluzione temporale
- Tutti i dati restituiti dall'API hanno risoluzione **oraria** (un valore per ogni ora del periodo richiesto).

---

## 5. Altre caratteristiche del dataset

| Caratteristica | Dettaglio |
|----------------|-----------|
| Formato di risposta | JSON |
| Autenticazione | Non richiesta (servizio gratuito e open) |
| Limite di velocità | Nessun limite esplicito per uso non commerciale |
| Modello climatico usato | ERA5 (ECMWF) per i dati storici |
| Valori mancanti | Possibili in alcune zone remote; restituiti come `null` nell'array JSON |
| Fuso orario | UTC di default; configurabile tramite parametro `timezone` |
| Licenza dei dati | CC BY 4.0 (Creative Commons Attribuzione) |

---

## 6. Come l'applicazione scarica i dati

### 6.1 Costruzione delle URL di richiesta

Le URL vengono costruite dinamicamente in `WeatherService.cs` con i parametri inseriti dall'utente (coordinate e intervallo di date):

```
// Meteo storico
https://archive-api.open-meteo.com/v1/archive
  ?latitude={lat}
  &longitude={lng}
  &hourly=temperature_2m,relativehumidity_2m,apparent_temperature,
          precipitation,windspeed_10m,surface_pressure
  &start_date={YYYY-MM-dd}
  &end_date={YYYY-MM-dd}

// Qualità dell'aria
https://air-quality-api.open-meteo.com/v1/air-quality
  ?latitude={lat}
  &longitude={lng}
  &hourly=european_aqi
  &start_date={YYYY-MM-dd}
  &end_date={YYYY-MM-dd}
```

Le coordinate vengono formattate con `CultureInfo.InvariantCulture` per garantire il punto decimale indipendentemente dalla lingua di sistema.

### 6.2 Esecuzione della richiesta HTTP

Il progetto usa **`System.Net.Http.HttpClient`**, il client HTTP nativo di .NET, senza librerie esterne.

```csharp
using HttpClient client = new HttpClient();

string weatherResponse = await client.GetStringAsync(weatherUrl);
string airResponse     = await client.GetStringAsync(airUrl);
```

- Le chiamate sono **asincrone** (`async/await`), così l'interfaccia grafica non si blocca durante il download.
- Viene usato il metodo `GetStringAsync()`, che restituisce direttamente il corpo della risposta come stringa JSON.
- Non vengono impostati header personalizzati né timeout espliciti.

### 6.3 Parsing della risposta

Il JSON viene elaborato con **`System.Text.Json.JsonDocument`** (libreria standard di .NET):

```csharp
using JsonDocument weatherJson = JsonDocument.Parse(weatherResponse);
var hourly = weatherJson.RootElement.GetProperty("hourly");

// Esempio: lettura temperatura
float temp = hourly.GetProperty("temperature_2m")[i].GetSingle();
```

I valori vengono letti indice per indice dall'array orario e salvati come oggetti `DataPoint { DateTime Time, float Value }`, poi raggruppati in un dizionario `Dictionary<RecordedFeature, List<DataPoint>>`.

### 6.4 Cache locale

Per evitare richieste ripetute verso le API, i dati scaricati vengono salvati localmente in:

```
EcoAnalyzerData/wheatherDataCache.json
```

Ad ogni richiesta, l'applicazione controlla prima se la combinazione di coordinate e intervallo di date è già presente nella cache. Se sì, i dati vengono caricati dal file locale senza contattare Open-Meteo.

---

## 7. Schema del flusso dati

```
Utente seleziona
  coordinate + date
        |
        v
WeatherService controlla
  la cache locale
        |
   [dati presenti] ---------> Carica da file JSON
        |
   [dati assenti]
        |
        v
HttpClient invia GET
  alle due API Open-Meteo
        |
        v
JsonDocument parsa
  le risposte JSON
        |
        v
Dati salvati nella cache
  e restituiti all'UI
        |
        v
ScottPlot visualizza
  i grafici
```
