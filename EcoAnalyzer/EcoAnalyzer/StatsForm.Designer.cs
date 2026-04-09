namespace EcoAnalyzer
{
    partial class EcoAnalyzerStatsForm
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
            tbl_PlotMain = new TableLayoutPanel();
            plt_Plot = new ScottPlot.WinForms.FormsPlot();
            tbl_Legend = new TableLayoutPanel();
            lbl_Legend = new Label();
            lbl_Hover = new Label();
            tbl_LegendButtons = new TableLayoutPanel();
            tbl_PlotMain.SuspendLayout();
            tbl_Legend.SuspendLayout();
            SuspendLayout();
            // 
            // tbl_PlotMain
            // 
            tbl_PlotMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbl_PlotMain.ColumnCount = 2;
            tbl_PlotMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tbl_PlotMain.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 250F));
            tbl_PlotMain.Controls.Add(plt_Plot, 0, 0);
            tbl_PlotMain.Controls.Add(tbl_Legend, 1, 0);
            tbl_PlotMain.Location = new Point(0, 0);
            tbl_PlotMain.Name = "tbl_PlotMain";
            tbl_PlotMain.RowCount = 1;
            tbl_PlotMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tbl_PlotMain.Size = new Size(819, 488);
            tbl_PlotMain.TabIndex = 17;
            // 
            // plt_Plot
            // 
            plt_Plot.Dock = DockStyle.Fill;
            plt_Plot.Location = new Point(3, 3);
            plt_Plot.Name = "plt_Plot";
            plt_Plot.Size = new Size(563, 482);
            plt_Plot.TabIndex = 14;
            // 
            // tbl_Legend
            // 
            tbl_Legend.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbl_Legend.ColumnCount = 1;
            tbl_Legend.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tbl_Legend.Controls.Add(lbl_Legend, 0, 0);
            tbl_Legend.Controls.Add(lbl_Hover, 0, 1);
            tbl_Legend.Controls.Add(tbl_LegendButtons, 0, 2);
            tbl_Legend.Location = new Point(572, 3);
            tbl_Legend.Name = "tbl_Legend";
            tbl_Legend.RowCount = 4;
            tbl_Legend.RowStyles.Add(new RowStyle());
            tbl_Legend.RowStyles.Add(new RowStyle());
            tbl_Legend.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tbl_Legend.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tbl_Legend.Size = new Size(244, 482);
            tbl_Legend.TabIndex = 15;
            // 
            // lbl_Legend
            // 
            lbl_Legend.AllowDrop = true;
            lbl_Legend.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_Legend.Font = new Font("Microsoft Sans Serif", 11.999999F);
            lbl_Legend.Location = new Point(3, 0);
            lbl_Legend.Name = "lbl_Legend";
            lbl_Legend.Size = new Size(238, 53);
            lbl_Legend.TabIndex = 15;
            lbl_Legend.Text = "Linear Regression Graph (click to show features)";
            lbl_Legend.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_Hover
            // 
            lbl_Hover.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbl_Hover.Font = new Font("Microsoft Sans Serif", 8.999999F);
            lbl_Hover.Location = new Point(3, 53);
            lbl_Hover.Name = "lbl_Hover";
            lbl_Hover.Size = new Size(238, 31);
            lbl_Hover.TabIndex = 17;
            // 
            // tbl_LegendButtons
            // 
            tbl_LegendButtons.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbl_LegendButtons.ColumnCount = 2;
            tbl_LegendButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.15075F));
            tbl_LegendButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 83.84925F));
            tbl_LegendButtons.Location = new Point(3, 87);
            tbl_LegendButtons.Name = "tbl_LegendButtons";
            tbl_LegendButtons.RowCount = 1;
            tbl_LegendButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tbl_LegendButtons.Size = new Size(238, 352);
            tbl_LegendButtons.TabIndex = 16;
            // 
            // EcoAnalyzerStatsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(816, 485);
            Controls.Add(tbl_PlotMain);
            Name = "EcoAnalyzerStatsForm";
            Text = "StatsForm";
            tbl_PlotMain.ResumeLayout(false);
            tbl_Legend.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tbl_PlotMain;
        private ScottPlot.WinForms.FormsPlot plt_Plot;
        private TableLayoutPanel tbl_Legend;
        private Label lbl_Legend;
        private Label lbl_Hover;
        private TableLayoutPanel tbl_LegendButtons;
    }
}