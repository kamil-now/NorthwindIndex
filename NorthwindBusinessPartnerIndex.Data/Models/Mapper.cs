using NorthwindBusinessPartnerIndex.Contracts.DataContracts;
using NorthwindBusinessPartnerIndex.Data.Models;

namespace NorthwindBusinessPartnerIndex.Data.Models
{
    public static class Mapper
    {
        public static CustomerDto Map(Customer entity)
        {
            return new CustomerDto()
            {
                CustomerID = entity.CustomerID,
                CompanyName = entity.CompanyName,
                ContactName = entity.ContactName,
                ContactTitle = entity.ContactTitle,
                Address = entity.Address,
                City = entity.City,
                Region = entity.Region,
                PostalCode = entity.PostalCode,
                Country = entity.Country,
                Phone = entity.Phone,
                Fax = entity.Fax
            };
        }
        public static ShipperDto Map(Shipper entity)
        {
            return new ShipperDto()
            {
                ShipperID = entity.ShipperID,
                CompanyName = entity.CompanyName,
                Phone = entity.Phone
            };
        }
        public static SupplierDto Map(Supplier entity)
        {
            return new SupplierDto()
            {
                SupplierID = entity.SupplierID,
                CompanyName = entity.CompanyName,
                ContactName = entity.ContactName,
                ContactTitle = entity.ContactTitle,
                Address = entity.Address,
                City = entity.City,
                Region = entity.Region,
                PostalCode = entity.PostalCode,
                Country = entity.Country,
                Phone = entity.Phone,
                Fax = entity.Fax
            };
        }
        public static Customer Map(CustomerDto entity)
        {
            return new Customer()
            {
                CustomerID = entity.CustomerID,
                CompanyName = entity.CompanyName,
                ContactName = entity.ContactName,
                ContactTitle = entity.ContactTitle,
                Address = entity.Address,
                City = entity.City,
                Region = entity.Region,
                PostalCode = entity.PostalCode,
                Country = entity.Country,
                Phone = entity.Phone,
                Fax = entity.Fax
            };
        }
        public static Shipper Map(ShipperDto entity)
        {
            return new Shipper()
            {
                ShipperID = entity.ShipperID,
                CompanyName = entity.CompanyName,
                Phone = entity.Phone
            };
        }
        public static Supplier Map(SupplierDto entity)
        {
            return new Supplier()
            {
                SupplierID = entity.SupplierID,
                CompanyName = entity.CompanyName,
                ContactName = entity.ContactName,
                ContactTitle = entity.ContactTitle,
                Address = entity.Address,
                City = entity.City,
                Region = entity.Region,
                PostalCode = entity.PostalCode,
                Country = entity.Country,
                Phone = entity.Phone,
                Fax = entity.Fax
            };
        }
    }
}
