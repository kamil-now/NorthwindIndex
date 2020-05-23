using NorthwindBusinessPartnerIndex.Data;
using System;
using System.ServiceModel;

namespace NorthwindBusinessPartnerIndex.Host
{
    public class BpServiceHost : ServiceHost
    {
        public BpServiceHost(UnitOfWork unitOfWork, Type type, params Uri[] address) : base(type, address)
        {
            foreach (var cd in ImplementedContracts.Values)
            {
                cd.Behaviors.Add(new ServiceInstanceProvider(unitOfWork));
            }
        }
    }
}
