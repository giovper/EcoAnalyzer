# Interfaccia Utente — EcoAnalyzer

Il progetto `EcoAnalyzer` (WinForms) è composto da due form principali e una form di statistiche. Tutte le form comunicano con la libreria `EcoAnalyzerLib` per ottenere e mostrare i dati.

---

## `EcoAnalyzerStartingPage` — Pagina iniziale

**File:** `EcoAnalyzerStartingPage.cs`

È la prima finestra che appare all'avvio dell'applicazione. Permette all'utente di scegliere dove e quando raccogliere i dati.

### Componenti principali

| Componente | Tipo | Funzione |
|------------|------|----------|
| `gMapControl` | `GMapControl` | Mappa interattiva (Google Hybrid) per selezionare la posizione |
| `dtp_StartDate` | `DateTimePicker` | Selezione data di inizio |
| `dtp_EndDate` | `DateTimePicker` | Selezione data di fine |
| `btn_Search` | `Button` | Avvia l'analisi (disabilitato finché non si clicca sulla mappa) |

### Comportamento

1. **Mappa**: usa `GMap.NET` in modalità `GoogleHybridMap` con accesso `ServerAndCache`. Il tasto sinistro del mouse trascina la mappa, il click posiziona un marker blu.
2. **Marker**: al primo click viene creato un `GMarkerGoogle` (blu); ai click successivi il marker si sposta nella nuova posizione.
3. **Pulsante Cerca**: rimane disabilitato (`btn_Search.Enabled = false`) finché l'utente non clicca almeno una volta sulla mappa.
4. **Lancio della pagina grafica**: il metodo `LaunchMainWindow()` legge le coordinate del marker e le date dai `DateTimePicker`, costruisce un `RecordDomain` e apre `EcoAnalyzerGraphPage` come dialogo modale. Quando la pagina grafica viene chiusa (senza `DialogResult.Abort`), la pagina iniziale ritorna visibile.

---

## `EcoAnalyzerGraphPage` — Pagina del grafico

**File:** `EcoAnalyzerGraphPage.cs`

Finestra principale di analisi. Riceve un `RecordDomain` dal costruttore, scarica i dati tramite `WeatherService` e li visualizza in un grafico interattivo.

### Componenti principali

| Componente | Tipo | Funzione |
|------------|------|----------|
| `plt_Plot` | `FormsPlot` (ScottPlot) | Grafico delle serie temporali |
| `tbl_LegendButtons` | `TableLayoutPanel` | Legenda con bottoni per attivare/disattivare le variabili |
| `txt_Location` | `TextBox` | Mostra coordinate del punto selezionato |
| `dtp_StartDate` / `dtp_EndDate` | `DateTimePicker` | Mostrano le date del periodo analizzato (sola lettura) |
| `lbl_Hover` | `Label` | Mostra il timestamp corrispondente alla posizione del mouse |
| `btn_Back` | `Button` | Torna alla pagina iniziale |
| `btn_CSV` | `Button` | Esporta i dati come file CSV |
| `btn_JSON` | `Button` | Esporta i dati come file JSON |
| `btn_Stats` | `Button` | Apre la form delle statistiche |

### Flusso di caricamento

```
EcoAnalyzerGraphPage_Load (evento asincrono)
        |
        v
GatherGraphData()          → chiama WeatherService.GetRecordsFromDomain()
        |
        v
GenerateGraph()            → disegna le linee con ScottPlot
```

Se `GatherGraphData()` lancia un'eccezione (es. nessuna connessione internet e cache vuota), viene mostrato un `MessageBox` con il messaggio d'errore e la form si chiude.

### Legenda interattiva

La legenda viene generata dinamicamente in `GenerateLegend()`. Per ogni valore di `RecordedFeature` vengono creati:

- Un **Button** colorato con il colore della variabile (click → mostra/nasconde la linea)
- Una **Label** con il nome della variabile
- Una **Label** che mostra il valore corrente mentre il mouse si muove sul grafico

Quando si clicca su un bottone, `ClickButtonLegend()` inverte il flag `shownFeatures[rc]` e chiama `ShowFeatureLine()` per aggiornare la visibilità della linea nel grafico.

### Grafico (ScottPlot)

Configurazione del grafico in `GenerateGraph()`:

- **Asse Y**: fissato a `[-0.2, 1.2]` (valori normalizzati), asse Y nascosto
- **Asse X**: date in formato OADate, con `DateTimeTicksBottom()`
- **Scala Y bloccata**: `LockedVertical` impedisce all'autoscale di modificare l'asse Y
- **Crosshair**: linea verticale rossa che segue il mouse (la linea orizzontale è disabilitata)
- **Leggenda**: nascosta (la legenda è gestita manualmente con `tbl_LegendButtons`)

Ogni variabile viene tracciata come `ScatterLine`. I valori Y sono normalizzati con `WeatherService.ScaleFeature()`.

### Hover del mouse

`Plot_MouseMove` viene agganciato all'evento `MouseMove` di `plt_Plot`. Ad ogni movimento:

1. Converte le coordinate pixel in coordinate del grafico con `plt.GetCoordinates()`
2. Sposta il crosshair
3. Chiama `WriteValues(coords.X)` che, per ogni variabile, trova il `DataPoint` più vicino nel tempo e aggiorna la label corrispondente

### Esportazione dati

**CSV** (`btn_CSV_Click`): apre un `SaveFileDialog` e scrive il risultato di `RecordPeriod.ObtainCSV()` nel file scelto.

**JSON** (`btn_JSON_Click`): apre un `SaveFileDialog` e scrive il JSON grezzo ricevuto dall'API (la variabile `json` restituita da `WeatherService.GetRecordsFromDomain()`).

---

## `RecordedFeatureExtension` (UI)

**File:** `EcoAnalyzer/RecordedFeatureExtension.cs`

Versione più generica del metodo estensione `GetInfo()`, dichiarata nel namespace `EcoAnalyzer`. Funziona su qualsiasi `Enum` (non solo `RecordedFeature`) tramite reflection. Usata dalle form per accedere ai metadati delle variabili senza dover importare direttamente i tipi interni della libreria.

---

## `Program.cs` — Entry point

**File:** `Program.cs`

Standard per un'applicazione WinForms .NET:

```csharp
[STAThread]
static void Main()
{
    ApplicationConfiguration.Initialize();
    Application.Run(new EcoAnalyzerStartingPage());
}
```

`[STAThread]` è obbligatorio per WinForms (il threading model di COM richiede il Single-Threaded Apartment). `ApplicationConfiguration.Initialize()` imposta i comportamenti moderni come il DPI awareness.
