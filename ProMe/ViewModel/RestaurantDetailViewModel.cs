using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using ProMe.Message;
using ProMe.Model;
using ProMe.View.Cell;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace ProMe.ViewModel
{
    public class RestaurantDetailViewModel : ViewModelBase, INavigable
    {
        public RestaurantDetailViewModel()
        {

        }

        public bool AllowGoBack()
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationEventArgs e)
        {
            
        }

        public async void OnNavigatedTo(NavigationEventArgs e)
        {
            MessageDialog dialog = new MessageDialog("entered");
            await dialog.ShowAsync();
        }

        public void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Back && !AllowGoBack())
            {
                e.Cancel = true;
            }
        }
    }
}
