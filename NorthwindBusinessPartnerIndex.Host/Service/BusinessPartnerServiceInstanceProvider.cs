using NorthwindBusinessPartnerIndex.Data;
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace NorthwindBusinessPartnerIndex.Host
{
    public class BusinessPartnerServiceInstanceProvider : IInstanceProvider, IContractBehavior
    {
        private readonly UnitOfWork _unitOfWork;

        public BusinessPartnerServiceInstanceProvider(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return GetInstance(instanceContext);
        }

        public object GetInstance(InstanceContext instanceContext)
        {
            return new BusinessPartnerService(new CustomerService(_unitOfWork), new ShipperService(_unitOfWork), new SupplierService(_unitOfWork));
        }

        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
            var disposable = instance as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }

        public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
        }

        public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, DispatchRuntime dispatchRuntime)
        {
            dispatchRuntime.InstanceProvider = this;
        }

        public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
        {
        }
    }
}
