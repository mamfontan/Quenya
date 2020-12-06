using Quenya.Common.interfaces;
using Quenya.Domain;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Quenya.View
{
    public partial class FrmStockDetail : FrmBase
    {
        private string _stockCode = string.Empty;

        public FrmStockDetail()
        {
            InitializeComponent();
        }

        public FrmStockDetail(string stockCode, IConfigurationHelper config, IDatabaseHelper database, IApiHelper api)
        {
            InitializeComponent();

            _stockCode = stockCode;

            _config = config;
            _database = database;
            _api = api;
        }

        private void FrmStockDetail_Load(object sender, EventArgs e)
        {
            HookButtonEvents(new List<Control>() { btnExport, btnClose });

            LoadOverviewData();
        }

        private void LoadOverviewData()
        {
            if (string.IsNullOrEmpty(_stockCode) || _database == null)
                return;

            var overview = _database.GetStockOverviewByCode(_stockCode);
            if (overview != null)
                ShowData(overview);
            else
            {
                if (_api != null)
                {
                    overview = _api.SearchStockOverview(_stockCode);
                    if (overview != null) {
                        ShowData(overview);
                        _database.InsertStockOverview(overview);
                    }
                    else
                        ClearData();
                }
                else
                    ClearData();
            }
        }

        private void ShowData(Overview data)
        {
            if (data != null)
            {
                gbStockValueInfo.Text = " " + data.Name + "  ";
                lblDescriptionValue.Text = data.Description;
                lblAssetTypeValue.Text = data.AssetType;
                lblExchangeValue.Text = data.Exchange;
                lblCurrencyValue.Text = data.Currency;
                lblCountryValue.Text = data.Country;
                lblSectorValue.Text = data.Sector;
                lblIndustryValue.Text = data.Industry;
                lblEmployeesValue.Text = data.FullTimeEmployees;
                lblAddressValue.Text = data.Address;
            }
        }

        private void ClearData()
        {
            gbStockValueInfo.Text = " No info  ";
            lblDescriptionValue.Text = string.Empty;
            lblAssetTypeValue.Text = string.Empty;
            lblExchangeValue.Text = string.Empty;
            lblCurrencyValue.Text = string.Empty;
            lblCountryValue.Text = string.Empty;
            lblSectorValue.Text = string.Empty;
            lblIndustryValue.Text = string.Empty;
            lblEmployeesValue.Text = string.Empty;
            lblAddressValue.Text = string.Empty;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
