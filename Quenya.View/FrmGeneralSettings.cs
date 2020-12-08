using Quenya.Common.interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Quenya.View
{
    public partial class FrmGeneralSettings : FrmBase
    {
        private List<KeyValuePair<int, string>> _languageList;

        public FrmGeneralSettings()
        {
            InitializeComponent();
        }

        public FrmGeneralSettings(IConfigurationHelper config)
        {
            InitializeComponent();

            _config = config;
        }

        private void FrmGeneralSettings_Load(object sender, EventArgs e)
        {
            HookButtonEvents(new List<Control>() { btnExportFolder, btnCancel, btnSave });

            CreateAndLoadList();
            ShowGeneralSettingsData();
        }

        private void CreateAndLoadList()
        {
            _languageList = new List<KeyValuePair<int, string>>()
            {
                new KeyValuePair<int, string>(0, "Spanish"),
                new KeyValuePair<int, string>(1, "English"),
                new KeyValuePair<int, string>(2, "French"),
            };

            SetComboBox(cmbLanguageList, _languageList, "Key", "Value");
        }

        private void ShowGeneralSettingsData()
        {
            if (_config == null)
                return;

            cmbLanguageList.SelectedValue = (int)_config.Language;
            txtExportFolder.Text = _config.ExportFolder;
        }

        private void btnExportFolder_Click(object sender, EventArgs e)
        {
            using var fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                txtExportFolder.Text = fbd.SelectedPath;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var selectedLanguage = (LANGUAGE)cmbLanguageList.SelectedValue;
            var selectedExportFolder = txtExportFolder.Text.Trim();
            var needToSave = false;

            if (_config.Language != selectedLanguage)
            {
                needToSave = true;
                _config.Language = selectedLanguage;
            }

            if (!string.Equals(_config.ExportFolder, selectedExportFolder))
            {
                needToSave = true;
                _config.ExportFolder = selectedExportFolder;
            }

            if (needToSave)
                _config.Save();

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
