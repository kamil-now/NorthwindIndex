using NorthwindBusinessPartnerIndex.Contracts.API;
using NorthwindBusinessPartnerIndex.Contracts.DataContracts;

namespace NorthwindBusinessPartnerIndex.Client.Services
{
    public class CustomerService : BaseService<ICustomerService, CustomerDto>
    {
        protected override string Endpoint => "Customers";
    }
}
