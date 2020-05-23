using NorthwindBusinessPartnerIndex.Contracts.API;
using NorthwindBusinessPartnerIndex.Contracts.DataContracts;
using NorthwindBusinessPartnerIndex.Data;
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

        public IList<ShipperDto> GetAll()
        {
            var customers = _unitOfWork.Shippers.GetAll().ToList();
            return customers
                .Select(x => new ShipperDto()
                {
                    ShipperId = x.ShipperID,
                    CompanyName = x.CompanyName,
                    Phone = x.Phone
                }).ToList();
        }

        public ShipperDto GetById(int id)
        {
            var x = _unitOfWork.Shippers.Get(id.ToString());
            return new ShipperDto()
            {
                ShipperId = x.ShipperID,
                CompanyName = x.CompanyName,
                Phone = x.Phone
            };
        }

        public bool AddOrUpdate(ShipperDto entity)
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
