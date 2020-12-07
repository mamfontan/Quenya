using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quenya.Domain
{
    public enum MOVEMENT { UP, DOWN, NO_CHANGE}

    public class StockPrice : IStockPrice
    {
        [Key, Column("Code", Order = 1), MaxLength(8)]
        public string Code { get; set; }

        [Key, Column("Date", Order = 2)]
        public DateTime Date { get; set; }

        [Column("Max")]
        public double Max { get; set; }

        [Column("Min")]
        public double Min { get; set; }

        [Column("Open")]
        public double Open { get; set; }

        [Column("Close")]
        public double Close { get; set; }

        [Column("Volume")]
        public double Volume { get; set; }

        public MOVEMENT Movement 
        { 
            get
            {
                if (Open > Close)
                    return MOVEMENT.DOWN;
                else
                    if (Open < Close)
                    return MOVEMENT.UP;
                else
                    return MOVEMENT.NO_CHANGE;

            }
        }
    }
}
