using NorthwindBusinessPartnerIndex.Service.Data;
using NorthwindBusinessPartnerIndex.Service.Data.Models;
using System;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace NorthwindBusinessPartnerIndex.Service.API
{
    public class BusinessPartnerServiceHostFactory : ServiceHostFactory
    {
        private readonly UnitOfWork _unitOfWork;

        public BusinessPartnerServiceHostFactory()
        {
            _unitOfWork = new UnitOfWork(new Northwind());
        }

        protected override ServiceHost CreateServiceHost(Type serviceType,
            Uri[] baseAddresses)
        {
            return new BusinessPartnerServiceHost(_unitOfWork, serviceType, baseAddresses);
        }
    }
}
