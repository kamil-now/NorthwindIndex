using NorthwindBusinessPartnerIndex.Contracts.DataContracts;
using System.Collections.Generic;
using System.ServiceModel;

namespace NorthwindBusinessPartnerIndex.Contracts.API
{
    [ServiceContract]
    public interface IDataService<T> where T : IBusinessPartner
    {
        [OperationContract]
        IList<T> GetAll();
        [OperationContract]
        T GetById(int id);
        [OperationContract]
        bool AddOrUpdate(T entity);
    }
}
