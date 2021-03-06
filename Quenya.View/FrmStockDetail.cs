﻿using System;
using System.Windows.Forms;
using System.Collections.Generic;

using Quenya.Common;
using Quenya.Domain;
using Quenya.Common.interfaces;
using System.Drawing;
using System.ComponentModel;

namespace Quenya.View
{
    public partial class FrmStockDetail : FrmBase
    {
        private string _stockCode = string.Empty;

        private IExportHelper _exportHelper = null;

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

            _exportHelper = new ExportHelper(_config.ExportFolder);
        }

        private void FrmStockDetail_Load(object sender, EventArgs e)
        {
            HookButtonEvents(new List<Control>() { btnExport, btnClose, btnRefreshLogo });

            LoadOverviewData();
            LoadLogoData();
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
                ClearData();
                if (_api != null)
                {
                    overview = _api.SearchStockOverview(_stockCode);
                    if (overview != null)
                    {
                        ShowData(overview);
                        _database.InsertStockOverview(overview);
                    }
                }
            }
        }

        private void LoadLogoData()
        {
            if (string.IsNullOrEmpty(_stockCode) || _database == null)
                return;

            var logo = _database.GetLogo(_stockCode);
            if (logo != null)
                ShowLogo(logo);
            else
            {

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

        private void ShowLogo(Logo logo)
        {
            if (logo != null)
            {
                TypeConverter tc = TypeDescriptor.GetConverter(typeof(Bitmap));
                pbLogo.Image = (Bitmap)tc.ConvertFrom(logo.Thumb);
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
            if (string.IsNullOrEmpty(_stockCode) || _exportHelper == null)
                return;

            Cursor = Cursors.WaitCursor;

            var result = _exportHelper.ExportToPdf(_database.GetStockOverviewByCode(_stockCode));

            Cursor = Cursors.Default;

            ShowMessageToUser(result);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRefreshLogo_Click(object sender, EventArgs e)
        {
            if (_api == null)
                return;

            _api.SearchLogo(_stockCode);
        }
    }
}
