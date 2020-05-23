using Caliburn.Micro;
using NorthwindBusinessPartnerIndex.Contracts.DataContracts;
using System.Collections.Generic;

namespace NorthwindBusinessPartnerIndex.Client.UI.ViewModels
{
    public class BusinessPartnerListViewModel : Screen, ISelectedBusinessPartnerSubject
    {
        List<ISelectedBusinessPartnerObserver> observers = new List<ISelectedBusinessPartnerObserver>();
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


        public void SetData(IEnumerable<IBusinessPartner> newData)
        {
            if (newData is null)
                return;
            Data = new BindableCollection<IBusinessPartner>(newData);
            NotifyOfPropertyChange(() => Data);
            Data.Refresh();
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
            observers.ForEach(n => n.UpdateSelectedContractor(SelectedBusinessPartner));
        }

    }
}
