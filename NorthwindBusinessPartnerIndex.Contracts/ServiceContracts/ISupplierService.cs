using NorthwindBusinessPartnerIndex.Contracts.DataContracts;
using System.ServiceModel;

namespace NorthwindBusinessPartnerIndex.Contracts.API
{
    [ServiceContract]
    public interface ISupplierService : IDataService<SupplierDto>
    {
    }
}
