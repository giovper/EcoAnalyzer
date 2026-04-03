namespace EcoAnalyzer
{
    partial class Temp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            mapControl = new GMap.NET.WindowsForms.GMapControl();
            SuspendLayout();
            // 
            // mapControl
            // 
            mapControl.Bearing = 0F;
            mapControl.CanDragMap = true;
            mapControl.Dock = DockStyle.Right;
            mapControl.EmptyTileColor = Color.Navy;
            mapControl.GrayScaleMode = false;
            mapControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            mapControl.LevelsKeepInMemory = 5;
            mapControl.Location = new Point(248, 0);
            mapControl.MarkersEnabled = true;
            mapControl.MaxZoom = 20;
            mapControl.MinZoom = 1;
            mapControl.MouseWheelZoomEnabled = true;
            mapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
            mapControl.Name = "mapControl";
            mapControl.NegativeMode = false;
            mapControl.PolygonsEnabled = true;
            mapControl.RetryLoadTile = 0;
            mapControl.RoutesEnabled = true;
            mapControl.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            mapControl.SelectedAreaFillColor = Color.FromArgb(33, 65, 105, 225);
            mapControl.ShowTileGridLines = false;
            mapControl.Size = new Size(552, 450);
            mapControl.TabIndex = 0;
            mapControl.Zoom = 1D;
            // 
            // Temp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(mapControl);
            Name = "Temp";
            Text = "Temp";
            ResumeLayout(false);
        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl mapControl;
    }
}