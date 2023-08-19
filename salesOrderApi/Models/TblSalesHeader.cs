using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace salesOrderApi.Models
{
    [Table("tbl_SalesHeader")]
    public class TblSalesHeader
    {
        [Key]
        [MaxLength(20)]
        [Column(TypeName = "nvarchar(20)")]
        public string InvoiceNo { get; set; } = null!;
        [Required]
        [Column(TypeName = "smalldatetime")]
        public DateTime InvoiceDate { get; set; }
        [Required]
        [MaxLength(20)]
        [Column(TypeName = "nvarchar(20)")]
        public string CustomerId { get; set; } = null!;
        [MaxLength(100)]
        [Column("Customer Name", TypeName = "nvarchar(100)")]
        public string? CustomerName { get; set; }
        [Column(TypeName = "ntext")]
        public string? DeliveryAddress { get; set; }
        [Column(TypeName = "ntext")]
        public string? Remarks { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? Total { get; set; }
        [Column(TypeName = "numeric(18, 4)")]
        public decimal? Tax { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? NetTotal { get; set; }
        [MaxLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public string? CreateUser { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? CreateDate { get; set; }
        [MaxLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public string? ModifyUser { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? ModifyDate { get; set; }
    }
}
