using System.Threading.Tasks;

namespace NorthwindBusinessPartnerIndex.Client.UI
{
    public interface IDataChangedSubject
    {
        void Attach(IDataChangedObserver observer);
        void Detach(IDataChangedObserver observer);
        Task NotifyObservers();
    }
}
