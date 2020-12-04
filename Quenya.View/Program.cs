using Quenya.Common;
using Quenya.Common.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            IConfigurationHelper _config = new ConfigurationHelper();
            IDatabaseHelper _database = new DatabaseHelper(_config.DbHost, _config.DbPort, _config.DbName, _config.DbUser, _config.DbPassword);

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain(_config, _database));
        }
    }
}
