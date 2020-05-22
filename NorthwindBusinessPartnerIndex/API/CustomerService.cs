using System.Collections.Generic;
using System.Linq;
using NorthwindBusinessPartnerIndex.Contracts.Data.Models;
using NorthwindBusinessPartnerIndex.Service.Data;
using NorthwindBusinessPartnerIndex.Contracts.API;

namespace NorthwindBusinessPartnerIndex.Service.API
{
    public class CustomerService : ICustomerService
    {
        private readonly UnitOfWork _unitOfWork;
        public CustomerService(UnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<ICustomer> GetAll()
        {
            return _unitOfWork.Customers.GetAll().ToList();
        }

        public  ICustomer GetById(int id)
        {
            return _unitOfWork.Customers.Get(id.ToString());
        }
        public bool AddOrUpdate(ICustomer entity)
        {
            return _unitOfWork.AddOrUpdate(entity);
        }

        public void Commit()
        {
            _unitOfWork.Commit();
        }

        public bool ValidateRequiredProperties(ICustomer entity)
        {
            return this._unitOfWork.ValidateRequiredProperties(entity);
        }
    }
}
