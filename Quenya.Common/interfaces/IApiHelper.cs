using System;
using System.Collections.Generic;
using System.Text;

namespace Quenya.Common.interfaces
{
    public interface IApiHelper
    {
        List<string> SearchStockValues(string strFilter);
    }
}
