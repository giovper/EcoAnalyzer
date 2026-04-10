# Algoritmi — EcoAnalyzer

Questo documento descrive i due principali algoritmi implementati in `WeatherService.cs`: la normalizzazione delle variabili e la regressione lineare semplice.

---

## 1. Normalizzazione delle variabili (Feature Scaling)

### Problema

Le sette variabili meteorologiche hanno unità di misura e ordini di grandezza completamente diversi: la temperatura varia tra −10 e 40 °C, la pressione tra 950 e 1050 hPa, l'AQI tra 0 e 500. Se le si tracciasse sullo stesso grafico senza normalizzazione, alcune variabili occuperebbero l'intera finestra e altre sarebbero invisibili.

### Soluzione

Ogni valore viene trasformato nel range `[0, 1]` usando la formula **min-max normalization**:

$$
x' = \frac{x - x_{\min}}{x_{\max} - x_{\min}}
$$

dove `x_min` e `x_max` sono valori fissi scelti in base all'intervallo fisico ragionevole per ciascuna variabile.

### Intervalli usati

| Variabile | `x_min` | `x_max` | Unità |
|-----------|---------|---------|-------|
| Temperatura | −10 | 40 | °C |
| Temp. percepita | −10 | 40 | °C |
| Umidità relativa | 0 | 100 | % |
| Precipitazioni | 0 | 20 | mm |
| Velocità del vento | 0 | 100 | km/h |
| Pressione | 950 | 1050 | hPa |
| Qualità dell'aria (AQI) | 0 | 500 | AQI |

Un valore che cade fuori dall'intervallo (es. una tempesta con 60 mm di pioggia) produrrà un valore normalizzato fuori da `[0, 1]`, ma il grafico usa `LockedVertical` che mostra solo `[-0.2, 1.2]`, quindi valori estremi rimangono comunque leggibili.

### Implementazione

```csharp
public static double ScaleFeature(RecordedFeature feature, double value)
{
    double min, max;

    switch (feature)
    {
        case RecordedFeature.Temperature:
        case RecordedFeature.ApparentTemperature:
            min = -10; max = 40; break;

        case RecordedFeature.RelativeHumidity:
            min = 0; max = 100; break;

        case RecordedFeature.PrecipitationProbability:
            min = 0; max = 20; break;

        case RecordedFeature.WindSpeed:
            min = 0; max = 100; break;

        case RecordedFeature.SurfacePressure:
            min = 950; max = 1050; break;

        case RecordedFeature.AirQuality:
            min = 0; max = 500; break;

        default:
            return value;
    }

    return (value - min) / (max - min);
}
```

---

## 2. Regressione Lineare Semplice

### Scopo

La regressione lineare permette di trovare la retta che meglio approssima un insieme di punti `(x, y)`. Nel contesto di EcoAnalyzer viene usata per identificare la tendenza di una variabile nel tempo, ovvero se una grandezza (es. la temperatura media) sta aumentando o diminuendo nel periodo analizzato.

La retta è espressa nella forma:

$$
y = a \cdot x + b
$$

dove `a` è il coefficiente angolare (la pendenza della retta) e `b` è l'intercetta.

### Formula (regressione lineare semplice — metodo dei minimi quadrati)

Dati `n` punti `(x_i, y_i)`, si calcolano prima le medie:

$$
\bar{x} = \frac{1}{n} \sum_{i=1}^{n} x_i, \qquad \bar{y} = \frac{1}{n} \sum_{i=1}^{n} y_i
$$

Poi i coefficienti:

$$
a = \frac{\sum_{i=1}^{n} (x_i - \bar{x})(y_i - \bar{y})}{\sum_{i=1}^{n} (x_i - \bar{x})^2}
$$

$$
b = \bar{y} - a \cdot \bar{x}
$$

Il denominatore è la **varianza** di `x`. Se è zero (tutti i valori di `x` sono uguali), non esiste una retta con pendenza definita: in questo caso `a = 0` e `b = media(y)`.

### Errore medio percentuale

Dopo aver trovato `a` e `b`, si calcola l'**errore medio percentuale** per valutare quanto la retta si avvicina ai dati reali:

$$
E = \frac{1}{n} \sum_{i=1}^{n} \left| \frac{y_i - (a \cdot x_i + b)}{y_i} \right|
$$

Un valore vicino a 0 indica che la retta è una buona approssimazione; un valore alto indica molta dispersione attorno alla retta.

> **Nota:** questa formula assume `y_i ≠ 0`. Se la serie contiene zeri (es. precipitazioni nulle), il contributo di quel punto all'errore diventa indefinito (`/0`). Nel codice attuale non è presente una gestione esplicita di questo caso.

### Implementazione

```csharp
public static (double a, double b, double errore_medio) RegressioneLineare(
    List<double> x, List<double> y)
{
    int n = x.Count;
    double avgX = x.Average();
    double avgY = y.Average();

    double num = 0, den = 0;

    for (int i = 0; i < n; i++)
    {
        double dx = x[i] - avgX;
        num += dx * (y[i] - avgY);
        den += Math.Pow(dx, 2);
    }

    if (den == 0)           // nessuna varianza in x
    {
        double a0 = 0, b0 = y.Average();
        return (a0, b0, ErrorePercentuale(x, y, a0, b0));
    }

    double a = num / den;
    double b = avgY - a * avgX;

    return (a, b, ErrorePercentuale(x, y, a, b));
}
```

### Utilizzo pratico

Per usare la regressione nel codice, si convertono i `DataPoint` in due liste di `double` (i valori di X possono essere i `ToOADate()` dei timestamp):

```csharp
var points = recordPeriod.GetAllValuesForFeature(RecordedFeature.Temperature);

List<double> xValues = points.Select(p => p.Time.ToOADate()).ToList();
List<double> yValues = points.Select(p => (double)p.Value).ToList();

var (a, b, errore) = WeatherService.RegressioneLineare(xValues, yValues);

// Calcola y per un dato timestamp
double yPredetto = WeatherService.CalculateLinear(data.ToOADate(), a, b);
```

### Riferimenti

- Wikipedia — [Regressione lineare semplice](https://it.wikipedia.org/wiki/Regressione_lineare#Regressione_lineare_semplice)
- Video esplicativo: [youtube.com/watch?v=rmqQkgs4uHw](https://www.youtube.com/watch?v=rmqQkgs4uHw)
