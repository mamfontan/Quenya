using Quenya.Common.interfaces;
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
            HookButtonEvents(new List<Control>() { btnCancel, btnSave });

            LoadOverviewData();
        }

        private void LoadOverviewData()
        {
            if (string.IsNullOrEmpty(_stockCode) || _database == null)
                return;

            var overview = _database.GetStockOverviewByCode(_stockCode);
            if (overview != null)
            {
                gbStockValueInfo.Text = " " + overview.Name + "  ";
                lblDescriptionValue.Text = overview.Description;
                lblAddressValue.Text = overview.Address;
            }
            else
            {
                gbStockValueInfo.Text = " No info  ";
                lblDescriptionValue.Text = string.Empty;
                lblAddressValue.Text = string.Empty;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // TODO
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
