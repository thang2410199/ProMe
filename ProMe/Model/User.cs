using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProMe.Model
{
    public class User : ObservableObject
    {
        private string _Avatar = "ms-appx:///Assets/Demo/Avatar.png";

        public string Avatar
        {
            get
            {
                return _Avatar;
            }
            set
            {
                Set(ref _Avatar, value);
            }
        }

        private string _Username = "";

        /// <summary>
        /// Sets and gets the Username property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Username
        {
            get
            {
                return _Username;
            }

            set
            {
                Set(ref _Username, value);
            }
        }
    }
}
