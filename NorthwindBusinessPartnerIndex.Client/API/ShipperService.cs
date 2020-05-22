using NorthwindBusinessPartnerIndex.Contracts.Data.Models;

namespace NorthwindBusinessPartnerIndex.Client.API
{
    public class ShipperService : BaseService<Shipper>
    {
        protected override string Endpoint => "Shippers";
        public ShipperService()
        {
        }
    }
}
