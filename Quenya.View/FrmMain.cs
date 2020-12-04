using Quenya.Common.interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quenya.View
{
    public partial class FrmMain : FrmBase
    {
        private List<KeyValuePair<int, string>> _timeRangeList;

        public FrmMain()
        {
            InitializeComponent();
        }

        public FrmMain(IConfigurationHelper config, IDatabaseHelper database)
        {
            InitializeComponent();

            _config = config;
            _database = database;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            HookButtonEvents(new List<Control>() { btnAddStockValue, btnDeleteStockValue, btnShowStockValue, btnCommSettings, btnDatabaseSettings, btnGeneralSettings });

            CreateBasicObjects();
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void btnAddStockValue_Click(object sender, EventArgs e)
        {
            // TODO
        }

        private void btnInfoStockValue_Click(object sender, EventArgs e)
        {
            // TODO
        }

        private void btnDelStockValue_Click(object sender, EventArgs e)
        {
            // TODO
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

            cmbTimeRange.DataSource = _timeRangeList;
            cmbTimeRange.DisplayMember = "Value";
            cmbTimeRange.ValueMember = "Key";
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
