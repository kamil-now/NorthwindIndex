using Caliburn.Micro;
using NorthwindBusinessPartnerIndex.Client.Services;

namespace NorthwindBusinessPartnerIndex.Client.UI.ViewModels
{
    public class MainViewModel : Screen
    {
        public BusinessPartnerListViewModel BusinessPartnerList { get; }
        public BusinessPartnerDataViewModel BusinessPartnerData { get; }

        private readonly BusinessPartnerService _businessPartnerService;
        public MainViewModel(
            BusinessPartnerService service,
            BusinessPartnerListViewModel contractorList,
            BusinessPartnerDataViewModel contractorData)
        {
            _businessPartnerService = service;

            BusinessPartnerList = contractorList;
            BusinessPartnerList.Attach(contractorData);
            BusinessPartnerData = contractorData;
        }
        public async void ShowCustomers()
        {
            var data = await _businessPartnerService.CustomersService.GetAll();
            BusinessPartnerList.SetData(data);
        }
        public async void ShowShippers()
        {
            var data = await _businessPartnerService.ShippersService.GetAll();
            BusinessPartnerList.SetData(data);
        }
        public async void ShowSuppliers()
        {
            var data = await _businessPartnerService.SuppliersService.GetAll();
            BusinessPartnerList.SetData(data);
        }
    }
}
