namespace EcoAnalyzer
{
    partial class EcoAnalyzerStartingPage
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dtp_StartDate = new DateTimePicker();
            dtp_EndDate = new DateTimePicker();
            pnl_TitleLogo = new Panel();
            lbl_Location = new Label();
            lbl_StartDate = new Label();
            lbl_EndDate = new Label();
            tbl_MainInput = new TableLayoutPanel();
            gMapControl = new GMap.NET.WindowsForms.GMapControl();
            btn_Search = new Button();
            tbl_MainInput.SuspendLayout();
            SuspendLayout();
            // 
            // dtp_StartDate
            // 
            dtp_StartDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtp_StartDate.CustomFormat = "MM/dd/yyyy hh:mm";
            dtp_StartDate.Font = new Font("Microsoft Sans Serif", 8.25F);
            dtp_StartDate.Format = DateTimePickerFormat.Custom;
            dtp_StartDate.Location = new Point(352, 33);
            dtp_StartDate.Name = "dtp_StartDate";
            dtp_StartDate.Size = new Size(134, 20);
            dtp_StartDate.TabIndex = 1;
            // 
            // dtp_EndDate
            // 
            dtp_EndDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtp_EndDate.CustomFormat = "MM/dd/yyyy hh:mm";
            dtp_EndDate.Font = new Font("Microsoft Sans Serif", 8.25F);
            dtp_EndDate.Format = DateTimePickerFormat.Custom;
            dtp_EndDate.Location = new Point(492, 33);
            dtp_EndDate.Name = "dtp_EndDate";
            dtp_EndDate.Size = new Size(134, 20);
            dtp_EndDate.TabIndex = 2;
            // 
            // pnl_TitleLogo
            // 
            pnl_TitleLogo.BackgroundImage = Properties.Resources.cooltext505340410401435;
            pnl_TitleLogo.BackgroundImageLayout = ImageLayout.Zoom;
            pnl_TitleLogo.Dock = DockStyle.Top;
            pnl_TitleLogo.Location = new Point(0, 0);
            pnl_TitleLogo.Name = "pnl_TitleLogo";
            pnl_TitleLogo.Size = new Size(665, 70);
            pnl_TitleLogo.TabIndex = 3;
            // 
            // lbl_Location
            // 
            lbl_Location.Font = new Font("Microsoft Sans Serif", 11.999999F);
            lbl_Location.Location = new Point(3, 0);
            lbl_Location.Name = "lbl_Location";
            lbl_Location.Size = new Size(100, 23);
            lbl_Location.TabIndex = 4;
            lbl_Location.Text = "Location";
            // 
            // lbl_StartDate
            // 
            lbl_StartDate.Font = new Font("Microsoft Sans Serif", 11.999999F);
            lbl_StartDate.Location = new Point(352, 0);
            lbl_StartDate.Name = "lbl_StartDate";
            lbl_StartDate.Size = new Size(100, 23);
            lbl_StartDate.TabIndex = 5;
            lbl_StartDate.Text = "Start Time";
            // 
            // lbl_EndDate
            // 
            lbl_EndDate.Font = new Font("Microsoft Sans Serif", 11.999999F);
            lbl_EndDate.Location = new Point(492, 0);
            lbl_EndDate.Name = "lbl_EndDate";
            lbl_EndDate.Size = new Size(100, 23);
            lbl_EndDate.TabIndex = 6;
            lbl_EndDate.Text = "End Time";
            // 
            // tbl_MainInput
            // 
            tbl_MainInput.ColumnCount = 4;
            tbl_MainInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tbl_MainInput.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140F));
            tbl_MainInput.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140F));
            tbl_MainInput.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 36F));
            tbl_MainInput.Controls.Add(lbl_Location, 0, 0);
            tbl_MainInput.Controls.Add(lbl_StartDate, 1, 0);
            tbl_MainInput.Controls.Add(lbl_EndDate, 2, 0);
            tbl_MainInput.Controls.Add(dtp_EndDate, 2, 1);
            tbl_MainInput.Controls.Add(dtp_StartDate, 1, 1);
            tbl_MainInput.Controls.Add(gMapControl, 0, 1);
            tbl_MainInput.Controls.Add(btn_Search, 3, 1);
            tbl_MainInput.Dock = DockStyle.Fill;
            tbl_MainInput.Location = new Point(0, 70);
            tbl_MainInput.Name = "tbl_MainInput";
            tbl_MainInput.RowCount = 2;
            tbl_MainInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tbl_MainInput.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tbl_MainInput.Size = new Size(665, 291);
            tbl_MainInput.TabIndex = 10;
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
            gMapControl.SelectedAreaFillColor = Color.FromArgb(33, 65, 105, 225);
            gMapControl.ShowTileGridLines = false;
            gMapControl.Size = new Size(343, 255);
            gMapControl.TabIndex = 7;
            gMapControl.Zoom = 3D;
            // 
            // btn_Search
            // 
            btn_Search.BackgroundImage = Properties.Resources.loupe;
            btn_Search.BackgroundImageLayout = ImageLayout.Zoom;
            btn_Search.Location = new Point(632, 33);
            btn_Search.Name = "btn_Search";
            btn_Search.Size = new Size(30, 30);
            btn_Search.TabIndex = 10;
            btn_Search.UseVisualStyleBackColor = false;
            // 
            // EcoAnalyzerStartingPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(665, 361);
            Controls.Add(tbl_MainInput);
            Controls.Add(pnl_TitleLogo);
            MinimumSize = new Size(400, 200);
            Name = "EcoAnalyzerStartingPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EcoAnalyzer";
            tbl_MainInput.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
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
