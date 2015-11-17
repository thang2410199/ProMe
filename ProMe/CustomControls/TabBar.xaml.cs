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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace ProMe.CustomControls
{
    public sealed partial class TabBar : UserControl
    {

        //TODO: Event for binding later in View
        //TODO: Dependency property for IsChecked


        public TabBar()
        {
            this.InitializeComponent();
            LeftBar.GroupName = RightBar.GroupName = Guid.NewGuid().ToString();
        }

        //public bool CurrentPostTab = true;

        private void RightBar_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //if (CurrentPostTab)
            //{
                //DoubleAnimation animation = new DoubleAnimation();
                //animation.From = RightBar.Width;
                //animation.To = LeftBar.Width;
                //animation.Duration = TimeSpan.FromMilliseconds(200);
                //animation.EnableDependentAnimation = true;
                ////QuadraticEase ease = new QuadraticEase();
                ////ease.EasingMode = EasingMode.EaseIn;
                ////animation.EasingFunction = ease;

                //DoubleAnimation animation1 = new DoubleAnimation();
                //animation1.From = LeftBar.Width;
                //animation1.To = RightBar.Width;
                //animation1.Duration = TimeSpan.FromMilliseconds(200);
                //animation1.EnableDependentAnimation = true;

                ////QuadraticEase ease1 = new QuadraticEase();
                ////ease1.EasingMode = EasingMode.EaseOut;
                ////animation1.EasingFunction = ease1;

                //Storyboard storyboard = new Storyboard();
                //Storyboard.SetTarget(animation, RightBar);
                //Storyboard.SetTargetProperty(animation, "Width");
                //storyboard.Children.Add(animation);

                //Storyboard.SetTarget(animation1, LeftBar);
                //Storyboard.SetTargetProperty(animation1, "Width");
                //storyboard.Children.Add(animation1);
                //storyboard.Begin();
                //CurrentPostTab = false;
            //}
        }

        private void LeftBar_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //if (!CurrentPostTab)
            //{
                //DoubleAnimation animation = new DoubleAnimation();
                //animation.From = RightBar.Width;
                //animation.To = LeftBar.Width;
                //animation.Duration = TimeSpan.FromMilliseconds(200);
                //animation.EnableDependentAnimation = true;
                ////QuadraticEase ease = new QuadraticEase();
                ////ease.EasingMode = EasingMode.EaseOut;
                ////animation.EasingFunction = ease;

                //DoubleAnimation animation1 = new DoubleAnimation();
                //animation1.From = LeftBar.Width;
                //animation1.To = RightBar.Width;
                //animation1.Duration = TimeSpan.FromMilliseconds(200);
                //animation1.EnableDependentAnimation = true;

                ////QuadraticEase ease1 = new QuadraticEase();
                ////ease1.EasingMode = EasingMode.EaseIn;
                ////animation1.EasingFunction = ease1;

                //Storyboard storyboard = new Storyboard();
                //Storyboard.SetTarget(animation, RightBar);
                //Storyboard.SetTargetProperty(animation, "Width");
                //storyboard.Children.Add(animation);

                //Storyboard.SetTarget(animation1, LeftBar);
                //Storyboard.SetTargetProperty(animation1, "Width");
                //storyboard.Children.Add(animation1);
                //storyboard.Begin();
                //CurrentPostTab = true;

            //}
        }
    }
}
