using NorthwindBusinessPartnerIndex.Contracts.DataContracts;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace NorthwindBusinessPartnerIndex.Data.Repo
{
    public interface IGenericRepository<T> : IRepository where T : class, IBusinessPartner
    {
        new T Get(string id);
        new IQueryable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        new void Save();
    }
}
