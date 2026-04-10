using EcoAnalyzerLib;
using ScottPlot;
using ScottPlot.Plottables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

// https://www.youtube.com/watch?v=HVH_vNAn8hs

/*
Robe da fare:
- Modalità correlazioni tra le due variabili (temperatura e qualità dell'aria)
- Pagina di statistiche
- Analisi giorno x giorno / settimana per settimana
- Tabelle/grafici..
 
*/

namespace EcoAnalyzer
{
    public partial class EcoAnalyzerGraphPage : Form
    {
        WeatherService weatherService;
        Dictionary<RecordedFeature, bool> shownFeatures;
        Dictionary<RecordedFeature, System.Windows.Forms.Label> printFeatures;
        Dictionary<RecordedFeature, Scatter> featureLines;
        RecordDomain currentDomain;
        RecordPeriod recordPeriod;
        string json;

        Crosshair crosshair;

        public EcoAnalyzerGraphPage(RecordDomain recordDomain)
        {
            InitializeComponent();
            //plt_Plot.Plot.Axes.AutoScaleExpand();
            currentDomain = recordDomain;

            GenerateHeader();
            GenerateLegend();
            weatherService = new();

            plt_Plot.MouseMove += Plot_MouseMove;
        }

        private void GenerateHeader()
        {
            txt_Location.Text = $"{currentDomain.Coordinates.Lat}°N {currentDomain.Coordinates.Lng}°E";
            dtp_StartDate.Value = currentDomain.StartingTime;
            dtp_EndDate.Value = currentDomain.EndingTime;
        }

        private void GenerateLegend()
        {
            tbl_LegendButtons.SuspendLayout();
            tbl_LegendButtons.Controls.Clear();
            tbl_LegendButtons.RowStyles.Clear();
            tbl_LegendButtons.RowCount = 0;
            shownFeatures = new();
            printFeatures = new();

            foreach (RecordedFeature rc in Enum.GetValues(typeof(RecordedFeature)))
            {
                FeatureInformation fi = rc.GetInfo();
                System.Drawing.Color c = fi.Color;
                string txt = fi.Name;

                int row = tbl_LegendButtons.RowCount;
                tbl_LegendButtons.RowCount = row + 1;
                tbl_LegendButtons.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));

                System.Windows.Forms.Button btn = new();
                btn.Name = $"btn_{txt}";
                btn.Tag = rc;
                btn.Text = "";
                btn.BackColor = c;
                btn.Size = new Size(27, 27);
                btn.Click += ClickButtonLegend;

                /*CheckBox chk = new();
                chk.Name = $"chk_{txt}";
                chk.Tag = rc;
                chk.Text = "";
                chk.Size = new Size(27, 27);
                chk.Click += HandleChangeHover;
                chk.Checked = rc == RecordedFeature.Temperature;
                */

                System.Windows.Forms.Label lbl = new();
                lbl.Name = $"lbl_{txt}";
                lbl.AutoSize = true;
                lbl.Text = txt;
                lbl.TextAlign = ContentAlignment.MiddleLeft;

                System.Windows.Forms.Label lbl_val = new();
                lbl_val.Name = $"lbl_val{txt}";
                lbl_val.AutoSize = true;
                lbl_val.Text = "";
                lbl_val.TextAlign = ContentAlignment.MiddleCenter;

                tbl_LegendButtons.Controls.Add(btn, 0, row);
                //tbl_LegendButtons.Controls.Add(chk, 1, row);
                tbl_LegendButtons.Controls.Add(lbl, 1, row);
                tbl_LegendButtons.Controls.Add(lbl_val, 2, row);

                shownFeatures.Add(rc, true);
                printFeatures.Add(rc, lbl_val);
            }

            tbl_LegendButtons.ResumeLayout();
        }

        public void ClickButtonLegend(object? sender, EventArgs ea)
        {
            var rc = (RecordedFeature)((Control)sender!).Tag!;
            bool shouldShowNow = !shownFeatures[rc];
            ((System.Windows.Forms.Button)sender!).BackColor = shouldShowNow ? rc.GetInfo().Color : System.Drawing.Color.White;
            shownFeatures[(RecordedFeature)((Control)sender!).Tag!] = shouldShowNow;

            ShowFeatureLine(rc, shouldShowNow);
        }

        private void ShowFeatureLine(RecordedFeature rc, bool shouldShowNow)
        {
            featureLines[rc].IsVisible = shouldShowNow;
            //plt_Plot.Plot.Axes.AutoScale();
            plt_Plot.Refresh();
        }

        private void Plot_MouseMove(object sender, MouseEventArgs e)
        {
            var plt = plt_Plot.Plot;

            Coordinates coords = plt.GetCoordinates(e.X, e.Y);

            if (crosshair == null) return;
            else
            {
                crosshair.X = coords.X;
                crosshair.Y = coords.Y;
                crosshair.IsVisible = true;
            }

            WriteValues(coords.X);

            plt_Plot.Refresh();
        }

        private void WriteValues(double mouseX)
        {
            foreach (var kvp in printFeatures)
            {
                RecordedFeature feature = kvp.Key;

                var points = recordPeriod.GetAllValuesForFeature(feature);

                var nearest = points
                    .OrderBy(p => Math.Abs(p.Time.ToOADate() - mouseX))
                    .FirstOrDefault();

                if (nearest != null)
                {
                    kvp.Value.Text = (WeatherService.GetFeatureString(feature, nearest.Value));
                }

                lbl_Hover.Text = $"Tempo: {nearest.Time}";
            }
        }

        private void GenerateGraph()
        {
            var plt = plt_Plot.Plot;
            plt.Clear();

            crosshair = plt_Plot.Plot.Add.Crosshair(0, 0);
            crosshair.LineColor = ScottPlot.Color.FromColor(System.Drawing.Color.Red);
            crosshair.LineWidth = 2;
            crosshair.IsVisible = true;
            crosshair.HorizontalLine.IsVisible = false;

            plt.Axes.SetLimitsY(-0.2, 1.2);
            plt.Axes.Left.IsVisible = false;

            double xMin = recordPeriod.Domain.StartingTime.ToOADate();
            double xMax = recordPeriod.Domain.EndingTime.ToOADate();

            double margin = (xMax - xMin) * 0.05;
            plt.Axes.SetLimitsX(xMin - margin, xMax + margin);

            plt.Axes.ContinuouslyAutoscale = false;

            plt.Axes.Rules.Add(new ScottPlot.AxisRules.LockedVertical(plt.Axes.Left, -0.2, 1.2));

            featureLines = new();

            foreach (RecordedFeature rc in Enum.GetValues(typeof(RecordedFeature)))
            {
                if (shownFeatures[rc])
                {
                    FeatureInformation fi = rc.GetInfo();
                    System.Drawing.Color c = fi.Color;
                    string txt = fi.Name;

                    var recordsOfThisFeature = recordPeriod.GetAllValuesForFeature(rc);

                    double[] x = new double[recordsOfThisFeature.Count];
                    double[] y = new double[recordsOfThisFeature.Count];
                    int i = 0;
                    foreach (var record in recordsOfThisFeature)
                    {
                        x[i] = record.Time.ToOADate();
                        y[i] = WeatherService.ScaleFeature(rc, record.Value);
                        i++;
                    }

                    featureLines[rc] = plt.Add.ScatterLine(x, y, new ScottPlot.Color(c));
                    featureLines[rc].LegendText = txt;

                }
            }

            //plt.Axes.AutoScale();
            plt.Axes.DateTimeTicksBottom();
            plt.HideLegend();
            plt_Plot.Refresh();
        }

        private async Task GatherGraphData()
        {
            (recordPeriod, json) = await weatherService.GetRecordsFromDomain(currentDomain);
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void EcoAnalyzerGraphPage_Load(object sender, EventArgs e)
        {
            try
            {
                await GatherGraphData();
                GenerateGraph();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore\n" + ex.Message);
                Close();
            }
        }


        private void btn_CSV_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "File CSV (*.csv)|*.csv";

            saveFileDialog1.Title = "Salva file";
            saveFileDialog1.DefaultExt = "csv";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string percorsoFile = saveFileDialog1.FileName;
                System.IO.File.WriteAllText(percorsoFile, recordPeriod.ObtainCSV());

                MessageBox.Show("File salvato con successo!");
            }

        }

        private void btn_JSON_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "File JSON (*.json)|*.json";

            saveFileDialog1.Title = "Salva file";
            saveFileDialog1.DefaultExt = "json";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string percorsoFile = saveFileDialog1.FileName;
                System.IO.File.WriteAllText(percorsoFile, json);

                MessageBox.Show("File salvato con successo!");
            }

        }

        private void btn_Stats_Click(object sender, EventArgs e)
        {
            if (recordPeriod == null) return;

            if (recordPeriod.Domain.EndingTime - recordPeriod.Domain.StartingTime > TimeSpan.FromDays(5))
            {
                MessageBox.Show("E' probabile che la regressione lineare non sia molto precisa, visto che considera una sola variabile alla volta per estrapolare una predizione di AQI, e in un periodo di tempo maggiore le altre misure possono cambiare molto");
            }

            EcoAnalyzerStatsForm statsForm = new EcoAnalyzerStatsForm(recordPeriod);
            statsForm.Show();
        }
    }
}
