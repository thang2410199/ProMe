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
        private Restaurant _CurrentRestaurant = null;
        public Restaurant CurrentRestaurant
        {
            get
            {
                return _CurrentRestaurant;
            }
            set
            {
                Set<Restaurant>(ref _CurrentRestaurant, value);
            }
        }

        public RelayCommand OpenRestaurantCommand { get; set; } = new RelayCommand(OpenRestaurant);

        private static void OpenRestaurant()
        {
            NavigationService.NavigateTo(Pages.RestaurantDetailPage, new Restaurant());
        }

        public double ScreenWidth
        {
            get
            {
                if (IsInDesignMode)
                    return 300;
                else
                    return DesignValue.ScreenWidth;
            }
        }
        public RestaurantDetailViewModel()
        {
            if (IsInDesignMode)
            {
                CurrentRestaurant = new Restaurant();
                CurrentRestaurant.Images.Add(new RestaurantImage("test 1"));
                CurrentRestaurant.Images.Add(new RestaurantImage("test 2"));
                CurrentRestaurant.Images.Add(new RestaurantImage("test 3"));
                CurrentRestaurant.Images.Add(new RestaurantImage("test 4"));

                CurrentRestaurant.Hashtags.Add("#viewdep");
                CurrentRestaurant.Hashtags.Add("#wifimanh");
                CurrentRestaurant.Hashtags.Add("#tradao");
                CurrentRestaurant.Hashtags.Add("#yentinh");
            }
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
            CurrentRestaurant = e.Parameter as Restaurant;
            //TEST DATA
            if (CurrentRestaurant.Images.Count == 0)
            {
                CurrentRestaurant.Images.Add(new RestaurantImage("test 1"));
                CurrentRestaurant.Images.Add(new RestaurantImage("test 2"));
                CurrentRestaurant.Images.Add(new RestaurantImage("test 3"));
                CurrentRestaurant.Images.Add(new RestaurantImage("test 4"));

                CurrentRestaurant.Hashtags.Add("#viewdep");
                CurrentRestaurant.Hashtags.Add("#wifimanh");
                CurrentRestaurant.Hashtags.Add("#tradao");
                CurrentRestaurant.Hashtags.Add("#yentinh");
            }

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
