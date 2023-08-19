using Microsoft.EntityFrameworkCore;
using salesOrderApi.Models;

namespace salesOrderApi.DataAccess
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public virtual DbSet<TblCategory> TblCategories { get; set; } = null!;
        public virtual DbSet<TblCustomer> TblCustomers { get; set; } = null!;
        public virtual DbSet<TblMastervariant> TblMastervariants { get; set; } = null!;
        public virtual DbSet<TblProduct> TblProducts { get; set; } = null!;
        public virtual DbSet<TblProductvariant> TblProductvarinats { get; set; } = null!;
        public virtual DbSet<TblRole> TblRoles { get; set; } = null!;
        public virtual DbSet<TblSalesHeader> TblSalesHeaders { get; set; } = null!;
        public virtual DbSet<TblSalesProductInfo> TblSalesProductInfos { get; set; } = null!;
        public virtual DbSet<TblUser> TblUsers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblSalesProductInfo>()
                .HasKey(e => new { e.InvoiceNo, e.ProductCode });
        }
    }

   
}
