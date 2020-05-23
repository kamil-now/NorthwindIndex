using NorthwindBusinessPartnerIndex.Contracts.API;
using NorthwindBusinessPartnerIndex.Contracts.DataContracts;
using System.Collections.Generic;

namespace NorthwindBusinessPartnerIndex.Client.Services
{
    public class ShipperService : BaseService<IShipperService, ShipperDto>
    {
        protected override string Address => "http://localhost:8080//Shippers";

        public override IList<ShipperDto> GetAll() => FromService(service => service.GetAllShippers());
        public override ShipperDto GetById(int id) => FromService(service => service.GetShipperById(id));
    }
}
