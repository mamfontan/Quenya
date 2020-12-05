using Newtonsoft.Json;
using Quenya.Common.interfaces;
using Quenya.Common.messages;
using Quenya.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using TinyMessenger;

namespace Quenya.Common
{
    public class ApiHelper : IApiHelper
    {
        private ITinyMessengerHub _bus;

        private const string LIMIT_REACHED = "Thank you for using Alpha Vantage!";

        private string SEARCH_ENDPOINT = "https://www.alphavantage.co/query?function=SYMBOL_SEARCH&keywords=***&apikey=";

        private string COMPANY_OVERVIEW_ENDPOINT = "https://www.alphavantage.co/query?function=OVERVIEW&symbol=***&apikey=";

        private string DAILY_ENDPOINT = "https://www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol=***&apikey=";

        private string PRICE_60M_ENDPOINT = "https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol=***&interval=60min&apikey=";

        private string PRICE_15M_ENDPOINT = "https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol=***&interval=15min&apikey=";

        private string PRICE_05M_ENDPOINT = "https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol=***&interval=5min&apikey=";

        private string PRICE_01M_ENDPOINT = "https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol=***&interval=1min&apikey=";

        private ApiKeyHelper _keyHelper = new ApiKeyHelper();

        public ApiHelper(ITinyMessengerHub bus)
        {
            _bus = bus;
        }

        public List<StockValue> SearchStockValues(string strFilter)
        {
            var result = new List<StockValue>();

            if (!string.IsNullOrEmpty(strFilter))
            {
                var strUrl = SEARCH_ENDPOINT.Replace("***", strFilter) + _keyHelper.GetKey();
                var endPointResult = CallEndPoint(strUrl);

                if (!endPointResult.Contains(LIMIT_REACHED))
                    result = CreateStockValuesFromJson(endPointResult);
                else
                    _bus?.Publish(new MsgReportToUser(this, new StatusMessage() { MsgType = MSG_TYPE.WARNING, MsgText = "Hemos alcanzado el limite de llamadas a la api" }));
            }

            return result;
        }

        public Overview SearchStockOverview(string stockCode)
        {
            var result = new Overview();

            if (!string.IsNullOrEmpty(stockCode))
            {
                var strUrl = COMPANY_OVERVIEW_ENDPOINT.Replace("***", stockCode) + _keyHelper.GetKey();
                var endPointResult = CallEndPoint(strUrl);

                if (!endPointResult.Contains(LIMIT_REACHED))
                {
                    result = CreateStockOverviewFromJson(endPointResult);
                    result.Code = stockCode;
                }
                else
                    _bus?.Publish(new MsgReportToUser(this, new StatusMessage() { MsgType = MSG_TYPE.WARNING, MsgText = "Hemos alcanzado el limite de llamadas a la api" }));
            }

            return result;
        }

        public List<Daily> SearchDailyStock(string stockCode)
        {
            var result = new List<Daily>();

            if (!string.IsNullOrEmpty(stockCode))
            {
                var strUrl = DAILY_ENDPOINT.Replace("***", stockCode) + _keyHelper.GetKey();
                var endPointResult = CallEndPoint(strUrl);

                if (!endPointResult.Contains(LIMIT_REACHED))
                {
                    result = CreateDailyStockValuesFromJson(endPointResult);

                    if (result != null && result.Any())
                        foreach (var item in result)
                            item.Code = stockCode;
                }
                else
                    _bus?.Publish(new MsgReportToUser(this, new StatusMessage() { MsgType = MSG_TYPE.WARNING, MsgText = "Hemos alcanzado el limite de llamadas a la api" }));
            }

            return result;
        }

        public List<StockPrice01M> SearchStockPrice1M(string stockCode)
        {
            var result = new List<StockPrice01M>();

            if (!string.IsNullOrEmpty(stockCode))
            {
                var strUrl = PRICE_01M_ENDPOINT.Replace("***", stockCode) + _keyHelper.GetKey();
                var endPointResult = CallEndPoint(strUrl);

                if (!endPointResult.Contains(LIMIT_REACHED))
                {
                    result = CreateStockValues1MFromJson(endPointResult);

                    if (result != null && result.Any())
                        foreach (var item in result)
                            item.Code = stockCode;

                    _bus?.Publish(new MsgReportToUser(this, new StatusMessage() { MsgType = MSG_TYPE.SUCCESS, MsgText = "Recuperamos cotizacióm de " + stockCode + " (1 min)" }));
                }
                else
                    _bus?.Publish(new MsgReportToUser(this, new StatusMessage() { MsgType = MSG_TYPE.WARNING, MsgText = "Hemos alcanzado el limite de llamadas a la api" }));
            }

            return result;
        }

        public List<StockPrice05M> SearchStockPrice5M(string stockCode)
        {
            var result = new List<StockPrice05M>();

            if (!string.IsNullOrEmpty(stockCode))
            {
                var strUrl = PRICE_05M_ENDPOINT.Replace("***", stockCode) + _keyHelper.GetKey();
                var endPointResult = CallEndPoint(strUrl);

                if (!endPointResult.Contains(LIMIT_REACHED))
                {
                    result = CreateStockValues5MFromJson(endPointResult);

                    if (result != null && result.Any())
                        foreach (var item in result)
                            item.Code = stockCode;

                    _bus?.Publish(new MsgReportToUser(this, new StatusMessage() { MsgType = MSG_TYPE.SUCCESS, MsgText = "Recuperamos cotizacióm de " + stockCode + " (5 min)" }));
                }
                else
                    _bus?.Publish(new MsgReportToUser(this, new StatusMessage() { MsgType = MSG_TYPE.WARNING, MsgText = "Hemos alcanzado el limite de llamadas a la api" }));
            }

            return result;
        }

        public List<StockPrice15M> SearchStockPrice15M(string stockCode)
        {
            var result = new List<StockPrice15M>();

            if (!string.IsNullOrEmpty(stockCode))
            {
                var strUrl = PRICE_15M_ENDPOINT.Replace("***", stockCode) + _keyHelper.GetKey();
                var endPointResult = CallEndPoint(strUrl);

                if (!endPointResult.Contains(LIMIT_REACHED))
                {
                    result = CreateStockValues15MFromJson(endPointResult);

                    if (result != null && result.Any())
                        foreach (var item in result)
                            item.Code = stockCode;

                    _bus?.Publish(new MsgReportToUser(this, new StatusMessage() { MsgType = MSG_TYPE.SUCCESS, MsgText = "Recuperamos cotizacióm de " + stockCode + " (15 min)" }));
                }
                else
                    _bus?.Publish(new MsgReportToUser(this, new StatusMessage() { MsgType = MSG_TYPE.WARNING, MsgText = "Hemos alcanzado el limite de llamadas a la api" }));
            }

            return result;
        }

        public List<StockPrice60M> SearchStockPrice60M(string stockCode)
        {
            var result = new List<StockPrice60M>();

            if (!string.IsNullOrEmpty(stockCode))
            {
                var strUrl = PRICE_60M_ENDPOINT.Replace("***", stockCode) + _keyHelper.GetKey();
                var endPointResult = CallEndPoint(strUrl);

                if (!endPointResult.Contains(LIMIT_REACHED))
                {
                    result = CreateStockValues60MFromJson(endPointResult);

                    if (result != null && result.Any())
                        foreach (var item in result)
                            item.Code = stockCode;

                    _bus?.Publish(new MsgReportToUser(this, new StatusMessage() { MsgType = MSG_TYPE.SUCCESS, MsgText = "Recuperamos cotizacióm de " + stockCode + " (60 min)" }));
                }
                else
                    _bus?.Publish(new MsgReportToUser(this, new StatusMessage() { MsgType = MSG_TYPE.WARNING, MsgText = "Hemos alcanzado el limite de llamadas a la api" }));
            }

            return result;
        }

        private string CallEndPoint(string url)
        {
            var result = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";

            try
            {
                //while (!_timeHelper.AllowRequest()) { }

                WebResponse webResponse = request.GetResponse();
                Stream webStream = webResponse.GetResponseStream();
                StreamReader responseReader = new StreamReader(webStream);
                result = responseReader.ReadToEnd();
                responseReader.Close();
            }
            catch (Exception e)
            {
                // TODO Logguear el error
            }

            return result;
        }

        private List<StockValue> CreateStockValuesFromJson(string data)
        {
            var result = new List<StockValue>();

            var jsonString = data;

            jsonString = jsonString.Substring(21);

            jsonString = jsonString.Replace("1. symbol", "Symbol");
            jsonString = jsonString.Replace("2. name", "Name");
            jsonString = jsonString.Replace("3. type", "Type");
            jsonString = jsonString.Replace("4. region", "Region");
            jsonString = jsonString.Replace("5. marketOpen", "MarketOpen");
            jsonString = jsonString.Replace("6. marketClose", "MarketClose");
            jsonString = jsonString.Replace("7. timezone", "Timezone");
            jsonString = jsonString.Replace("8. currency", "Currency");
            jsonString = jsonString.Replace("9. matchScore", "MatchScore");

            jsonString = jsonString.Substring(0, jsonString.Length - 1);

            try
            {
                var dataConverted = JsonConvert.DeserializeObject<StockSearchResult[]>(jsonString);
                if (dataConverted != null)
                {
                    foreach (var item in dataConverted)
                    {
                        result.Add(new StockValue()
                        {
                            Code = item.Symbol,
                            Name = item.Name,
                            Country = item.Region,
                            Currency = item.Currency,
                            //LastUpdate = null,
                            //Active = true,
                        });
                    }
                }

            }
            catch (Exception error)
            {
                // TODO Log error
                Console.WriteLine(error.Message);
            }

            return result;
        }

        private Overview CreateStockOverviewFromJson(string data)
        {
            var result = new Overview();

            try
            {
                result = JsonConvert.DeserializeObject<Overview>(data);
            }
            catch (Exception error)
            {
                // TODO Log error
                Console.WriteLine(error.Message);
            }

            return result;
        }

        private List<Daily> CreateDailyStockValuesFromJson(string data)
        {
            var result = new List<Daily>();

            var jsonString = data;

            jsonString = jsonString.Replace("Meta Data", "Metadata");
            jsonString = jsonString.Replace("Time Series (Daily)", "Timeseries");

            jsonString = jsonString.Replace("1. open", "Open");
            jsonString = jsonString.Replace("2. high", "High");
            jsonString = jsonString.Replace("3. low", "Low");
            jsonString = jsonString.Replace("4. close", "Close");
            jsonString = jsonString.Replace("5. volume", "Volume");

            jsonString = jsonString.Substring(0, jsonString.Length - 1);

            try
            {
                JsonTextReader reader = new JsonTextReader(new StringReader(jsonString));

                while (reader.Read())
                {
                    if (reader.Value != null)
                    {
                        if (reader.TokenType == JsonToken.PropertyName)
                        {
                            var cad = reader.Value;

                            var regex = @"^\d{4}-\d{2}-\d{2}$";
                            Match match = Regex.Match(reader.Value.ToString(), regex, RegexOptions.IgnoreCase);
                            if (match.Success)
                            {
                                var strDate = reader.Value.ToString();

                                // ATENCION: Vamoa a leer los siguientes registros por orden
                                reader.Read(); reader.Read(); reader.Read();
                                var strOpen = reader.Value.ToString();

                                reader.Read(); reader.Read();
                                var strHigh = reader.Value.ToString();

                                reader.Read(); reader.Read();
                                var strLow = reader.Value.ToString();

                                reader.Read(); reader.Read();
                                var strClose = reader.Value.ToString();

                                reader.Read(); reader.Read();
                                var strVolume = reader.Value.ToString();

                                result.Add(new Daily()
                                {
                                    Date = Convert.ToDateTime(strDate),
                                    Open = Double.Parse(strOpen, CultureInfo.InvariantCulture),
                                    Max = Double.Parse(strHigh, CultureInfo.InvariantCulture),
                                    Min = Double.Parse(strLow, CultureInfo.InvariantCulture),
                                    Close = Double.Parse(strClose, CultureInfo.InvariantCulture),
                                    Volume = Double.Parse(strVolume, CultureInfo.InvariantCulture),
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception error)
            {
                // TODO Log error
                Console.WriteLine(error.Message);
            }

            return result;
        }

        private List<StockPrice01M> CreateStockValues1MFromJson(string data)
        {
            var result = new List<StockPrice01M>();

            var jsonString = data;

            // TODO. Esta linea deberia sobrar. Pendiente de comprobacion
            jsonString = jsonString.Substring(0, jsonString.Length - 1);

            try
            {
                JsonTextReader reader = new JsonTextReader(new StringReader(jsonString));

                while (reader.Read())
                {
                    if (reader.Value != null)
                    {
                        if (reader.TokenType == JsonToken.PropertyName)
                        {
                            var cad = reader.Value;

                            var regex = @"^\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}$";
                            Match match = Regex.Match(reader.Value.ToString(), regex, RegexOptions.IgnoreCase);
                            if (match.Success)
                            {
                                var strDate = reader.Value.ToString();

                                // ATENCION: Vamoa a leer los siguientes registros por orden
                                reader.Read(); reader.Read(); reader.Read();
                                var strOpen = reader.Value.ToString();

                                reader.Read(); reader.Read();
                                var strHigh = reader.Value.ToString();

                                reader.Read(); reader.Read();
                                var strLow = reader.Value.ToString();

                                reader.Read(); reader.Read();
                                var strClose = reader.Value.ToString();

                                reader.Read(); reader.Read();
                                var strVolume = reader.Value.ToString();

                                result.Add(new StockPrice01M()
                                {
                                    Date = Convert.ToDateTime(strDate),
                                    Open = Double.Parse(strOpen, CultureInfo.InvariantCulture),
                                    Max = Double.Parse(strHigh, CultureInfo.InvariantCulture),
                                    Min = Double.Parse(strLow, CultureInfo.InvariantCulture),
                                    Close = Double.Parse(strClose, CultureInfo.InvariantCulture),
                                    Volume = Double.Parse(strVolume, CultureInfo.InvariantCulture),
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception error)
            {
                // TODO Log error
                Console.WriteLine(error.Message);
            }

            return result;
        }

        private List<StockPrice05M> CreateStockValues5MFromJson(string data)
        {
            var result = new List<StockPrice05M>();

            var jsonString = data;

            try
            {
                JsonTextReader reader = new JsonTextReader(new StringReader(jsonString));

                while (reader.Read())
                {
                    if (reader.Value != null)
                    {
                        if (reader.TokenType == JsonToken.PropertyName)
                        {
                            var cad = reader.Value;

                            var regex = @"^\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}$";
                            Match match = Regex.Match(reader.Value.ToString(), regex, RegexOptions.IgnoreCase);
                            if (match.Success)
                            {
                                var strDate = reader.Value.ToString();

                                // ATENCION: Vamoa a leer los siguientes registros por orden
                                reader.Read(); reader.Read(); reader.Read();
                                var strOpen = reader.Value.ToString();

                                reader.Read(); reader.Read();
                                var strHigh = reader.Value.ToString();

                                reader.Read(); reader.Read();
                                var strLow = reader.Value.ToString();

                                reader.Read(); reader.Read();
                                var strClose = reader.Value.ToString();

                                reader.Read(); reader.Read();
                                var strVolume = reader.Value.ToString();

                                result.Add(new StockPrice05M()
                                {
                                    Date = Convert.ToDateTime(strDate),
                                    Open = Double.Parse(strOpen, CultureInfo.InvariantCulture),
                                    Max = Double.Parse(strHigh, CultureInfo.InvariantCulture),
                                    Min = Double.Parse(strLow, CultureInfo.InvariantCulture),
                                    Close = Double.Parse(strClose, CultureInfo.InvariantCulture),
                                    Volume = Double.Parse(strVolume, CultureInfo.InvariantCulture),
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception error)
            {
                // TODO Log error
                Console.WriteLine(error.Message);
            }

            return result;
        }

        private List<StockPrice15M> CreateStockValues15MFromJson(string data)
        {
            var result = new List<StockPrice15M>();

            var jsonString = data;

            try
            {
                JsonTextReader reader = new JsonTextReader(new StringReader(jsonString));

                while (reader.Read())
                {
                    if (reader.Value != null)
                    {
                        if (reader.TokenType == JsonToken.PropertyName)
                        {
                            var cad = reader.Value;

                            var regex = @"^\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}$";
                            Match match = Regex.Match(reader.Value.ToString(), regex, RegexOptions.IgnoreCase);
                            if (match.Success)
                            {
                                var strDate = reader.Value.ToString();

                                // ATENCION: Vamoa a leer los siguientes registros por orden
                                reader.Read(); reader.Read(); reader.Read();
                                var strOpen = reader.Value.ToString();

                                reader.Read(); reader.Read();
                                var strHigh = reader.Value.ToString();

                                reader.Read(); reader.Read();
                                var strLow = reader.Value.ToString();

                                reader.Read(); reader.Read();
                                var strClose = reader.Value.ToString();

                                reader.Read(); reader.Read();
                                var strVolume = reader.Value.ToString();

                                result.Add(new StockPrice15M()
                                {
                                    Date = Convert.ToDateTime(strDate),
                                    Open = Double.Parse(strOpen, CultureInfo.InvariantCulture),
                                    Max = Double.Parse(strHigh, CultureInfo.InvariantCulture),
                                    Min = Double.Parse(strLow, CultureInfo.InvariantCulture),
                                    Close = Double.Parse(strClose, CultureInfo.InvariantCulture),
                                    Volume = Double.Parse(strVolume, CultureInfo.InvariantCulture),
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception error)
            {
                // TODO Log error
                Console.WriteLine(error.Message);
            }

            return result;
        }

        private List<StockPrice60M> CreateStockValues60MFromJson(string data)
        {
            var result = new List<StockPrice60M>();

            var jsonString = data;

            try
            {
                JsonTextReader reader = new JsonTextReader(new StringReader(jsonString));

                while (reader.Read())
                {
                    if (reader.Value != null)
                    {
                        if (reader.TokenType == JsonToken.PropertyName)
                        {
                            var cad = reader.Value;

                            var regex = @"^\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}$";
                            Match match = Regex.Match(reader.Value.ToString(), regex, RegexOptions.IgnoreCase);
                            if (match.Success)
                            {
                                var strDate = reader.Value.ToString();

                                // ATENCION: Vamoa a leer los siguientes registros por orden
                                reader.Read(); reader.Read(); reader.Read();
                                var strOpen = reader.Value.ToString();

                                reader.Read(); reader.Read();
                                var strHigh = reader.Value.ToString();

                                reader.Read(); reader.Read();
                                var strLow = reader.Value.ToString();

                                reader.Read(); reader.Read();
                                var strClose = reader.Value.ToString();

                                reader.Read(); reader.Read();
                                var strVolume = reader.Value.ToString();

                                result.Add(new StockPrice60M()
                                {
                                    Date = Convert.ToDateTime(strDate),
                                    Open = Double.Parse(strOpen, CultureInfo.InvariantCulture),
                                    Max = Double.Parse(strHigh, CultureInfo.InvariantCulture),
                                    Min = Double.Parse(strLow, CultureInfo.InvariantCulture),
                                    Close = Double.Parse(strClose, CultureInfo.InvariantCulture),
                                    Volume = Double.Parse(strVolume, CultureInfo.InvariantCulture),
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception error)
            {
                // TODO Log error
                Console.WriteLine(error.Message);
            }

            return result;
        }


        private class StockSearchResult
        {
            public string Symbol { get; set; }

            public string Name { get; set; }

            public string Type { get; set; }

            public string Region { get; set; }

            public string MarketOpen { get; set; }

            public string MarketClose { get; set; }

            public string Timezone { get; set; }

            public string Currency { get; set; }

            public string MatchScore { get; set; }
        }

        private class StockOverviewResult
        {
            public string Symbol { get; set; }

            public string AssetType { get; set; }

            public string Name { get; set; }

            public string Description { get; set; }

            public string Industry { get; set; }

            public string Sector { get; set; }

            public string Address { get; set; }
        }
    }
}
