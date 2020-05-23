using NorthwindBusinessPartnerIndex.Contracts.DataContracts;
using System.Collections.Generic;
using System.ServiceModel;

namespace NorthwindBusinessPartnerIndex.Contracts.API
{
    [ServiceContract]
    public interface ICustomerService : IDataService<CustomerDto>
    {
        [OperationContract]
        IList<CustomerDto> GetAllCustomers();
        [OperationContract]
        CustomerDto GetCustomerById(int id);
    }
}
