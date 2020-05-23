//using NorthwindBusinessPartnerIndex.Contracts.API;
//using NorthwindBusinessPartnerIndex.Contracts.DataContracts;
//using NorthwindBusinessPartnerIndex.Data;
//using System.Collections.Generic;
//using System.Linq;

//namespace NorthwindBusinessPartnerIndex.Host
//{
//    public class BpService : ICustomerService, ISupplierService, IShipperService
//    {
//        private readonly UnitOfWork _unitOfWork;
//        public BpService(UnitOfWork unitOfWork)
//        {
//            _unitOfWork = unitOfWork;
//        }

//        public IList<CustomerDto> GetAll()
//        {
//            var customers = _unitOfWork.Customers.GetAll().ToList();
//            return customers
//                .Select(x => new CustomerDto()
//                {
//                    CustomerId = x.CustomerID,
//                    CompanyName = x.CompanyName,
//                    ContactName = x.ContactName,
//                    ContactTitle = x.ContactTitle,
//                    Address = x.Address,
//                    City = x.City,
//                    Region = x.Region,
//                    PostalCode = x.PostalCode,
//                    Country = x.Country,
//                    Phone = x.Phone,
//                    Fax = x.Fax
//                }).ToList();
//        }

//        public CustomerDto GetById(int id)
//        {
//            var x = _unitOfWork.Customers.Get(id.ToString());
//            return new CustomerDto()
//            {
//                CustomerId = x.CustomerID,
//                CompanyName = x.CompanyName,
//                ContactName = x.ContactName,
//                ContactTitle = x.ContactTitle,
//                Address = x.Address,
//                City = x.City,
//                Region = x.Region,
//                PostalCode = x.PostalCode,
//                Country = x.Country,
//                Phone = x.Phone,
//                Fax = x.Fax
//            };
//        }
//        public bool AddOrUpdate(CustomerDto entity)
//        {
//            var result = _unitOfWork.AddOrUpdate(entity);
//            if (result)
//            {
//                _unitOfWork.Commit();
//            }
//            return result;
//        }

//        public IList<SupplierDto> GetAll()
//        {
//            var customers = _unitOfWork.Suppliers.GetAll().ToList();
//            return customers
//                .Select(x => new SupplierDto()
//                {
//                    SupplierId = x.SupplierID,
//                    CompanyName = x.CompanyName,
//                    ContactName = x.ContactName,
//                    ContactTitle = x.ContactTitle,
//                    Address = x.Address,
//                    City = x.City,
//                    Region = x.Region,
//                    PostalCode = x.PostalCode,
//                    Country = x.Country,
//                    Phone = x.Phone,
//                    Fax = x.Fax
//                }).ToList();
//        }

//        public SupplierDto GetById(int id)
//        {
//            var x = _unitOfWork.Suppliers.Get(id.ToString());
//            return new SupplierDto()
//            {
//                SupplierId = x.SupplierID,
//                CompanyName = x.CompanyName,
//                ContactName = x.ContactName,
//                ContactTitle = x.ContactTitle,
//                Address = x.Address,
//                City = x.City,
//                Region = x.Region,
//                PostalCode = x.PostalCode,
//                Country = x.Country,
//                Phone = x.Phone,
//                Fax = x.Fax
//            };
//        }
//        public bool AddOrUpdate(SupplierDto entity)
//        {
//            var result = _unitOfWork.AddOrUpdate(entity);
//            if (result)
//            {
//                _unitOfWork.Commit();
//            }
//            return result;
//        }

//        public IList<ShipperDto> GetAll()
//        {
//            var customers = _unitOfWork.Shippers.GetAll().ToList();
//            return customers
//                .Select(x => new ShipperDto()
//                {
//                    ShipperId = x.ShipperID,
//                    CompanyName = x.CompanyName,
//                    Phone = x.Phone
//                }).ToList();
//        }

//        public ShipperDto GetById(int id)
//        {
//            var x = _unitOfWork.Shippers.Get(id.ToString());
//            return new ShipperDto()
//            {
//                ShipperId = x.ShipperID,
//                CompanyName = x.CompanyName,
//                Phone = x.Phone
//            };
//        }

//        public bool AddOrUpdate(ShipperDto entity)
//        {
//            var result = _unitOfWork.AddOrUpdate(entity);
//            if (result)
//            {
//                _unitOfWork.Commit();
//            }
//            return result;
//        }

//    }
//}
