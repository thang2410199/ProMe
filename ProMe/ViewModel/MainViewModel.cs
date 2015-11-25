using System;
using GalaSoft.MvvmLight;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using ProMe.Model;
using Windows.UI.Xaml.Controls;
using System.Collections.Generic;
using Windows.UI.Xaml.Media;
using Windows.UI;
using GalaSoft.MvvmLight.Messaging;
using ProMe.Message;
using System.Linq;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml;
using GalaSoft.MvvmLight.Command;
using ProMe.View.Cell;

namespace ProMe.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase, INavigable
    {
        private string _PageTitle = "Hello World";
        double ScreenWidth = 100;
        //double ScreenWidth = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBounds.Width;
        public string PageTitle
        {
            get
            {
                return _PageTitle;
            }
            set
            {
                Set(() => PageTitle, ref _PageTitle, value);
            }
        }

        List<RestaurantCell> ListCard;
        Grid CardCanvas;

        public RelayCommand SwipeTestCommand { get; set; }

        public RelayCommand GoToPromotionCommand { get; set; }

        public RelayCommand GoToSettingCommand { get; set; }

        public ObservableCollection<Restaurant> Restaurants { get; set; }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            if (IsInDesignMode)
            {
                //    // Code runs in Blend --> create design time data.
                //    PageTitle = "Hello Designer";

                //    Restaurants.Add(new Restaurant() { Name = "Dai Phi" });
            }
            else
            {
                // Code runs "for real"
                ScreenWidth = DesignValue.ScreenWidth;
            }

            Restaurants = new ObservableCollection<Restaurant>();

            SwipeTestCommand = new RelayCommand(SwipeTest);
            GoToPromotionCommand = new RelayCommand(GoToPromotion);
            GoToSettingCommand = new RelayCommand(GoToSetting);

            Messenger.Default.Register<MainPageMessage>(this, ReceiveMessage);
        }

        private void GoToSetting()
        {
            NavigationService.NavigateTo(Pages.Setting);
        }

        private void GoToPromotion()
        {
            NavigationService.NavigateTo(Pages.Promotion);
        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {



        }

        private void ReceiveMessage(MainPageMessage e)
        {
            CardCanvas = e.CardStack;
            ListCard = new List<RestaurantCell>();
            Random rand = new Random();
            var Names = new List<string>()
            {
                "BookCoffee",
                "Bún Cô Ba",
                "KFC",
                "Pizza Hut",
                "Yuyumi"
            };
            for (int i = 1; i <= 5; i++)
            {
                RestaurantCell border = new RestaurantCell();
                var data = new Restaurant();
                data.Name = Names[i - 1];

                data.DealImage = "/Assets/Demo/deal_" + i.ToString() + ".jpg";
                data.FriendRate = rand.Next(9);
                border.DataContext = data;
                border.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Stretch;
                //border.ManipulationMode = Windows.UI.Xaml.Input.ManipulationModes.All;
                border.RenderTransformOrigin = new Windows.Foundation.Point(0.5, 4);
                var transform = new CompositeTransform();
                border.RenderTransform = transform;
                border.IsHitTestVisible = false;
                border.ManipulationDelta += Border_ManipulationDelta;
                border.ManipulationCompleted += Border_ManipulationCompleted;
                transform.TranslateY = (5 - i);
                transform.ScaleX = transform.ScaleY = 1 - ((double)(((5 - i) * 2)) / 100D) / 6;
                //border.Margin = new Windows.UI.Xaml.Thickness(0, (5 - i) * 5, 0, 0);
                //border.SetBackground(new SolidColorBrush(Color.FromArgb(255, (byte)rand.Next(0, 255), (byte)rand.Next(0, 255), (byte)rand.Next(0, 255))));
                Canvas.SetZIndex(border, (int)i);
                ListCard.Add(border);
                CardCanvas.Children.Add(border);
            }

            ListCard.LastOrDefault().IsHitTestVisible = true;
        }

        private void Border_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            var transform = (sender as FrameworkElement).RenderTransform as CompositeTransform;
            if (Math.Abs(transform.Rotation) < 10)
            {
                DoubleAnimation animation = new DoubleAnimation();
                animation.From = transform.Rotation;
                animation.To = 0;
                animation.Duration = TimeSpan.FromMilliseconds(400);
                QuadraticEase ease = new QuadraticEase();
                ease.EasingMode = EasingMode.EaseOut;
                animation.EasingFunction = ease;

                Storyboard storyboard = new Storyboard();
                Storyboard.SetTarget(animation, transform);
                Storyboard.SetTargetProperty(animation, "Rotation");
                storyboard.Children.Add(animation);
                storyboard.Begin();
            }
            else
            {
                //TODO Animate the card to left or right depend on the current position, maximum 200
                if (transform.Rotation > 0)
                    Swipe(transform, 100);
                else
                    Swipe(transform, 100, false);

            }
        }

        private void Swipe(CompositeTransform transform, double Milisecs, bool IsRight = true)
        {
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = transform.Rotation;
            animation.To = IsRight ? 30 : -30;
            animation.Duration = TimeSpan.FromMilliseconds(Milisecs);
            QuadraticEase ease = new QuadraticEase();
            ease.EasingMode = EasingMode.EaseOut;
            animation.EasingFunction = ease;

            Storyboard storyboard = new Storyboard();
            Storyboard.SetTarget(animation, transform);
            Storyboard.SetTargetProperty(animation, "Rotation");
            storyboard.Children.Add(animation);
            storyboard.Completed += Storyboard_Completed;
            storyboard.Begin();

            var Wallet = (new ViewModelLocator()).Wallet;
            var current_res = ListCard.LastOrDefault().DataContext as Restaurant;
            var res = Wallet.Restaurants.Where(r => r.Name == current_res.Name).FirstOrDefault();
            if (res == null)
            {

                if (IsRight)
                {
                    //Move to quán ruột
                    Wallet.Restaurants.Add(current_res);
            }
                else
                {

                }
            }
        }

        private void Storyboard_Completed(object sender, object e)
        {
            SwapTopToBottom();
        }

        private void Border_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            var transform = (sender as FrameworkElement).RenderTransform as CompositeTransform;
            transform.Rotation += (e.Delta.Translation.X / ScreenWidth) * 16;
            if (Math.Abs(transform.Rotation) > 15)
                e.Complete();
        }

        private void Border_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {

        }

        private void SwipeTest()
        {
            Random rand = new Random();
            var transform = ListCard[ListCard.Count - 1].RenderTransform as CompositeTransform;
            Swipe(transform, 1000, rand.Next(1) > 0 ? true : false);
        }

        public void SwapTopToBottom()
        {
            if (ListCard == null || ListCard.Count == 0)
                return;

            var bottom = ListCard.LastOrDefault();
            var transform = bottom.RenderTransform as CompositeTransform;
            bottom.IsHitTestVisible = false;
            ListCard.Remove(bottom);
            ListCard.Insert(0, bottom);

            for (int i = 1; i <= ListCard.Count; i++)
            {
                //ListCard[i - 1].Margin = new Windows.UI.Xaml.Thickness(0, (ListCard.Count - i) * 5, 0, 0);
                var tempTransform = ListCard[i - 1].RenderTransform as CompositeTransform;
                tempTransform.TranslateY = (ListCard.Count - i);
                tempTransform.ScaleX = tempTransform.ScaleY = 1 - ((double)(ListCard.Count - i) * 2D) / 100D / 6D;

                Canvas.SetZIndex(ListCard[i - 1], i);
                ListCard[i - 1].Tag = i;
            }
            ListCard[ListCard.Count - 1].IsHitTestVisible = true;
            transform.Rotation = 0;
        }

        public void OnNavigatedFrom(NavigationEventArgs e)
        {

        }

        public bool AllowGoBack()
        {
            return true;
        }

        public void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            if (!AllowGoBack())
            {
                e.Cancel = true;
            }
        }
    }
}