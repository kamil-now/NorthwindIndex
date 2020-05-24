using NorthwindBusinessPartnerIndex.Contracts.API;
using NorthwindBusinessPartnerIndex.Contracts.DataContracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NorthwindBusinessPartnerIndex.Client.Services
{
    public class CustomerService : BaseService<ICustomerService, CustomerDto>
    {
        protected override string Address => "http://localhost:8080//Customers";
        public override Task<IList<CustomerDto>> GetAll() => FromService(service => service.GetAllCustomers());
        public override Task<CustomerDto> GetById(int id) => FromService(service => service.GetCustomerById(id));
    }
}
