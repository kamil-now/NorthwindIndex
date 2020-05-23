using NorthwindBusinessPartnerIndex.Contracts.DataContracts;
using System.Collections.Generic;
using System.ServiceModel;

namespace NorthwindBusinessPartnerIndex.Contracts.API
{
    [ServiceContract]
    public interface ISupplierService : IDataService<SupplierDto>
    {
        [OperationContract]
        IList<SupplierDto> GetAllSuppliers();
        [OperationContract]
        SupplierDto GetSupplierById(int id);
    }
}
