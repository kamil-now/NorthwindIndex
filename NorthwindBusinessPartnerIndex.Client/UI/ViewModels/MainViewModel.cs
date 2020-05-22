using Caliburn.Micro;
using NorthwindBusinessPartnerIndex.Client.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBusinessPartnerIndex.Client.UI.ViewModels
{
    public class MainViewModel : Screen
    {
        UnitOfWork unitOfWork;

        public BusinessPartnerListViewModel BusinessPartnerList { get; }
        public BusinessPartnerDataViewModel BusinessPartnerData { get; }
        public MainViewModel(
            UnitOfWork unitOfWork, 
            BusinessPartnerListViewModel contractorList, 
            BusinessPartnerDataViewModel contractorData)
        {
            this.unitOfWork = unitOfWork;

            BusinessPartnerList = contractorList;
            BusinessPartnerList.Attach(contractorData);
            BusinessPartnerData = contractorData;
        }
        public void ShowCustomers() => BusinessPartnerList.SetData(unitOfWork.CustomersService.GetAll().ToList());
        public void ShowShippers() => BusinessPartnerList.SetData(unitOfWork.ShippersService.GetAll().ToList());
        public void ShowSuppliers() => BusinessPartnerList.SetData(unitOfWork.SuppliersService.GetAll().ToList());
    }
}
