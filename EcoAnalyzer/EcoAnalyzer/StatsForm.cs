using EcoAnalyzerLib;
using ScottPlot;
using ScottPlot.Plottables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EcoAnalyzer
{
    public partial class EcoAnalyzerStatsForm : Form
    {
        RecordedFeature shownFeature;
        RecordPeriod recordPeriod;

        Crosshair crosshair;

        public EcoAnalyzerStatsForm(RecordPeriod rp)
        {
            InitializeComponent();

            recordPeriod = rp;

            GenerateFeaturesList();
            GenerateGraph(RecordedFeature.Temperature);

            plt_Plot.MouseMove += Plot_MouseMove;
        }

        private void GenerateGraph(RecordedFeature rc)
        {
            lbl_Hover.Text = "";

            var plt = plt_Plot.Plot;
            plt.Clear();

            crosshair = plt_Plot.Plot.Add.Crosshair(0, 0);
            crosshair.LineColor = ScottPlot.Color.FromColor(System.Drawing.Color.Red);
            crosshair.LineWidth = 2;
            crosshair.IsVisible = true;
            crosshair.HorizontalLine.IsVisible = false;

            FeatureInformation fi = rc.GetInfo();
            System.Drawing.Color c = fi.Color;
            string txt = fi.Name;

            var recordsOfThisFeature = recordPeriod.GetAllValuesForFeature(rc);
            var recordsAirQuality = recordPeriod.GetAllValuesForFeature(RecordedFeature.AirQuality);

            void InsertLine(List<EcoAnalyzerLib.DataPoint> points, System.Drawing.Color color, bool scatter = false)
            {
                double[] x = new double[points.Count];
                double[] y = new double[points.Count];
                int i = 0;
                foreach (var record in points)
                {
                    x[i] = record.Time.ToOADate();
                    y[i] = record.Value;
                    i++;
                }

                if (!scatter)
                {
                    plt.Add.ScatterLine(x, y, new ScottPlot.Color(color));
                }
                else
                {
                    plt.Add.Scatter(x, y, new ScottPlot.Color(color));
                }
            }

            InsertLine(recordsAirQuality, System.Drawing.Color.Black);
            InsertLine(recordsOfThisFeature, c);


            List<double> air = recordsAirQuality.Select(v => (double)v.Value).ToList();
            List<double> values = recordsOfThisFeature.Select(v => (double)v.Value).ToList();

            var (a, b, em) = WeatherService.RegressioneLineare(values, air);

            MessageBox.Show($"La retta di regressione è: y = {b:F2} + {a:F2}x | Errore medio: {em * 100}");


            List<EcoAnalyzerLib.DataPoint> reg_points = new();

            foreach (var feature_val in recordsOfThisFeature)
            {
                reg_points.Add(new(feature_val.Time, (float)WeatherService.CalculateLinear(feature_val.Value, a, b)));
            }

            InsertLine(reg_points, System.Drawing.Color.Red, true);

            plt.Axes.AutoScale();
            plt.Axes.DateTimeTicksBottom();
            plt.HideLegend();
            plt_Plot.Refresh();
        }

        private void GenerateFeaturesList()
        {
            tbl_LegendButtons.SuspendLayout();
            tbl_LegendButtons.Controls.Clear();
            tbl_LegendButtons.RowStyles.Clear();
            tbl_LegendButtons.RowCount = 0;

            foreach (RecordedFeature rc in Enum.GetValues(typeof(RecordedFeature)))
            {
                FeatureInformation fi = rc.GetInfo();

                if (!fi.suitableForLineGraph) continue;

                System.Drawing.Color c = fi.Color;
                string txt = fi.Name;

                int row = tbl_LegendButtons.RowCount;
                tbl_LegendButtons.RowCount = row + 1;
                tbl_LegendButtons.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));

                RadioButton rdo = new();
                rdo.Name = $"rdo_{txt}";
                rdo.Tag = rc;
                rdo.Checked = rc == RecordedFeature.Temperature; // default
                rdo.AutoSize = true;
                rdo.CheckedChanged += ClickRadioLegend;

                System.Windows.Forms.Label lbl = new();
                lbl.Name = $"lbl_{txt}";
                lbl.AutoSize = true;
                lbl.Text = txt;
                lbl.TextAlign = ContentAlignment.MiddleLeft;

                tbl_LegendButtons.Controls.Add(rdo, 0, row);
                //tbl_LegendButtons.Controls.Add(chk, 1, row);
                tbl_LegendButtons.Controls.Add(lbl, 1, row);
            }

            tbl_LegendButtons.ResumeLayout();
        }

        public void ClickRadioLegend(object sender, EventArgs e)
        {
            if (sender is RadioButton rdo && rdo.Checked)
            {
                MessageBox.Show(rdo.Name);
                GenerateGraph((RecordedFeature)rdo.Tag);
            }
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

        private void WriteValues(double x)
        {
            DateTime time = DateTime.FromOADate(x);

            var points = recordPeriod.GetAllValuesForFeature(shownFeature);

            var nearest = points
                .OrderBy(p => Math.Abs(p.Time.ToOADate() - x))
                .FirstOrDefault();

            string str = "..";
            if (nearest != null)
            {
                str = $"Data: {time} | Selezionata:\n" + (WeatherService.GetFeatureString(shownFeature, nearest.Value, true));
            }

            //aggiungi l'errore

            lbl_Hover.Text = str;
        }
    }
}
