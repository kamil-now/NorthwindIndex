using NorthwindBusinessPartnerIndex.Contracts.API;
using NorthwindBusinessPartnerIndex.Contracts.DataContracts;
using NorthwindBusinessPartnerIndex.Data;
using NorthwindBusinessPartnerIndex.Data.Models;
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
            var suppliers = _unitOfWork.Suppliers.GetAll().ToList();
            return suppliers.Select(entity => Mapper.Map(entity)).ToList();
        }

        public SupplierDto GetSupplierById(int id)
        {
            var entity = _unitOfWork.Suppliers.Get(id.ToString());
            return Mapper.Map(entity);
        }
        public bool AddOrUpdate(SupplierDto dto)
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
