using NorthwindBusinessPartnerIndex.Contracts.API;
using NorthwindBusinessPartnerIndex.Contracts.Data.Models;
using System.Collections.Generic;
using System.ServiceModel;

namespace NorthwindBusinessPartnerIndex.Client.API
{
    public abstract class BaseService<T> : IDataService<T> where T : IDataEntity
    {
        protected abstract string Endpoint { get; }
        static readonly string Address = "http://localhost:2222";

        public bool AddOrUpdate(T entity)
        {
            bool retval = false;
            using (var factory = GetChannelFactory())
            {
                var channel = factory.CreateChannel();
                retval = channel.AddOrUpdate(entity);
            }
            return retval;
        }

        public void Commit()
        {
            using (var factory = GetChannelFactory())
            {
                var channel = factory.CreateChannel();
                channel.Commit();
            }
        }

        public IEnumerable<T> GetAll()
        {
            IEnumerable<T> retval = null;
            using (var factory = GetChannelFactory())
            {
                var channel = factory.CreateChannel();
                retval = channel.GetAll();
            }
            return retval;
        }

        public T GetById(int id)
        {
            T retval = default;
            using (var factory = GetChannelFactory())
            {
                var channel = factory.CreateChannel();
                retval = channel.GetById(id);
            }
            return retval;
        }

        public bool ValidateRequiredProperties(T entity)
        {
            bool retval = false;
            using (var factory = GetChannelFactory())
            {
                var channel = factory.CreateChannel();
                retval = channel.ValidateRequiredProperties(entity);
            }
            return retval;
        }

        protected ChannelFactory<IDataService<T>> GetChannelFactory()
        {
            return new ChannelFactory<IDataService<T>>(new BasicHttpBinding(), new EndpointAddress($"{Address}/{Endpoint}"));
        }
    }
}
