using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProMe.Model
{

    public class RestaurantGroup : ObservableCollection<Restaurant>
    {
        public RestaurantGroup(IEnumerable<Restaurant> items) : base(items)
        {
        }

        public string Header { get; set; }
    }

}
