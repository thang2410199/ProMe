using GalaSoft.MvvmLight.Messaging;
using ProMe.Message;
using ProMe.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace ProMe
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : BindablePage
    {

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

           
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Back)
                return;
            var msg = new MainPageMessage();
            msg.CardStack = CardStack;
            Messenger.Default.Send<MainPageMessage>(msg);
            base.OnNavigatedTo(e);
        }

        private void Border_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            //if(Math.Abs(transformD.Rotation) < 10)
            //{
            //    DoubleAnimation animation = new DoubleAnimation();
            //    animation.From = transformD.Rotation;
            //    animation.To = 0;
            //    animation.Duration = TimeSpan.FromMilliseconds(400);
            //    QuadraticEase ease = new QuadraticEase();
            //    ease.EasingMode = EasingMode.EaseOut;
            //    animation.EasingFunction = ease;

            //    Storyboard storyboard = new Storyboard();
            //    Storyboard.SetTarget(animation, transformD);
            //    Storyboard.SetTargetProperty(animation, "Rotation");
            //    storyboard.Children.Add(animation);
            //    storyboard.Begin();
            //}
            //else
            //{
            //    UpperCardRT.IsHitTestVisible = false;
            //    UnderCardRT.IsHitTestVisible = false;

            //    //TODO Animate the card to left or right depend on the current position, maximum 200
            //    DoubleAnimation animation = new DoubleAnimation();
            //    animation.From = transformD.Rotation;
            //    animation.To = transformD.Rotation > 0 ? 90 : -90;
            //    animation.Duration = TimeSpan.FromMilliseconds(400);
            //    QuadraticEase ease = new QuadraticEase();
            //    ease.EasingMode = EasingMode.EaseOut;
            //    animation.EasingFunction = ease;

            //    Storyboard storyboard = new Storyboard();
            //    Storyboard.SetTarget(animation, transformD);
            //    Storyboard.SetTargetProperty(animation, "Rotation");
            //    storyboard.Children.Add(animation);
            //    storyboard.Completed += Storyboard_Completed;
            //    storyboard.Begin();

            //}
        }
    }
}
