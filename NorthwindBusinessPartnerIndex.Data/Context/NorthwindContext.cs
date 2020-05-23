using NorthwindBusinessPartnerIndex.Data.Models;
using System.Data.Entity;

namespace NorthwindBusinessPartnerIndex.Data
{
    public class NorthwindContext : DbContext
    {
        public NorthwindContext()
            : base("name=NorthwindContext")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Shipper> Shippers { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(e => e.CustomerID)
                .IsFixedLength();
        }
    }
}
