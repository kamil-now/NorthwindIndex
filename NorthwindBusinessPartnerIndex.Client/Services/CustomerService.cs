using NorthwindBusinessPartnerIndex.Contracts.API;
using NorthwindBusinessPartnerIndex.Contracts.DataContracts;
using System.Collections.Generic;

namespace NorthwindBusinessPartnerIndex.Client.Services
{
    public class CustomerService : BaseService<ICustomerService, CustomerDto>
    {
        protected override string Address => "http://localhost:8080//Customers";
        public override IList<CustomerDto> GetAll() => FromService(service => service.GetAllCustomers());
        public override CustomerDto GetById(int id) => FromService(service => service.GetCustomerById(id));
    }
}
