using Caliburn.Micro;
using NorthwindBusinessPartnerIndex.Client.Services;
using NorthwindBusinessPartnerIndex.Contracts.DataContracts;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace NorthwindBusinessPartnerIndex.Client.UI.ViewModels
{
    public class BusinessPartnerDataViewModel : Screen, ISelectedBusinessPartnerObserver, IDataChangedSubject
    {
        private List<IDataChangedObserver> observers = new List<IDataChangedObserver>();
        public IBusinessPartner SelectedBusinessPartner { get; private set; }
        private readonly BusinessPartnerService _service;
        public BusinessPartnerDataViewModel(BusinessPartnerService service)
        {
            _service = service;
        }

        public void SetBusinessPartner(IBusinessPartner selectedBusinessPartner)
        {
            SelectedBusinessPartner = selectedBusinessPartner;
            NotifyOfPropertyChange(() => SelectedBusinessPartner);
        }
        public async void Save()
        {
            if (await _service.AddOrUpdate(SelectedBusinessPartner))
            {
                MessageBox.Show("Data has been saved", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                await NotifyObservers();
            }
            else
            {
                MessageBox.Show("Input data is invalid", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public async void Delete()
        {
            var result = MessageBox.Show("Are you sure you ant to delete selected business partner", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.No)
            {
                return;
            }
            if (await _service.Delete(SelectedBusinessPartner))
            {
                MessageBox.Show("Data has been deleted", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
               await NotifyObservers();
            }
            else
            {
                MessageBox.Show("Data cannot be deleted", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
        public void Attach(IDataChangedObserver observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
        }

        public void Detach(IDataChangedObserver observer)
        {
            if (observers.Contains(observer))
                observers.Remove(observer);
        }

        public async Task NotifyObservers()
        {
            foreach (var observer in observers)
            {
                await observer.RefreshData();
            }
        }

    }
}
