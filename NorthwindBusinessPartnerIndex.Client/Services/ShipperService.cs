using NorthwindBusinessPartnerIndex.Contracts.API;
using NorthwindBusinessPartnerIndex.Contracts.DataContracts;

namespace NorthwindBusinessPartnerIndex.Client.Services
{
    public class ShipperService : BaseService<IShipperService, ShipperDto>
    {
        protected override string Endpoint => "Shippers";
    }
}
