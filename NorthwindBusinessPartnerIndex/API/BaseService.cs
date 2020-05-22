using NorthwindBusinessPartnerIndex.Contracts.API;
using NorthwindBusinessPartnerIndex.Contracts.Data.Models;
using NorthwindBusinessPartnerIndex.Service.Data;
using System;
using System.Collections.Generic;

namespace NorthwindBusinessPartnerIndex.Service.API
{
    public abstract class BaseService<T> : IDataService<T> where T : class, IDataEntity
    {
        protected readonly UnitOfWork unitOfWork;
        public BaseService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public abstract IEnumerable<T> GetAll();

        public abstract T GetById(int id);
        public bool AddOrUpdate(T entity)
        {
            return unitOfWork.AddOrUpdate(entity);
        }

        public void Commit()
        {
            unitOfWork.Commit();
        }

        

        public bool ValidateRequiredProperties(T entity)
        {
            return this.unitOfWork.ValidateRequiredProperties(entity);
        }
    }
}
