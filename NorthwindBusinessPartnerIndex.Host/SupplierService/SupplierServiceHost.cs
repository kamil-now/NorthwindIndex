using NorthwindBusinessPartnerIndex.Data;
using System;
using System.ServiceModel;

namespace NorthwindBusinessPartnerIndex.Host
{
    public class SupplierServiceHost : ServiceHost
    {
        public SupplierServiceHost(UnitOfWork unitOfWork, Type t, params Uri[] baseAddresses) : base(t, baseAddresses)
        {
            foreach (var cd in this.ImplementedContracts.Values)
            {
                cd.Behaviors.Add(new SupplierServiceInstanceProvider(unitOfWork));
            }
        }

    }
}
