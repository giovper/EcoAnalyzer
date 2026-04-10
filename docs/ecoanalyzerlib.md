# EcoAnalyzerLib — Documentazione della libreria

EcoAnalyzerLib è il cuore dell'applicazione: contiene tutti i modelli di dati, la logica di comunicazione con le API e i calcoli matematici. È un progetto .NET 10 autonomo, senza dipendenze da WinForms, quindi potrebbe essere riutilizzato anche in altri tipi di applicazione.

---

## Classi e tipi

### `DataPoint`

**File:** `WeatherService.cs`

Rappresenta una singola misurazione meteorologica: un timestamp e un valore numerico.

```csharp
public class DataPoint
{
    public DateTime Time  { get; set; }
    public float    Value { get; set; }
}
```

| Proprietà | Tipo | Descrizione |
|-----------|------|-------------|
| `Time` | `DateTime` | Data e ora della misurazione (risoluzione oraria) |
| `Value` | `float` | Valore della variabile nell'unità nativa (°C, %, mm, ecc.) |

---

### `RecordedFeature`

**File:** `RecordedFeature.cs`

Enumerazione che elenca tutte le variabili meteorologiche gestite dall'applicazione. Ogni valore è decorato con l'attributo `[FeatureInformation]` che ne descrive il nome e il colore da usare nel grafico.

```csharp
public enum RecordedFeature
{
    Temperature,            // Temperatura a 2 m
    RelativeHumidity,       // Umidità relativa
    ApparentTemperature,    // Temperatura percepita
    PrecipitationProbability, // Precipitazioni (mm)
    WindSpeed,              // Velocità del vento
    SurfacePressure,        // Pressione atmosferica
    AirQuality              // Indice europeo qualità aria (AQI)
}
```

Per accedere ai metadati di un valore si usa il metodo estensione `GetInfo()`:

```csharp
FeatureInformation fi = RecordedFeature.Temperature.GetInfo();
string nome  = fi.Name;   // "Temperature"
Color  colore = fi.Color; // Color.FromArgb(220, 20, 60)
```

---

### `FeatureInformation`

**File:** `FeatureInformation.cs`

Attributo personalizzato applicato ai campi di `RecordedFeature`. Memorizza:

| Proprietà | Tipo | Descrizione |
|-----------|------|-------------|
| `Name` | `string` | Nome da visualizzare (es. `"Wind Speed"`) |
| `Color` | `Color` | Colore della linea nel grafico |
| `suitableForLineGraph` | `bool` | `true` se la variabile è adatta a essere tracciata come linea continua |

Esempio di dichiarazione:

```csharp
[FeatureInformation("Temperature", r: 220, g: 20, b: 60, suitableForLineGraph: true)]
Temperature,
```

---

### `RecordDomain`

**File:** `RecordDomain.cs`

Struct che rappresenta i parametri di una richiesta dati: dove e quando.

```csharp
public struct RecordDomain
{
    public (float Lat, float Lng) Coordinates;
    public DateTime StartingTime;
    public DateTime EndingTime;
}
```

| Campo | Tipo | Descrizione |
|-------|------|-------------|
| `Coordinates` | `(float Lat, float Lng)` | Latitudine e longitudine del punto selezionato |
| `StartingTime` | `DateTime` | Data di inizio del periodo richiesto |
| `EndingTime` | `DateTime` | Data di fine del periodo richiesto |

Viene usato sia come chiave per la ricerca nella cache, sia come parametro per costruire le URL delle API.

---

### `RecordPeriod`

**File:** `RecordPeriod.cs`

Classe che rappresenta una risposta completa: tutti i dati orari per un dato dominio geografico e temporale.

```csharp
public class RecordPeriod
{
    public RecordDomain Domain { get; set; }
    public Dictionary<RecordedFeature, List<DataPoint>> Data { get; set; }
}
```

| Membro | Tipo | Descrizione |
|--------|------|-------------|
| `Domain` | `RecordDomain` | Il dominio cui si riferiscono i dati |
| `Data` | `Dictionary<RecordedFeature, List<DataPoint>>` | Un elenco di `DataPoint` per ogni variabile |

#### Metodi principali

**`GetAllValuesForFeature(RecordedFeature rf)`**

Restituisce la lista di `DataPoint` per la variabile specificata.

```csharp
List<DataPoint> temps = periodo.GetAllValuesForFeature(RecordedFeature.Temperature);
```

**`ObtainCSV(string separator = "\t")`**

Restituisce una stringa in formato CSV (o TSV) con tutte le variabili in colonne, una riga per ora. Può essere salvata direttamente su file.

```csharp
string csv = periodo.ObtainCSV();
File.WriteAllText("export.csv", csv);
```

---

### `RecordedFeatureExtension`

**File:** `RecordedFeatureExtension.cs`

Classe statica con il metodo estensione `GetInfo()`, che permette di leggere l'attributo `FeatureInformation` da qualsiasi valore di `RecordedFeature` tramite reflection.

```csharp
public static FeatureInformation GetInfo(this RecordedFeature value)
{
    FieldInfo field = value.GetType().GetField(value.ToString())!;
    return (FeatureInformation)Attribute.GetCustomAttribute(field, typeof(FeatureInformation))!;
}
```

---

### `WeatherService`

**File:** `WeatherService.cs`

Classe principale della libreria. Gestisce:
- il recupero dei dati dalle API di Open-Meteo
- la cache locale su file JSON
- la normalizzazione dei valori per il grafico
- la regressione lineare
- la formattazione dei valori con unità di misura

#### Costruttore

```csharp
public WeatherService(string dataFolder = "EcoAnalyzerData\\")
```

`dataFolder` specifica la cartella in cui viene salvata la cache. Di default è `EcoAnalyzerData\`.

#### `GetRecordsFromDomain(RecordDomain rd)` — metodo pubblico principale

```csharp
public async Task<(RecordPeriod, string json)> GetRecordsFromDomain(RecordDomain rd)
```

Punto di ingresso per ottenere i dati. La logica è:

1. Se esiste il file di cache, lo legge e cerca `rd` al suo interno.
2. Se trovato → restituisce i dati dalla cache.
3. Se non trovato → chiama le API, aggiunge il risultato alla cache e lo restituisce.
4. Se il file di cache non esiste → chiama le API, crea il file e restituisce i dati.

Lancia un'eccezione se la chiamata API fallisce.

#### `ScaleFeature(RecordedFeature feature, double value)` — metodo statico

```csharp
public static double ScaleFeature(RecordedFeature feature, double value)
```

Normalizza un valore nel range `[0, 1]` (può uscire leggermente fuori range per valori estremi) in base a intervalli fissi per ogni variabile. Serve a far sì che tutte le serie temporali siano confrontabili sullo stesso asse verticale del grafico.

Vedi anche: [algoritmi.md](algoritmi.md)

#### `GetFeatureString(RecordedFeature feature, float value, bool inserisciNome)` — metodo statico

```csharp
public static string GetFeatureString(RecordedFeature feature, float value, bool inserisciNome = false)
```

Restituisce una stringa formattata con il valore e la sua unità di misura, in italiano. Esempio:

```csharp
WeatherService.GetFeatureString(RecordedFeature.Temperature, 21.4f) // "21.4 °C"
WeatherService.GetFeatureString(RecordedFeature.WindSpeed, 35f, inserisciNome: true) // "Vento: 35.0 km/h"
```

#### `RegressioneLineare(List<double> x, List<double> y)` — metodo statico

```csharp
public static (double a, double b, double errore_medio) RegressioneLineare(List<double> x, List<double> y)
```

Calcola la retta di regressione lineare su due serie di valori e ne restituisce i coefficienti e l'errore medio percentuale. Vedi [algoritmi.md](algoritmi.md) per i dettagli matematici.

#### `CalculateLinear(double x, double a, double b)` — metodo statico

```csharp
public static double CalculateLinear(double x, double a, double b)
```

Calcola `y = a·x + b`. Usato per valutare la retta di regressione in un punto.
