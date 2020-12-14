﻿namespace Quenya.View
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDeleteStockValue = new System.Windows.Forms.Button();
            this.treeStockValue = new System.Windows.Forms.TreeView();
            this.treeContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuUpdate01M = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUpdate05M = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUpdate15M = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUpdate60M = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuUpdateDaily = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.dgStockValueData = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtInfo = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnCommSettings = new System.Windows.Forms.Button();
            this.btnDatabaseSettings = new System.Windows.Forms.Button();
            this.btnGeneralSettings = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnSystemGo = new System.Windows.Forms.Button();
            this.cmbSystem = new System.Windows.Forms.ComboBox();
            this.lblUsage = new System.Windows.Forms.Label();
            this.cmbTimeRange = new System.Windows.Forms.ComboBox();
            this.btnShowStockValue = new System.Windows.Forms.Button();
            this.btnAddStockValue = new System.Windows.Forms.Button();
            this.toolTip_ES = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip_EN = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.treeContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgStockValueData)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.btnDeleteStockValue);
            this.groupBox1.Controls.Add(this.treeStockValue);
            this.groupBox1.Location = new System.Drawing.Point(10, 9);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(291, 407);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Stock value list  ";
            // 
            // btnDeleteStockValue
            // 
            this.btnDeleteStockValue.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDeleteStockValue.BackgroundImage")));
            this.btnDeleteStockValue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDeleteStockValue.Location = new System.Drawing.Point(259, 1);
            this.btnDeleteStockValue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeleteStockValue.Name = "btnDeleteStockValue";
            this.btnDeleteStockValue.Size = new System.Drawing.Size(21, 18);
            this.btnDeleteStockValue.TabIndex = 1;
            this.toolTip_ES.SetToolTip(this.btnDeleteStockValue, "Eliminar valor");
            this.toolTip_EN.SetToolTip(this.btnDeleteStockValue, "Delete stock");
            this.btnDeleteStockValue.UseVisualStyleBackColor = true;
            this.btnDeleteStockValue.Click += new System.EventHandler(this.btnDelStockValue_Click);
            // 
            // treeStockValue
            // 
            this.treeStockValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeStockValue.ContextMenuStrip = this.treeContextMenu;
            this.treeStockValue.HideSelection = false;
            this.treeStockValue.Location = new System.Drawing.Point(14, 25);
            this.treeStockValue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.treeStockValue.Name = "treeStockValue";
            this.treeStockValue.ShowNodeToolTips = true;
            this.treeStockValue.Size = new System.Drawing.Size(262, 377);
            this.treeStockValue.TabIndex = 0;
            this.treeStockValue.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeStockValue_AfterSelect);
            // 
            // treeContextMenu
            // 
            this.treeContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.treeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUpdate01M,
            this.menuUpdate05M,
            this.menuUpdate15M,
            this.menuUpdate60M,
            this.toolStripSeparator1,
            this.menuUpdateDaily});
            this.treeContextMenu.Name = "treeContextMenu";
            this.treeContextMenu.Size = new System.Drawing.Size(224, 120);
            // 
            // menuUpdate01M
            // 
            this.menuUpdate01M.Name = "menuUpdate01M";
            this.menuUpdate01M.Size = new System.Drawing.Size(223, 22);
            this.menuUpdate01M.Text = "Update one minute range";
            // 
            // menuUpdate05M
            // 
            this.menuUpdate05M.Name = "menuUpdate05M";
            this.menuUpdate05M.Size = new System.Drawing.Size(223, 22);
            this.menuUpdate05M.Text = "Update five minute range";
            // 
            // menuUpdate15M
            // 
            this.menuUpdate15M.Name = "menuUpdate15M";
            this.menuUpdate15M.Size = new System.Drawing.Size(223, 22);
            this.menuUpdate15M.Text = "Update fifteen minute range";
            // 
            // menuUpdate60M
            // 
            this.menuUpdate60M.Name = "menuUpdate60M";
            this.menuUpdate60M.Size = new System.Drawing.Size(223, 22);
            this.menuUpdate60M.Text = "Update one hour range";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(220, 6);
            // 
            // menuUpdateDaily
            // 
            this.menuUpdateDaily.Name = "menuUpdateDaily";
            this.menuUpdateDaily.Size = new System.Drawing.Size(223, 22);
            this.menuUpdateDaily.Text = "Update daily values";
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer.Location = new System.Drawing.Point(307, 64);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.dgStockValueData);
            this.splitContainer.Size = new System.Drawing.Size(621, 309);
            this.splitContainer.SplitterDistance = 183;
            this.splitContainer.SplitterWidth = 3;
            this.splitContainer.TabIndex = 2;
            this.splitContainer.Text = "splitContainer1";
            // 
            // dgStockValueData
            // 
            this.dgStockValueData.AllowUserToResizeRows = false;
            this.dgStockValueData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgStockValueData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgStockValueData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgStockValueData.Location = new System.Drawing.Point(3, 2);
            this.dgStockValueData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgStockValueData.Name = "dgStockValueData";
            this.dgStockValueData.RowHeadersWidth = 51;
            this.dgStockValueData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgStockValueData.Size = new System.Drawing.Size(611, 174);
            this.dgStockValueData.TabIndex = 0;
            this.dgStockValueData.Text = "dataGridView1";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtInfo);
            this.groupBox2.Location = new System.Drawing.Point(307, 367);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(463, 50);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // txtInfo
            // 
            this.txtInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInfo.Location = new System.Drawing.Point(5, 11);
            this.txtInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ReadOnly = true;
            this.txtInfo.Size = new System.Drawing.Size(451, 36);
            this.txtInfo.TabIndex = 0;
            this.txtInfo.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox3.Controls.Add(this.btnCommSettings);
            this.groupBox3.Controls.Add(this.btnDatabaseSettings);
            this.groupBox3.Controls.Add(this.btnGeneralSettings);
            this.groupBox3.Location = new System.Drawing.Point(775, 367);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(150, 50);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            // 
            // btnCommSettings
            // 
            this.btnCommSettings.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCommSettings.BackgroundImage")));
            this.btnCommSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCommSettings.Location = new System.Drawing.Point(6, 10);
            this.btnCommSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCommSettings.Name = "btnCommSettings";
            this.btnCommSettings.Size = new System.Drawing.Size(42, 36);
            this.btnCommSettings.TabIndex = 1;
            this.toolTip_ES.SetToolTip(this.btnCommSettings, "Configuración de las comunicaciones");
            this.toolTip_EN.SetToolTip(this.btnCommSettings, "Communication settings");
            this.btnCommSettings.UseVisualStyleBackColor = true;
            this.btnCommSettings.Click += new System.EventHandler(this.btnCommSettings_Click);
            // 
            // btnDatabaseSettings
            // 
            this.btnDatabaseSettings.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDatabaseSettings.BackgroundImage")));
            this.btnDatabaseSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDatabaseSettings.Location = new System.Drawing.Point(53, 10);
            this.btnDatabaseSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDatabaseSettings.Name = "btnDatabaseSettings";
            this.btnDatabaseSettings.Size = new System.Drawing.Size(42, 36);
            this.btnDatabaseSettings.TabIndex = 1;
            this.toolTip_ES.SetToolTip(this.btnDatabaseSettings, "Configuración de la base de datos");
            this.toolTip_EN.SetToolTip(this.btnDatabaseSettings, "Database settings");
            this.btnDatabaseSettings.UseVisualStyleBackColor = true;
            this.btnDatabaseSettings.Click += new System.EventHandler(this.btnDatabaseSettings_Click);
            // 
            // btnGeneralSettings
            // 
            this.btnGeneralSettings.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGeneralSettings.BackgroundImage")));
            this.btnGeneralSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGeneralSettings.Location = new System.Drawing.Point(101, 10);
            this.btnGeneralSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGeneralSettings.Name = "btnGeneralSettings";
            this.btnGeneralSettings.Size = new System.Drawing.Size(42, 36);
            this.btnGeneralSettings.TabIndex = 1;
            this.toolTip_ES.SetToolTip(this.btnGeneralSettings, "Configuración general");
            this.toolTip_EN.SetToolTip(this.btnGeneralSettings, "General settings");
            this.btnGeneralSettings.UseVisualStyleBackColor = true;
            this.btnGeneralSettings.Click += new System.EventHandler(this.btnGeneralSettings_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.btnSystemGo);
            this.groupBox4.Controls.Add(this.cmbSystem);
            this.groupBox4.Controls.Add(this.lblUsage);
            this.groupBox4.Controls.Add(this.cmbTimeRange);
            this.groupBox4.Location = new System.Drawing.Point(307, 9);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Size = new System.Drawing.Size(618, 50);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            // 
            // btnSystemGo
            // 
            this.btnSystemGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSystemGo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSystemGo.BackgroundImage")));
            this.btnSystemGo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSystemGo.Location = new System.Drawing.Point(502, 16);
            this.btnSystemGo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSystemGo.Name = "btnSystemGo";
            this.btnSystemGo.Size = new System.Drawing.Size(28, 28);
            this.btnSystemGo.TabIndex = 3;
            this.toolTip_ES.SetToolTip(this.btnSystemGo, "Añadir valor");
            this.toolTip_EN.SetToolTip(this.btnSystemGo, "Add stock");
            this.btnSystemGo.UseVisualStyleBackColor = true;
            this.btnSystemGo.Click += new System.EventHandler(this.btnSystemGo_Click);
            // 
            // cmbSystem
            // 
            this.cmbSystem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSystem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSystem.FormattingEnabled = true;
            this.cmbSystem.Location = new System.Drawing.Point(326, 19);
            this.cmbSystem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbSystem.Name = "cmbSystem";
            this.cmbSystem.Size = new System.Drawing.Size(170, 23);
            this.cmbSystem.TabIndex = 2;
            // 
            // lblUsage
            // 
            this.lblUsage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblUsage.Location = new System.Drawing.Point(560, 15);
            this.lblUsage.Name = "lblUsage";
            this.lblUsage.Size = new System.Drawing.Size(50, 28);
            this.lblUsage.TabIndex = 1;
            this.lblUsage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbTimeRange
            // 
            this.cmbTimeRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTimeRange.FormattingEnabled = true;
            this.cmbTimeRange.Location = new System.Drawing.Point(16, 20);
            this.cmbTimeRange.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbTimeRange.Name = "cmbTimeRange";
            this.cmbTimeRange.Size = new System.Drawing.Size(170, 23);
            this.cmbTimeRange.TabIndex = 0;
            this.cmbTimeRange.SelectedValueChanged += new System.EventHandler(this.cmbTimeRange_SelectedValueChanged);
            // 
            // btnShowStockValue
            // 
            this.btnShowStockValue.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnShowStockValue.BackgroundImage")));
            this.btnShowStockValue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnShowStockValue.Location = new System.Drawing.Point(244, 10);
            this.btnShowStockValue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnShowStockValue.Name = "btnShowStockValue";
            this.btnShowStockValue.Size = new System.Drawing.Size(21, 18);
            this.btnShowStockValue.TabIndex = 1;
            this.toolTip_ES.SetToolTip(this.btnShowStockValue, "Informacion del valor");
            this.toolTip_EN.SetToolTip(this.btnShowStockValue, "Stock information");
            this.btnShowStockValue.UseVisualStyleBackColor = true;
            this.btnShowStockValue.Click += new System.EventHandler(this.btnInfoStockValue_Click);
            // 
            // btnAddStockValue
            // 
            this.btnAddStockValue.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddStockValue.BackgroundImage")));
            this.btnAddStockValue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddStockValue.Location = new System.Drawing.Point(220, 10);
            this.btnAddStockValue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddStockValue.Name = "btnAddStockValue";
            this.btnAddStockValue.Size = new System.Drawing.Size(21, 18);
            this.btnAddStockValue.TabIndex = 1;
            this.toolTip_ES.SetToolTip(this.btnAddStockValue, "Añadir valor");
            this.toolTip_EN.SetToolTip(this.btnAddStockValue, "Add stock");
            this.btnAddStockValue.UseVisualStyleBackColor = true;
            this.btnAddStockValue.Click += new System.EventHandler(this.btnAddStockValue_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 425);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.btnAddStockValue);
            this.Controls.Add(this.btnShowStockValue);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmMain";
            this.Text = "Quenya";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.treeContextMenu.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgStockValueData)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView treeStockValue;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cmbTimeRange;
        private System.Windows.Forms.Button btnDeleteStockValue;
        private System.Windows.Forms.Button btnShowStockValue;
        private System.Windows.Forms.Button btnAddStockValue;
        private System.Windows.Forms.RichTextBox txtInfo;
        private System.Windows.Forms.ToolTip toolTip_ES;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.DataGridView dgStockValueData;
        private System.Windows.Forms.Button btnCommSettings;
        private System.Windows.Forms.Button btnDatabaseSettings;
        private System.Windows.Forms.Button btnGeneralSettings;
        private LiveCharts.WinForms.CartesianChart chartStockValue;
        private System.Windows.Forms.ToolTip toolTip_EN;
        private System.Windows.Forms.Label lblUsage;
        private System.Windows.Forms.ContextMenuStrip treeContextMenu;
        private System.Windows.Forms.ToolStripMenuItem menuUpdate01M;
        private System.Windows.Forms.ToolStripMenuItem menuUpdate05M;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem menuUpdateDaily;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuUpdate15M;
        private System.Windows.Forms.ToolStripMenuItem menuUpdate60M;
        private System.Windows.Forms.Button btnSystemGo;
        private System.Windows.Forms.ComboBox cmbSystem;
    }
}

