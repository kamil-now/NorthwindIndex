using NorthwindBusinessPartnerIndex.Contracts.Data.Models;
using System.ServiceModel;

namespace NorthwindBusinessPartnerIndex.Contracts.API
{
    [ServiceContract]
    public interface ISupplierService : IDataService<ISupplier>
    {
    }
}
