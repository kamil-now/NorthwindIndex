using NorthwindBusinessPartnerIndex.Data.Models;
using System.Data.Entity;
using System.Linq;

namespace NorthwindBusinessPartnerIndex.Data.Repo
{
    public class CustomerRepository : GenericRepository<DbContext, Customer>
    {
        public override Customer Get(string id) => GetAll().FirstOrDefault(x => x.CustomerID == id);
        public CustomerRepository(DbContext context)
        {
            Context = context;
        }
    }
}
