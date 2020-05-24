using Caliburn.Micro;
using NorthwindBusinessPartnerIndex.Client.Services;
using NorthwindBusinessPartnerIndex.Contracts.DataContracts;
using System.Windows;

namespace NorthwindBusinessPartnerIndex.Client.UI.ViewModels
{
    public class BusinessPartnerDataViewModel : Screen, ISelectedBusinessPartnerObserver
    {
        public IBusinessPartner SelectedBusinessPartner { get; private set; }
        private readonly BusinessPartnerService _service;
        public BusinessPartnerDataViewModel(BusinessPartnerService service)
        {
            _service = service;
        }

        public void UpdateSelectedContractor(IBusinessPartner selectedBusinessPartner)
        {
            SelectedBusinessPartner = selectedBusinessPartner;
            NotifyOfPropertyChange(() => SelectedBusinessPartner);
        }
        public async void Save()
        {
            if (await _service.AddOrUpdate(SelectedBusinessPartner))
            {
                MessageBox.Show("Data has been saved", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Input data is invalid", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
