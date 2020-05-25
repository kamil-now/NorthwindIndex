using Caliburn.Micro;

namespace NorthwindBusinessPartnerIndex.Client.UI.ViewModels
{
    public class ShellViewModel : Screen
    {
        public MainViewModel MainView { get; }
        public ShellViewModel(MainViewModel mainView)
        {
            MainView = mainView;
        }
    }
}
