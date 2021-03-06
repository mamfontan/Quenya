﻿using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Wpf;
using Quenya.Common;
using Quenya.Common.interfaces;
using Quenya.Common.messages;
using Quenya.Domain;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Windows.Forms;
using TinyMessenger;
using CartesianChart = LiveCharts.WinForms.CartesianChart;

namespace Quenya.View
{
    public partial class FrmMain : FrmBase
    {
        private const string REQUEST_LIMIT = " / 5";

        private const string OP_NOT_REVERSIBLE = "This operation is not reversible";

        private List<KeyValuePair<int, string>> _timeRangeList;

        private List<KeyValuePair<int, string>> _systemsList;

        private LineSeries _openSerie;

        private LineSeries _closeSerie;

        private LineSeries _averageSerie;

        private LineSeries _volumeSerie;

        #region Tokens de subrcripcion a eventos
        private TinyMessageSubscriptionToken _tokenMsgUpdateApiUse;
        #endregion

        public FrmMain()
        {
            InitializeComponent();
        }

        public FrmMain(IConfigurationHelper config, IDatabaseHelper database, IApiHelper api, IEmailHelper email, ITinyMessengerHub bus)
        {
            InitializeComponent();

            _config = config;
            _database = database;
            _api = api;
            _email = email;
            _bus = bus;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            HookButtonEvents(new List<Control>() { btnAddStockValue, btnDeleteStockValue, btnShowStockValue, btnCommSettings, btnDatabaseSettings, btnGeneralSettings, btnSystemGo });

            HookMenuEvents();

            CreateBasicObjects();

            CreateStockValuesTree();

            SubscribeToEvents();
            PrepareForm();
        }

        private void PrepareForm()
        {
            CreateNoDataChart();
            TranslateToolTips();
            GetMemoryUsage();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("¿Seguro que deseas salir del programa?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                e.Cancel = true;
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

            menuShowHideVolume.Click += menuShowHideVolume_Click;
            menuShowHideOpenValue.Click += menuShowHideOpenValue_Click;
            menuShowHideCloseValue.Click += menuShowHideCloseValue_Click;
        }

        private void SubscribeToEvents()
        {
            if (_bus == null)
                return;

            _tokenMsgUpdateApiUse = _bus.Subscribe<MsgUpdateApiUse>((m) => {

                BeginInvoke((Action)(() => {
                    var apiUseLevel = m.Content;
                    lblUsage.Text = apiUseLevel + REQUEST_LIMIT;
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

                if (result.MsgType == MSG_TYPE.SUCCESS)
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

            var strName = treeStockValue.SelectedNode.Text;

            if (MessageBox.Show("Delete " + strName + "?" + Environment.NewLine +
                OP_NOT_REVERSIBLE, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Cursor = Cursors.WaitCursor;

                var selectedStockCode = treeStockValue.SelectedNode.Tag.ToString();
                var result = _database.DeleteStockValue(selectedStockCode);

                Cursor = Cursors.Default;

                if (result.MsgType == MSG_TYPE.SUCCESS)
                    CreateStockValuesTree();
                else
                    ShowMessageToUser(result);
            }
        }

        private void CreateBasicObjects()
        {
            #region
            _openSerie = new LineSeries();
            _openSerie.Title = "Open";

            _closeSerie = new LineSeries();
            _closeSerie.Title = "Close";

            _averageSerie = new LineSeries();
            _averageSerie.Title = "Average";

            _volumeSerie = new LineSeries();
            _volumeSerie.Title = "Volume";
            #endregion

            _timeRangeList = new List<KeyValuePair<int, string>>()
            {
                new KeyValuePair<int, string>(1, "1 minute"),
                new KeyValuePair<int, string>(2, "5 minutes"),
                new KeyValuePair<int, string>(3, "15 minutes"),
                new KeyValuePair<int, string>(4, "60 minutes"),
                new KeyValuePair<int, string>(0, "Daily values"),
            };

            SetComboBox(cmbTimeRange, _timeRangeList, "Key", "Value", 0);

            _systemsList = new List<KeyValuePair<int, string>>()
            {
                new KeyValuePair<int, string>(0, "Three turtles"),
                new KeyValuePair<int, string>(1, "System 002"),
                new KeyValuePair<int, string>(2, "System 003"),
                new KeyValuePair<int, string>(2, "System 004"),
            };

            SetComboBox(cmbSystem, _systemsList, "Key", "Value", 0);
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

        private void CreateNoDataChart()
        {
            Label noDataSelected = new Label();
            noDataSelected.Text = "No stock value selected";
            noDataSelected.Font = new Font("Arial", 36, FontStyle.Bold);
            noDataSelected.TextAlign = ContentAlignment.MiddleCenter;
            splitContainer.Panel2.Controls.Add(noDataSelected);
            noDataSelected.Dock = DockStyle.Fill;
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
                    List<IStockPrice> dataDaily = _database.GetDailyRatePrices(selectedStockValueCode, 90);
                    dgStockValueData.DataSource = dataDaily;
                    UpdateDailyChart(dataDaily);
                    break;
                case 1: // One minute rate
                    List<IStockPrice> data01M = _database.GetOneMinuteRatePrices(selectedStockValueCode, 8000);
                    dgStockValueData.DataSource = data01M;
                    UpdateChart(data01M);
                    break;
                case 2: // Five minute rate
                    List<IStockPrice> data05M = _database.GetFiveMinuteRatePrices(selectedStockValueCode, 450);
                    dgStockValueData.DataSource = data05M;
                    UpdateChart(data05M);
                    break;
                case 3: // Fifteen minute rate
                    List<IStockPrice> data15M = _database.GetFifteenMinuteRatePrices(selectedStockValueCode, 278);
                    dgStockValueData.DataSource = data15M;
                    UpdateChart(data15M);
                    break;
                case 4: // Sixty minute rate
                    List<IStockPrice> data60M = _database.GetSixtyMinuteRatePrices(selectedStockValueCode, 72);
                    dgStockValueData.DataSource = data60M;
                    UpdateChart(data60M);
                    break;
            }

            ConfigureGridColumns();

            GetMemoryUsage();
        }

        private void ConfigureGridColumns()
        {
            // Modificamos la cabecera
            var font = dgStockValueData.ColumnHeadersDefaultCellStyle.Font;
            var fontBold = new Font(font.FontFamily, font.Size, FontStyle.Bold);
            dgStockValueData.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);

            // Modificamos las celdas
            for (int x = 2; x <= 5; x++)
                dgStockValueData.Columns[x].DefaultCellStyle.Format = "N4";
            dgStockValueData.Columns[8].DefaultCellStyle.Format = "N4";

            dgStockValueData.RowPrePaint += dgEvents_RowPrePaint;
        }

        private void dgEvents_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            double open = Convert.ToDouble(dgStockValueData.Rows[e.RowIndex].Cells[4].Value);
            double close = Convert.ToDouble(dgStockValueData.Rows[e.RowIndex].Cells[5].Value);

            Color color = (open > close) ? Color.Red :
                (close > open) ? Color.Green : Color.Black;

            dgStockValueData.Rows[e.RowIndex].Cells[7].Style.ForeColor = color;
        }

        private void UpdateChart(List<IStockPrice> data)
        {
            splitContainer.Panel2.Controls.Clear();

            if (data != null && data.Any())
            {

                var dayConfig = Mappers.Xy<ChartModel>()
                       .X(dayModel => (double)dayModel.DateTime.Ticks / TimeSpan.FromSeconds(1).Ticks)
                       .Y(dayModel => dayModel.Value);

                CartesianChart chart = new CartesianChart();

                ChartValues<ChartModel> max2 = new ChartValues<ChartModel>();
                ChartValues<ChartModel> min2 = new ChartValues<ChartModel>();
                foreach (var item in data)
                {
                    max2.Add(new ChartModel(item.Date, item.Max));
                    min2.Add(new ChartModel(item.Date, item.Min));
                }

                chart.Series = new SeriesCollection(dayConfig)
                {
                    new LineSeries
                    {
                        Title = "Max",
                        Values = max2,
                    },
                    new LineSeries
                    {
                        Title = "Min",
                        Values = min2,
                    },
                };

                chart.AxisX.Add(new Axis
                {
                    LabelFormatter = DateLabelFormater,
                });

                chart.LegendLocation = LegendLocation.Right;

                splitContainer.Panel2.Controls.Add(chart);
                chart.Dock = DockStyle.Fill;
                chart.Zoom = ZoomingOptions.Xy;
                chart.Pan = PanningOptions.Xy;
            }
        }

        private void UpdateDailyChart(List<IStockPrice> data)
        {
            splitContainer.Panel2.Controls.Clear();

            if (data != null && data.Any())
            {
                var dayConfig = Mappers.Xy<ChartModel>()
                       .X(dayModel => (double)dayModel.DateTime.Ticks / TimeSpan.FromSeconds(1).Ticks)
                       .Y(dayModel => dayModel.Value);

                CartesianChart chart = new CartesianChart();
                ChartValues<ChartModel> average = new ChartValues<ChartModel>();
                ChartValues<ChartModel> volume = new ChartValues<ChartModel>();

                ChartValues<ChartModel> open = new ChartValues<ChartModel>();
                ChartValues<ChartModel> close = new ChartValues<ChartModel>();

                foreach (var item in data)
                {
                    average.Add(new ChartModel(item.Date, item.Min + (item.Max - item.Min) / 2));
                    open.Add(new ChartModel(item.Date, item.Open));
                    close.Add(new ChartModel(item.Date, item.Close));
                    volume.Add(new ChartModel(item.Date, item.Volume));
                }

                _openSerie.Values = open;
                _closeSerie.Values = close;
                _averageSerie.Values = average;
                //_volumeSerie.Values = volume;

                chart.Series = new SeriesCollection(dayConfig)
                {
                    _openSerie, _closeSerie, _averageSerie,
                    //_volumeSerie,
                };

                chart.AxisX.Add(new Axis
                {
                    LabelFormatter = DateLabelFormaterDailyX,
                });

                chart.AxisY.Add(new Axis
                {
                    LabelFormatter = DateLabelFormaterDailyY,
                });

                chart.LegendLocation = LegendLocation.Right;

                splitContainer.Panel2.Controls.Add(chart);
                chart.Dock = DockStyle.Fill;
                chart.Zoom = ZoomingOptions.Xy;
                chart.Pan = PanningOptions.Xy;

                chart.ContextMenuStrip = chartContextMenu;
            }
        }

        private string DateLabelFormaterDailyX(double value)
        {
            DateTime dateTime = new DateTime((long)(value * TimeSpan.FromSeconds(1).Ticks));
            return dateTime.ToString("dd/MM/yy");
        }

        private string DateLabelFormaterDailyY(double value)
        {
            return value.ToString("0.000");
        }

        private string DateLabelFormater(double value)
        {
            DateTime dateTime = new DateTime((long)(value * TimeSpan.FromSeconds(1).Ticks));
            return dateTime.ToString("dd/MM HH:mm:ss");
        }

        #region Menu Events
        private void menuUpdate01M_Click(object sender, EventArgs e)
        {
            // HACK Funcionalidad abandonada temporalmente
            return;

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

        private void menuShowHideVolume_Click(object sender, EventArgs e)
        {
            ShowHideSerie(_averageSerie);
        }

        private void menuShowHideOpenValue_Click(object sender, EventArgs e)
        {
            ShowHideSerie(_openSerie);
        }
        
        private void menuShowHideCloseValue_Click(object sender, EventArgs e)
        {
            ShowHideSerie(_closeSerie);
        }
        #endregion

        private void ShowHideSerie(LineSeries serie)
        {
            if (serie.Visibility == System.Windows.Visibility.Visible)
                serie.Visibility = System.Windows.Visibility.Hidden;
            else
                serie.Visibility = System.Windows.Visibility.Visible;
        }

        #region Systems
        private void btnSystemGo_Click(object sender, EventArgs e)
        {
            if (cmbSystem.SelectedItem != null)
            {
                var selectedSystem = (int)cmbSystem.SelectedValue;
                switch(selectedSystem)
                {
                    case 0:
                        var form01 = new FrmSystem001(_database, _bus);
                        form01.Show();
                        break;
                    case 1:
                        var form02 = new FrmSystem002(_database, _bus);
                        form02.Show();
                        break;
                    case 2:
                        var form03 = new FrmSystem003(_database, _bus);
                        form03.Show();
                        break;
                    default:
                        MessageBox.Show("Not implemented", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }
            }
        }

        #endregion

        private void TranslateToolTips()
        {
            if (_config != null)
            {
                switch (_config.Language)
                {
                    case LANGUAGE.SPANISH:
                        toolTip_EN.Active = false;
                        toolTip_ES.Active = true;
                        break;
                    case LANGUAGE.ENGLISH:
                        toolTip_EN.Active = true;
                        toolTip_ES.Active = false;
                        break;
                    case LANGUAGE.FRENCH:
                        toolTip_EN.Active = false;
                        toolTip_ES.Active = false;
                        break;
                }
            }    
        }

        #region Memory usage
        private void GetMemoryUsage()
        {
            var wmiObject = new ManagementObjectSearcher("select * from Win32_OperatingSystem");

            var memoryValues = wmiObject.Get().Cast<ManagementObject>().Select(mo => new {
                FreePhysicalMemory = Double.Parse(mo["FreePhysicalMemory"].ToString()),
                TotalVisibleMemorySize = Double.Parse(mo["TotalVisibleMemorySize"].ToString())
            }).FirstOrDefault();

            if (memoryValues != null)
            {
                var percent = ((memoryValues.TotalVisibleMemorySize - memoryValues.FreePhysicalMemory) / memoryValues.TotalVisibleMemorySize) * 100;
                BeginInvoke((Action)(() => {
                    lblMemoryCounter.Text = percent.ToString("0.00") + " %";
                }));
            }
        }
        #endregion
    }
}
