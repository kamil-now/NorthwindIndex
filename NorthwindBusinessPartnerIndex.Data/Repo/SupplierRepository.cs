using NorthwindBusinessPartnerIndex.Contracts.DataContracts;
using NorthwindBusinessPartnerIndex.Data.Models;
using System.Data.Entity;
using System.Linq;

namespace NorthwindBusinessPartnerIndex.Data.Repo
{
    public class SupplierRepository : GenericRepository<DbContext, Supplier>, IGenericRepository<Supplier>
    {
        public Supplier Get(int id) => GetAll().FirstOrDefault(x => x.SupplierID == id);
        public override Supplier Get(string id) => GetAll().FirstOrDefault(x => x.SupplierID.ToString() == id);
        public SupplierRepository(DbContext context)
        {
            Context = context;
        }
    }
}
