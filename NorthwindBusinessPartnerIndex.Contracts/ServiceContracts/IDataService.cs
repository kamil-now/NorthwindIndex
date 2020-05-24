using NorthwindBusinessPartnerIndex.Contracts.DataContracts;
using System.ServiceModel;

namespace NorthwindBusinessPartnerIndex.Contracts.API
{
    [ServiceContract]
    public interface IDataService<T> where T : IBusinessPartner
    {
        [OperationContract]
        bool AddOrUpdate(T entity);
        [OperationContract]
        bool Delete(T entity);
    }
}
