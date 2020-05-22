using System.Data.Entity;

namespace NorthwindBusinessPartnerIndex.Service.Data.Models
{
    public class Northwind : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
    }
}
