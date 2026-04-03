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
            button1 = new Button();
            SuspendLayout();
            // 
            // txt_Location
            // 
            txt_Location.Font = new Font("Microsoft Sans Serif", 8.25F);
            txt_Location.Location = new Point(34, 208);
            txt_Location.Name = "txt_Location";
            txt_Location.Size = new Size(272, 20);
            txt_Location.TabIndex = 0;
            // 
            // dtp_StartDate
            // 
            dtp_StartDate.CustomFormat = "MM/dd/yyyy hh:mm";
            dtp_StartDate.Font = new Font("Microsoft Sans Serif", 8.25F);
            dtp_StartDate.Format = DateTimePickerFormat.Custom;
            dtp_StartDate.Location = new Point(350, 206);
            dtp_StartDate.Name = "dtp_StartDate";
            dtp_StartDate.Size = new Size(191, 20);
            dtp_StartDate.TabIndex = 1;
            // 
            // dtp_EndDate
            // 
            dtp_EndDate.CustomFormat = "MM/dd/yyyy hh:mm";
            dtp_EndDate.Font = new Font("Microsoft Sans Serif", 8.25F);
            dtp_EndDate.Format = DateTimePickerFormat.Custom;
            dtp_EndDate.Location = new Point(561, 206);
            dtp_EndDate.Name = "dtp_EndDate";
            dtp_EndDate.Size = new Size(191, 20);
            dtp_EndDate.TabIndex = 2;
            // 
            // pnl_TitleLogo
            // 
            pnl_TitleLogo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnl_TitleLogo.BackgroundImage = Properties.Resources.cooltext505340410401435;
            pnl_TitleLogo.BackgroundImageLayout = ImageLayout.Zoom;
            pnl_TitleLogo.Location = new Point(121, 27);
            pnl_TitleLogo.Name = "pnl_TitleLogo";
            pnl_TitleLogo.Size = new Size(558, 93);
            pnl_TitleLogo.TabIndex = 3;
            // 
            // lbl_Location
            // 
            lbl_Location.Font = new Font("Microsoft Sans Serif", 11.999999F);
            lbl_Location.Location = new Point(34, 179);
            lbl_Location.Name = "lbl_Location";
            lbl_Location.Size = new Size(100, 23);
            lbl_Location.TabIndex = 4;
            lbl_Location.Text = "Location";
            // 
            // lbl_StartDate
            // 
            lbl_StartDate.Font = new Font("Microsoft Sans Serif", 11.999999F);
            lbl_StartDate.Location = new Point(350, 177);
            lbl_StartDate.Name = "lbl_StartDate";
            lbl_StartDate.Size = new Size(100, 23);
            lbl_StartDate.TabIndex = 5;
            lbl_StartDate.Text = "Start Time";
            // 
            // lbl_EndDate
            // 
            lbl_EndDate.Font = new Font("Microsoft Sans Serif", 11.999999F);
            lbl_EndDate.Location = new Point(561, 177);
            lbl_EndDate.Name = "lbl_EndDate";
            lbl_EndDate.Size = new Size(100, 23);
            lbl_EndDate.TabIndex = 6;
            lbl_EndDate.Text = "End Time";
            // 
            // button1
            // 
            button1.Location = new Point(315, 257);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 7;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // EcoAnalyzerStartingPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(777, 312);
            Controls.Add(button1);
            Controls.Add(lbl_Location);
            Controls.Add(lbl_StartDate);
            Controls.Add(lbl_EndDate);
            Controls.Add(pnl_TitleLogo);
            Controls.Add(dtp_EndDate);
            Controls.Add(dtp_StartDate);
            Controls.Add(txt_Location);
            Name = "EcoAnalyzerStartingPage";
            Text = "EcoAnalyzer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_Location;
        private DateTimePicker dtp_StartDate;
        private DateTimePicker dtp_EndDate;
        private Panel pnl_TitleLogo;
        private Label lbl_Location;
        private Label lbl_StartDate;
        private Label lbl_EndDate;
        private Button button1;
    }
}
