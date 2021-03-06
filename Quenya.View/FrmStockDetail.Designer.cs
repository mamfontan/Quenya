﻿namespace Quenya.View
{
    partial class FrmStockDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStockDetail));
            this.btnClose = new System.Windows.Forms.Button();
            this.gbStockValueInfo = new System.Windows.Forms.GroupBox();
            this.lblDescriptionValue = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblAddressValue = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.lblAssetTypeValue = new System.Windows.Forms.Label();
            this.lblAssetType = new System.Windows.Forms.Label();
            this.lblExchangeValue = new System.Windows.Forms.Label();
            this.lblExchange = new System.Windows.Forms.Label();
            this.lblCurrencyValue = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCountryValue = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSectorValue = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblIndustryValue = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblEmployeesValue = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.gbLogo = new System.Windows.Forms.GroupBox();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnRefreshLogo = new System.Windows.Forms.Button();
            this.gbStockValueInfo.SuspendLayout();
            this.gbLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(724, 558);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(94, 29);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gbStockValueInfo
            // 
            this.gbStockValueInfo.Controls.Add(this.lblDescriptionValue);
            this.gbStockValueInfo.Location = new System.Drawing.Point(261, 12);
            this.gbStockValueInfo.Name = "gbStockValueInfo";
            this.gbStockValueInfo.Size = new System.Drawing.Size(557, 512);
            this.gbStockValueInfo.TabIndex = 1;
            this.gbStockValueInfo.TabStop = false;
            this.gbStockValueInfo.Text = " Stock value name  ";
            // 
            // lblDescriptionValue
            // 
            this.lblDescriptionValue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDescriptionValue.ForeColor = System.Drawing.Color.Blue;
            this.lblDescriptionValue.Location = new System.Drawing.Point(18, 29);
            this.lblDescriptionValue.Name = "lblDescriptionValue";
            this.lblDescriptionValue.Size = new System.Drawing.Size(521, 467);
            this.lblDescriptionValue.TabIndex = 2;
            this.lblDescriptionValue.Text = "Description";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(12, 534);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(65, 20);
            this.lblAddress.TabIndex = 2;
            this.lblAddress.Text = "Address:";
            // 
            // lblAddressValue
            // 
            this.lblAddressValue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAddressValue.ForeColor = System.Drawing.Color.Blue;
            this.lblAddressValue.Location = new System.Drawing.Point(12, 562);
            this.lblAddressValue.Name = "lblAddressValue";
            this.lblAddressValue.Size = new System.Drawing.Size(523, 20);
            this.lblAddressValue.TabIndex = 2;
            this.lblAddressValue.Text = "Address";
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(624, 558);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(94, 29);
            this.btnExport.TabIndex = 0;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lblAssetTypeValue
            // 
            this.lblAssetTypeValue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAssetTypeValue.ForeColor = System.Drawing.Color.Blue;
            this.lblAssetTypeValue.Location = new System.Drawing.Point(15, 176);
            this.lblAssetTypeValue.Name = "lblAssetTypeValue";
            this.lblAssetTypeValue.Size = new System.Drawing.Size(208, 20);
            this.lblAssetTypeValue.TabIndex = 3;
            this.lblAssetTypeValue.Text = "Asset type";
            // 
            // lblAssetType
            // 
            this.lblAssetType.AutoSize = true;
            this.lblAssetType.Location = new System.Drawing.Point(15, 154);
            this.lblAssetType.Name = "lblAssetType";
            this.lblAssetType.Size = new System.Drawing.Size(80, 20);
            this.lblAssetType.TabIndex = 4;
            this.lblAssetType.Text = "Asset type:";
            // 
            // lblExchangeValue
            // 
            this.lblExchangeValue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblExchangeValue.ForeColor = System.Drawing.Color.Blue;
            this.lblExchangeValue.Location = new System.Drawing.Point(15, 228);
            this.lblExchangeValue.Name = "lblExchangeValue";
            this.lblExchangeValue.Size = new System.Drawing.Size(208, 20);
            this.lblExchangeValue.TabIndex = 5;
            this.lblExchangeValue.Text = "Exchange";
            // 
            // lblExchange
            // 
            this.lblExchange.AutoSize = true;
            this.lblExchange.Location = new System.Drawing.Point(15, 207);
            this.lblExchange.Name = "lblExchange";
            this.lblExchange.Size = new System.Drawing.Size(75, 20);
            this.lblExchange.TabIndex = 6;
            this.lblExchange.Text = "Exchange:";
            // 
            // lblCurrencyValue
            // 
            this.lblCurrencyValue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCurrencyValue.ForeColor = System.Drawing.Color.Blue;
            this.lblCurrencyValue.Location = new System.Drawing.Point(15, 282);
            this.lblCurrencyValue.Name = "lblCurrencyValue";
            this.lblCurrencyValue.Size = new System.Drawing.Size(208, 20);
            this.lblCurrencyValue.TabIndex = 7;
            this.lblCurrencyValue.Text = "Currency";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 261);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Currency:";
            // 
            // lblCountryValue
            // 
            this.lblCountryValue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCountryValue.ForeColor = System.Drawing.Color.Blue;
            this.lblCountryValue.Location = new System.Drawing.Point(15, 335);
            this.lblCountryValue.Name = "lblCountryValue";
            this.lblCountryValue.Size = new System.Drawing.Size(208, 20);
            this.lblCountryValue.TabIndex = 9;
            this.lblCountryValue.Text = "Country";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 314);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Country:";
            // 
            // lblSectorValue
            // 
            this.lblSectorValue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSectorValue.ForeColor = System.Drawing.Color.Blue;
            this.lblSectorValue.Location = new System.Drawing.Point(15, 390);
            this.lblSectorValue.Name = "lblSectorValue";
            this.lblSectorValue.Size = new System.Drawing.Size(208, 20);
            this.lblSectorValue.TabIndex = 11;
            this.lblSectorValue.Text = "Sector";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 368);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Sector:";
            // 
            // lblIndustryValue
            // 
            this.lblIndustryValue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblIndustryValue.ForeColor = System.Drawing.Color.Blue;
            this.lblIndustryValue.Location = new System.Drawing.Point(15, 447);
            this.lblIndustryValue.Name = "lblIndustryValue";
            this.lblIndustryValue.Size = new System.Drawing.Size(208, 20);
            this.lblIndustryValue.TabIndex = 13;
            this.lblIndustryValue.Text = "Industry";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 425);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "Industry:";
            // 
            // lblEmployeesValue
            // 
            this.lblEmployeesValue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblEmployeesValue.ForeColor = System.Drawing.Color.Blue;
            this.lblEmployeesValue.Location = new System.Drawing.Point(15, 500);
            this.lblEmployeesValue.Name = "lblEmployeesValue";
            this.lblEmployeesValue.Size = new System.Drawing.Size(208, 20);
            this.lblEmployeesValue.TabIndex = 15;
            this.lblEmployeesValue.Text = "Employess";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 477);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 20);
            this.label10.TabIndex = 16;
            this.label10.Text = "Employees:";
            // 
            // gbLogo
            // 
            this.gbLogo.Controls.Add(this.pbLogo);
            this.gbLogo.Location = new System.Drawing.Point(15, 12);
            this.gbLogo.Name = "gbLogo";
            this.gbLogo.Size = new System.Drawing.Size(208, 130);
            this.gbLogo.TabIndex = 17;
            this.gbLogo.TabStop = false;
            this.gbLogo.Text = " Logo  ";
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(23, 24);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(167, 98);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // btnRefreshLogo
            // 
            this.btnRefreshLogo.Location = new System.Drawing.Point(209, 7);
            this.btnRefreshLogo.Name = "btnRefreshLogo";
            this.btnRefreshLogo.Size = new System.Drawing.Size(34, 34);
            this.btnRefreshLogo.TabIndex = 1;
            this.btnRefreshLogo.UseVisualStyleBackColor = true;
            this.btnRefreshLogo.Click += new System.EventHandler(this.btnRefreshLogo_Click);
            // 
            // FrmStockDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 599);
            this.Controls.Add(this.btnRefreshLogo);
            this.Controls.Add(this.gbLogo);
            this.Controls.Add(this.lblEmployeesValue);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblIndustryValue);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblSectorValue);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblCountryValue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblCurrencyValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblExchangeValue);
            this.Controls.Add(this.lblExchange);
            this.Controls.Add(this.lblAssetTypeValue);
            this.Controls.Add(this.lblAssetType);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.lblAddressValue);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.gbStockValueInfo);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmStockDetail";
            this.Text = "Stock Detail";
            this.Load += new System.EventHandler(this.FrmStockDetail_Load);
            this.gbStockValueInfo.ResumeLayout(false);
            this.gbLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox gbStockValueInfo;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblAddressValue;
        private System.Windows.Forms.Label lblDescriptionValue;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label lblAssetTypeValue;
        private System.Windows.Forms.Label lblAssetType;
        private System.Windows.Forms.Label lblExchangeValue;
        private System.Windows.Forms.Label lblExchange;
        private System.Windows.Forms.Label lblCurrencyValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCountryValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSectorValue;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblIndustryValue;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblEmployeesValue;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox gbLogo;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Button btnRefreshLogo;
    }
}