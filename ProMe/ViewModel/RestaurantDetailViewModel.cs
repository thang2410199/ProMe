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

        public RelayCommand GoBackCommand { get; set; }


        private void GoBack()
        {
            if (AllowGoBack())
            {
                NavigationService.GoBack();
            }
        }
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
                CurrentRestaurant.Images.Add(new RestaurantImage("ms-appx:///Assets/Demo/deal_1.jpg"));
                CurrentRestaurant.Images.Add(new RestaurantImage("ms-appx:///Assets/Demo/deal_2.jpg"));
                CurrentRestaurant.Images.Add(new RestaurantImage("ms-appx:///Assets/Demo/deal_3.jpg"));
                CurrentRestaurant.Images.Add(new RestaurantImage("ms-appx:///Assets/Demo/deal_4.jpg"));

                CurrentRestaurant.Hashtags.Add("#viewdep");
                CurrentRestaurant.Hashtags.Add("#wifimanh");
                CurrentRestaurant.Hashtags.Add("#tradao");
                CurrentRestaurant.Hashtags.Add("#yentinh");

                CurrentRestaurant.Description = "Prevailed sincerity behaviour to so do principle mr. As departure at no propriety zealously my.";
            }
            GoBackCommand = new RelayCommand(GoBack);
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
                CurrentRestaurant.Images.Add(new RestaurantImage("ms-appx:///Assets/Demo/deal_1.jpg"));
                CurrentRestaurant.Images.Add(new RestaurantImage("ms-appx:///Assets/Demo/deal_2.jpg"));
                CurrentRestaurant.Images.Add(new RestaurantImage("ms-appx:///Assets/Demo/deal_3.jpg"));
                CurrentRestaurant.Images.Add(new RestaurantImage("ms-appx:///Assets/Demo/deal_4.jpg"));

                CurrentRestaurant.Hashtags.Add("#viewdep");
                CurrentRestaurant.Hashtags.Add("#wifimanh");
                CurrentRestaurant.Hashtags.Add("#tradao");
                CurrentRestaurant.Hashtags.Add("#yentinh");

                CurrentRestaurant.Description = "Prevailed sincerity behaviour to so do principle mr. As departure at no propriety zealously my.";
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
