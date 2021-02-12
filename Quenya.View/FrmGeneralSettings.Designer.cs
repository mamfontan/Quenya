namespace Quenya.View
{
    partial class FrmGeneralSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGeneralSettings));
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbLanguageList = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnExportFolder = new System.Windows.Forms.Button();
            this.txtExportFolder = new System.Windows.Forms.TextBox();
            this.gbChart = new System.Windows.Forms.GroupBox();
            this.chkShowVolumeSeries = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbChart.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(310, 148);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(82, 22);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Location = new System.Drawing.Point(10, 148);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 22);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbLanguageList);
            this.groupBox1.Location = new System.Drawing.Point(10, 9);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(192, 65);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Language  ";
            // 
            // cmbLanguageList
            // 
            this.cmbLanguageList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLanguageList.FormattingEnabled = true;
            this.cmbLanguageList.Location = new System.Drawing.Point(22, 28);
            this.cmbLanguageList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbLanguageList.Name = "cmbLanguageList";
            this.cmbLanguageList.Size = new System.Drawing.Size(151, 23);
            this.cmbLanguageList.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnExportFolder);
            this.groupBox2.Controls.Add(this.txtExportFolder);
            this.groupBox2.Location = new System.Drawing.Point(10, 78);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(377, 65);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Export folder  ";
            // 
            // btnExportFolder
            // 
            this.btnExportFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportFolder.Location = new System.Drawing.Point(333, 29);
            this.btnExportFolder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExportFolder.Name = "btnExportFolder";
            this.btnExportFolder.Size = new System.Drawing.Size(32, 22);
            this.btnExportFolder.TabIndex = 1;
            this.btnExportFolder.Text = "...";
            this.btnExportFolder.UseVisualStyleBackColor = true;
            this.btnExportFolder.Click += new System.EventHandler(this.btnExportFolder_Click);
            // 
            // txtExportFolder
            // 
            this.txtExportFolder.Location = new System.Drawing.Point(22, 28);
            this.txtExportFolder.Name = "txtExportFolder";
            this.txtExportFolder.ReadOnly = true;
            this.txtExportFolder.Size = new System.Drawing.Size(307, 23);
            this.txtExportFolder.TabIndex = 0;
            // 
            // gbChart
            // 
            this.gbChart.Controls.Add(this.chkShowVolumeSeries);
            this.gbChart.Location = new System.Drawing.Point(207, 9);
            this.gbChart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbChart.Name = "gbChart";
            this.gbChart.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbChart.Size = new System.Drawing.Size(179, 65);
            this.gbChart.TabIndex = 1;
            this.gbChart.TabStop = false;
            this.gbChart.Text = " Chart  ";
            // 
            // chkShowVolumeSeries
            // 
            this.chkShowVolumeSeries.AutoSize = true;
            this.chkShowVolumeSeries.Location = new System.Drawing.Point(19, 29);
            this.chkShowVolumeSeries.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkShowVolumeSeries.Name = "chkShowVolumeSeries";
            this.chkShowVolumeSeries.Size = new System.Drawing.Size(130, 19);
            this.chkShowVolumeSeries.TabIndex = 0;
            this.chkShowVolumeSeries.Text = "Show volume series";
            this.chkShowVolumeSeries.UseVisualStyleBackColor = true;
            // 
            // FrmGeneralSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 178);
            this.Controls.Add(this.gbChart);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGeneralSettings";
            this.Text = "General Settings";
            this.Load += new System.EventHandler(this.FrmGeneralSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbChart.ResumeLayout(false);
            this.gbChart.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbLanguageList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnExportFolder;
        private System.Windows.Forms.TextBox txtExportFolder;
        private System.Windows.Forms.GroupBox gbChart;
        private System.Windows.Forms.CheckBox chkShowVolumeSeries;
    }
}