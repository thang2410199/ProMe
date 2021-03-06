﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ProMe.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProMe.Model
{
    public class Restaurant : ObservableObject, IComparable
    {
        private string _Description = "";
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                Set(ref _Description, value);
            }
        }

        private int _FriendRate = 0;

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

        private string _Name = "";

        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                Set(() => Name, ref _Name, value);
            }
        }

        private string _Address = "";
        public string Address
        {
            get
            {
                return _Address;
            }
            set
            {
                Set(() => Address, ref _Address, value);
            }
        }
        string _DealImage = "";
        public string DealImage
        {
            get
            {
                return _DealImage;
            }
            set
            {
                Set(() => DealImage, ref _DealImage, value);
            }
        }

        public string GroupHeader
        {
            get
            {
                if (string.IsNullOrEmpty(Name))
                    return "";
                else
                    return Name[0].ToString().ToUpper();
            }
        }

        public ObservableCollection<RestaurantImage> Images { get; set; } = new ObservableCollection<RestaurantImage>();
        public ObservableCollection<string> Hashtags { get; set; } = new ObservableCollection<string>();


        public RelayCommand ViewDetailCommand { get; set; }
        Action ViewDetailAction;

        public Restaurant()
        {
            ViewDetailAction = new Action(ViewDetail);
            ViewDetailCommand = new RelayCommand(ViewDetailAction);

            Name = Guid.NewGuid().ToString();
            Address = "86-83 Cao Thang, Q3";
        }

        private async void ViewDetail()
        {
            await Task.Delay(200);
            NavigationService.NavigateTo(Pages.RestaurantDetailPage, this);
        }

        public override string ToString()
        {
            return Name;
        }

        public int CompareTo(object obj)
        {
            Restaurant res = obj as Restaurant;
            return String.Compare(this.Name, res.Name);

        }
    }
}
