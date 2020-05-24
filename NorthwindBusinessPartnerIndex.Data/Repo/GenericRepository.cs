using NorthwindBusinessPartnerIndex.Contracts.DataContracts;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace NorthwindBusinessPartnerIndex.Data.Repo
{
    public abstract class GenericRepository<C, T> : IGenericRepository<T> where T : class, IBusinessPartner where C : DbContext
    {
        public abstract T Get(string id);
        public C Context { get; set; }

        public virtual IQueryable<T> GetAll() => Context.Set<T>();

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate) => Context.Set<T>().Where(predicate);

        public virtual void Add(T entity) => Context.Set<T>().Add(entity);

        public virtual void Delete(T entity) => Context.Set<T>().Remove(entity);

        public virtual void Edit(T entity) => Context.Entry(entity).State = EntityState.Modified;

        public virtual void Save() => Context.SaveChanges();
        public virtual void Clear() => Context.Set<T>().ForEachAsync(n => Delete(n));

        IBusinessPartner IRepository.Get(string id) => Get(id);

        IQueryable<IBusinessPartner> IRepository.GetAll() => GetAll();

        public void Add(IBusinessPartner entity) => Add((T)entity);

        public void Delete(IBusinessPartner entity) => Delete((T)entity);

        public void Edit(IBusinessPartner entity) => Edit((T)entity);
    }
}
