using Caliburn.Micro;
using NorthwindBusinessPartnerIndex.Client.Services;

namespace NorthwindBusinessPartnerIndex.Client.UI.ViewModels
{
    public class ShellViewModel : Screen
    {
        public MainViewModel MainView { get; }
        public ShellViewModel(BusinessPartnerService service, MainViewModel mainView)
        {
            MainView = mainView;
        }
    }
}
