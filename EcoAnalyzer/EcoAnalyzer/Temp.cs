using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcoAnalyzer
{
    public partial class Temp : Form
    {
        public Temp()
        {
            InitializeComponent();
            mapControl.MapProvider = GMap.NET.MapProviders.GMapProviders.GoogleHybridMap;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            mapControl.DragButton = MouseButtons.Left;
        }
    }
}
