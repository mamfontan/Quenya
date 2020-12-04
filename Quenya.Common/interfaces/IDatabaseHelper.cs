using Quenya.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quenya.Common.interfaces
{
    public interface IDatabaseHelper
    {
        StatusMessage TestConnection();

        List<StockValue> GetStockValueList();
    }
}
