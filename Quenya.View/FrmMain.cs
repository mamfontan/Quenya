using LiveCharts;
using LiveCharts.Wpf;
using Quenya.Common.interfaces;
using Quenya.Common.messages;
using Quenya.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TinyMessenger;
using CartesianChart = LiveCharts.WinForms.CartesianChart;

namespace Quenya.View
{
    public partial class FrmMain : FrmBase
    {
        private List<KeyValuePair<int, string>> _timeRangeList;

        private List<KeyValuePair<int, string>> _systemsList;

        #region Tokens de subrcripcion a eventos
        private TinyMessageSubscriptionToken _tokenMsgUpdateApiUse;
        #endregion

        public FrmMain()
        {
            InitializeComponent();
        }

        public FrmMain(IConfigurationHelper config, IDatabaseHelper database, IApiHelper api, ILoggerHelper log, ITinyMessengerHub bus)
        {
            InitializeComponent();

            _config = config;
            _database = database;
            _api = api;
            _bus = bus;
            _log = log;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            HookButtonEvents(new List<Control>() { btnAddStockValue, btnDeleteStockValue, btnShowStockValue, btnCommSettings, btnDatabaseSettings, btnGeneralSettings, btnSystemGo });

            HookMenuEvents();

            CreateBasicObjects();

            CreateStockValuesTree();
            CreateBasicChart();

            SubscribeToEvents();
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            UnSubscribeToEvents();
        }

        // HACK El diseñador no enlaza bien los eventos del menu contextual, asi que los lanzamos por codigo
        private void HookMenuEvents()
        {
            menuUpdateDaily.Click += menuUpdateDaily_Click;

            menuUpdate01M.Click += menuUpdate01M_Click;
            menuUpdate05M.Click += menuUpdate05M_Click;
            menuUpdate15M.Click += menuUpdate15M_Click;
            menuUpdate60M.Click += menuUpdate60M_Click;
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

            _systemsList = new List<KeyValuePair<int, string>>()
            {
                new KeyValuePair<int, string>(0, "Three turtles"),
                new KeyValuePair<int, string>(1, "Unknow method"),
                new KeyValuePair<int, string>(2, "Unknow method"),
            };

            SetComboBox(cmbSystem, _systemsList, "Key", "Value");
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

        private void cmbTimeRange_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbTimeRange.SelectedItem == null || treeStockValue.SelectedNode == null || treeStockValue.SelectedNode.Tag == null)
                return;

            UpdateSelectedDataAndChart();
        }

        private void treeStockValue_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (cmbTimeRange.SelectedItem == null || treeStockValue.SelectedNode == null || treeStockValue.SelectedNode.Tag == null)
                return;

            UpdateSelectedDataAndChart();
        }

        private void UpdateSelectedDataAndChart()
        {
            var selectedTimeRange = cmbTimeRange.SelectedValue;
            var selectedStockValueCode = treeStockValue.SelectedNode.Tag.ToString();

            List<IStockPrice> data = new List<IStockPrice>();

            // Update datagrid
            switch (selectedTimeRange)
            {
                case 0: // Daily values
                    List<IStockPrice> dataDaily = _database.GetDailyRatePrices(selectedStockValueCode);
                    dgStockValueData.DataSource = dataDaily;
                    UpdateChart(dataDaily);
                    break;
                case 1: // One minute rate
                    List<IStockPrice> data01M = _database.GetOneMinuteRatePrices(selectedStockValueCode);
                    dgStockValueData.DataSource = data01M;
                    UpdateChart(data01M);
                    break;
                case 2: // Five minute rate
                    List<IStockPrice> data05M = _database.GetFiveMinuteRatePrices(selectedStockValueCode);
                    dgStockValueData.DataSource = data05M;
                    UpdateChart(data05M);
                    break;
                case 3: // Fifteen minute rate
                    List<IStockPrice> data15M = _database.GetFifteenMinuteRatePrices(selectedStockValueCode);
                    dgStockValueData.DataSource = data15M;
                    UpdateChart(data15M);
                    break;
                case 4: // Sixty minute rate
                    List<IStockPrice> data60M = _database.GetSixtyMinuteRatePrices(selectedStockValueCode);
                    dgStockValueData.DataSource = data60M;
                    UpdateChart(data60M);
                    break;
            }
        }

        private void UpdateChart(List<IStockPrice> data)
        {
            splitContainer.Panel2.Controls.Clear();

            if (data != null && data.Any())
            {

                CartesianChart chart = new CartesianChart();

                ChartValues<double> max = new ChartValues<double>();
                ChartValues<double> min = new ChartValues<double>();
                foreach (var item in data)
                {
                    max.Add(item.Max);
                    min.Add(item.Min);
                }

                chart.Series = new SeriesCollection
                {
                    new LineSeries
                    {
                        Title = "Max",
                        Values = max,
                    },
                    new LineSeries
                    {
                        Title = "Min",
                        Values = min,
                    },
                };

                chart.AxisX.Add(new Axis
                {
                    Title = data[0].Code,
                    Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May" }
                });

                chart.AxisY.Add(new Axis
                {
                    Title = "Values",
                    LabelFormatter = value => value.ToString("C")
                });

                chart.LegendLocation = LegendLocation.Right;

                
                splitContainer.Panel2.Controls.Add(chart);
                chart.Dock = DockStyle.Fill;
            }
        }

        #region Menu Events
        private void menuUpdate01M_Click(object sender, EventArgs e)
        {
            if (_api == null || _database == null || treeStockValue.SelectedNode == null || treeStockValue.SelectedNode.Tag == null)
                return;

            Cursor = Cursors.WaitCursor;

            var selectedStockValueCode = treeStockValue.SelectedNode.Tag.ToString();
            var data = _api.SearchStockPrice01M(selectedStockValueCode);
            if (data != null && data.Any())
            {
                var lastDate = _database.GetLastUpdateFor01MinValues(selectedStockValueCode);
                if (lastDate != null)
                    data = data.Where(x => x.Date > lastDate).ToList();

                if (data.Any())
                {
                    var result = _database.InsertOneMinuteRatePrices(data);
                    if (result.MsgType != MSG_TYPE.SUCCESS)
                    {
                        Cursor = Cursors.Default;
                        ShowMessageToUser(result);
                    }

                    // Si estamos viendo los valores de 5 minutos hora, es necesario refrescar la pantalla
                    if ((int)cmbTimeRange.SelectedValue == 2)
                        UpdateSelectedDataAndChart();
                }
            }

            Cursor = Cursors.Default;
        }

        private void menuUpdate05M_Click(object sender, EventArgs e)
        {
            if (_api == null || _database == null || treeStockValue.SelectedNode == null || treeStockValue.SelectedNode.Tag == null)
                return;

            Cursor = Cursors.WaitCursor;

            var selectedStockValueCode = treeStockValue.SelectedNode.Tag.ToString();
            var data = _api.SearchStockPrice05M(selectedStockValueCode);
            if (data != null && data.Any())
            {
                var lastDate = _database.GetLastUpdateFor05MinValues(selectedStockValueCode);
                if (lastDate != null)
                    data = data.Where(x => x.Date > lastDate).ToList();

                if (data.Any())
                {
                    var result = _database.InsertFiveMinuteRatePrices(data);
                    if (result.MsgType != MSG_TYPE.SUCCESS)
                    {
                        Cursor = Cursors.Default;
                        ShowMessageToUser(result);
                    }

                    // Si estamos viendo los valores de 5 minutos hora, es necesario refrescar la pantalla
                    if ((int)cmbTimeRange.SelectedValue == 2)
                        UpdateSelectedDataAndChart();
                }
            }

            Cursor = Cursors.Default;
        }

        private void menuUpdate15M_Click(object sender, EventArgs e)
        {
            if (_api == null || _database == null || treeStockValue.SelectedNode == null || treeStockValue.SelectedNode.Tag == null)
                return;

            Cursor = Cursors.WaitCursor;

            var selectedStockValueCode = treeStockValue.SelectedNode.Tag.ToString();
            var data = _api.SearchStockPrice15M(selectedStockValueCode);
            if (data != null && data.Any())
            {
                var lastDate = _database.GetLastUpdateFor15MinValues(selectedStockValueCode);
                if (lastDate != null)
                    data = data.Where(x => x.Date > lastDate).ToList();

                if (data.Any())
                {
                    var result = _database.InsertFifteenMinuteRatePrices(data);
                    if (result.MsgType != MSG_TYPE.SUCCESS)
                    {
                        Cursor = Cursors.Default;
                        ShowMessageToUser(result);
                    }

                    // Si estamos viendo los valores de 15 minutos hora, es necesario refrescar la pantalla
                    if ((int)cmbTimeRange.SelectedValue == 3)
                        UpdateSelectedDataAndChart();
                }
            }

            Cursor = Cursors.Default;
        }

        private void menuUpdate60M_Click(object sender, EventArgs e)
        {
            if (_api == null || _database == null || treeStockValue.SelectedNode == null || treeStockValue.SelectedNode.Tag == null)
                return;

            Cursor = Cursors.WaitCursor;

            var selectedStockValueCode = treeStockValue.SelectedNode.Tag.ToString();
            var data = _api.SearchStockPrice60M(selectedStockValueCode);
            if (data != null && data.Any())
            {
                var lastDate = _database.GetLastUpdateFor60MinValues(selectedStockValueCode);
                if (lastDate != null)
                    data = data.Where(x => x.Date > lastDate).ToList();

                if (data.Any())
                {
                    var result = _database.InsertSixtyMinuteRatePrices(data);
                    if (result.MsgType != MSG_TYPE.SUCCESS)
                    {
                        Cursor = Cursors.Default;
                        ShowMessageToUser(result);
                    }

                    // Si estamos viendo los valores de 1 hora, es necesario refrescar la pantalla
                    if ((int)cmbTimeRange.SelectedValue == 4)
                        UpdateSelectedDataAndChart();
                }
            }

            Cursor = Cursors.Default;
        }

        private void menuUpdateDaily_Click(object sender, EventArgs e)
        {
            if (_api == null || _database == null || treeStockValue.SelectedNode == null || treeStockValue.SelectedNode.Tag == null)
                return;

            Cursor = Cursors.WaitCursor;

            var selectedStockValueCode = treeStockValue.SelectedNode.Tag.ToString();
            var data = _api.SearchDailyStock(selectedStockValueCode);
            if (data != null && data.Any())
            {
                var lastDate = _database.GetLastUpdateForDailyValues(selectedStockValueCode);
                if (lastDate != null)
                    data = data.Where(x => x.Date > lastDate).ToList();

                if (data.Any())
                {
                    var result = _database.InsertDailyRatePrices(data);
                    if (result.MsgType != MSG_TYPE.SUCCESS)
                    {
                        Cursor = Cursors.Default;
                        ShowMessageToUser(result);
                    }

                    // Si estamos viendo los valores diarios, es necesario refrescar la pantalla
                    if ((int)cmbTimeRange.SelectedValue == 0)
                        UpdateSelectedDataAndChart();
                }
            }

            Cursor = Cursors.Default;

        }
        #endregion

        #region Systems
        private void btnSystemGo_Click(object sender, EventArgs e)
        {
            if (cmbSystem.SelectedItem != null)
            {
                var selectedSystem = (int)cmbSystem.SelectedValue;
                switch(selectedSystem)
                {
                    case 0:
                        var form = new FrmSystem001(_database, _bus);
                        form.Show();
                        break;
                    default:
                        MessageBox.Show("Not implemented", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }
            }
        }
        #endregion
    }
}
