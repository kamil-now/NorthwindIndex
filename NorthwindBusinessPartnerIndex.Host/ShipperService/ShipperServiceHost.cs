using NorthwindBusinessPartnerIndex.Data;
using System;
using System.ServiceModel;

namespace NorthwindBusinessPartnerIndex.Host
{
    public class ShipperServiceHost : ServiceHost
    {
        public ShipperServiceHost(UnitOfWork unitOfWork, Type t, params Uri[] baseAddresses) : base(t, baseAddresses)
        {
            foreach (var cd in this.ImplementedContracts.Values)
            {
                cd.Behaviors.Add(new ShipperServiceInstanceProvider(unitOfWork));
            }
        }

    }
}
