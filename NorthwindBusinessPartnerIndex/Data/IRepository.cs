using NorthwindBusinessPartnerIndex.Contracts.Data.Models;
using System.Linq;

namespace NorthwindBusinessPartnerIndex.Service.Data
{
    public interface IRepository
    {
        IDataEntity Get(string id);
        IQueryable<IDataEntity> GetAll();
        void Add(IDataEntity entity);
        void Delete(IDataEntity entity);
        void Edit(IDataEntity entity);
        void Save();
    }
}
