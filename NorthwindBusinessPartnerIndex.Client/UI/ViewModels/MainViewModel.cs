using Caliburn.Micro;
using NorthwindBusinessPartnerIndex.Client.Services;
using System.Linq;

namespace NorthwindBusinessPartnerIndex.Client.UI.ViewModels
{
    public class MainViewModel : Screen
    {
        AggregateService unitOfWork;

        public BusinessPartnerListViewModel BusinessPartnerList { get; }
        public BusinessPartnerDataViewModel BusinessPartnerData { get; }
        public MainViewModel(
            AggregateService unitOfWork,
            BusinessPartnerListViewModel contractorList,
            BusinessPartnerDataViewModel contractorData)
        {
            this.unitOfWork = unitOfWork;

            BusinessPartnerList = contractorList;
            BusinessPartnerList.Attach(contractorData);
            BusinessPartnerData = contractorData;
        }
        public void ShowCustomers() => BusinessPartnerList.SetData(unitOfWork.CustomersService.GetAll()?.ToList());
        public void ShowShippers() => BusinessPartnerList.SetData(unitOfWork.ShippersService.GetAll().ToList());
        public void ShowSuppliers() => BusinessPartnerList.SetData(unitOfWork.SuppliersService.GetAll().ToList());
    }
}
