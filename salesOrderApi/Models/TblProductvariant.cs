using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace salesOrderApi.Models
{
    [Table("tbl_productvariant")]
    public class TblProductvariant
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [MaxLength(20)]
        [Column(TypeName = "varchar(20)")]
        public string ProductCode { get; set; } = null!;
        public int? ColorId { get; set; }
        public int? SizeId { get; set; }
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string? Remarks { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Price { get; set; }
        public bool? Isactive { get; set; }
    }
}
