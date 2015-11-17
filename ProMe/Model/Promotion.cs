using GalaSoft.MvvmLight;

namespace ProMe.Model
{
    public class Promotion : ObservableObject
    {
        int _FriendRate = 0;
        public int FriendRate
        {
            get
            {
                return _FriendRate;
            }
            set
            {
                Set(ref _FriendRate, value);
            }
        }

        string _Name = "";
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                Set(ref _Name, value);
            }
        }

        string _Address = "";
        public string Address
        {
            get
            {
                return _Address;
            }
            set
            {
                Set(ref _Address, value);
            }
        }

        string _Logo = "";
        public string Logo
        {
            get
            {
                return _Logo;
            }
            set
            {
                Set(ref _Logo, value);
            }
        }

        string _Picture = "";
        public string Picture
        {
            get
            {
                return _Picture;
            }
            set
            {
                Set(ref _Picture, value);
            }
        }

        string _TimeLeft = "";
        public string TimeLeft
        {
            get
            {
                return _TimeLeft;
            }
            set
            {
                Set(ref _TimeLeft, value);
            }
        }

    }
}