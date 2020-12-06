using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quenya.Domain
{
    public class StockPrice
    {
        [Key, Column("Code", Order = 1), MaxLength(8)]
        public string Code { get; set; }

        [Key, Column("Date", Order = 2)]
        public DateTime Date { get; set; }

        [Column("PriceHigh")]
        public double Max { get; set; }

        [Column("PriceLow")]
        public double Min { get; set; }

        [Column("PriceOpen")]
        public double Open { get; set; }

        [Column("PriceClose")]
        public double Close { get; set; }

        [Column("Volume")]
        public double Volume { get; set; }
    }
}
