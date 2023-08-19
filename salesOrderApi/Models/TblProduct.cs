using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace salesOrderApi.Models
{
    [Table("tbl_product")]
    public class TblProduct
    {
        [Key]
        [MaxLength(20)]
        [Column(TypeName = "varchar(20)")]
        public string Code { get; set; } = null!;
        [MaxLength(250)]
        [Column(TypeName = "varchar(250)")]
        public string? Name { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal? Price { get; set; }
        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public TblCategory Category { get; set; }
        public string? Remarks { get; set; }
    }
}
