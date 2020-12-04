namespace Quenya.View
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
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.dgStockValueData = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtInfo = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnCommSettings = new System.Windows.Forms.Button();
            this.btnDatabaseSettings = new System.Windows.Forms.Button();
            this.btnGeneralSettings = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cmbTimeRange = new System.Windows.Forms.ComboBox();
            this.btnShowStockValue = new System.Windows.Forms.Button();
            this.btnAddStockValue = new System.Windows.Forms.Button();
            this.toolTip_ES = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
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
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(298, 543);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Stock value list  ";
            // 
            // btnDeleteStockValue
            // 
            this.btnDeleteStockValue.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDeleteStockValue.BackgroundImage")));
            this.btnDeleteStockValue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDeleteStockValue.Location = new System.Drawing.Point(259, 1);
            this.btnDeleteStockValue.Name = "btnDeleteStockValue";
            this.btnDeleteStockValue.Size = new System.Drawing.Size(24, 24);
            this.btnDeleteStockValue.TabIndex = 1;
            this.toolTip_ES.SetToolTip(this.btnDeleteStockValue, "Eliminar valor");
            this.btnDeleteStockValue.UseVisualStyleBackColor = true;
            this.btnDeleteStockValue.Click += new System.EventHandler(this.btnDelStockValue_Click);
            // 
            // treeStockValue
            // 
            this.treeStockValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeStockValue.Location = new System.Drawing.Point(16, 33);
            this.treeStockValue.Name = "treeStockValue";
            this.treeStockValue.Size = new System.Drawing.Size(264, 501);
            this.treeStockValue.TabIndex = 0;
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer.Location = new System.Drawing.Point(322, 86);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.dgStockValueData);
            this.splitContainer.Size = new System.Drawing.Size(739, 412);
            this.splitContainer.SplitterDistance = 246;
            this.splitContainer.TabIndex = 2;
            this.splitContainer.Text = "splitContainer1";
            // 
            // dgStockValueData
            // 
            this.dgStockValueData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgStockValueData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgStockValueData.Location = new System.Drawing.Point(3, 3);
            this.dgStockValueData.Name = "dgStockValueData";
            this.dgStockValueData.RowHeadersWidth = 51;
            this.dgStockValueData.Size = new System.Drawing.Size(730, 236);
            this.dgStockValueData.TabIndex = 0;
            this.dgStockValueData.Text = "dataGridView1";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtInfo);
            this.groupBox2.Location = new System.Drawing.Point(316, 489);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(564, 66);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // txtInfo
            // 
            this.txtInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInfo.Location = new System.Drawing.Point(6, 15);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ReadOnly = true;
            this.txtInfo.Size = new System.Drawing.Size(550, 46);
            this.txtInfo.TabIndex = 0;
            this.txtInfo.Text = "";
            this.txtInfo.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox3.Controls.Add(this.btnCommSettings);
            this.groupBox3.Controls.Add(this.btnDatabaseSettings);
            this.groupBox3.Controls.Add(this.btnGeneralSettings);
            this.groupBox3.Location = new System.Drawing.Point(886, 489);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(171, 66);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            // 
            // btnCommSettings
            // 
            this.btnCommSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCommSettings.Location = new System.Drawing.Point(7, 14);
            this.btnCommSettings.Name = "btnCommSettings";
            this.btnCommSettings.Size = new System.Drawing.Size(48, 48);
            this.btnCommSettings.TabIndex = 1;
            this.toolTip_ES.SetToolTip(this.btnCommSettings, "Configuración de las comunicaciones");
            this.btnCommSettings.UseVisualStyleBackColor = true;
            this.btnCommSettings.Click += new System.EventHandler(this.btnAddStockValue_Click);
            // 
            // btnDatabaseSettings
            // 
            this.btnDatabaseSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDatabaseSettings.Location = new System.Drawing.Point(61, 14);
            this.btnDatabaseSettings.Name = "btnDatabaseSettings";
            this.btnDatabaseSettings.Size = new System.Drawing.Size(48, 48);
            this.btnDatabaseSettings.TabIndex = 1;
            this.toolTip_ES.SetToolTip(this.btnDatabaseSettings, "Configuración de la base de datos");
            this.btnDatabaseSettings.UseVisualStyleBackColor = true;
            this.btnDatabaseSettings.Click += new System.EventHandler(this.btnAddStockValue_Click);
            // 
            // btnGeneralSettings
            // 
            this.btnGeneralSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGeneralSettings.Location = new System.Drawing.Point(115, 14);
            this.btnGeneralSettings.Name = "btnGeneralSettings";
            this.btnGeneralSettings.Size = new System.Drawing.Size(48, 48);
            this.btnGeneralSettings.TabIndex = 1;
            this.toolTip_ES.SetToolTip(this.btnGeneralSettings, "Configuración general");
            this.btnGeneralSettings.UseVisualStyleBackColor = true;
            this.btnGeneralSettings.Click += new System.EventHandler(this.btnAddStockValue_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.cmbTimeRange);
            this.groupBox4.Location = new System.Drawing.Point(316, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(741, 66);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            // 
            // cmbTimeRange
            // 
            this.cmbTimeRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTimeRange.FormattingEnabled = true;
            this.cmbTimeRange.Location = new System.Drawing.Point(18, 26);
            this.cmbTimeRange.Name = "cmbTimeRange";
            this.cmbTimeRange.Size = new System.Drawing.Size(194, 28);
            this.cmbTimeRange.TabIndex = 0;
            // 
            // btnShowStockValue
            // 
            this.btnShowStockValue.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnShowStockValue.BackgroundImage")));
            this.btnShowStockValue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnShowStockValue.Location = new System.Drawing.Point(242, 13);
            this.btnShowStockValue.Name = "btnShowStockValue";
            this.btnShowStockValue.Size = new System.Drawing.Size(24, 24);
            this.btnShowStockValue.TabIndex = 1;
            this.toolTip_ES.SetToolTip(this.btnShowStockValue, "Informacion del valor");
            this.btnShowStockValue.UseVisualStyleBackColor = true;
            this.btnShowStockValue.Click += new System.EventHandler(this.btnInfoStockValue_Click);
            // 
            // btnAddStockValue
            // 
            this.btnAddStockValue.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddStockValue.BackgroundImage")));
            this.btnAddStockValue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddStockValue.Location = new System.Drawing.Point(215, 13);
            this.btnAddStockValue.Name = "btnAddStockValue";
            this.btnAddStockValue.Size = new System.Drawing.Size(24, 24);
            this.btnAddStockValue.TabIndex = 1;
            this.toolTip_ES.SetToolTip(this.btnAddStockValue, "Añadir valor");
            this.btnAddStockValue.UseVisualStyleBackColor = true;
            this.btnAddStockValue.Click += new System.EventHandler(this.btnAddStockValue_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 567);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.btnAddStockValue);
            this.Controls.Add(this.btnShowStockValue);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmMain";
            this.Text = "Quenya";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.groupBox1.ResumeLayout(false);
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
    }
}

