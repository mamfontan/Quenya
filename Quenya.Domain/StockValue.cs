using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quenya.Domain
{
    [Table("Stocks")]
    public class StockValue
    {
        private const string SEPARATOR = " - ";

        [Key, Column("Code"), MaxLength(10)]
        public string Code { get; set; }

        [Column("Name"), MaxLength(75)]
        public string Name { get; set; }

        [Column("Country"), MaxLength(30)]
        public string Country { get; set; }

        [Column("Currency"), MaxLength(30)]
        public string Currency { get; set; }

        public string FullName => Code + SEPARATOR + Name;
    }
}
