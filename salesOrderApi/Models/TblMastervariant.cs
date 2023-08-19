using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace salesOrderApi.Models
{
    [Table("tbl_mastervariant")]
    public class TblMastervariant
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [MaxLength(20)]
        [Column(TypeName = "nvarchar(20)")]
        public string? VariantName { get; set; }
        [MaxLength(1)]
        [Column(TypeName = "nvarchar(1)")]
        public string? VariantType { get; set; }
        public bool? IsActive { get; set; }
    }
}
