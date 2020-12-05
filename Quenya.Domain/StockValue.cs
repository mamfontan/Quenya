using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quenya.Domain
{
    [Table("stocks")]
    public class StockValue
    {
        [Key, Column("Code")]
        public string Code { get; set; }

        [Column("Name")]
        public string Name { get; set; }
    }
}
