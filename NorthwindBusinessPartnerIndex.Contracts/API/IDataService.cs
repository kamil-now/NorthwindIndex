using NorthwindBusinessPartnerIndex.Contracts.Data.Models;
using System.Collections.Generic;
using System.ServiceModel;

namespace NorthwindBusinessPartnerIndex.Contracts.API
{
    [ServiceContract]
    public interface IDataService<T> where T : IDataEntity
    {
        [OperationContract]
        IEnumerable<T> GetAll();
        [OperationContract]
        T GetById(int id);
        bool AddOrUpdate(T entity);
        bool ValidateRequiredProperties(T entity);
        void Commit();
    }
}
