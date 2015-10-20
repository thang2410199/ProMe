using System;
using GalaSoft.MvvmLight;
using Windows.UI.Xaml.Navigation;
using GalaSoft.MvvmLight.Command;

namespace ProMe.ViewModel
{
    public class IntroViewModel : ViewModelBase, INavigable
    {
        public RelayCommand FB_LoginCommand { get; set; }
        public RelayCommand LoginCommand { get; set; }

        public IntroViewModel()
        {
            LoginCommand = new RelayCommand(Login);
            FB_LoginCommand = new RelayCommand(FB_Login);
        }

        private void FB_Login()
        {
            NavigationService.NavigateTo(Pages.MainPage);
        }

        private void Login()
        {
            NavigationService.NavigateTo(Pages.MainPage);
        }

        public bool AllowGoBack()
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationEventArgs e)
        {
            
        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {
            
        }

        public void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            
        }
    }
}