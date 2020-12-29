using Quenya.Common;
using Quenya.Common.interfaces;
using System;
using System.Windows.Forms;
using TinyMessenger;

namespace Quenya.View
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ITinyMessengerHub _bus = new TinyMessengerHub();
            IConfigurationHelper _config = new ConfigurationHelper();
            IDatabaseHelper _database = new DatabaseHelper(_config.DbHost, _config.DbPort, _config.DbName, _config.DbUser, _config.DbPassword);
            IApiHelper _api = new ApiHelper(_bus);
            IEmailHelper _email = new EmailHelper(_config.EmailSmtpServer, _config.EmailUsername, _config.EmailPassword);

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain(_config, _database, _api, _email, _bus));
        }
    }
}
