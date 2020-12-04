using Quenya.Common.interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Quenya.View
{
    public partial class FrmBase : Form
    {
        internal IConfigurationHelper _config;

        internal IDatabaseHelper _database;

        public FrmBase()
        {
            InitializeComponent();
        }

        public void HookButtonEvents(List<Control> controls)
        {
            foreach(var ctrl in controls)
            {
                ctrl.MouseEnter += BtnMouseEnter;
                ctrl.MouseLeave += BtnMouseLeave;
            }
        }

        public void SetComboBox(ComboBox cmb, List<KeyValuePair<int, string>> data, string strKey, string strValue)
        {
            cmb.DataSource = data;
            cmb.DisplayMember = strValue;
            cmb.ValueMember = strKey;
        }

        private void BtnMouseEnter(object sender, EventArgs e)
        {
            if (Cursor != Cursors.WaitCursor)
                Cursor = Cursors.Hand;
        }

        private void BtnMouseLeave(object sender, EventArgs e)
        {
            if (Cursor != Cursors.WaitCursor)
                Cursor = Cursors.Default;
        }
    }
}
