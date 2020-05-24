using NorthwindBusinessPartnerIndex.Contracts.API;
using NorthwindBusinessPartnerIndex.Contracts.DataContracts;
using NorthwindBusinessPartnerIndex.Data;
using NorthwindBusinessPartnerIndex.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace NorthwindBusinessPartnerIndex.Host
{
    public class ShipperService : IShipperService
    {
        private readonly UnitOfWork _unitOfWork;
        public ShipperService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IList<ShipperDto> GetAllShippers()
        {
            var shippers = _unitOfWork.Shippers.GetAll().ToList();
            return shippers.Select(entity => Mapper.Map(entity)).ToList();
        }

        public ShipperDto GetShipperById(int id)
        {
            var entity = _unitOfWork.Shippers.Get(id.ToString());
            return Mapper.Map(entity);
        }

        public bool AddOrUpdate(ShipperDto dto)
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
