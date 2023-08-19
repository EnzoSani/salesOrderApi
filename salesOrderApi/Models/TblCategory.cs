using System.ComponentModel.DataAnnotations.Schema;

namespace salesOrderApi.Models
{
    [Table("tbl_Category")]
    public class TblCategory
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
