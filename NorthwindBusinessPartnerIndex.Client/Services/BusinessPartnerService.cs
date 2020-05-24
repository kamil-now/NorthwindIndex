using NorthwindBusinessPartnerIndex.Contracts.DataContracts;
using System.Threading.Tasks;

namespace NorthwindBusinessPartnerIndex.Client.Services
{
    public class BusinessPartnerService
    {
        public CustomerService CustomersService { get; }
        public ShipperService ShippersService { get; }
        public SupplierService SuppliersService { get; }

        public BusinessPartnerService(CustomerService customersService, ShipperService shippersService, SupplierService suppliersService)
        {
            CustomersService = customersService;
            ShippersService = shippersService;
            SuppliersService = suppliersService;
        }
        public async Task<bool> AddOrUpdate<T>(T entity)
        {
            switch (entity)
            {
                case CustomerDto x: return await CustomersService.AddOrUpdate(x);
                case SupplierDto x: return await SuppliersService.AddOrUpdate(x);
                case ShipperDto x: return await ShippersService.AddOrUpdate(x);
                default: return false;
            }
        }
    }
}
