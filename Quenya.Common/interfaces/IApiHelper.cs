using Quenya.Domain;
using System.Collections.Generic;

namespace Quenya.Common.interfaces
{
    public interface IApiHelper
    {
        List<StockValue> SearchStockValues(string strFilter);
    }
}
