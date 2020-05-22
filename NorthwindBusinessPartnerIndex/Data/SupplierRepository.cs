using NorthwindBusinessPartnerIndex.Contracts.Data.Models;
using System.Data.Entity;
using System.Linq;

namespace NorthwindBusinessPartnerIndex.Service.Data
{
    public class SupplierRepository : GenericRepository<DbContext, ISupplier>, IGenericRepository<ISupplier>
    {
        public ISupplier Get(int id) => GetAll().FirstOrDefault(x => x.SupplierId == id);
        public override ISupplier Get(string id) => GetAll().FirstOrDefault(x => x.SupplierId.ToString() == id);
        public SupplierRepository(DbContext context)
        {
            Context = context;
        }
    }
}
