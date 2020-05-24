using NorthwindBusinessPartnerIndex.Contracts.API;
using NorthwindBusinessPartnerIndex.Contracts.DataContracts;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace NorthwindBusinessPartnerIndex.Client.Services
{

    public abstract class BaseService<TService, TData> where TService : IDataService<TData> where TData : IBusinessPartner
    {
        protected abstract string Address { get; }
        public async Task<bool> AddOrUpdate(TData entity) => await FromService(service => service.AddOrUpdate(entity));
        public async Task<bool> Delete(TData entity) => await FromService(service => service.Delete(entity));
        public abstract Task<IList<TData>> GetAll();
        public abstract Task<TData> GetById(int id);
        public async Task<TResult> FromService<TResult>(Func<TService, TResult> func)
        {
            var retval = default(TResult);
            await Task.Run(() =>
            {
                var client = new ChannelFactory<TService>(new BasicHttpBinding(), new EndpointAddress(Address));
                try
                {
                    var channel = client.CreateChannel();
                    retval = func(channel);
                    client.Close();
                }
                catch
                {
                    client.Abort();
                }
            });

            return retval;
        }
    }

}
