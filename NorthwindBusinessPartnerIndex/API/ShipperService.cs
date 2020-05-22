using NorthwindBusinessPartnerIndex.Contracts.API;
using NorthwindBusinessPartnerIndex.Contracts.Data.Models;
using NorthwindBusinessPartnerIndex.Service.Data;
using System.Collections.Generic;
using System.Linq;

namespace NorthwindBusinessPartnerIndex.Service.API
{
    public class ShipperService : IShipperService
    {
        private readonly UnitOfWork _unitOfWork;
        public ShipperService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<IShipper> GetAll()
        {
            return _unitOfWork.Shippers.GetAll().ToList();
        }

        public IShipper GetById(int id)
        {
            return _unitOfWork.Shippers.Get(id.ToString());
        }

        public bool AddOrUpdate(IShipper entity)
        {
            return _unitOfWork.AddOrUpdate(entity);
        }

        public void Commit()
        {
            _unitOfWork.Commit();
        }

        public bool ValidateRequiredProperties(IShipper entity)
        {
            return this._unitOfWork.ValidateRequiredProperties(entity);
        }
    }
}
