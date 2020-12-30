using Quenya.Common;
using Quenya.Common.interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Quenya.View
{
    public partial class FrmCommSettings : FrmBase
    {
        public FrmCommSettings()
        {
            InitializeComponent();
        }

        public FrmCommSettings(IConfigurationHelper config)
        {
            InitializeComponent();

            _config = config;
        }

        private void FrmCommSettings_Load(object sender, EventArgs e)
        {
            HookButtonEvents(new List<Control>() { btnCancel, btnSave, btnTestEmail });

            ShowCommsSettingsData();
        }

        private void ShowCommsSettingsData()
        {
            if (_config == null)
                return;

            txtSmtpServer.Text = _config.EmailSmtpServer;
            txtUsername.Text = _config.EmailUsername;
            txtPassword.Text = _config.EmailPassword;
        }

        private void btnTestEmail_Click(object sender, EventArgs e)
        {
            var strSmtpServer = txtSmtpServer.Text.Trim();
            var strUsername = txtUsername.Text.Trim();
            var strPassword = txtPassword.Text.Trim();

            IEmailHelper emailHelper = new EmailHelper(strSmtpServer, strUsername, strPassword);
            var result = emailHelper.SendMessaqe("tema del mensaje", "cuerpo del mensaje", "mamfontan@gmail.com");
            ShowMessageToUser(result);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_config == null)
                return;

            var needToSave = false;

            var strSmtpServer = txtSmtpServer.Text.Trim();
            var strUsername = txtUsername.Text.Trim();
            var strPassword = txtPassword.Text.Trim();

            if (!string.Equals(strSmtpServer, _config.EmailSmtpServer, StringComparison.CurrentCultureIgnoreCase))
            {
                needToSave = true;
                _config.EmailSmtpServer = strSmtpServer;
            }

            if (!string.Equals(strUsername, _config.EmailUsername, StringComparison.CurrentCultureIgnoreCase))
            {
                needToSave = true;
                _config.EmailUsername = strUsername;
            }

            if (!string.Equals(strPassword, _config.EmailPassword, StringComparison.CurrentCultureIgnoreCase))
            {
                needToSave = true;
                _config.EmailPassword = strPassword;
            }

            if (needToSave)
                _config.Save();

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
