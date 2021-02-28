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
            _cnnDatabase = "Server = " + host + "; Port = " + port + "; Database = " + schema + "; Uid = " + user + "; Pwd = " + password + ";";
            _cnnServer = "Server = " + host + "; Port = " + port + "; Database = " + schema + "; Uid = " + user + "; Pwd = " + password + ";";

            _stockContext = new StockContext(_cnnDatabase);
        }

        ~DatabaseHelper()
        {
            _stockContext.Dispose();
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

        public StatusMessage CheckCompatibility()
        {
            if (_stockContext.Database.CompatibleWithModel(false))
                return new StatusMessage(MSG_TYPE.SUCCESS, "La versión de la base de datos es correcta");

            return new StatusMessage(MSG_TYPE.ERROR, "Versión de la base de datos incorrecta");
        }

        public StatusMessage CheckCompatibility(string host, string port, string schema, string user, string password)
        {
            var strCnn = "Server = " + host + "; Port = " + port + "; Database = " + schema + "; Uid = " + user + "; Pwd = " + password + ";";
            var newContext = new StockContext(strCnn);

            StatusMessage result = null;

            try
            {
                if (newContext.Database.CompatibleWithModel(false))
                    result = new StatusMessage(MSG_TYPE.SUCCESS, "La versión de la base de datos es correcta");
            }
            catch(Exception error)
            {
                result = new StatusMessage(MSG_TYPE.ERROR, "Versión de la base de datos incorrecta" + Environment.NewLine + error.Message);
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
                LoggerHelper.LogException(true, error);
            }

            return result;
        }

        public StockValue GetStockValueByCode(string stockCode)
        {
            StockValue result = null;

            try
            {
                result = _stockContext.Stocks.FirstOrDefault(x => x.Code.Equals(stockCode, StringComparison.InvariantCultureIgnoreCase));
            }
            catch (Exception error)
            {
                LoggerHelper.LogException(true, error);
            }

            return result;
        }

        public Overview GetStockOverviewByCode(string stockCode)
        {
            Overview result = null;

            try
            {
                result = _stockContext.Overviews.FirstOrDefault(x => x.Code.Equals(stockCode, StringComparison.InvariantCultureIgnoreCase));
            }
            catch (Exception error)
            {
                LoggerHelper.LogException(true, error);
            }

            return result;
        }

        public List<IStockPrice> GetDailyRatePrices(string stockCode, int? maxResults)
        {
            var result = new List<IStockPrice>();

            try
            {
                if (maxResults == null)
                    result.AddRange(_stockContext.Dailys.Where(x => string.Equals(x.Code, stockCode)).OrderByDescending(x => x.Date).ToList());
                else
                    result.AddRange(_stockContext.Dailys.Where(x => string.Equals(x.Code, stockCode)).OrderByDescending(x => x.Date).Take((int)maxResults).ToList());
            }
            catch (Exception error)
            {
                LoggerHelper.LogException(true, error);
            }

            return result;
        }

        public List<IStockPrice> GetOneMinuteRatePrices(string stockCode, int? maxResults)
        {
            var result = new List<IStockPrice>();

            try
            {
                if (maxResults == null)
                    result.AddRange(_stockContext.OneMinuteValues.Where(x => string.Equals(x.Code, stockCode)).OrderByDescending(x => x.Date).ToList());
                else
                    result.AddRange(_stockContext.OneMinuteValues.Where(x => string.Equals(x.Code, stockCode)).OrderByDescending(x => x.Date).Take((int)maxResults).ToList());
            }
            catch (Exception error)
            {
                LoggerHelper.LogException(true, error);
            }

            return result;
        }

        public List<IStockPrice> GetFiveMinuteRatePrices(string stockCode, int? maxResults)
        {
            var result = new List<IStockPrice>();

            try
            {
                if (maxResults == null)
                    result.AddRange(_stockContext.FiveMinuteValues.Where(x => string.Equals(x.Code, stockCode)).OrderByDescending(x => x.Date).ToList());
                else
                    result.AddRange(_stockContext.FiveMinuteValues.Where(x => string.Equals(x.Code, stockCode)).OrderByDescending(x => x.Date).Take((int)maxResults).ToList());
            }
            catch (Exception error)
            {
                LoggerHelper.LogException(true, error);
            }

            return result;
        }

        public List<IStockPrice> GetFifteenMinuteRatePrices(string stockCode, int? maxResults)
        {
            var result = new List<IStockPrice>();

            try
            {
                if (maxResults == null)
                    result.AddRange(_stockContext.FifteenMinuteValues.Where(x => string.Equals(x.Code, stockCode)).OrderByDescending(x => x.Date).ToList());
                else
                    result.AddRange(_stockContext.FifteenMinuteValues.Where(x => string.Equals(x.Code, stockCode)).OrderByDescending(x => x.Date).Take((int)maxResults).ToList());
            }
            catch (Exception error)
            {
                LoggerHelper.LogException(true, error);
            }

            return result;
        }

        public List<IStockPrice> GetSixtyMinuteRatePrices(string stockCode, int? maxResults)
        {
            var result = new List<IStockPrice>();

            try
            {
                if (maxResults == null)
                    result.AddRange(_stockContext.SixtyMinuteValues.Where(x => string.Equals(x.Code, stockCode)).OrderByDescending(x => x.Date).ToList());
                else
                    result.AddRange(_stockContext.SixtyMinuteValues.Where(x => string.Equals(x.Code, stockCode)).OrderByDescending(x => x.Date).Take((int)maxResults).ToList());
            }
            catch (Exception error)
            {
                LoggerHelper.LogException(true, error);
            }

            return result;
        }

        public StatusMessage InsertStockValue(StockValue data)
        {
            StatusMessage result = new StatusMessage();

            if (_stockContext != null)
            {
                try
                {
                    if (!_stockContext.Stocks.Any(x => x.Code.Equals(data.Code, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        _stockContext.Stocks.Add(data);
                        _stockContext.SaveChanges();

                        result = new StatusMessage(MSG_TYPE.SUCCESS, "Datos insertados correctamente");
                    }
                }
                catch (Exception error)
                {
                    LoggerHelper.LogException(true, error);
                    result = GetErrorMessage(error);
                }
            }

            return result;
        }

        public StatusMessage InsertStockOverview(Overview data)
        {
            StatusMessage result = new StatusMessage();

            if (_stockContext != null)
            {
                try
                {
                    if (!_stockContext.Overviews.Any(x => x.Code.Equals(data.Code, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        _stockContext.Overviews.Add(data);
                        _stockContext.SaveChanges();

                        result = new StatusMessage(MSG_TYPE.SUCCESS, "Datos insertados correctamente");
                    }
                }
                catch (Exception error)
                {
                    LoggerHelper.LogException(true, error);
                    result = GetErrorMessage(error);
                }
            }

            return result;
        }

        public StatusMessage InsertDailyRatePrices(List<StockPriceDaily> data)
        {
            StatusMessage result = new StatusMessage();

            if (_stockContext != null)
            {
                try
                {
                    _stockContext.Dailys.AddRange(data);
                    _stockContext.SaveChanges();

                    result = new StatusMessage(MSG_TYPE.SUCCESS, "Datos insertados correctamente");
                }
                catch (Exception error)
                {
                    LoggerHelper.LogException(true, error);
                    result = GetErrorMessage(error);
                }
            }

            return result;
        }

        public StatusMessage InsertOneMinuteRatePrices(List<StockPrice01M> data)
        {
            StatusMessage result = new StatusMessage();

            if (_stockContext != null)
            {
                try
                {
                    _stockContext.OneMinuteValues.AddRange(data);
                    _stockContext.SaveChanges();

                    result = new StatusMessage(MSG_TYPE.SUCCESS, "Datos insertados correctamente");
                }
                catch (Exception error)
                {
                    LoggerHelper.LogException(true, error);
                    result = GetErrorMessage(error);
                }
            }

            return result;
        }

        public StatusMessage InsertFiveMinuteRatePrices(List<StockPrice05M> data)
        {
            StatusMessage result = new StatusMessage();

            if (_stockContext != null)
            {
                try
                {
                    _stockContext.FiveMinuteValues.AddRange(data);
                    _stockContext.SaveChanges();

                    result = new StatusMessage(MSG_TYPE.SUCCESS, "Datos insertados correctamente");
                }
                catch (Exception error)
                {
                    LoggerHelper.LogException(true, error);
                    result = GetErrorMessage(error);
                }
            }

            return result;
        }

        public StatusMessage InsertFifteenMinuteRatePrices(List<StockPrice15M> data)
        {
            StatusMessage result = new StatusMessage();

            if (_stockContext != null)
            {
                try
                {
                    _stockContext.FifteenMinuteValues.AddRange(data);
                    _stockContext.SaveChanges();

                    result = new StatusMessage(MSG_TYPE.SUCCESS, "Datos insertados correctamente");
                }
                catch (Exception error)
                {
                    LoggerHelper.LogException(true, error);
                    result = GetErrorMessage(error);
                }
            }

            return result;
        }

        public StatusMessage InsertSixtyMinuteRatePrices(List<StockPrice60M> data)
        {
            StatusMessage result = new StatusMessage();

            if (_stockContext != null)
            {
                try
                {
                    _stockContext.SixtyMinuteValues.AddRange(data);
                    _stockContext.SaveChanges();

                    result = new StatusMessage(MSG_TYPE.SUCCESS, "Datos insertados correctamente");
                }
                catch (Exception error)
                {
                    LoggerHelper.LogException(true, error);
                    result = GetErrorMessage(error);
                }
            }

            return result;
        }

        public StatusMessage DeleteStockValue(string stockCode)
        {
            StatusMessage result = new StatusMessage();

            if (_stockContext != null)
            {
                try
                {
                    var savedStock = _stockContext.Stocks.FirstOrDefault(x => x.Code.Equals(stockCode, StringComparison.InvariantCultureIgnoreCase));
                    var savedOverview = _stockContext.Overviews.FirstOrDefault(x => x.Code.Equals(stockCode, StringComparison.InvariantCultureIgnoreCase));
                    var savedPrices01 = _stockContext.OneMinuteValues.Where(x => x.Code.Equals(stockCode, StringComparison.InvariantCultureIgnoreCase));
                    var savedPrices05 = _stockContext.FiveMinuteValues.Where(x => x.Code.Equals(stockCode, StringComparison.InvariantCultureIgnoreCase));
                    var savedPrices15 = _stockContext.FifteenMinuteValues.Where(x => x.Code.Equals(stockCode, StringComparison.InvariantCultureIgnoreCase));
                    var savedPrices60 = _stockContext.SixtyMinuteValues.Where(x => x.Code.Equals(stockCode, StringComparison.InvariantCultureIgnoreCase));
                    var savedDailys = _stockContext.Dailys.Where(x => x.Code.Equals(stockCode, StringComparison.InvariantCultureIgnoreCase));

                    if (savedStock != null)
                        _stockContext.Stocks.Remove(savedStock);

                    if (savedOverview != null)
                        _stockContext.Overviews.Remove(savedOverview);

                    if (savedDailys != null)
                        _stockContext.Dailys.RemoveRange(savedDailys);

                    if (savedPrices01 != null)
                        _stockContext.OneMinuteValues.RemoveRange(savedPrices01);

                    if (savedPrices05 != null)
                        _stockContext.FiveMinuteValues.RemoveRange(savedPrices05);

                    if (savedPrices15 != null)
                        _stockContext.FifteenMinuteValues.RemoveRange(savedPrices15);

                    if (savedPrices60 != null)
                        _stockContext.SixtyMinuteValues.RemoveRange(savedPrices60);

                    _stockContext.SaveChanges();

                    result = new StatusMessage(MSG_TYPE.SUCCESS, "Datos eliminados correctamente");
                }
                catch (Exception error)
                {
                    LoggerHelper.LogException(true, error);
                    result = GetErrorMessage(error);
                }
            }

            return result;
        }

        public DateTime? GetLastUpdateForDailyValues(string stockCode)
        {
            var newestData = _stockContext.Dailys.Where(x => x.Code == stockCode).OrderByDescending(t => t.Date).FirstOrDefault();

            if (newestData == null)
                return null;
            else
                return newestData.Date;
        }

        public DateTime? GetLastUpdateFor01MinValues(string stockCode)
        {
            var newestData = _stockContext.OneMinuteValues.Where(x => x.Code == stockCode).OrderByDescending(t => t.Date).FirstOrDefault();

            if (newestData == null)
                return null;
            else
                return newestData.Date;
        }

        public DateTime? GetLastUpdateFor05MinValues(string stockCode)
        {
            var newestData = _stockContext.FiveMinuteValues.Where(x => x.Code == stockCode).OrderByDescending(t => t.Date).FirstOrDefault();

            if (newestData == null)
                return null;
            else
                return newestData.Date;
        }

        public DateTime? GetLastUpdateFor15MinValues(string stockCode)
        {
            var newestData = _stockContext.FifteenMinuteValues.Where(x => x.Code == stockCode).OrderByDescending(t => t.Date).FirstOrDefault();

            if (newestData == null)
                return null;
            else
                return newestData.Date;
        }

        public DateTime? GetLastUpdateFor60MinValues(string stockCode)
        {
            var newestData = _stockContext.SixtyMinuteValues.Where(x => x.Code == stockCode).OrderByDescending(t => t.Date).FirstOrDefault();

            if (newestData == null)
                return null;
            else
                return newestData.Date;
        }

        private StatusMessage GetErrorMessage(Exception error)
        {
            if (error.InnerException == null)
                return new StatusMessage(MSG_TYPE.ERROR, error.Message);
            else
                return new StatusMessage(MSG_TYPE.ERROR, error.InnerException.Message);
        }
    }
}
