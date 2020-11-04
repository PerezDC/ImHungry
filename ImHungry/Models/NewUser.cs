using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ImHungry.Models
{
    public partial class NewUser
    {
        public NewUser()
        {
            PrefCategories = new HashSet<PrefCategories>();
            VisitedRestaurant = new HashSet<VisitedRestaurant>();
        }

        public int UserId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string UserEmail { get; set; }

        [Required]
        public string UserPassword { get; set; }

        public int? SearchRadius { get; set; }

        public virtual ICollection<PrefCategories> PrefCategories { get; set; }
        public virtual ICollection<VisitedRestaurant> VisitedRestaurant { get; set; }
    }
}
