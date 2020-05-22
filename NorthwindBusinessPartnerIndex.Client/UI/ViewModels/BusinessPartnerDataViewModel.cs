using Caliburn.Micro;
using NorthwindBusinessPartnerIndex.Client.API;
using NorthwindBusinessPartnerIndex.Contracts.Data.Models;

namespace NorthwindBusinessPartnerIndex.Client.UI.ViewModels
{
    public class BusinessPartnerDataViewModel : Screen, ISelectedBusinessPartnerObserver
    {
        public IDataEntity SelectedBusinessPartner { get; private set; }
        private readonly UnitOfWork _unitOfWork;
        public BusinessPartnerDataViewModel(UnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public void UpdateSelectedContractor(IDataEntity selectedBusinessPartner)
        {
            SelectedBusinessPartner = selectedBusinessPartner;
            NotifyOfPropertyChange(() => SelectedBusinessPartner);
        }
        public void Save()
        {
            _unitOfWork.AddOrUpdateAndCommit(SelectedBusinessPartner);
        }
        public void New()
        {
            switch (SelectedBusinessPartner)
            {
                case Customer x: SelectedBusinessPartner = new Customer(); break;
                case Shipper x: SelectedBusinessPartner = new Shipper(); break;
                case Supplier x: SelectedBusinessPartner = new Supplier(); break;
                default: break;
            }
            NotifyOfPropertyChange(() => SelectedBusinessPartner);
        }

    }
}
