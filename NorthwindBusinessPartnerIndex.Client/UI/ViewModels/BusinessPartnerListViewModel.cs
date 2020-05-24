using Caliburn.Micro;
using NorthwindBusinessPartnerIndex.Contracts.DataContracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NorthwindBusinessPartnerIndex.Client.UI.ViewModels
{
    public class BusinessPartnerListViewModel : Screen, ISelectedBusinessPartnerSubject, IDataChangedObserver
    {
        private readonly List<ISelectedBusinessPartnerObserver> _observers = new List<ISelectedBusinessPartnerObserver>();
        private IBusinessPartner _selectedBusinessPartner;

        public BindableCollection<IBusinessPartner> Data { get; set; } = new BindableCollection<IBusinessPartner>();
        public IBusinessPartner SelectedBusinessPartner
        {
            get => _selectedBusinessPartner;
            set
            {
                _selectedBusinessPartner = value;
                NotifyObservers();
            }
        }
        private Task<IList<IBusinessPartner>> _fetchData;

        public async Task RefreshData()
        {
            if(_fetchData is null)
            {
                return;
            }
            var newData = await _fetchData;
            if(newData is null)
            {
                return;
            }
            Data = new BindableCollection<IBusinessPartner>(newData);
            NotifyOfPropertyChange(() => Data);
            Data.Refresh();
        }
        public async Task SetData(Task<IList<IBusinessPartner>> fetchData)
        {
            _fetchData = fetchData;
            await RefreshData();
        }
        public void Attach(ISelectedBusinessPartnerObserver observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);
        }

        public void Detach(ISelectedBusinessPartnerObserver observer)
        {
            if (_observers.Contains(observer))
                _observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            _observers.ForEach(n => n.SetBusinessPartner(SelectedBusinessPartner));
        }

    }
}
