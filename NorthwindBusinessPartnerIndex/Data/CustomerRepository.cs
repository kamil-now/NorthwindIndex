using NorthwindBusinessPartnerIndex.Contracts.Data.Models;
using System.Data.Entity;
using System.Linq;

namespace NorthwindBusinessPartnerIndex.Service.Data
{
    public class CustomerRepository : GenericRepository<DbContext, ICustomer>
    {
        public override ICustomer Get(string id) => GetAll().FirstOrDefault(x => x.CustomerId == id);
        public CustomerRepository(DbContext context)
        {
            Context = context;
        }
    }
}
