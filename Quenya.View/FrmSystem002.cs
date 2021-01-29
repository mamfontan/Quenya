using Quenya.Common.interfaces;
using System;
using System.Windows.Forms;
using TinyMessenger;

namespace Quenya.View
{
    public partial class FrmSystem002 : FrmBase
    {
        public FrmSystem002(IDatabaseHelper database, ITinyMessengerHub bus)
        {
            InitializeComponent();

            _database = database;
            _bus = bus;
        }

        private void FrmSystem002_Load(object sender, EventArgs e)
        {

        }

        private void FrmSystem002_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
