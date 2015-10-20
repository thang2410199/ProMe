using System;
using GalaSoft.MvvmLight;

namespace ProMe.Model
{
    public class RestaurantImage : ObservableObject
    {
        public RestaurantImage()
        {

        }

        public RestaurantImage(string url)
        {
            Url = url;
        }

        public string Url { get; set; } = "";
    }
}