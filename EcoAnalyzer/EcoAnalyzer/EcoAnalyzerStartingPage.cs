
//LOGHI
// https://cooltext.com/
// https://www.flamingtext.com/Cool-Text-Generator/

using EcoAnalyzerLib;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System.Windows.Forms;

namespace EcoAnalyzer
{
    public partial class EcoAnalyzerStartingPage : Form
    {
        private GMapOverlay mapMarkersOverlay;
        private GMarkerGoogle mapMarker;
        public EcoAnalyzerStartingPage()
        {
            InitializeComponent();
            gMapControl.MapProvider = GMap.NET.MapProviders.GMapProviders.GoogleHybridMap;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            gMapControl.ShowCenter = false;
            gMapControl.DragButton = MouseButtons.Left;
            gMapControl.DisableAltForSelection = false;
        }

        private void EcoAnalyzerStartingPage_Load(object sender, EventArgs e)
        {
            mapMarkersOverlay = new GMapOverlay("markers");
            gMapControl.Overlays.Add(mapMarkersOverlay);
            btn_Search.Enabled = false;
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            LaunchMainWindow();
        }

        private void LaunchMainWindow()
        {
            PointLatLng coords = mapMarker.Position;
            var rd = new RecordDomain(((float)coords.Lat, (float)coords.Lng), dtp_StartDate.Value, dtp_EndDate.Value);
            Hide();
            EcoAnalyzerGraphPage form = new(rd);
            DialogResult dr = form.ShowDialog();
            if (dr != DialogResult.Abort)
                Show();
        }

        private void gMapControl_OnMapClick(PointLatLng pointClick, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                btn_Search.Enabled = true;
                if (mapMarker == null)
                {
                    mapMarker = new GMarkerGoogle(pointClick, GMarkerGoogleType.blue);
                    mapMarkersOverlay.Markers.Add(mapMarker);
                }
                else
                {
                    mapMarker.Position = pointClick;
                }
            }
        }
    }
}