using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quenya.Domain
{
    [Table("Daily")]
    public class Daily
    {
        [Key, Column("Code", Order = 1), MaxLength(8)]
        public string Code { get; set; }

        [Key, Column("Date", Order = 2)]
        public DateTime Date { get; set; }

        [Column("Max")]
        public double Max { get; set; }

        [Column("Min")]
        public double Min { get; set; }

        [Column("OpenValue")]
        public double Open { get; set; }

        [Column("CloseValue")]
        public double Close { get; set; }

        [Column("Volume")]
        public double Volume { get; set; }
    }
}
