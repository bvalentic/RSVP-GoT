using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSVP.Models
{
    public class Guest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Attending { get; set; }
        public bool PlusOne { get; set; }
    }

    public class Dish
    {
        public string GuestName { get; set; }
        public string Phone { get; set; }
        public string DishName { get; set; }
        public string Description { get; set; }
        public bool GlutenFree { get; set; }
        public bool Vegan { get; set; }
        public bool Vegetarian { get; set; }
    }
}