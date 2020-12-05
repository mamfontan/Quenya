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
    public partial class FrmAddStockValue : FrmBase
    {
        public FrmAddStockValue()
        {
            InitializeComponent();
        }

        public FrmAddStockValue(IConfigurationHelper config, IDatabaseHelper database, IApiHelper api)
        {
            InitializeComponent();

            _config = config;
            _database = database;
            _api = api;
        }

        private void FrmAddStockValue_Load(object sender, EventArgs e)
        {
            HookButtonEvents(new List<Control>() { btnCancel, btnSave, btnSearch });
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var strFilter = cmbFilter.Text.Trim();

            if (_api == null || string.IsNullOrEmpty(strFilter))
                return;

            // TODO Buscar elemento...
            var data = _api.SearchStockValues(strFilter);
            int x = 99;

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
