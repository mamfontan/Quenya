﻿namespace Quenya.View
{
    partial class FrmCommSettings
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbEmail = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtSmtpServer = new System.Windows.Forms.TextBox();
            this.lblSmtpServer = new System.Windows.Forms.Label();
            this.btnTestEmail = new System.Windows.Forms.Button();
            this.gbTelegram = new System.Windows.Forms.GroupBox();
            this.gbEmail.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(579, 336);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 29);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Location = new System.Drawing.Point(11, 336);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 29);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // gbEmail
            // 
            this.gbEmail.Controls.Add(this.label2);
            this.gbEmail.Controls.Add(this.txtPassword);
            this.gbEmail.Controls.Add(this.label1);
            this.gbEmail.Controls.Add(this.txtUsername);
            this.gbEmail.Controls.Add(this.txtSmtpServer);
            this.gbEmail.Controls.Add(this.lblSmtpServer);
            this.gbEmail.Controls.Add(this.btnTestEmail);
            this.gbEmail.Location = new System.Drawing.Point(15, 13);
            this.gbEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbEmail.Name = "gbEmail";
            this.gbEmail.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbEmail.Size = new System.Drawing.Size(658, 151);
            this.gbEmail.TabIndex = 3;
            this.gbEmail.TabStop = false;
            this.gbEmail.Text = " Email  ";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(41, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(153, 109);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(374, 27);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.Text = "textBox2";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(41, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "User name:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(153, 76);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(374, 27);
            this.txtUsername.TabIndex = 3;
            this.txtUsername.Text = "textBox1";
            // 
            // txtSmtpServer
            // 
            this.txtSmtpServer.Location = new System.Drawing.Point(153, 43);
            this.txtSmtpServer.Name = "txtSmtpServer";
            this.txtSmtpServer.Size = new System.Drawing.Size(374, 27);
            this.txtSmtpServer.TabIndex = 3;
            this.txtSmtpServer.Text = "txtSmtpServer";
            // 
            // lblSmtpServer
            // 
            this.lblSmtpServer.Location = new System.Drawing.Point(41, 44);
            this.lblSmtpServer.Name = "lblSmtpServer";
            this.lblSmtpServer.Size = new System.Drawing.Size(105, 25);
            this.lblSmtpServer.TabIndex = 2;
            this.lblSmtpServer.Text = "SMTP Server:";
            // 
            // btnTestEmail
            // 
            this.btnTestEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTestEmail.Location = new System.Drawing.Point(547, 107);
            this.btnTestEmail.Name = "btnTestEmail";
            this.btnTestEmail.Size = new System.Drawing.Size(94, 29);
            this.btnTestEmail.TabIndex = 1;
            this.btnTestEmail.Text = "Test email";
            this.btnTestEmail.UseVisualStyleBackColor = true;
            this.btnTestEmail.Click += new System.EventHandler(this.btnTestEmail_Click);
            // 
            // gbTelegram
            // 
            this.gbTelegram.Location = new System.Drawing.Point(11, 172);
            this.gbTelegram.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbTelegram.Name = "gbTelegram";
            this.gbTelegram.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbTelegram.Size = new System.Drawing.Size(658, 151);
            this.gbTelegram.TabIndex = 3;
            this.gbTelegram.TabStop = false;
            this.gbTelegram.Text = " Telegram  ";
            // 
            // FrmCommSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 377);
            this.Controls.Add(this.gbTelegram);
            this.Controls.Add(this.gbEmail);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCommSettings";
            this.Text = "Comunication settings";
            this.Load += new System.EventHandler(this.FrmCommSettings_Load);
            this.gbEmail.ResumeLayout(false);
            this.gbEmail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox gbEmail;
        private System.Windows.Forms.Button btnTestEmail;
        private System.Windows.Forms.TextBox txtSmtpServer;
        private System.Windows.Forms.Label lblSmtpServer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.GroupBox gbTelegram;
    }
}