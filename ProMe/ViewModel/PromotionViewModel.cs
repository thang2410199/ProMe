using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;

namespace ProMe.ViewModel
{
    public class PromotionViewModel : ViewModelBase, INavigable
    {
        public RelayCommand GoToWalletCommand { get; set; }
        public RelayCommand GoBackCommand { get; set; }

        public PromotionViewModel()
        {
            GoToWalletCommand = new RelayCommand(GoToWallet);
            GoBackCommand = new RelayCommand(GoBack);
        }

        private void GoBack()
        {
            if (AllowGoBack())
            {
                NavigationService.GoBack();
            }
        }

        private void GoToWallet()
        {
            NavigationService.NavigateTo(Pages.Wallet);
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
