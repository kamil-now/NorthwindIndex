using NorthwindBusinessPartnerIndex.Contracts.DataContracts;
using System.Collections.Generic;
using System.ServiceModel;

namespace NorthwindBusinessPartnerIndex.Contracts.API
{
    [ServiceContract]
    public interface IShipperService : IDataService<ShipperDto>
    {
        [OperationContract]
        IList<ShipperDto> GetAllShippers();
        [OperationContract]
        ShipperDto GetShipperById(int id);
    }
}
