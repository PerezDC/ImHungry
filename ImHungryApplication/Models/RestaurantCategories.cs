using System;
using System.Collections.Generic;

namespace ImHungryApp.Models
{
    public partial class RestaurantCategories
    {
        public RestaurantCategories()
        {
            PrefCategories = new HashSet<PrefCategories>();
            Restaurants = new HashSet<Restaurants>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<PrefCategories> PrefCategories { get; set; }
        public virtual ICollection<Restaurants> Restaurants { get; set; }
    }
}
