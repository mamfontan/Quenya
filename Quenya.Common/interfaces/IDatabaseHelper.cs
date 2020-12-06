using Quenya.Domain;
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

        
    }
}
