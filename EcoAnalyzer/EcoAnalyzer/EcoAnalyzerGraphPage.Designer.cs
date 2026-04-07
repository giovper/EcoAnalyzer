namespace EcoAnalyzer
{
    partial class EcoAnalyzerGraphPage
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
            btn_Back = new Button();
            tbl_MainInput = new TableLayoutPanel();
            lbl_New = new Label();
            lbl_Location = new Label();
            dtp_StartDate = new DateTimePicker();
            lbl_StartDate = new Label();
            lbl_EndDate = new Label();
            dtp_EndDate = new DateTimePicker();
            txt_Location = new TextBox();
            pnl_TitleLogo = new Panel();
            plt_Plot = new ScottPlot.WinForms.FormsPlot();
            tbl_PlotMain = new TableLayoutPanel();
            tbl_Legend = new TableLayoutPanel();
            lbl_Legend = new Label();
            lbl_Hover = new Label();
            tbl_LegendButtons = new TableLayoutPanel();
            tbl_MainInput.SuspendLayout();
            tbl_PlotMain.SuspendLayout();
            tbl_Legend.SuspendLayout();
            SuspendLayout();
            // 
            // btn_Back
            // 
            btn_Back.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_Back.BackgroundImage = Properties.Resources.back_arrow;
            btn_Back.BackgroundImageLayout = ImageLayout.Zoom;
            btn_Back.Location = new Point(623, 23);
            btn_Back.Name = "btn_Back";
            btn_Back.Size = new Size(36, 30);
            btn_Back.TabIndex = 13;
            btn_Back.UseVisualStyleBackColor = false;
            btn_Back.Click += btn_Back_Click;
            // 
            // tbl_MainInput
            // 
            tbl_MainInput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbl_MainInput.ColumnCount = 4;
            tbl_MainInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40.9498138F));
            tbl_MainInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.1653919F));
            tbl_MainInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.1653976F));
            tbl_MainInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.7194023F));
            tbl_MainInput.Controls.Add(lbl_New, 3, 0);
            tbl_MainInput.Controls.Add(btn_Back, 3, 1);
            tbl_MainInput.Controls.Add(lbl_Location, 0, 0);
            tbl_MainInput.Controls.Add(dtp_StartDate, 1, 1);
            tbl_MainInput.Controls.Add(lbl_StartDate, 1, 0);
            tbl_MainInput.Controls.Add(lbl_EndDate, 2, 0);
            tbl_MainInput.Controls.Add(dtp_EndDate, 2, 1);
            tbl_MainInput.Controls.Add(txt_Location, 0, 1);
            tbl_MainInput.Location = new Point(310, 1);
            tbl_MainInput.Name = "tbl_MainInput";
            tbl_MainInput.RowCount = 2;
            tbl_MainInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tbl_MainInput.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tbl_MainInput.Size = new Size(662, 56);
            tbl_MainInput.TabIndex = 12;
            // 
            // lbl_New
            // 
            lbl_New.Font = new Font("Microsoft Sans Serif", 8.999999F);
            lbl_New.Location = new Point(580, 0);
            lbl_New.Name = "lbl_New";
            lbl_New.Size = new Size(79, 20);
            lbl_New.TabIndex = 14;
            lbl_New.Text = "New Search";
            // 
            // lbl_Location
            // 
            lbl_Location.Font = new Font("Microsoft Sans Serif", 8.999999F);
            lbl_Location.Location = new Point(3, 0);
            lbl_Location.Name = "lbl_Location";
            lbl_Location.Size = new Size(100, 20);
            lbl_Location.TabIndex = 4;
            lbl_Location.Text = "Location";
            // 
            // dtp_StartDate
            // 
            dtp_StartDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtp_StartDate.CustomFormat = "dd/MM/yyyy";
            dtp_StartDate.Enabled = false;
            dtp_StartDate.Font = new Font("Microsoft Sans Serif", 8.25F);
            dtp_StartDate.Format = DateTimePickerFormat.Custom;
            dtp_StartDate.Location = new Point(274, 23);
            dtp_StartDate.Name = "dtp_StartDate";
            dtp_StartDate.Size = new Size(147, 20);
            dtp_StartDate.TabIndex = 1;
            // 
            // lbl_StartDate
            // 
            lbl_StartDate.Font = new Font("Microsoft Sans Serif", 8.999999F);
            lbl_StartDate.Location = new Point(274, 0);
            lbl_StartDate.Name = "lbl_StartDate";
            lbl_StartDate.Size = new Size(100, 20);
            lbl_StartDate.TabIndex = 5;
            lbl_StartDate.Text = "Start Time";
            // 
            // lbl_EndDate
            // 
            lbl_EndDate.Font = new Font("Microsoft Sans Serif", 8.999999F);
            lbl_EndDate.Location = new Point(427, 0);
            lbl_EndDate.Name = "lbl_EndDate";
            lbl_EndDate.Size = new Size(100, 20);
            lbl_EndDate.TabIndex = 6;
            lbl_EndDate.Text = "End Time";
            // 
            // dtp_EndDate
            // 
            dtp_EndDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtp_EndDate.CustomFormat = "dd/MM/yyyy";
            dtp_EndDate.Enabled = false;
            dtp_EndDate.Font = new Font("Microsoft Sans Serif", 8.25F);
            dtp_EndDate.Format = DateTimePickerFormat.Custom;
            dtp_EndDate.Location = new Point(427, 23);
            dtp_EndDate.Name = "dtp_EndDate";
            dtp_EndDate.Size = new Size(147, 20);
            dtp_EndDate.TabIndex = 2;
            // 
            // txt_Location
            // 
            txt_Location.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txt_Location.Enabled = false;
            txt_Location.Font = new Font("Microsoft Sans Serif", 8.25F);
            txt_Location.Location = new Point(3, 23);
            txt_Location.Name = "txt_Location";
            txt_Location.Size = new Size(265, 20);
            txt_Location.TabIndex = 0;
            // 
            // pnl_TitleLogo
            // 
            pnl_TitleLogo.BackgroundImage = Properties.Resources.cooltext505340410401435;
            pnl_TitleLogo.BackgroundImageLayout = ImageLayout.Zoom;
            pnl_TitleLogo.Location = new Point(1, 1);
            pnl_TitleLogo.Name = "pnl_TitleLogo";
            pnl_TitleLogo.Size = new Size(303, 56);
            pnl_TitleLogo.TabIndex = 11;
            // 
            // plt_Plot
            // 
            plt_Plot.Dock = DockStyle.Fill;
            plt_Plot.Location = new Point(3, 3);
            plt_Plot.Name = "plt_Plot";
            plt_Plot.Size = new Size(652, 468);
            plt_Plot.TabIndex = 14;
            // 
            // tbl_PlotMain
            // 
            tbl_PlotMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbl_PlotMain.ColumnCount = 2;
            tbl_PlotMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tbl_PlotMain.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
            tbl_PlotMain.Controls.Add(plt_Plot, 0, 0);
            tbl_PlotMain.Controls.Add(tbl_Legend, 1, 0);
            tbl_PlotMain.Location = new Point(12, 74);
            tbl_PlotMain.Name = "tbl_PlotMain";
            tbl_PlotMain.RowCount = 1;
            tbl_PlotMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tbl_PlotMain.Size = new Size(958, 474);
            tbl_PlotMain.TabIndex = 16;
            // 
            // tbl_Legend
            // 
            tbl_Legend.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbl_Legend.ColumnCount = 1;
            tbl_Legend.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tbl_Legend.Controls.Add(lbl_Legend, 0, 0);
            tbl_Legend.Controls.Add(lbl_Hover, 0, 1);
            tbl_Legend.Controls.Add(tbl_LegendButtons, 0, 2);
            tbl_Legend.Location = new Point(661, 3);
            tbl_Legend.Name = "tbl_Legend";
            tbl_Legend.RowCount = 3;
            tbl_Legend.RowStyles.Add(new RowStyle());
            tbl_Legend.RowStyles.Add(new RowStyle());
            tbl_Legend.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tbl_Legend.Size = new Size(294, 468);
            tbl_Legend.TabIndex = 15;
            // 
            // lbl_Legend
            // 
            lbl_Legend.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_Legend.Font = new Font("Microsoft Sans Serif", 11.999999F);
            lbl_Legend.Location = new Point(3, 0);
            lbl_Legend.Name = "lbl_Legend";
            lbl_Legend.Size = new Size(288, 34);
            lbl_Legend.TabIndex = 15;
            lbl_Legend.Text = "Legend (click to toggle)";
            // 
            // lbl_Hover
            // 
            lbl_Hover.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_Hover.Font = new Font("Microsoft Sans Serif", 8.999999F);
            lbl_Hover.Location = new Point(3, 34);
            lbl_Hover.Name = "lbl_Hover";
            lbl_Hover.Size = new Size(288, 31);
            lbl_Hover.TabIndex = 17;
            // 
            // tbl_LegendButtons
            // 
            tbl_LegendButtons.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbl_LegendButtons.ColumnCount = 3;
            tbl_LegendButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.8829184F));
            tbl_LegendButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48.8646F));
            tbl_LegendButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 37.2524757F));
            tbl_LegendButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tbl_LegendButtons.Location = new Point(3, 68);
            tbl_LegendButtons.Name = "tbl_LegendButtons";
            tbl_LegendButtons.RowCount = 1;
            tbl_LegendButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tbl_LegendButtons.Size = new Size(288, 397);
            tbl_LegendButtons.TabIndex = 16;
            // 
            // EcoAnalyzerGraphPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 561);
            Controls.Add(tbl_PlotMain);
            Controls.Add(tbl_MainInput);
            Controls.Add(pnl_TitleLogo);
            Name = "EcoAnalyzerGraphPage";
            Text = "EcoAnalyzerGraphPage";
            Load += EcoAnalyzerGraphPage_Load;
            tbl_MainInput.ResumeLayout(false);
            tbl_MainInput.PerformLayout();
            tbl_PlotMain.ResumeLayout(false);
            tbl_Legend.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btn_Back;
        private TableLayoutPanel tbl_MainInput;
        private Label lbl_Location;
        private DateTimePicker dtp_StartDate;
        private Label lbl_StartDate;
        private Label lbl_EndDate;
        private DateTimePicker dtp_EndDate;
        private Panel pnl_TitleLogo;
        private ScottPlot.WinForms.FormsPlot plt_Plot;
        private TableLayoutPanel tbl_PlotMain;
        private TextBox txt_Location;
        private TableLayoutPanel tbl_Legend;
        private TableLayoutPanel tbl_LegendButtons;
        private Label lbl_Legend;
        private Label lbl_New;
        private Label lbl_Hover;
    }
}