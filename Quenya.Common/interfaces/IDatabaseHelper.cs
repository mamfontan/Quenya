using Quenya.Domain;
using System;
using System.Collections.Generic;

namespace Quenya.Common.interfaces
{
    public interface IDatabaseHelper
    {
        StatusMessage TestConnection();

        StatusMessage TestConnection(string dbHost, string dbPort, string dbName, string dbUser, string dbPass);

        StatusMessage CheckCompatibility();

        StatusMessage CheckCompatibility(string dbHost, string dbPort, string dbName, string dbUser, string dbPass);

        List<StockValue> GetStockValueList();

        StockValue GetStockValueByCode(string stockCode);

        Overview GetStockOverviewByCode(string stockCode);

        StatusMessage InsertStockValue(StockValue data);

        StatusMessage InsertStockOverview(Overview data);

        StatusMessage DeleteStockValue(string stockCode);

        List<Daily> GetDailyRatePrices(string selectedStockValueCode);

        List<StockPrice01M> GetOneMinuteRatePrices(string selectedStockValueCode);

        List<StockPrice05M> GetFiveMinuteRatePrices(string selectedStockValueCode);

        List<StockPrice15M> GetFifteenMinuteRatePrices(string selectedStockValueCode);

        List<StockPrice60M> GetSixtyMinuteRatePrices(string selectedStockValueCode);

        StatusMessage InsertDailyRatePrices(List<Daily> data);

        StatusMessage InsertOneMinuteRatePrices(List<StockPrice01M> data);

        StatusMessage InsertFiveMinuteRatePrices(List<StockPrice05M> data);

        StatusMessage InsertFifteenMinuteRatePrices(List<StockPrice15M> data);

        StatusMessage InsertSixtyMinuteRatePrices(List<StockPrice60M> data);

        DateTime? GetLastUpdateForDailyValues(string stockCode);

        DateTime? GetLastUpdateFor01MinValues(string stockCode);

        DateTime? GetLastUpdateFor05MinValues(string stockCode);

        DateTime? GetLastUpdateFor15MinValues(string stockCode);

        DateTime? GetLastUpdateFor60MinValues(string stockCode);
    }
}
