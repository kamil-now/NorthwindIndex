using NorthwindBusinessPartnerIndex.Contracts.Data.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;

namespace NorthwindBusinessPartnerIndex.Service.Data
{
    public class UnitOfWork
    {
        private readonly DbContext dbContext;

        public CustomerRepository Customers { get; }
        public ShipperRepository Shippers { get; }
        public SupplierRepository Suppliers { get; }

        public UnitOfWork(DbContext dbContext)
        {
            this.dbContext = dbContext;
            Customers = new CustomerRepository(dbContext);
            Shippers = new ShipperRepository(dbContext);
            Suppliers = new SupplierRepository(dbContext);
        }
        public IRepository GetRepository<T>(T entity) where T : class, IDataEntity
        {
            if (entity is ICustomer)
            {
                return Customers;
            }
            else if (entity is ISupplier)
            {
                return Suppliers;
            }
            else if (entity is IShipper)
            {
                return Shippers;
            }
            else return null;
        }
        public bool AddOrUpdate<T>(T entity) where T : class, IDataEntity
        {
            var repo = GetRepository(entity);
            var databaseEntity = repo.Get(entity.Id);
            var exists = databaseEntity != null;
            var isValid = ValidateRequiredProperties(entity);

            if (isValid)
            {
                repo.Add(entity);
                if (exists)
                {
                    repo.Edit(databaseEntity);
                }
            }
            return isValid;
        }
        public bool ValidateRequiredProperties<T>(T entity) where T : class, IDataEntity
        {
            var props = entity.GetType().GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(RequiredAttribute)));
            return props.Where(p => p.GetValue(entity) == null).Count() == 0;
        }
        public void Commit()
        {
            dbContext.SaveChanges();
        }
        public void Dispose()
        {
            dbContext.Dispose();
        }
        public void RejectChanges()
        {
            foreach (var entry in dbContext.ChangeTracker.Entries()
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
    }
}
