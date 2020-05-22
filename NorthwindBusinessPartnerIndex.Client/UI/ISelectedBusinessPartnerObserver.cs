using NorthwindBusinessPartnerIndex.Contracts.Data.Models;

namespace NorthwindBusinessPartnerIndex.Client.UI
{
    public interface ISelectedBusinessPartnerObserver
    {
        void UpdateSelectedContractor(IDataEntity selectedContractor);
    }
}
