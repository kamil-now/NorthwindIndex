namespace NorthwindBusinessPartnerIndex.Client.UI
{
    public interface ISelectedBusinessPartnerSubject
    {
        void Attach(ISelectedBusinessPartnerObserver observer);
        void Detach(ISelectedBusinessPartnerObserver observer);
        void NotifyObservers();
    }
}
