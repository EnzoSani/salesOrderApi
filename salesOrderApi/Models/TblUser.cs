using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace salesOrderApi.Models
{
    [Table("tbl_user")]
    public class TblUser
    {
        [Key]
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string Userid { get; set; } = null!;

        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string? Name { get; set; }
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string? Password { get; set; }
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string? Email { get; set; }
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string? Role { get; set; }
        public bool? IsActive { get; set; }
    }
}
