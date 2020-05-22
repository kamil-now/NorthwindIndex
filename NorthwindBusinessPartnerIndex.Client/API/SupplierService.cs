using NorthwindBusinessPartnerIndex.Contracts.Data.Models;

namespace NorthwindBusinessPartnerIndex.Client.API
{
    public class SupplierService : BaseService<Supplier>
    {
        protected override string Endpoint => "Suppliers";
        public SupplierService()
        {
        }
    }
}
