using NorthwindBusinessPartnerIndex.Contracts.API;
using NorthwindBusinessPartnerIndex.Contracts.DataContracts;
using NorthwindBusinessPartnerIndex.Data;
using System.Collections.Generic;
using System.Linq;

namespace NorthwindBusinessPartnerIndex.Host
{
    public class SupplierService : ISupplierService
    {
        private readonly UnitOfWork _unitOfWork;
        public SupplierService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IList<SupplierDto> GetAllSuppliers()
        {
            var customers = _unitOfWork.Suppliers.GetAll().ToList();
            return customers
                .Select(x => new SupplierDto()
                {
                    SupplierId = x.SupplierID,
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

        public SupplierDto GetSupplierById(int id)
        {
            var x = _unitOfWork.Suppliers.Get(id.ToString());
            return new SupplierDto()
            {
                SupplierId = x.SupplierID,
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
        public bool AddOrUpdate(SupplierDto entity)
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
