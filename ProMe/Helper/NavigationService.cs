using ProMe.View;
using ProMe.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace ProMe
{
    public static class NavigationService
    {
        public static Dictionary<Pages, Type> PageDictionary = new Dictionary<Pages, Type>();
        public static Frame MainFrame;
        public static void Configure(Frame frame)
        {
            PageDictionary.Add(Pages.MainPage, typeof(MainPage));
            PageDictionary.Add(Pages.RestaurantDetailPage, typeof(RestaurantDetailPage));

            MainFrame = frame;
        }

        internal static void GoBack()
        {
            if (MainFrame.CanGoBack)
                MainFrame.GoBack();
        }

        internal static bool CanGoBack
        {
            get
            {

                return MainFrame.CanGoBack;
            }
        }

        internal static void NavigateTo(Pages page)
        {
            MainFrame.Navigate(PageDictionary[page]);
        }
        internal static void NavigateTo(Pages page, object parameter)
        {
            MainFrame.Navigate(PageDictionary[page], parameter);

        }
    }
}
