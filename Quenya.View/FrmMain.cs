using LiveCharts;
using LiveCharts.WinForms;
using LiveCharts.Wpf;
using Quenya.Common.interfaces;
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
            
        }

        private void UnSubscribeToEvents()
        {

        }

        private void btnAddStockValue_Click(object sender, EventArgs e)
        {
            var form = new FrmAddStockValue(_config, _database, _api);
            if (form.ShowDialog() == DialogResult.OK)
            {
                var newStockValue = form.SelectedStockValue;
                var result = _database.InsertStockValue(newStockValue);
                ShowMessageToUser(result);

                if (result.MsgType == Domain.MSG_TYPE.SUCCESS)
                {
                    CreateStockValuesTree();
                }
            }
        }

        private void btnInfoStockValue_Click(object sender, EventArgs e)
        {
            var form = new FrmStockDetail(_config, _database, _api);
            form.ShowDialog();

        }

        private void btnDelStockValue_Click(object sender, EventArgs e)
        {
            if (treeStockValue.SelectedNode == null)
                return;

            var selectedStock = treeStockValue.SelectedNode;
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

                rootNode.Nodes.Add(newNode);
            }

            treeStockValue.Nodes.Add(rootNode);
        }

        private void CreateBasicChart()
        {
            CartesianChart chart = new CartesianChart();

            chart.Series = new SeriesCollection
            {
                new LiveCharts.Wpf.LineSeries
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

            //modifying the series collection will animate and update the chart
            chart.Series.Add(new LineSeries
            {
                Values = new ChartValues<double> { 5, 3, 2, 4, 5 },
                LineSmoothness = 0, //straight lines, 1 really smooth lines
                PointGeometry = Geometry.Parse("m 25 70.36218 20 -28 -20 22 -8 -6 z"),
                PointGeometrySize = 50,
                PointForeground = Brushes.Gray
            });

            //modifying any series values will also animate and update the chart
            chart.Series[2].Values.Add(5d);

            splitContainer.Panel2.Controls.Add(chart);
            chart.Dock = DockStyle.Fill;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

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
    }
}
