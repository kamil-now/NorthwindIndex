using NorthwindBusinessPartnerIndex.Contracts.Data.Models;
using System.Data.Entity;
using System.Linq;

namespace NorthwindBusinessPartnerIndex.Service.Data
{
    public class ShipperRepository : GenericRepository<DbContext, IShipper>, IGenericRepository<IShipper>
    {
        public IShipper Get(int id) => GetAll().FirstOrDefault(x => x.ShipperId == id);
        public override IShipper Get(string id) => GetAll().FirstOrDefault(x => x.ShipperId.ToString() == id);
        public ShipperRepository(DbContext context)
        {
            Context = context;
        }
    }
}
