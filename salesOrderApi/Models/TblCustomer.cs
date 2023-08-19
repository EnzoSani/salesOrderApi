using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace salesOrderApi.Models
{
    [Table("tbl_Customer")]
    public partial class TblCustomer
    {
        [Key]
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Address { get; set; }
        public string? Phoneno { get; set; }
        public string? Email { get; set; }
        public bool? IsActive { get; set; }
        public string? CreateUser { get; set; }
        public string? ModifyUser { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
