using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quenya.Domain
{
    [Table("Stocks")]
    public class StockValue
    {
        private const string SEPARATOR = " - ";

        [Key, Column("Code"), MaxLength(8)]
        public string Code { get; set; }

        [Column("Name"), MaxLength(30)]
        public string Name { get; set; }

        [Column("Country")]
        public string Country { get; set; }

        [Column("Currency")]
        public string Currency { get; set; }

        public string FullName => Code + SEPARATOR + Name;
    }
}
