using NorthwindBusinessPartnerIndex.Contracts.API;
using NorthwindBusinessPartnerIndex.Contracts.DataContracts;
using System.Collections.Generic;

namespace NorthwindBusinessPartnerIndex.Host
{
    public class BusinessPartnerService : ICustomerService, ISupplierService, IShipperService
    {
        private readonly CustomerService _customerService;
        private readonly ShipperService _shipperService;
        private readonly SupplierService _supplierService;
        public BusinessPartnerService(CustomerService customerService, ShipperService shipperService, SupplierService supplierService)
        {
            _customerService = customerService;
            _shipperService = shipperService;
            _supplierService = supplierService;
        }

        public bool AddOrUpdate(CustomerDto entity) => _customerService.AddOrUpdate(entity);

        public bool AddOrUpdate(SupplierDto entity) => _supplierService.AddOrUpdate(entity);
        public bool AddOrUpdate(ShipperDto entity) => _shipperService.AddOrUpdate(entity);

        public IList<CustomerDto> GetAllCustomers() => _customerService.GetAllCustomers();
        public IList<ShipperDto> GetAllShippers() => _shipperService.GetAllShippers();
        public IList<SupplierDto> GetAllSuppliers() => _supplierService.GetAllSuppliers();

        public CustomerDto GetCustomerById(int id) => _customerService.GetCustomerById(id);
        public ShipperDto GetShipperById(int id) => _shipperService.GetShipperById(id);
        public SupplierDto GetSupplierById(int id) => _supplierService.GetSupplierById(id);
    }
}
