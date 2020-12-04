﻿using Quenya.Common.interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Quenya.View
{
    public partial class FrmDatabaseSettings : FrmBase
    {
        private List<KeyValuePair<int, string>> _actionList;

        public FrmDatabaseSettings()
        {
            InitializeComponent();
        }

        public FrmDatabaseSettings(IConfigurationHelper config)
        {
            InitializeComponent();

            _config = config;
        }

        private void FrmDatabaseSettings_Load(object sender, EventArgs e)
        {
            HookButtonEvents(new List<Control>() { btnCancel, btnSave, btnActionGo });

            CreateAndLoadList();
            ShowDatabaseSettingsData();
        }

        private void CreateAndLoadList()
        {
            _actionList = new List<KeyValuePair<int, string>>()
            {
                new KeyValuePair<int, string>(0, "Check connection"),
                new KeyValuePair<int, string>(100, "Destroy the computer"),
            };

            SetComboBox(cmbActionList, _actionList, "Key", "Value");
        }

        private void ShowDatabaseSettingsData()
        {
            if (_config == null)
                return;

            txtDbHost.Text = _config.DbHost;
            txtDbName.Text = _config.DbName;
            txtDbUser.Text = _config.DbUser;
            txtDbPassword.Text = _config.DbPassword;
            npDbPort.Value = Convert.ToInt32(_config.DbPort);
        }

        private void btnActionGo_Click(object sender, EventArgs e)
        {
            var selectedAction = (int)cmbActionList.SelectedValue;

            switch(selectedAction)
            {
                case 0:
                    MessageBox.Show("Not implemented", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case 100:
                    MessageBox.Show("Not implemented", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var strDbHost = txtDbHost.Text.Trim();
            var strDbName = txtDbName.Text.Trim();
            var strDbUser = txtDbUser.Text.Trim();
            var strDbPass = txtDbPassword.Text.Trim();
            var strDbPort = npDbPort.Value.ToString();

            var needToSave = false;

            if (!string.Equals(_config.DbHost, strDbHost))
            {
                needToSave = true;
                _config.DbHost = strDbHost;
            }

            if (!string.Equals(_config.DbPort, strDbPort))
            {
                needToSave = true;
                _config.DbPort = strDbPort;
            }

            if (!string.Equals(_config.DbName, strDbName))
            {
                needToSave = true;
                _config.DbName = strDbName;
            }

            if (!string.Equals(_config.DbUser, strDbUser))
            {
                needToSave = true;
                _config.DbUser = strDbUser;
            }

            if (!string.Equals(_config.DbPassword, strDbPass))
            {
                needToSave = true;
                _config.DbPassword = strDbPass;
            }

            if (needToSave)
                _config.Save();

            Close();
        }
    }
}
