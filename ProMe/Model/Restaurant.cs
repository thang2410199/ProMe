using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ProMe.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProMe.Model
{
    public class Restaurant : ObservableObject
    {


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


        public RelayCommand ViewDetailCommand { get; set; }
        Action ViewDetailAction;

        public Restaurant()
        {
            ViewDetailAction = new Action(ViewDetail);
            ViewDetailCommand = new RelayCommand(ViewDetailAction);

            Name = Guid.NewGuid().ToString();
        }

        private void ViewDetail()
        {
            NavigationService.NavigateTo(Pages.RestaurantDetailPage);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
