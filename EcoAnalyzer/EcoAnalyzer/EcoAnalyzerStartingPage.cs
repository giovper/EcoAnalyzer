
//LOGHI
// https://cooltext.com/
// https://www.flamingtext.com/Cool-Text-Generator/

using EcoAnalyzerLib;
using ScottPlot.MultiplotLayouts;

namespace EcoAnalyzer
{
    public partial class EcoAnalyzerStartingPage : Form
    {
        public EcoAnalyzerStartingPage()
        {
            InitializeComponent();
            gMapControl.MapProvider = GMap.NET.MapProviders.GMapProviders.GoogleHybridMap;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            gMapControl.ShowCenter = false;
            gMapControl.DragButton = MouseButtons.Left;
            gMapControl.DisableAltForSelection = true;
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            LaunchMainWindow();
        }

        private void LaunchMainWindow()
        {
            float latitude; float longitude;
            try
            {
                string[] splitted = txt_Location.Text.Split(' ');
                latitude = float.Parse(splitted[0]);
                longitude = float.Parse(splitted[1]);
            }
            catch
            {
                MessageBox.Show("Input località invalido. Devono essere inserite coordinate nel formato <latitudine longitudine>. Usa il pulsante per selezionare dalla mappa");
                return;
            }
            var rd = new RecordDomain(latitude, longitude, dtp_StartDate.Value, dtp_EndDate.Value);
            Hide();
            EcoAnalyzerGraphPage form = new(rd);
            DialogResult dr = form.ShowDialog();
            if (dr != DialogResult.Abort)
                Show();
        }

        private void btn_SearchLocation_Click(object sender, EventArgs e)
        {

        }
    }
}