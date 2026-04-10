# Panoramica del Progetto — EcoAnalyzer

## Cos'è EcoAnalyzer

EcoAnalyzer è un'applicazione desktop per Windows che permette di visualizzare e analizzare dati meteorologici e sulla qualità dell'aria storici per qualsiasi punto del pianeta. L'utente seleziona una posizione geografica su una mappa interattiva, sceglie un intervallo di date, e l'applicazione scarica i dati da Open-Meteo, li visualizza in un grafico interattivo e permette di esportarli.

---

## Struttura della soluzione

La soluzione è composta da due progetti C# distinti:

```
EcoAnalyzer/                        (soluzione .sln)
├── EcoAnalyzerLib/                 (libreria .NET — net10.0)
│   ├── WeatherService.cs           Logica di recupero dati, calcoli, cache
│   ├── RecordedFeature.cs          Enum delle variabili meteorologiche
│   ├── FeatureInformation.cs       Attributo personalizzato per i metadati
│   ├── RecordDomain.cs             Parametri di una richiesta (luogo + periodo)
│   ├── RecordPeriod.cs             Risposta completa con tutti i dati
│   ├── DataPoint.cs                Singola misurazione (timestamp + valore)
│   └── RecordedFeatureExtension.cs Metodo estensione GetInfo()
│
└── EcoAnalyzer/                    (applicazione WinForms — net10.0-windows)
    ├── Program.cs                  Entry point
    ├── EcoAnalyzerStartingPage.cs  Pagina iniziale: mappa + selezione date
    ├── EcoAnalyzerGraphPage.cs     Pagina principale: grafico + export
    └── RecordedFeatureExtension.cs Metodo estensione GetInfo() (per l'UI)
```

**EcoAnalyzerLib** è una libreria autonoma senza dipendenze da WinForms: contiene tutta la logica applicativa. **EcoAnalyzer** è il progetto UI che fa riferimento alla libreria e si occupa solo della presentazione.

---

## Dipendenze esterne

| Pacchetto | Versione | Utilizzo |
|-----------|----------|----------|
| GMap.NET.WinForms | 2.1.7 | Mappa interattiva per la selezione della posizione |
| ScottPlot.WinForms | 5.1.58 | Grafico delle serie temporali |

La libreria EcoAnalyzerLib non ha dipendenze NuGet: usa solo le API standard di .NET 10.

---

## Come compilare ed eseguire

### Requisiti

- .NET SDK 10.0 o superiore
- Windows (richiesto da WinForms)

### Comandi

```bash
# Ripristina i pacchetti e compila
dotnet build EcoAnalyzer/EcoAnalyzer.sln

# Avvia l'applicazione
dotnet run --project EcoAnalyzer/EcoAnalyzer/EcoAnalyzer.csproj
```

### In Visual Studio

Aprire `EcoAnalyzer/EcoAnalyzer.sln`, impostare `EcoAnalyzer` come progetto di avvio e premere F5.

---

## Flusso di utilizzo

```
1. L'utente apre l'applicazione
        |
        v
2. EcoAnalyzerStartingPage mostra la mappa
        |
        v
3. L'utente clicca sulla mappa → segna un punto
   L'utente sceglie date inizio/fine
        |
        v
4. Click su "Cerca" → si apre EcoAnalyzerGraphPage
        |
        v
5. WeatherService controlla la cache locale
   Se i dati non sono presenti → chiama le API Open-Meteo
        |
        v
6. I dati vengono mostrati nel grafico ScottPlot
   L'utente può:
     - Passare il mouse per vedere i valori in tempo reale
     - Attivare/disattivare singole variabili
     - Aprire la pagina statistiche
     - Esportare in CSV o JSON
```

---

## Cache locale

Per evitare chiamate API ripetute, i dati scaricati vengono salvati in:

```
EcoAnalyzerData/wheatherDataCache.json
```

Questo file è una lista JSON di oggetti `RecordPeriod`. Ad ogni avvio, se la combinazione coordinate + date è già presente, i dati vengono caricati dal disco senza contattare Open-Meteo.
