using NorthwindBusinessPartnerIndex.Data.Models;
using System.Data.Entity;

namespace NorthwindBusinessPartnerIndex.Data.Repo
{
    public class ShipperRepository : GenericRepository<DbContext, Shipper>, IGenericRepository<Shipper>
    {
        public ShipperRepository(DbContext context)
        {
            Context = context;
        }
    }
}
