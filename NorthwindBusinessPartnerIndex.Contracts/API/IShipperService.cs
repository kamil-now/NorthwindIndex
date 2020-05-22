using NorthwindBusinessPartnerIndex.Contracts.Data.Models;
using System.ServiceModel;

namespace NorthwindBusinessPartnerIndex.Contracts.API
{
    [ServiceContract]
    public interface IShipperService : IDataService<IShipper>
    {
    }
}
