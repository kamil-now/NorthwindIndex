using NorthwindBusinessPartnerIndex.Contracts.API;
using NorthwindBusinessPartnerIndex.Contracts.DataContracts;
using NorthwindBusinessPartnerIndex.Data;
using NorthwindBusinessPartnerIndex.Data.Models;
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
            return customers.Select(entity => Mapper.Map(entity)).ToList();
        }

        public CustomerDto GetCustomerById(int id)
        {
            var entity = _unitOfWork.Customers.Get(id.ToString());
            return Mapper.Map(entity);
        }
        public bool AddOrUpdate(CustomerDto dto)
        {
            var result = _unitOfWork.AddOrUpdate(Mapper.Map(dto));
            if (result)
            {
                _unitOfWork.Commit();
            }
            return result;
        }
    }
}
