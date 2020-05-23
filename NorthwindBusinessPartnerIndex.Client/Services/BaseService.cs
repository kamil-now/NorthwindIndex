using NorthwindBusinessPartnerIndex.Client.Extensions;
using NorthwindBusinessPartnerIndex.Contracts.API;
using NorthwindBusinessPartnerIndex.Contracts.DataContracts;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace NorthwindBusinessPartnerIndex.Client.Services
{

    public abstract class BaseService<TService, TData> where TService : IDataService<TData> where TData : IBusinessPartner  //: BaseService<ICustomerService, CustomerContract>
    {
        protected readonly string Address = "http://localhost:8080";
        protected abstract string Endpoint { get; }
        public bool AddOrUpdate(TData entity) => FromService(service => service.AddOrUpdate(entity));
        public IList<TData> GetAll() => FromService(service => service.GetAll());
        public TData GetById(int id) => FromService(service => service.GetById(id));

        private T FromService<T>(Func<TService, T> func)
        {
            return GetChannelFactory().Using(factory =>
           {
               var channel = factory.CreateChannel();
               return func(channel);
           });
        }
        protected ChannelFactory<TService> GetChannelFactory()
        {
            return new ChannelFactory<TService>(new BasicHttpBinding(), new EndpointAddress($"{Address}/{Endpoint}"));
        }
    }

}
