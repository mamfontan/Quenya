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
        }

        private void btnTestEmail_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
