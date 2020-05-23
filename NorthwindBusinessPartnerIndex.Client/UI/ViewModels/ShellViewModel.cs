using Caliburn.Micro;
using NorthwindBusinessPartnerIndex.Client.Services;

namespace NorthwindBusinessPartnerIndex.Client.UI.ViewModels
{
    public class ShellViewModel : Screen
    {
        public MainViewModel MainView { get; }
        public ShellViewModel(AggregateService service, MainViewModel mainView)
        {
            MainView = mainView;
        }
    }
}
