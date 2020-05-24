using Caliburn.Micro;
using NorthwindBusinessPartnerIndex.Client.Services;
using NorthwindBusinessPartnerIndex.Contracts.DataContracts;
using System.Collections.Generic;

namespace NorthwindBusinessPartnerIndex.Client.UI.ViewModels
{
    public class MainViewModel : Screen
    {
        public BusinessPartnerListViewModel BusinessPartnerList { get; }
        public BusinessPartnerDataViewModel BusinessPartnerData { get; }

        private readonly BusinessPartnerService _businessPartnerService;
        public MainViewModel(
            BusinessPartnerService service,
            BusinessPartnerListViewModel listView,
            BusinessPartnerDataViewModel dataView)
        {
            _businessPartnerService = service;

            BusinessPartnerList = listView;
            BusinessPartnerList.Attach(dataView);
            BusinessPartnerData = dataView;
            BusinessPartnerData.Attach(listView);
        }
        public async void ShowCustomers()
        {
            var data = _businessPartnerService.CustomersService.GetAll()
                .ContinueWith(task => (IList<IBusinessPartner>)task.Result);
            await BusinessPartnerList.SetData(data);
        }
        public async void ShowShippers()
        {
            var data = _businessPartnerService.ShippersService.GetAll()
                .ContinueWith(task => (IList<IBusinessPartner>)task.Result);;
            await BusinessPartnerList.SetData(data);
        }
        public async void ShowSuppliers()
        {
            var data = _businessPartnerService.SuppliersService.GetAll()
                .ContinueWith(task => (IList<IBusinessPartner>)task.Result);
            await BusinessPartnerList.SetData(data);
        }
    }
}
