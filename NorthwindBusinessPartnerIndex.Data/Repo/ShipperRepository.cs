using NorthwindBusinessPartnerIndex.Data.Models;
using System.Data.Entity;
using System.Linq;

namespace NorthwindBusinessPartnerIndex.Data.Repo
{
    public class ShipperRepository : GenericRepository<DbContext, Shipper>, IGenericRepository<Shipper>
    {
        public Shipper Get(int id) => GetAll().FirstOrDefault(x => x.ShipperID == id);
        public override Shipper Get(string id) => GetAll().FirstOrDefault(x => x.ShipperID.ToString() == id);
        public ShipperRepository(DbContext context)
        {
            Context = context;
        }
    }
}
