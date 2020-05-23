using NorthwindBusinessPartnerIndex.Contracts.DataContracts;

namespace NorthwindBusinessPartnerIndex.Client.Services
{
    public class AggregateService
    {
        public CustomerService CustomersService { get; }
        public ShipperService ShippersService { get; }
        public SupplierService SuppliersService { get; }

        public AggregateService(CustomerService customersService, ShipperService shippersService, SupplierService suppliersService)
        {
            CustomersService = customersService;
            ShippersService = shippersService;
            SuppliersService = suppliersService;
        }
        public void AddOrUpdate<T>(T entity)
        {
            switch (entity)
            {
                case CustomerDto x:
                    CustomersService.AddOrUpdate(x);
                    break;
                case SupplierDto x:
                    SuppliersService.AddOrUpdate(x);
                    break;
                case ShipperDto x:
                    ShippersService.AddOrUpdate(x);
                    break;
                default: break;
            }
        }
    }
}
