using NorthwindBusinessPartnerIndex.Contracts.Data.Models;

namespace NorthwindBusinessPartnerIndex.Client.API
{
    public class CustomerService : BaseService<ICustomer>
    {
        protected override string Endpoint => "Customers";
        public CustomerService()
        {
        }
    }
}
