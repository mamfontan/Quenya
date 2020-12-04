using MySql.Data.MySqlClient;
using Quenya.Common.interfaces;
using Quenya.Domain;
using System;
using System.Collections.Generic;

namespace Quenya.Common
{
    public class DatabaseHelper : IDatabaseHelper
    {

        private string _cnnDatabase = string.Empty;

        private string _cnnServer = string.Empty;

        //private StockContext _stockContext;

        public DatabaseHelper(string host, string port, string schema, string user, string password)
        {
            _cnnDatabase = "Server = "+host+"; Port = "+port+"; Database = "+schema+"; Uid = "+user+"; Pwd = "+password+";";
            _cnnServer = "Server = " + host + "; Port = " + port + "; Database = " + schema + "; Uid = " + user + "; Pwd = " + password + ";";

            //_stockContext = new StockContext(_cnnDatabase);
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

        public List<StockValue> GetStockValueList()
        {
            throw new NotImplementedException();
        }
    }
}
