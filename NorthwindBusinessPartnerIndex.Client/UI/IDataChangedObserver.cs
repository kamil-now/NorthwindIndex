using System.Threading.Tasks;

namespace NorthwindBusinessPartnerIndex.Client.UI
{
    public interface IDataChangedObserver
    {
        Task RefreshData();
    }
}
