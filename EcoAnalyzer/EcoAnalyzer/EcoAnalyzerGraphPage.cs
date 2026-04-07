using EcoAnalyzerLib;
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

// https://www.youtube.com/watch?v=HVH_vNAn8hs

namespace EcoAnalyzer
{
    public partial class EcoAnalyzerGraphPage : Form
    {
        WeatherService weatherService;
        Dictionary<RecordedFeature, bool> shownFeatures;
        Dictionary<RecordedFeature, Scatter> featureLines;
        RecordDomain currentDomain;
        RecordPeriod recordPeriod;

        public EcoAnalyzerGraphPage(RecordDomain recordDomain)
        {
            InitializeComponent();
            plt_Plot.Plot.Axes.AutoScaleExpand();
            currentDomain = recordDomain;

            GenerateHeader();
            GenerateLegend();
            weatherService = new();
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

            foreach (RecordedFeature rc in Enum.GetValues(typeof(RecordedFeature)))
            {
                FeatureInformation fi = rc.GetInfo();
                Color c = fi.Color;
                string txt = fi.Name;

                int row = tbl_LegendButtons.RowCount;
                tbl_LegendButtons.RowCount = row + 1;
                tbl_LegendButtons.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));

                Button btn = new();
                btn.Name = $"btn_{txt}";
                btn.Tag = rc;
                btn.Text = "";
                btn.BackColor = c;
                btn.Size = new Size(27, 27);
                btn.Click += ClickButtonLegend;

                Label lbl = new();
                lbl.Name = $"lbl_{txt}";
                lbl.AutoSize = true;
                lbl.Text = txt;
                lbl.TextAlign = ContentAlignment.MiddleLeft;

                tbl_LegendButtons.Controls.Add(btn, 0, row);
                tbl_LegendButtons.Controls.Add(lbl, 1, row);

                shownFeatures.Add(rc, true);
            }

            tbl_LegendButtons.ResumeLayout();
        }

        public void ClickButtonLegend(object? sender, EventArgs ea)
        {
            var rc = (RecordedFeature)((Control)sender!).Tag!;
            bool shouldShowNow = !shownFeatures[rc];
            ((Button)sender!).BackColor = shouldShowNow ? rc.GetInfo().Color : Color.White;
            shownFeatures[(RecordedFeature)((Control)sender!).Tag!] = shouldShowNow;

            ShowFeatureLine(rc, shouldShowNow);
        }

        private void ShowFeatureLine(RecordedFeature rc, bool shouldShowNow)
        {
            featureLines[rc].IsVisible = shouldShowNow;
            plt_Plot.Plot.Axes.AutoScale();
            plt_Plot.Refresh();
        }

        private void GenerateGraph()
        {
            var plt = plt_Plot.Plot;
            plt.Clear();

            featureLines = new();

            foreach (RecordedFeature rc in Enum.GetValues(typeof(RecordedFeature)))
            {
                if (shownFeatures[rc])
                {
                    FeatureInformation fi = rc.GetInfo();
                    Color c = fi.Color;
                    string txt = fi.Name;

                    var recordsOfThisFeature = recordPeriod.GetAllValuesForFeature(rc);

                    double[] x = new double[recordsOfThisFeature.Count];
                    double[] y = new double[recordsOfThisFeature.Count];
                    int i = 0;
                    foreach (var record in recordsOfThisFeature)
                    {
                        x[i] = record.X;
                        y[i] = record.Y;
                        i++;
                    }

                    featureLines[rc] = plt.Add.ScatterLine(x, y, new ScottPlot.Color(c));
                    featureLines[rc].LegendText = txt;

                }
            }

            plt.Axes.AutoScale();
            plt.HideLegend();
            plt_Plot.Refresh();
        }

        private async Task GatherGraphData()
        {
            recordPeriod = await weatherService.GetRecordsFromDomain(currentDomain);
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void EcoAnalyzerGraphPage_Load(object sender, EventArgs e)
        {
            await GatherGraphData();
            GenerateGraph();
        }
    }
}
