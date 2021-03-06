﻿using Quenya.Domain;
using System.Collections.Generic;
using System.Drawing;

namespace Quenya.Common.interfaces
{
    public interface IApiHelper
    {
        List<StockValue> SearchStockValues(string strFilter);

        Overview SearchStockOverview(string stockCode);

        List<StockPriceDaily> SearchDailyStock(string stockCode);

        List<StockPrice01M> SearchStockPrice01M(string stockCode);

        List<StockPrice05M> SearchStockPrice05M(string stockCode);

        List<StockPrice15M> SearchStockPrice15M(string stockCode);

        List<StockPrice60M> SearchStockPrice60M(string stockCode);

        Bitmap SearchLogo(string stockCode);
    }
}
