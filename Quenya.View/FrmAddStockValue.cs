using Quenya.Common.interfaces;
using Quenya.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Quenya.View
{
    public partial class FrmAddStockValue : FrmBase
    {
        public StockValue SelectedStockValue = null;

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
            if (data != null && data.Any())
            {
                cmbFilter.DataSource = data;
                cmbFilter.DisplayMember = "Code";
                cmbFilter.ValueMember = "Code";
            }
        }

        private void cmbFilter_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbFilter.SelectedItem != null)
            {
                var selectedStockValue = cmbFilter.SelectedItem as StockValue;
                txtStockValueName.Text = selectedStockValue.Name;
                txtCurrency.Text = selectedStockValue.Currency;
                txtCountry.Text = selectedStockValue.Country;
            }
            else
            {
                txtStockValueName.Text = txtCurrency.Text = txtCountry.Text = string.Empty;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbFilter.SelectedItem == null)
                return;

            SelectedStockValue = cmbFilter.SelectedItem as StockValue;
            DialogResult = DialogResult.OK;

            Close();
        }
    }
}
