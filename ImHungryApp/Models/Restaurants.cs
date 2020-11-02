using System;
using System.Collections.Generic;

namespace ImHungryApp.Models
{
    public partial class Restaurants
    {
        public Restaurants()
        {
            VisitedRestaurant = new HashSet<VisitedRestaurant>();
        }

        public int RestId { get; set; }
        public int CategoryId { get; set; }
        public string RestName { get; set; }
        public string RestAddress { get; set; }
        public string RestCity { get; set; }
        public int? RestZipcode { get; set; }
        public string RestCountry { get; set; }
        public string RestPhone { get; set; }

        public virtual RestaurantCategories Category { get; set; }
        public virtual ICollection<VisitedRestaurant> VisitedRestaurant { get; set; }
    }
}
