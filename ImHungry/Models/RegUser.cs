using System;
using System.Collections.Generic;

namespace ImHungry.Models
{
    public partial class RegUser
    {
        public RegUser()
        {
            PrefCategories = new HashSet<PrefCategories>();
            VisitedRestaurant = new HashSet<VisitedRestaurant>();
        }

        public int UserId { get; set; }
        public string UserPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? SearchRadius { get; set; }

        public virtual ICollection<PrefCategories> PrefCategories { get; set; }
        public virtual ICollection<VisitedRestaurant> VisitedRestaurant { get; set; }
    }
}
