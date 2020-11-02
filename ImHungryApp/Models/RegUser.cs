using System;
using System.Collections.Generic;

namespace ImHungryApp.Models
{
    public partial class RegUser
    {
        public RegUser()
        {
            PrefCategories = new HashSet<PrefCategories>();
            VisitedRestaurant = new HashSet<VisitedRestaurant>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public int? SearchRadius { get; set; }

        public virtual ICollection<PrefCategories> PrefCategories { get; set; }
        public virtual ICollection<VisitedRestaurant> VisitedRestaurant { get; set; }
    }
}
