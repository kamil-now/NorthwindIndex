using NorthwindBusinessPartnerIndex.Contracts.DataContracts;
using System.Linq;

namespace NorthwindBusinessPartnerIndex.Data.Repo
{
    public interface IRepository
    {
        IBusinessPartner Get(string id);
        IQueryable<IBusinessPartner> GetAll();
        void Add(IBusinessPartner entity);
        void Delete(IBusinessPartner entity);
        void Edit(IBusinessPartner entity);
        void Save();
    }
}
