﻿using LiveCharts;
using LiveCharts.WinForms;
using LiveCharts.Wpf;
using Quenya.Common.interfaces;
using Quenya.Common.messages;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Media;
using TinyMessenger;
using CartesianChart = LiveCharts.WinForms.CartesianChart;

namespace Quenya.View
{
    public partial class FrmMain : FrmBase
    {
        private List<KeyValuePair<int, string>> _timeRangeList;

        #region Tokens de subrcripcion a eventos
        private TinyMessageSubscriptionToken _tokenMsgUpdateApiUse;
        #endregion


        public FrmMain()
        {
            InitializeComponent();
        }

        public FrmMain(IConfigurationHelper config, IDatabaseHelper database, IApiHelper api, ITinyMessengerHub bus)
        {
            InitializeComponent();

            _config = config;
            _database = database;
            _api = api;
            _bus = bus;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            HookButtonEvents(new List<Control>() { btnAddStockValue, btnDeleteStockValue, btnShowStockValue, btnCommSettings, btnDatabaseSettings, btnGeneralSettings });

            CreateBasicObjects();

            CreateStockValuesTree();
            CreateBasicChart();

            SubscribeToEvents();
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            UnSubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            if (_bus == null)
                return;

            _tokenMsgUpdateApiUse = _bus.Subscribe<MsgUpdateApiUse>((m) => {

                BeginInvoke((Action)(() => {
                    var apiUseLevel = m.Content;
                    lblUsage.Text = apiUseLevel + " / 5";
                }));
            });
        }

        private void UnSubscribeToEvents()
        {
            if (_bus == null)
                return;

            if (_tokenMsgUpdateApiUse != null)
                _bus.Unsubscribe<MsgUpdateApiUse>(_tokenMsgUpdateApiUse);
        }

        private void btnAddStockValue_Click(object sender, EventArgs e)
        {
            var form = new FrmAddStockValue(_config, _database, _api);
            if (form.ShowDialog() == DialogResult.OK)
            {
                var newStockValue = form.SelectedStockValue;
                var result = _database.InsertStockValue(newStockValue);

                if (result.MsgType == Domain.MSG_TYPE.SUCCESS)
                {
                    var overview = _api.SearchStockOverview(newStockValue.Code);
                    if (overview != null)
                        _database.InsertStockOverview(overview);

                    CreateStockValuesTree();
                }
            }
        }

        private void btnInfoStockValue_Click(object sender, EventArgs e)
        {
            if (treeStockValue.SelectedNode == null || treeStockValue.SelectedNode.Tag == null)
                return;

            var selectedStockCode = treeStockValue.SelectedNode.Tag.ToString();
            var form = new FrmStockDetail(selectedStockCode, _config, _database, _api);
            form.ShowDialog();
        }

        private void btnDelStockValue_Click(object sender, EventArgs e)
        {
            if (treeStockValue.SelectedNode == null || treeStockValue.SelectedNode.Tag == null)
                return;

            var selectedStockCode = treeStockValue.SelectedNode.Tag.ToString();
            var result = _database.DeleteStockValue(selectedStockCode);
            if (result.MsgType == Domain.MSG_TYPE.SUCCESS)
                CreateStockValuesTree();
            else
                ShowMessageToUser(result);
        }

        private void CreateBasicObjects()
        {
            _timeRangeList = new List<KeyValuePair<int, string>>()
            {
                new KeyValuePair<int, string>(0, "Daily values"),
                new KeyValuePair<int, string>(1, "1 minute"),
                new KeyValuePair<int, string>(2, "5 minutes"),
                new KeyValuePair<int, string>(3, "15 minutes"),
                new KeyValuePair<int, string>(4, "60 minutes"),
            };

            SetComboBox(cmbTimeRange, _timeRangeList, "Key", "Value");
        }

        private void CreateStockValuesTree()
        {
            treeStockValue.Nodes.Clear();

            TreeNode rootNode = new TreeNode("Stock values");

            var data = _database.GetStockValueList();
            foreach(var item in data)
            {
                TreeNode newNode = new TreeNode(item.FullName);
                newNode.Tag = item.Code;
                newNode.ToolTipText = item.Name + Environment.NewLine + "Country: " + item.Country + Environment.NewLine + "Currency: " + item.Currency;

                rootNode.Nodes.Add(newNode);
            }

            treeStockValue.Nodes.Add(rootNode);
            treeStockValue.ExpandAll();
        }

        private void CreateBasicChart()
        {
            CartesianChart chart = new CartesianChart();

            chart.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Series 1",
                    Values = new ChartValues<double> {4, 6, 5, 2, 7}
                },
                new LineSeries
                {
                    Title = "Series 2",
                    Values = new ChartValues<double> {6, 7, 3, 4, 6},
                    PointGeometry = null
                }
            };

            chart.AxisX.Add(new Axis
            {
                Title = "Month",
                Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May" }
            });

            chart.AxisY.Add(new Axis
            {
                Title = "Sales",
                LabelFormatter = value => value.ToString("C")
            });

            chart.LegendLocation = LegendLocation.Right;

            splitContainer.Panel2.Controls.Add(chart);
            chart.Dock = DockStyle.Fill;
        }

        private void btnGeneralSettings_Click(object sender, EventArgs e)
        {
            var form = new FrmGeneralSettings(_config);
            if (form.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void btnDatabaseSettings_Click(object sender, EventArgs e)
        {
            var form = new FrmDatabaseSettings(_config, _database);
            if (form.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void btnCommSettings_Click(object sender, EventArgs e)
        {
            var form = new FrmCommSettings(_config);
            if (form.ShowDialog() == DialogResult.OK)
            {

            }
        }

        #region Menu Events
        private void menuUpdate01M_Click(object sender, EventArgs e)
        {
            // TODO
        }

        private void menuUpdate05M_Click(object sender, EventArgs e)
        {
            // TODO
        }

        private void menuUpdate15M_Click(object sender, EventArgs e)
        {
            // TODO
        }

        private void menuUpdate60M_Click(object sender, EventArgs e)
        {
            // TODO
        }

        private void menuUpdateDaily_Click(object sender, EventArgs e)
        {
            // TODO
        }
        #endregion
    }
}
