using System;
using GalaSoft.MvvmLight;
using Windows.UI.Xaml.Navigation;
using GalaSoft.MvvmLight.Command;
using System.Diagnostics;

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

        private async void FB_Login()
        {
            App.SocialAuthentication.AuthenSuccessed += SocialAuthentication_AuthenSuccessed;
            await App.SocialAuthentication.AuthenFacebook();
            
        }

        private void SocialAuthentication_AuthenSuccessed(string accessToken)
        {
            App.SocialAuthentication.AuthenSuccessed -= SocialAuthentication_AuthenSuccessed;
            Debug.WriteLine(accessToken);
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