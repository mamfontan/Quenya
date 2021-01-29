using System;
using System.Windows.Forms;
using TinyMessenger;

using Quenya.Common.interfaces;

namespace Quenya.View
{
    public partial class FrmSystem003 : FrmBase
    {
        public FrmSystem003(IDatabaseHelper database, ITinyMessengerHub bus)
        {
            InitializeComponent();

            _database = database;
            _bus = bus;
        }

        private void FrmSystem003_Load(object sender, EventArgs e)
        {

        }

        private void FrmSystem003_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
