using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quenya.Domain
{
    [Table("Overview")]
    public class Overview
    {
        [Key, Column("Code")]
        public string Code { get; set; }

        [Column("AssetType")]
        public string AssetType { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Description")]
        public string Description { get; set; }

        [Column("Exchange")]
        public string Exchange { get; set; }

        [Column("Currency")]
        public string Currency { get; set; }

        [Column("Country")]
        public string Country { get; set; }

        [Column("Sector")]
        public string Sector { get; set; }

        [Column("Industry")]
        public string Industry { get; set; }

        [Column("Address")]
        public string Address { get; set; }

        [Column("FullTimeEmployees")]
        public string FullTimeEmployees { get; set; }
    }
}
