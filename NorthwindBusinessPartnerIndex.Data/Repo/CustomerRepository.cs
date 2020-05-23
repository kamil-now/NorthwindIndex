using NorthwindBusinessPartnerIndex.Data.Models;
using System.Data.Entity;

namespace NorthwindBusinessPartnerIndex.Data.Repo
{
    public class CustomerRepository : GenericRepository<DbContext, Customer>
    {
        public CustomerRepository(DbContext context)
        {
            Context = context;
        }
    }
}
