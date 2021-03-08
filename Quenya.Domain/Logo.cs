using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace Quenya.Domain
{
    [Table("Logo")]
    public class Logo
    {
        [Key, Column("Code"), MaxLength(10)]
        public string Code { get; set; }

        [Column("Image")]
        public byte[] Thumb { get; set; }
    }
}
