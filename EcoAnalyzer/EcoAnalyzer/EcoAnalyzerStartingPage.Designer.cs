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
            txt_Location = new TextBox();
            dtp_StartDate = new DateTimePicker();
            dtp_EndDate = new DateTimePicker();
            pnl_TitleLogo = new Panel();
            lbl_Location = new Label();
            lbl_StartDate = new Label();
            lbl_EndDate = new Label();
            lbl_Theme = new Label();
            btn_ThemeDark = new Button();
            btn_LightTheme = new Button();
            tbl_MainInput = new TableLayoutPanel();
            tbl_Location = new TableLayoutPanel();
            btn_SearchLocation = new Button();
            btn_Search = new Button();
            lbp_Theme = new TableLayoutPanel();
            gMapControl = new GMap.NET.WindowsForms.GMapControl();

            tbl_MainInput.SuspendLayout();
            tbl_Location.SuspendLayout();
            lbp_Theme.SuspendLayout();
            SuspendLayout();

            // TEXTBOX LOCATION
            txt_Location.Dock = DockStyle.Fill;

            // DATE PICKERS
            dtp_StartDate.Format = DateTimePickerFormat.Custom;
            dtp_StartDate.CustomFormat = "MM/dd/yyyy hh:mm";

            dtp_EndDate.Format = DateTimePickerFormat.Custom;
            dtp_EndDate.CustomFormat = "MM/dd/yyyy hh:mm";

            // LOGO
            pnl_TitleLogo.Dock = DockStyle.Top;
            pnl_TitleLogo.Height = 70;
            pnl_TitleLogo.BackgroundImage = Properties.Resources.cooltext505340410401435;
            pnl_TitleLogo.BackgroundImageLayout = ImageLayout.Zoom;

            // LABELS
            lbl_Location.Text = "Location";
            lbl_StartDate.Text = "Start Time";
            lbl_EndDate.Text = "End Time";

            // MAPPA
            gMapControl.Dock = DockStyle.Fill;
            gMapControl.MinZoom = 3;
            gMapControl.MaxZoom = 18;
            gMapControl.Zoom = 3;

            // SEARCH BUTTON
            btn_Search.BackgroundImage = Properties.Resources.loupe;
            btn_Search.BackgroundImageLayout = ImageLayout.Zoom;
            btn_Search.Click += btn_Search_Click;

            // SEARCH LOCATION
            btn_SearchLocation.BackgroundImage = Properties.Resources.search_engine;
            btn_SearchLocation.BackgroundImageLayout = ImageLayout.Zoom;
            btn_SearchLocation.Click += btn_SearchLocation_Click;

            // THEME
            btn_ThemeDark.BackColor = Color.Black;
            btn_ThemeDark.Click += btn_ThemeDark_Click;

            btn_LightTheme.BackColor = Color.LightGray;
            btn_LightTheme.Click += btn_LightTheme_Click;

            // TABELLA LOCATION
            tbl_Location.ColumnCount = 2;
            tbl_Location.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tbl_Location.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            tbl_Location.Controls.Add(txt_Location, 0, 0);
            tbl_Location.Controls.Add(btn_SearchLocation, 1, 0);
            tbl_Location.Dock = DockStyle.Fill;

            // TABELLA PRINCIPALE
            tbl_MainInput.ColumnCount = 4;
            tbl_MainInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tbl_MainInput.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tbl_MainInput.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tbl_MainInput.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));

            tbl_MainInput.RowCount = 2;
            tbl_MainInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tbl_MainInput.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            tbl_MainInput.Controls.Add(lbl_Location, 0, 0);
            tbl_MainInput.Controls.Add(lbl_StartDate, 1, 0);
            tbl_MainInput.Controls.Add(lbl_EndDate, 2, 0);

            tbl_MainInput.Controls.Add(tbl_Location, 0, 1);
            tbl_MainInput.Controls.Add(dtp_StartDate, 1, 1);
            tbl_MainInput.Controls.Add(dtp_EndDate, 2, 1);
            tbl_MainInput.Controls.Add(btn_Search, 3, 1);

            // AGGIUNGO MAPPA SOTTO
            tbl_MainInput.Controls.Add(gMapControl, 0, 2);
            tbl_MainInput.SetColumnSpan(gMapControl, 4);

            tbl_MainInput.RowCount = 3;
            tbl_MainInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tbl_MainInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tbl_MainInput.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            tbl_MainInput.Dock = DockStyle.Fill;

            // THEME PANEL
            lbp_Theme.ColumnCount = 3;
            lbp_Theme.Controls.Add(lbl_Theme, 0, 0);
            lbp_Theme.Controls.Add(btn_ThemeDark, 1, 0);
            lbp_Theme.Controls.Add(btn_LightTheme, 2, 0);
            lbp_Theme.Dock = DockStyle.Bottom;
            lbp_Theme.Height = 60;

            // FORM
            Controls.Add(tbl_MainInput);
            Controls.Add(lbp_Theme);
            Controls.Add(pnl_TitleLogo);

            Text = "EcoAnalyzer";
            MinimumSize = new Size(600, 400);

            tbl_MainInput.ResumeLayout(false);
            tbl_Location.ResumeLayout(false);
            lbp_Theme.ResumeLayout(false);
            ResumeLayout(false);
        }

        private TextBox txt_Location;
        private DateTimePicker dtp_StartDate;
        private DateTimePicker dtp_EndDate;
        private Panel pnl_TitleLogo;
        private Label lbl_Location;
        private Label lbl_StartDate;
        private Label lbl_EndDate;
        private Label lbl_Theme;
        private Button btn_ThemeDark;
        private Button btn_LightTheme;
        private TableLayoutPanel tbl_MainInput;
        private TableLayoutPanel lbp_Theme;
        private Button btn_Search;
        private Button btn_SearchLocation;
        private TableLayoutPanel tbl_Location;
        private GMap.NET.WindowsForms.GMapControl gMapControl;
    }
}