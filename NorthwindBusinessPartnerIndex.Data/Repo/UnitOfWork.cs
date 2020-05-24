using NorthwindBusinessPartnerIndex.Contracts.DataContracts;
using NorthwindBusinessPartnerIndex.Data.Models;
using NorthwindBusinessPartnerIndex.Data.Repo;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;

namespace NorthwindBusinessPartnerIndex.Data
{
    public class UnitOfWork : IDisposable
    {
        private readonly DbContext _dbContext;

        public CustomerRepository Customers { get; }
        public ShipperRepository Shippers { get; }
        public SupplierRepository Suppliers { get; }

        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
            Customers = new CustomerRepository(dbContext);
            Shippers = new ShipperRepository(dbContext);
            Suppliers = new SupplierRepository(dbContext);
        }

        public bool AddOrUpdate<T>(T entity) where T : class, IBusinessPartner
        {
            var isValid = false;
            try
            {
                var repo = GetRepository(entity);
                var databaseEntity = repo.Get(entity.Id);
                var exists = databaseEntity != null;
                isValid = ValidateRequiredProperties(entity);

                if (isValid)
                {
                    if (exists)
                    {
                        repo.Edit(databaseEntity);
                    }
                    else
                    {
                        repo.Add(entity);
                    }
                }
            }
            catch (Exception e)
            {
                isValid = false;
                throw e;
            }

            return isValid;
        }
        public bool Delete<T>(T entity) where T : class, IBusinessPartner
        {
            var deleted = false;
            try
            {
                var repo = GetRepository(entity);
                var databaseEntity = repo.Get(entity.Id);
                var exists = databaseEntity != null;
                if (exists)
                {
                    repo.Delete(entity);
                    deleted = true;
                }

            }
            catch (Exception e)
            {
                throw e;
            }

            return deleted;
        }
        public bool ValidateRequiredProperties<T>(T entity) where T : class, IBusinessPartner
        {
            var props = entity.GetType().GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(RequiredAttribute)));
            return props.Where(p => p.GetValue(entity) == null).Count() == 0;
        }
        public void Commit()
        {
            _dbContext.SaveChanges();
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }
        public void RejectChanges()
        {
            foreach (var entry in _dbContext.ChangeTracker.Entries()
                  .Where(e => e.State != EntityState.Unchanged))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            }
        }
        private IRepository GetRepository<T>(T entity) where T : class, IBusinessPartner
        {
            switch (entity)
            {
                case Customer _: return Customers;
                case Supplier _: return Suppliers;
                case Shipper _: return Shippers;
                default: throw new Exception("Invalid type");
            }
        }
    }
}
