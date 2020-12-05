using MySql.Data.MySqlClient;
using Quenya.Common.interfaces;
using Quenya.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Quenya.Common
{
    public class DatabaseHelper : IDatabaseHelper
    {

        private string _cnnDatabase = string.Empty;

        private string _cnnServer = string.Empty;

        private StockContext _stockContext;

        public DatabaseHelper(string host, string port, string schema, string user, string password)
        {
            _cnnDatabase = "Server = "+host+"; Port = "+port+"; Database = "+schema+"; Uid = "+user+"; Pwd = "+password+";";
            _cnnServer = "Server = " + host + "; Port = " + port + "; Database = " + schema + "; Uid = " + user + "; Pwd = " + password + ";";

            _stockContext = new StockContext(_cnnDatabase);
        }

        public StatusMessage TestConnection()
        {
            var result = new StatusMessage();

            using (MySqlConnection connection = new MySqlConnection(_cnnDatabase))
            {
                try
                {
                    connection.Open();
                    result = new StatusMessage(MSG_TYPE.SUCCESS, "Comunicacion con el servidor correcta");
                }
                catch (MySqlException error)
                {
                    result = new StatusMessage(MSG_TYPE.ERROR, "No se puede acceder al servidor" + Environment.NewLine + error.Message);
                }
            }

            return result;
        }

        public StatusMessage TestConnection(string host, string port, string schema, string user, string password)
        {
            var result = new StatusMessage();
            var strCnn = "Server = " + host + "; Port = " + port + "; Database = " + schema + "; Uid = " + user + "; Pwd = " + password + ";";

            using (MySqlConnection connection = new MySqlConnection(strCnn))
            {
                try
                {
                    connection.Open();
                    result = new StatusMessage(MSG_TYPE.SUCCESS, "Comunicacion con el servidor correcta");
                }
                catch (MySqlException error)
                {
                    result = new StatusMessage(MSG_TYPE.ERROR, "No se puede acceder al servidor" + Environment.NewLine + error.Message);
                }
            }

            return result;
        }

        public List<StockValue> GetStockValueList()
        {
            var result = new List<StockValue>();

            try
            {
                result = _stockContext.Stocks.ToList();
            }
            catch (Exception error)
            {
                // TODO Log the error
                Console.WriteLine(error.Message);
            }

            return result;

        }
    }
}
