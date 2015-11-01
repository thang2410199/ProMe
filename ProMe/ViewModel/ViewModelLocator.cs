/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:ProMe"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using ProMe.View;
using Windows.Phone.UI.Input;

namespace ProMe.ViewModel
{

    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            //SimpleIoc.Default.Register<INavigationService>(() => navigationService);
            SimpleIoc.Default.Register<IDialogService, DialogService>();
            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<IntroViewModel>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<RestaurantDetailViewModel>();
            SimpleIoc.Default.Register<PromotionViewModel>();
            SimpleIoc.Default.Register<WalletViewModel>();
            SimpleIoc.Default.Register<SettingViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public RestaurantDetailViewModel RestaurantDetail
        {
            get
            {
                return ServiceLocator.Current.GetInstance<RestaurantDetailViewModel>();
            }
        }

        public PromotionViewModel Promotion
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PromotionViewModel>();
            }
        }

        public SettingViewModel Setting
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SettingViewModel>();
            }
        }

        public WalletViewModel Wallet
        {
            get
            {
                return ServiceLocator.Current.GetInstance<WalletViewModel>();
            }
        }

        public IntroViewModel Intro
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IntroViewModel>();
            }
        }

        //private INavigationService CreateNavigationService()
        //{
        //    var navigationService = new NavigationService();
        //    navigationService.Configure(Pages.MainPage.ToString(), typeof(MainPage));
        //    navigationService.Configure(Pages.RestaurantDetailPage.ToString(), typeof(RestaurantDetailPage));
        //    // navigationService.Configure("key2", typeof(OtherPage2));

        //    return navigationService;
        //}



        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }

    public enum Pages
    {
        Intro,
        MainPage,
        RestaurantDetailPage,
        Wallet,
        Promotion,
        Setting
    }
}