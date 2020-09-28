using System;
using System.Collections.Generic;

namespace ImHungry.Models
{
    public partial class PrefCategories
    {
        public int UserId { get; set; }
        public int CategoryId { get; set; }

        public virtual RestaurantCategories Category { get; set; }
        public virtual RegUser User { get; set; }
    }
}
