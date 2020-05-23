using Caliburn.Micro;
using NorthwindBusinessPartnerIndex.Client.Services;
using NorthwindBusinessPartnerIndex.Contracts.DataContracts;

namespace NorthwindBusinessPartnerIndex.Client.UI.ViewModels
{
    public class BusinessPartnerDataViewModel : Screen, ISelectedBusinessPartnerObserver
    {
        public IBusinessPartner SelectedBusinessPartner { get; private set; }
        private readonly AggregateService _service;
        public BusinessPartnerDataViewModel(AggregateService service)
        {
            _service = service;
        }

        public void UpdateSelectedContractor(IBusinessPartner selectedBusinessPartner)
        {
            SelectedBusinessPartner = selectedBusinessPartner;
            NotifyOfPropertyChange(() => SelectedBusinessPartner);
        }
        public void Save()
        {
            _service.AddOrUpdate(SelectedBusinessPartner);
        }
        public void New()
        {
            switch (SelectedBusinessPartner)
            {
                case CustomerDto x: SelectedBusinessPartner = new CustomerDto(); break;
                case ShipperDto x: SelectedBusinessPartner = new ShipperDto(); break;
                case SupplierDto x: SelectedBusinessPartner = new SupplierDto(); break;
                default: break;
            }
            NotifyOfPropertyChange(() => SelectedBusinessPartner);
        }

    }
}
