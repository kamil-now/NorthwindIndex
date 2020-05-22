using NorthwindBusinessPartnerIndex.Service.Data;
using System;
using System.ServiceModel;

namespace NorthwindBusinessPartnerIndex.Service.API
{
    public class BusinessPartnerServiceHost : ServiceHost
    {
        public BusinessPartnerServiceHost(UnitOfWork unitOfWork, Type t, params Uri[] baseAddresses) : base(t, baseAddresses)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("dep");
            }

            foreach (var cd in this.ImplementedContracts.Values)
            {
                cd.Behaviors.Add(new CustomerServiceInstanceProvider(unitOfWork));
                cd.Behaviors.Add(new SupplierServiceInstanceProvider(unitOfWork));
                cd.Behaviors.Add(new ShipperServiceInstanceProvider(unitOfWork));
            }
        }

    }
}
