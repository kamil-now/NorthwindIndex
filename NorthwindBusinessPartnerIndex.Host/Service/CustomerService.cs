using NorthwindBusinessPartnerIndex.Contracts.API;
using NorthwindBusinessPartnerIndex.Contracts.DataContracts;
using NorthwindBusinessPartnerIndex.Data;
using System.Collections.Generic;
using System.Linq;

namespace NorthwindBusinessPartnerIndex.Host
{
    public class CustomerService : ICustomerService
    {
        private readonly UnitOfWork _unitOfWork;
        public CustomerService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IList<CustomerDto> GetAllCustomers()
        {
            var customers = _unitOfWork.Customers.GetAll().ToList();
            return customers
                .Select(x => new CustomerDto()
                {
                    CustomerID = x.CustomerID,
                    CompanyName = x.CompanyName,
                    ContactName = x.ContactName,
                    ContactTitle = x.ContactTitle,
                    Address = x.Address,
                    City = x.City,
                    Region = x.Region,
                    PostalCode = x.PostalCode,
                    Country = x.Country,
                    Phone = x.Phone,
                    Fax = x.Fax
                }).ToList();
        }

        public CustomerDto GetCustomerById(int id)
        {
            var x = _unitOfWork.Customers.Get(id.ToString());
            return new CustomerDto()
            {
                CustomerID = x.CustomerID,
                CompanyName = x.CompanyName,
                ContactName = x.ContactName,
                ContactTitle = x.ContactTitle,
                Address = x.Address,
                City = x.City,
                Region = x.Region,
                PostalCode = x.PostalCode,
                Country = x.Country,
                Phone = x.Phone,
                Fax = x.Fax
            };
        }
        public bool AddOrUpdate(CustomerDto entity)
        {
            var result = _unitOfWork.AddOrUpdate(entity);
            if (result)
            {
                _unitOfWork.Commit();
            }
            return result;
        }
    }
}
