using Quenya.Common.interfaces;
using Quenya.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TinyMessenger;

namespace Quenya.View
{
    public partial class FrmSystem001 : FrmBase
    {
        public FrmSystem001()
        {
            InitializeComponent();
        }

        public FrmSystem001(IDatabaseHelper database, ITinyMessengerHub bus)
        {
            InitializeComponent();

            _database = database;
            _bus = bus;
        }

        private void FrmSystem001_Load(object sender, EventArgs e)
        {
            HookButtonEvents(new List<Control>() { btnPlay, btnClose });
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            // TODO
            var stocks = _database.GetStockValueList();
            if (stocks != null && stocks.Any())
            {
                foreach (var stock in stocks)
                    ProcessStockValue(stock);
            }
        }

        private void ProcessStockValue(StockValue stock)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
