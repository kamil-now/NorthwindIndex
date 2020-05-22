using NorthwindBusinessPartnerIndex.Contracts.API;
using NorthwindBusinessPartnerIndex.Contracts.Data.Models;
using NorthwindBusinessPartnerIndex.Service.Data;
using System.Collections.Generic;
using System.Linq;

namespace NorthwindBusinessPartnerIndex.Service.API
{
    public class SupplierService : ISupplierService
    {
        private readonly UnitOfWork _unitOfWork;
        public SupplierService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<ISupplier> GetAll()
        {
            return _unitOfWork.Suppliers.GetAll().ToList();
        }

        public ISupplier GetById(int id)
        {
            return _unitOfWork.Suppliers.Get(id.ToString());
        }
        public bool AddOrUpdate(ISupplier entity)
        {
            return _unitOfWork.AddOrUpdate(entity);
        }

        public void Commit()
        {
            _unitOfWork.Commit();
        }

        public bool ValidateRequiredProperties(ISupplier entity)
        {
            return this._unitOfWork.ValidateRequiredProperties(entity);
        }
    }
}
