using System;
using System.Collections.Generic;
using System.Text;

namespace Quenya.View
{
    public class ChartModel
    {
        public DateTime DateTime { get; set; }
        public double Value { get; set; }

        public ChartModel(DateTime dateTime, double value)
        {
            this.DateTime = dateTime;
            this.Value = value;
        }
    }
}
