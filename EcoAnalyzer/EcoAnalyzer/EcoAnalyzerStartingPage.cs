
//LOGHI
// https://cooltext.com/
// https://www.flamingtext.com/Cool-Text-Generator/

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
    }
}