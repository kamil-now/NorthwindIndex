using NorthwindBusinessPartnerIndex.Contracts.API;
using NorthwindBusinessPartnerIndex.Contracts.DataContracts;
using System.Collections.Generic;

namespace NorthwindBusinessPartnerIndex.Client.Services
{
    public class SupplierService : BaseService<ISupplierService, SupplierDto>
    {
        protected override string Address => "http://localhost:8080//Suppliers";
        public override IList<SupplierDto> GetAll() => FromService(service => service.GetAllSuppliers());
        public override SupplierDto GetById(int id) => FromService(service => service.GetSupplierById(id));
    }
}
