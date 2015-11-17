using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ProMe.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;

namespace ProMe.ViewModel
{
    public class WalletViewModel : ViewModelBase, INavigable
    {
        public RelayCommand GoBackCommand { get; set; }
        public RelayCommand ShowPromotionCommand { get; set; }
        public RelayCommand ShowRestaurantCommand { get; set; }

        bool _PromotionDisplay = true;
        public bool PromotionDisplay
        {
            get
            {
                return _PromotionDisplay;
            }
            set
            {
                if (value)
                    TabIndex = 0;
                else
                    TabIndex = 1;
                Set(ref _PromotionDisplay, value);
            }
        }

        int _TabIndex = 0;
        public int TabIndex
        {
            get
            {
                return _TabIndex;
            }
            set
            {
                Set(ref _TabIndex, value);
            }
        }

        public ObservableCollection<Promotion> Promotions { get; set; } = new ObservableCollection<Promotion>();

        public List<Restaurant> Restaurants = new List<Restaurant>();

        public ObservableCollection<RestaurantGroup> RestaurantGroups { get; set; } = new ObservableCollection<RestaurantGroup>();

        public WalletViewModel()
        {
            GoBackCommand = new RelayCommand(GoBack);
            ShowPromotionCommand = new RelayCommand(ShowPromotion);
            ShowPromotionCommand = new RelayCommand(ShowRestaurant);


            Promotions.Add(new Promotion() { Name = "Starbucks coffee", Address= "86-88 Cao Thang, Q.3", TimeLeft = "00:37:40", FriendRate = 6 });
            Promotions.Add(new Promotion());

            Restaurants.Add(new Restaurant() { Name = "An Nam Quán" });
            Restaurants.Add(new Restaurant() { Name = "Burger King" });
            Restaurants.Add(new Restaurant() { Name = "A Bửu Sài Gòn" });
            Restaurants.Add(new Restaurant() { Name = "BookCoffee" });
            Restaurants.Add(new Restaurant() { Name = "Crowed store" });
            Restaurants.Add(new Restaurant() { Name = "Dictator" });
            Restaurants.Add(new Restaurant() { Name = "Elfest" });
            Restaurants.Add(new Restaurant() { Name = "DungaRonpa" });
            Restaurants.Add(new Restaurant() { Name = "Fnatic" });

            Restaurants.Sort();

            var groups =
                from item in Restaurants
                group item by item.GroupHeader into groupItem
                select new RestaurantGroup(groupItem)
                {
                    Header = groupItem.Key
                };
            foreach (var item in groups)
            {
                RestaurantGroups.Add(item);
            }
        }

        private void ShowRestaurant()
        {
        }

        private void ShowPromotion()
        {
        }

        private void GoBack()
        {
            if (AllowGoBack())
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
