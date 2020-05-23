using NorthwindBusinessPartnerIndex.Data.Models;
using System.Data.Entity;

namespace NorthwindBusinessPartnerIndex.Data.Repo
{
    public class SupplierRepository : GenericRepository<DbContext, Supplier>, IGenericRepository<Supplier>
    {
        public SupplierRepository(DbContext context)
        {
            Context = context;
        }
    }
}
