using System;
using System.Collections.Generic;

namespace ImHungryApp.Models
{
    public partial class VisitedRestaurant
    {
        public int UserId { get; set; }
        public int RestId { get; set; }
        public bool UserLiked { get; set; }

        public virtual Restaurants Rest { get; set; }
        public virtual RegUser User { get; set; }
    }
}
