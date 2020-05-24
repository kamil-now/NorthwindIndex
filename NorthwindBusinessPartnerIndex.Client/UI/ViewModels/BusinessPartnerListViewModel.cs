using Caliburn.Micro;
using NorthwindBusinessPartnerIndex.Contracts.DataContracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NorthwindBusinessPartnerIndex.Client.UI.ViewModels
{
    public class BusinessPartnerListViewModel : Screen, ISelectedBusinessPartnerSubject, IDataChangedObserver
    {
        private List<ISelectedBusinessPartnerObserver> observers = new List<ISelectedBusinessPartnerObserver>();
        private IBusinessPartner selectedBusinessPartner;

        public BindableCollection<IBusinessPartner> Data { get; set; } = new BindableCollection<IBusinessPartner>();
        public IBusinessPartner SelectedBusinessPartner
        {
            get => selectedBusinessPartner;
            set
            {
                selectedBusinessPartner = value;
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
            if (!observers.Contains(observer))
                observers.Add(observer);
        }

        public void Detach(ISelectedBusinessPartnerObserver observer)
        {
            if (observers.Contains(observer))
                observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            observers.ForEach(n => n.SetBusinessPartner(SelectedBusinessPartner));
        }

    }
}
