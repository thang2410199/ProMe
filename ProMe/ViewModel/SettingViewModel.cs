using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ProMe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;

namespace ProMe.ViewModel
{
    public class SettingViewModel : ViewModelBase, INavigable
    {

        public RelayCommand GoBackCommand { get; set; }

        public User User { get; set; } = new User() { Username = "Kerr"};

        public SettingViewModel()
        {
            GoBackCommand = new RelayCommand(GoBack);
        }

        private void GoBack()
        {
            if(AllowGoBack())
            {
                NavigationService.GoBack();
            }
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
