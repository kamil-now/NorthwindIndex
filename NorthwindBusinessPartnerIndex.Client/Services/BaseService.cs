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
        protected abstract string Address { get; }
        public bool AddOrUpdate(TData entity) => FromService(service => service.AddOrUpdate(entity));
        public abstract IList<TData> GetAll();
        public abstract TData GetById(int id);

        protected T FromService<T>(Func<TService, T> func)
        {
            return GetChannelFactory().Using(factory =>
           {
               var channel = factory.CreateChannel();
               return func(channel);
           });
        }
        protected ChannelFactory<TService> GetChannelFactory()
        {
            return new ChannelFactory<TService>(new BasicHttpBinding(), new EndpointAddress(Address));
        }
    }

}
