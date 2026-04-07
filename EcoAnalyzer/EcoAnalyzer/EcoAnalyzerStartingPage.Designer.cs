namespace EcoAnalyzer
{
    partial class EcoAnalyzerStartingPage
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dtp_StartDate = new DateTimePicker();
            dtp_EndDate = new DateTimePicker();
            pnl_TitleLogo = new Panel();
            lbl_Location = new Label();
            lbl_StartDate = new Label();
            lbl_EndDate = new Label();
            tbl_MainInput = new TableLayoutPanel();
            btn_Search = new Button();
            gMapControl = new GMap.NET.WindowsForms.GMapControl();
            tbl_MainInput.SuspendLayout();
            SuspendLayout();
            // 
            // dtp_StartDate
            // 
            dtp_StartDate.CustomFormat = "MM/dd/yyyy";
            dtp_StartDate.Format = DateTimePickerFormat.Custom;
            dtp_StartDate.Location = new Point(707, 33);
            dtp_StartDate.Name = "dtp_StartDate";
            dtp_StartDate.Size = new Size(114, 23);
            dtp_StartDate.TabIndex = 4;
            // 
            // dtp_EndDate
            // 
            dtp_EndDate.CustomFormat = "MM/dd/yyyy";
            dtp_EndDate.Format = DateTimePickerFormat.Custom;
            dtp_EndDate.Location = new Point(827, 33);
            dtp_EndDate.Name = "dtp_EndDate";
            dtp_EndDate.Size = new Size(114, 23);
            dtp_EndDate.TabIndex = 5;
            // 
            // pnl_TitleLogo
            // 
            pnl_TitleLogo.BackgroundImage = Properties.Resources.cooltext505340410401435;
            pnl_TitleLogo.BackgroundImageLayout = ImageLayout.Zoom;
            pnl_TitleLogo.Dock = DockStyle.Top;
            pnl_TitleLogo.Location = new Point(0, 0);
            pnl_TitleLogo.Name = "pnl_TitleLogo";
            pnl_TitleLogo.Size = new Size(984, 70);
            pnl_TitleLogo.TabIndex = 2;
            // 
            // lbl_Location
            // 
            lbl_Location.Location = new Point(3, 0);
            lbl_Location.Name = "lbl_Location";
            lbl_Location.Size = new Size(100, 23);
            lbl_Location.TabIndex = 0;
            lbl_Location.Text = "Location";
            // 
            // lbl_StartDate
            // 
            lbl_StartDate.Location = new Point(707, 0);
            lbl_StartDate.Name = "lbl_StartDate";
            lbl_StartDate.Size = new Size(100, 23);
            lbl_StartDate.TabIndex = 1;
            lbl_StartDate.Text = "Start Time";
            // 
            // lbl_EndDate
            // 
            lbl_EndDate.Location = new Point(827, 0);
            lbl_EndDate.Name = "lbl_EndDate";
            lbl_EndDate.Size = new Size(100, 23);
            lbl_EndDate.TabIndex = 2;
            lbl_EndDate.Text = "End Time";
            // 
            // tbl_MainInput
            // 
            tbl_MainInput.ColumnCount = 4;
            tbl_MainInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tbl_MainInput.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tbl_MainInput.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tbl_MainInput.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            tbl_MainInput.Controls.Add(lbl_Location, 0, 0);
            tbl_MainInput.Controls.Add(lbl_StartDate, 1, 0);
            tbl_MainInput.Controls.Add(lbl_EndDate, 2, 0);
            tbl_MainInput.Controls.Add(dtp_StartDate, 1, 1);
            tbl_MainInput.Controls.Add(dtp_EndDate, 2, 1);
            tbl_MainInput.Controls.Add(btn_Search, 3, 1);
            tbl_MainInput.Controls.Add(gMapControl, 0, 1);
            tbl_MainInput.Dock = DockStyle.Fill;
            tbl_MainInput.Location = new Point(0, 70);
            tbl_MainInput.Name = "tbl_MainInput";
            tbl_MainInput.RowCount = 2;
            tbl_MainInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tbl_MainInput.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tbl_MainInput.Size = new Size(984, 491);
            tbl_MainInput.TabIndex = 0;
            // 
            // btn_Search
            // 
            btn_Search.BackgroundImage = Properties.Resources.loupe;
            btn_Search.BackgroundImageLayout = ImageLayout.Zoom;
            btn_Search.Location = new Point(947, 33);
            btn_Search.Name = "btn_Search";
            btn_Search.Size = new Size(30, 30);
            btn_Search.TabIndex = 6;
            btn_Search.Click += btn_Search_Click;
            // 
            // gMapControl
            // 
            gMapControl.Bearing = 0F;
            gMapControl.CanDragMap = true;
            gMapControl.Dock = DockStyle.Fill;
            gMapControl.EmptyTileColor = Color.Navy;
            gMapControl.GrayScaleMode = false;
            gMapControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            gMapControl.LevelsKeepInMemory = 5;
            gMapControl.Location = new Point(3, 33);
            gMapControl.MarkersEnabled = true;
            gMapControl.MaxZoom = 18;
            gMapControl.MinZoom = 3;
            gMapControl.MouseWheelZoomEnabled = true;
            gMapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
            gMapControl.Name = "gMapControl";
            gMapControl.NegativeMode = false;
            gMapControl.PolygonsEnabled = true;
            gMapControl.RetryLoadTile = 0;
            gMapControl.RoutesEnabled = true;
            gMapControl.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            gMapControl.SelectedAreaFillColor = Color.FromArgb(53, 85, 125, 205);
            gMapControl.ShowTileGridLines = false;
            gMapControl.Size = new Size(698, 455);
            gMapControl.TabIndex = 7;
            gMapControl.Zoom = 3D;
            gMapControl.OnMapClick += gMapControl_OnMapClick;
            // 
            // EcoAnalyzerStartingPage
            // 
            ClientSize = new Size(984, 561);
            Controls.Add(tbl_MainInput);
            Controls.Add(pnl_TitleLogo);
            MinimumSize = new Size(600, 400);
            Name = "EcoAnalyzerStartingPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EcoAnalyzer";
            Load += EcoAnalyzerStartingPage_Load;
            tbl_MainInput.ResumeLayout(false);
            ResumeLayout(false);
        }
        private DateTimePicker dtp_StartDate;
        private DateTimePicker dtp_EndDate;
        private Panel pnl_TitleLogo;
        private Label lbl_Location;
        private Label lbl_StartDate;
        private Label lbl_EndDate;
        private TableLayoutPanel tbl_MainInput;
        private Button btn_Search;
        private GMap.NET.WindowsForms.GMapControl gMapControl;
    }
}