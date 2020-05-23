using NorthwindBusinessPartnerIndex.Contracts.API;
using NorthwindBusinessPartnerIndex.Contracts.DataContracts;

namespace NorthwindBusinessPartnerIndex.Client.Services
{
    public class SupplierService : BaseService<ISupplierService, SupplierDto>
    {
        protected override string Endpoint => "Suppliers";
    }
}
