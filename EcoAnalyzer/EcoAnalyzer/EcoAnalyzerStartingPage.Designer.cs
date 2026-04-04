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
            tbl_MainInput.SuspendLayout();
            tbl_Location.SuspendLayout();
            lbp_Theme.SuspendLayout();
            SuspendLayout();
            // 
            // txt_Location
            // 
            txt_Location.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txt_Location.Font = new Font("Saira", 8.25F);
            txt_Location.Location = new Point(3, 3);
            txt_Location.Name = "txt_Location";
            txt_Location.Size = new Size(341, 25);
            txt_Location.TabIndex = 0;
            // 
            // dtp_StartDate
            // 
            dtp_StartDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtp_StartDate.CustomFormat = "MM/dd/yyyy hh:mm";
            dtp_StartDate.Font = new Font("Saira", 8.25F);
            dtp_StartDate.Format = DateTimePickerFormat.Custom;
            dtp_StartDate.Location = new Point(401, 33);
            dtp_StartDate.Name = "dtp_StartDate";
            dtp_StartDate.Size = new Size(161, 25);
            dtp_StartDate.TabIndex = 1;
            // 
            // dtp_EndDate
            // 
            dtp_EndDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtp_EndDate.CustomFormat = "MM/dd/yyyy hh:mm";
            dtp_EndDate.Font = new Font("Saira", 8.25F);
            dtp_EndDate.Format = DateTimePickerFormat.Custom;
            dtp_EndDate.Location = new Point(568, 33);
            dtp_EndDate.Name = "dtp_EndDate";
            dtp_EndDate.Size = new Size(162, 25);
            dtp_EndDate.TabIndex = 2;
            // 
            // pnl_TitleLogo
            // 
            pnl_TitleLogo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnl_TitleLogo.BackgroundImage = Properties.Resources.cooltext505340410401435;
            pnl_TitleLogo.BackgroundImageLayout = ImageLayout.Zoom;
            pnl_TitleLogo.Location = new Point(121, 27);
            pnl_TitleLogo.Name = "pnl_TitleLogo";
            pnl_TitleLogo.Size = new Size(585, 93);
            pnl_TitleLogo.TabIndex = 3;
            // 
            // lbl_Location
            // 
            lbl_Location.Font = new Font("Saira", 11.999999F);
            lbl_Location.Location = new Point(3, 0);
            lbl_Location.Name = "lbl_Location";
            lbl_Location.Size = new Size(392, 23);
            lbl_Location.TabIndex = 4;
            lbl_Location.Text = "Location (inserisci coordinata o cercala col pulsante)";
            // 
            // lbl_StartDate
            // 
            lbl_StartDate.Font = new Font("Saira", 11.999999F);
            lbl_StartDate.Location = new Point(401, 0);
            lbl_StartDate.Name = "lbl_StartDate";
            lbl_StartDate.Size = new Size(100, 23);
            lbl_StartDate.TabIndex = 5;
            lbl_StartDate.Text = "Start Time";
            // 
            // lbl_EndDate
            // 
            lbl_EndDate.Font = new Font("Saira", 11.999999F);
            lbl_EndDate.Location = new Point(568, 0);
            lbl_EndDate.Name = "lbl_EndDate";
            lbl_EndDate.Size = new Size(100, 23);
            lbl_EndDate.TabIndex = 6;
            lbl_EndDate.Text = "End Time";
            // 
            // lbl_Theme
            // 
            lbl_Theme.Font = new Font("Saira", 11.999999F);
            lbl_Theme.Location = new Point(3, 0);
            lbl_Theme.Name = "lbl_Theme";
            lbl_Theme.Size = new Size(89, 28);
            lbl_Theme.TabIndex = 7;
            lbl_Theme.Text = "Theme";
            // 
            // btn_ThemeDark
            // 
            btn_ThemeDark.BackColor = Color.Black;
            btn_ThemeDark.BackgroundImage = Properties.Resources.night_mode1;
            btn_ThemeDark.BackgroundImageLayout = ImageLayout.Zoom;
            btn_ThemeDark.ForeColor = Color.White;
            btn_ThemeDark.Location = new Point(98, 3);
            btn_ThemeDark.Name = "btn_ThemeDark";
            btn_ThemeDark.Size = new Size(70, 49);
            btn_ThemeDark.TabIndex = 8;
            btn_ThemeDark.TextImageRelation = TextImageRelation.TextAboveImage;
            btn_ThemeDark.UseVisualStyleBackColor = false;
            btn_ThemeDark.Click += btn_ThemeDark_Click;
            // 
            // btn_LightTheme
            // 
            btn_LightTheme.BackColor = Color.FromArgb(224, 224, 224);
            btn_LightTheme.BackgroundImage = Properties.Resources.sun;
            btn_LightTheme.BackgroundImageLayout = ImageLayout.Zoom;
            btn_LightTheme.ForeColor = Color.White;
            btn_LightTheme.Location = new Point(193, 3);
            btn_LightTheme.Name = "btn_LightTheme";
            btn_LightTheme.Size = new Size(70, 49);
            btn_LightTheme.TabIndex = 9;
            btn_LightTheme.TextImageRelation = TextImageRelation.TextAboveImage;
            btn_LightTheme.UseVisualStyleBackColor = false;
            btn_LightTheme.Click += btn_LightTheme_Click;
            // 
            // tbl_MainInput
            // 
            tbl_MainInput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbl_MainInput.ColumnCount = 3;
            tbl_MainInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 54.3478279F));
            tbl_MainInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.826086F));
            tbl_MainInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.826086F));
            tbl_MainInput.Controls.Add(tbl_Location, 0, 1);
            tbl_MainInput.Controls.Add(lbl_Location, 0, 0);
            tbl_MainInput.Controls.Add(dtp_StartDate, 1, 1);
            tbl_MainInput.Controls.Add(lbl_StartDate, 1, 0);
            tbl_MainInput.Controls.Add(lbl_EndDate, 2, 0);
            tbl_MainInput.Controls.Add(dtp_EndDate, 2, 1);
            tbl_MainInput.Location = new Point(12, 143);
            tbl_MainInput.Name = "tbl_MainInput";
            tbl_MainInput.RowCount = 2;
            tbl_MainInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tbl_MainInput.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tbl_MainInput.Size = new Size(733, 88);
            tbl_MainInput.TabIndex = 10;
            // 
            // tbl_Location
            // 
            tbl_Location.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbl_Location.ColumnCount = 2;
            tbl_Location.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tbl_Location.ColumnStyles.Add(new ColumnStyle());
            tbl_Location.Controls.Add(btn_SearchLocation, 1, 0);
            tbl_Location.Controls.Add(txt_Location, 0, 0);
            tbl_Location.Location = new Point(3, 33);
            tbl_Location.Name = "tbl_Location";
            tbl_Location.RowCount = 1;
            tbl_Location.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tbl_Location.Size = new Size(392, 52);
            tbl_Location.TabIndex = 13;
            // 
            // btn_SearchLocation
            // 
            btn_SearchLocation.BackgroundImage = Properties.Resources.search_engine;
            btn_SearchLocation.BackgroundImageLayout = ImageLayout.Zoom;
            btn_SearchLocation.Location = new Point(350, 3);
            btn_SearchLocation.Name = "btn_SearchLocation";
            btn_SearchLocation.Size = new Size(39, 34);
            btn_SearchLocation.TabIndex = 12;
            btn_SearchLocation.UseVisualStyleBackColor = false;
            btn_SearchLocation.Click += btn_SearchLocation_Click;
            // 
            // btn_Search
            // 
            btn_Search.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_Search.BackgroundImage = Properties.Resources.loupe;
            btn_Search.BackgroundImageLayout = ImageLayout.Zoom;
            btn_Search.Location = new Point(753, 170);
            btn_Search.Name = "btn_Search";
            btn_Search.Size = new Size(39, 34);
            btn_Search.TabIndex = 10;
            btn_Search.UseVisualStyleBackColor = false;
            btn_Search.Click += btn_Search_Click;
            // 
            // lbp_Theme
            // 
            lbp_Theme.ColumnCount = 4;
            lbp_Theme.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.2222176F));
            lbp_Theme.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.2222233F));
            lbp_Theme.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.2222271F));
            lbp_Theme.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            lbp_Theme.Controls.Add(lbl_Theme, 0, 0);
            lbp_Theme.Controls.Add(btn_ThemeDark, 1, 0);
            lbp_Theme.Controls.Add(btn_LightTheme, 2, 0);
            lbp_Theme.Location = new Point(12, 273);
            lbp_Theme.Name = "lbp_Theme";
            lbp_Theme.RowCount = 1;
            lbp_Theme.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            lbp_Theme.Size = new Size(429, 88);
            lbp_Theme.TabIndex = 11;
            lbp_Theme.Visible = false;
            // 
            // EcoAnalyzerStartingPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(804, 361);
            Controls.Add(btn_Search);
            Controls.Add(lbp_Theme);
            Controls.Add(tbl_MainInput);
            Controls.Add(pnl_TitleLogo);
            MaximumSize = new Size(820, 400);
            MinimumSize = new Size(820, 400);
            Name = "EcoAnalyzerStartingPage";
            Text = "EcoAnalyzer";
            tbl_MainInput.ResumeLayout(false);
            tbl_Location.ResumeLayout(false);
            tbl_Location.PerformLayout();
            lbp_Theme.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

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
    }
}
