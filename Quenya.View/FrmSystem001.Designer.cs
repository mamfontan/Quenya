
namespace Quenya.View
{
    partial class FrmSystem001
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSystem001));
            this.lblSystemTitle001 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.gbSystemInfo = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.gbSystemSettings = new System.Windows.Forms.GroupBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.lblNumDays = new System.Windows.Forms.Label();
            this.gbSystemLog = new System.Windows.Forms.GroupBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.gbSystemInfo.SuspendLayout();
            this.gbSystemSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.gbSystemLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSystemTitle001
            // 
            this.lblSystemTitle001.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSystemTitle001.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSystemTitle001.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSystemTitle001.ForeColor = System.Drawing.Color.Blue;
            this.lblSystemTitle001.Location = new System.Drawing.Point(12, 9);
            this.lblSystemTitle001.Name = "lblSystemTitle001";
            this.lblSystemTitle001.Size = new System.Drawing.Size(713, 45);
            this.lblSystemTitle001.TabIndex = 0;
            this.lblSystemTitle001.Text = "Three  Turtles";
            this.lblSystemTitle001.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(643, 399);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(82, 22);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPlay.Location = new System.Drawing.Point(12, 399);
            this.btnPlay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(82, 22);
            this.btnPlay.TabIndex = 2;
            this.btnPlay.Text = "GO";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // gbSystemInfo
            // 
            this.gbSystemInfo.Controls.Add(this.richTextBox1);
            this.gbSystemInfo.Location = new System.Drawing.Point(12, 66);
            this.gbSystemInfo.Name = "gbSystemInfo";
            this.gbSystemInfo.Size = new System.Drawing.Size(315, 160);
            this.gbSystemInfo.TabIndex = 3;
            this.gbSystemInfo.TabStop = false;
            this.gbSystemInfo.Text = " Description  ";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(14, 22);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(284, 132);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // gbSystemSettings
            // 
            this.gbSystemSettings.Controls.Add(this.numericUpDown1);
            this.gbSystemSettings.Controls.Add(this.lblNumDays);
            this.gbSystemSettings.Location = new System.Drawing.Point(12, 232);
            this.gbSystemSettings.Name = "gbSystemSettings";
            this.gbSystemSettings.Size = new System.Drawing.Size(315, 160);
            this.gbSystemSettings.TabIndex = 4;
            this.gbSystemSettings.TabStop = false;
            this.gbSystemSettings.Text = " Settings  ";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(113, 29);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(63, 23);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblNumDays
            // 
            this.lblNumDays.AutoSize = true;
            this.lblNumDays.Location = new System.Drawing.Point(30, 33);
            this.lblNumDays.Name = "lblNumDays";
            this.lblNumDays.Size = new System.Drawing.Size(67, 15);
            this.lblNumDays.TabIndex = 0;
            this.lblNumDays.Text = "Num. days:";
            // 
            // gbSystemLog
            // 
            this.gbSystemLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSystemLog.Controls.Add(this.richTextBox2);
            this.gbSystemLog.Location = new System.Drawing.Point(344, 66);
            this.gbSystemLog.Name = "gbSystemLog";
            this.gbSystemLog.Size = new System.Drawing.Size(381, 326);
            this.gbSystemLog.TabIndex = 5;
            this.gbSystemLog.TabStop = false;
            this.gbSystemLog.Text = " Log  ";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox2.Location = new System.Drawing.Point(14, 22);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(355, 296);
            this.richTextBox2.TabIndex = 0;
            this.richTextBox2.Text = "";
            // 
            // FrmSystem001
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 432);
            this.Controls.Add(this.gbSystemLog);
            this.Controls.Add(this.gbSystemSettings);
            this.Controls.Add(this.gbSystemInfo);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblSystemTitle001);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSystem001";
            this.Text = "System 001";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmSystem001_FormClosed);
            this.Load += new System.EventHandler(this.FrmSystem001_Load);
            this.gbSystemInfo.ResumeLayout(false);
            this.gbSystemSettings.ResumeLayout(false);
            this.gbSystemSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.gbSystemLog.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSystemTitle001;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.GroupBox gbSystemInfo;
        private System.Windows.Forms.GroupBox gbSystemSettings;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label lblNumDays;
        private System.Windows.Forms.GroupBox gbSystemLog;
        private System.Windows.Forms.RichTextBox richTextBox2;
    }
}