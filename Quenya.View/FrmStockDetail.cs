using Quenya.Common.interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Quenya.View
{
    public partial class FrmStockDetail : FrmBase
    {
        public FrmStockDetail()
        {
            InitializeComponent();
        }

        public FrmStockDetail(IConfigurationHelper config, IDatabaseHelper database, IApiHelper api)
        {
            InitializeComponent();

            _config = config;
            _database = database;
            _api = api;
        }

        private void FrmStockDetail_Load(object sender, EventArgs e)
        {
            HookButtonEvents(new List<Control>() { btnCancel, btnSave });
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
