using Quenya.Common.interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Quenya.View
{
    public partial class FrmGeneralSettings : FrmBase
    {
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
            HookButtonEvents(new List<Control>() { btnCancel, btnSave });
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
