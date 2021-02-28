using Quenya.Common;
using Quenya.Common.interfaces;
using Quenya.Domain;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TinyMessenger;

namespace Quenya.View
{
    public partial class FrmBase : Form
    {
        internal IConfigurationHelper _config;

        internal IDatabaseHelper _database;

        internal IApiHelper _api;

        internal IEmailHelper _email;

        internal ITinyMessengerHub _bus;

        internal ILoggerHelper _log;

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

        public void ShowMessageToUser(StatusMessage msg)
        {
            Cursor = Cursors.Default;

            MessageBoxIcon icon = ChooseIcon(msg.MsgType);

            MessageBox.Show(msg.MsgText, msg.MsgType.ToString(), MessageBoxButtons.OK, icon);
        }

        private MessageBoxIcon ChooseIcon(MSG_TYPE iconType)
        {
            var result = MessageBoxIcon.Exclamation;

            switch (iconType)
            {
                case MSG_TYPE.INFORMATION:
                    result = MessageBoxIcon.Information;
                    break;
                case MSG_TYPE.SUCCESS:
                    result = MessageBoxIcon.Information;
                    break;
                case MSG_TYPE.WARNING:
                    result = MessageBoxIcon.Warning;
                    break;
                case MSG_TYPE.ERROR:
                    result = MessageBoxIcon.Error;
                    break;
            }

            return result;
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

        private void Translate()
        {
            if (_config == null)
                return;

            switch(_config.Language)
            {
                case LANGUAGE.SPANISH:
                    break;
                case LANGUAGE.ENGLISH:
                    break;
                case LANGUAGE.FRENCH:
                    break;
            }
        }
    }
}
