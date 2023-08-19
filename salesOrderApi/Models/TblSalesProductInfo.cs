using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace salesOrderApi.Models
{
    [Table("tbl_SalesProductInfo")]
    public class TblSalesProductInfo
    {
        
        [MaxLength(20)]
        [Column(TypeName = "nvarchar(20)")]
        public string InvoiceNo { get; set; } = null!;
        [MaxLength(20)]
        [Column(TypeName = "nvarchar(20)")]
        public string ProductCode { get; set; } = null!;
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string? ProductName { get; set; }
        public int? Qty { get; set; }
        [Column(TypeName = "numeric(18, 3)")]
        public decimal? SalesPrice { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? Total { get; set; }
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
