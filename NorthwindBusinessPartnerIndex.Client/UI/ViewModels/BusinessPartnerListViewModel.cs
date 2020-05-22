using Caliburn.Micro;
using NorthwindBusinessPartnerIndex.Contracts.Data.Models;
using System.Collections.Generic;

namespace NorthwindBusinessPartnerIndex.Client.UI.ViewModels
{
    public class BusinessPartnerListViewModel : Screen, ISelectedBusinessPartnerSubject
    {
        List<ISelectedBusinessPartnerObserver> observers = new List<ISelectedBusinessPartnerObserver>();
        private IDataEntity selectedContractor;

        public BindableCollection<IDataEntity> Data { get; set; } = new BindableCollection<IDataEntity>();
        public IDataEntity SelectedContractor
        {
            get => selectedContractor;
            set
            {
                selectedContractor = value;
                NotifyObservers();
            }
        }


        public void SetData(IEnumerable<IDataEntity> newData)
        {
            Data = new BindableCollection<IDataEntity>(newData);
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
            observers.ForEach(n => n.UpdateSelectedContractor(SelectedContractor));
        }

    }
}
