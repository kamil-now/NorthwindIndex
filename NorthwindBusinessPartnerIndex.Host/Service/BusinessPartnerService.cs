using NorthwindBusinessPartnerIndex.Contracts.API;
using NorthwindBusinessPartnerIndex.Contracts.DataContracts;
using System;
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

        public IList<CustomerDto> GetAllCustomers()
        {
            Console.WriteLine("Get all customers...");
            var result = _customerService.GetAllCustomers();
            Console.WriteLine($"\tFetched {result.Count} customers");
            return result;
        }
        public IList<ShipperDto> GetAllShippers()
        {
            Console.WriteLine("Get all shippers...");
            var result = _shipperService.GetAllShippers();
            Console.WriteLine($"\tFetched {result.Count} shippers");
            return result;
        }
        public IList<SupplierDto> GetAllSuppliers()
        {
            Console.WriteLine("Get all suppliers...");
            var result = _supplierService.GetAllSuppliers();
            Console.WriteLine($"\tFetched {result.Count} suppliers");
            return result;
        }

        public CustomerDto GetCustomerById(int id)
        {
            Console.WriteLine($"Get customer with id={id}...");
            var result = _customerService.GetCustomerById(id);
            if (result is null)
            {
                Console.WriteLine($"\tFailed to fetch customer with id={id}");
            }
            Console.WriteLine($"\tFetched customer with id={id}");
            return result;
        }
        public ShipperDto GetShipperById(int id)
        {
            Console.WriteLine($"Get shipper with id={id}...");
            var result = _shipperService.GetShipperById(id);
            if (result is null)
            {
                Console.WriteLine($"\tFailed to fetch shipper with id={id}");
            }
            Console.WriteLine($"\tFetched shipper with id={id}");
            return result;
        }
        public SupplierDto GetSupplierById(int id)
        {
            Console.WriteLine($"Get customer with id={id}...");
            var result = _supplierService.GetSupplierById(id);
            if (result is null)
            {
                Console.WriteLine($"\tFailed to fetch customer with id={id}");
            }
            Console.WriteLine($"\tFetched with id={id}");
            return result;
        }

        public bool AddOrUpdate(CustomerDto entity)
        {
            Console.WriteLine($"Add (update) customer with id={entity.Id}...");
            var result = _customerService.AddOrUpdate(entity);
            if (!result)
            {
                Console.WriteLine($"\tFailed to add (update) customer with id={entity.Id}");
            }
            Console.WriteLine($"Added (updated) customer with id={entity.Id}");
            return result;
        }
        public bool AddOrUpdate(SupplierDto entity)
        {
            Console.WriteLine($"Add (update) supplier with id={entity.Id}...");
            var result = _supplierService.AddOrUpdate(entity);
            if (!result)
            {
                Console.WriteLine($"\tFailed to add (update) supplier with id={entity.Id}");
            }
            Console.WriteLine($"\tAdded (updated) supplier with id={entity.Id}");
            return result;
        }
        public bool AddOrUpdate(ShipperDto entity)
        {
            Console.WriteLine($"Add (update) shipper with id={entity.Id}...");
            var result = _shipperService.AddOrUpdate(entity);
            if (!result)
            {
                Console.WriteLine($"\tFailed to add (update) shipper with id={entity.Id}");
            }
            Console.WriteLine($"\tAdded (updated) shipper with id={entity.Id}");
            return result;
        }
        public bool Delete(CustomerDto entity)
        {
            Console.WriteLine($"Delete customer with id={entity.Id}...");
            var result = _customerService.Delete(entity);
            if (!result)
            {
                Console.WriteLine($"\tFailed to delete customer with id={entity.Id}");
            }
            Console.WriteLine($"\tDeleted customer with id={entity.Id}");
            return result;
        }
        public bool Delete(SupplierDto entity)
        {
            Console.WriteLine($"Delete supplier with id={entity.Id}...");
            var result = _supplierService.Delete(entity);
            if (!result)
            {
                Console.WriteLine($"\tFailed to delete supplier with id={entity.Id}");
            }
            Console.WriteLine($"\tDeleted supplier with id={entity.Id}");
            return result;
        }
        public bool Delete(ShipperDto entity)
        {
            Console.WriteLine($"Delete shipper with id={entity.Id}...");
            var result = _shipperService.Delete(entity);
            if (!result)
            {
                Console.WriteLine($"\tFailed to delete shipper with id={entity.Id}");
            }
            Console.WriteLine($"\tDeleted shipper with id={entity.Id}");
            return result;
        }
    }
}
