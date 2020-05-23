using NorthwindBusinessPartnerIndex.Contracts.DataContracts;

namespace NorthwindBusinessPartnerIndex.Client.UI
{
    public interface ISelectedBusinessPartnerObserver
    {
        void UpdateSelectedContractor(IBusinessPartner selectedContractor);
    }
}
