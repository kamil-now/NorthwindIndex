using Caliburn.Micro;
using NorthwindBusinessPartnerIndex.Client.API;

namespace NorthwindBusinessPartnerIndex.Client.UI.ViewModels
{
    public class ShellViewModel : Screen
    {
        public MainViewModel MainView { get; }
        public ShellViewModel(UnitOfWork unitOfWork, MainViewModel mainView)
        {
            MainView = mainView;
        }
    }
}
