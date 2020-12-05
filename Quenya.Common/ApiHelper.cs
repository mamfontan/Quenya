using Quenya.Common.interfaces;
using System.Collections.Generic;
using YahooFinance.NET;

namespace Quenya.Common
{
    public class ApiHelper : IApiHelper
    {
        private const string cookie = "3ja26e9f4r12b&b=3&s=5k";

        private const string crumb = "956UGhjyYDf";

        private YahooExchangeHelper _exchangeHelper;

        private string[] _asiaExchanges = new string[] { "ASX", "HKG", "SHA", "SHE", "NSE", "BSE", "JAK", "SEO", "KDQ", "KUL", "NZE", "SIN", "TPE" };

        private string[] _europeExchanges = new string[] { "WBAG", "EBR", "EPA", "BER", "ETR", "FRA", "STU", "ISE", "BIT", "AMS", "OSL", "ELI", "MCE", "VTX", "LON" };

        private string[] _middleEastExchanges = new string[] { "TLV" };
    
        private string[] _northAmericaExchanges = new string[] { "TSE", "CVE", "AMEX", "NASDAQ", "NYSE" };

        public ApiHelper()
        {
            _exchangeHelper = new YahooExchangeHelper();
        }


        public List<string> SearchStockValues(string strFilter)
        {
            var result = new List<string>();

            for (var x1 = 0; x1 < _asiaExchanges.Length; x1++)
                result.Add(_exchangeHelper.GetYahooStockCode(_asiaExchanges[x1], strFilter));

            for (var x2 = 0; x2 < _europeExchanges.Length; x2++)
                result.Add(_exchangeHelper.GetYahooStockCode(_europeExchanges[x2], strFilter));

            for (var x3 = 0; x3 < _northAmericaExchanges.Length; x3++)
                result.Add(_exchangeHelper.GetYahooStockCode(_northAmericaExchanges[x3], strFilter));

            for (var x4 = 0; x4 < _middleEastExchanges.Length; x4++)
                result.Add(_exchangeHelper.GetYahooStockCode(_middleEastExchanges[x4], strFilter));

            YahooFinanceClient yahooFinance = new YahooFinanceClient(cookie, crumb);

            foreach(var code in result)
            {
                List<YahooHistoricalPriceData> yahooPriceHistory = yahooFinance.GetDailyHistoricalPriceData(code);
                List<YahooHistoricalDividendData> yahooDividendHistory = yahooFinance.GetHistoricalDividendData(code);
                //YahooRealTimeData yahooRealTimeData = yahooFinance.GetRealTimeData(code);
            }

            return result;
        }
    }
}
