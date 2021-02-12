using System;

namespace Quenya.Domain
{
    public interface IStockPrice
    {
        string Code { get; set; }

        DateTime Date { get; set; }

        double Max { get; set; }

        double Min { get; set; }

        double Open { get; set; }

        double Close { get; set; }

        double Volume { get; set; }

        MOVEMENT Movement { get;  }

        double Percentage { get; }
    }
}
