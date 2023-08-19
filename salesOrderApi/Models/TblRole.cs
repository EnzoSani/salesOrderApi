using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace salesOrderApi.Models
{
    [Table("tbl_role")]
    public class TblRole
    {
        [Key]
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string Roleid { get; set; } = null!;

        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string? Name { get; set; }
    }
}
