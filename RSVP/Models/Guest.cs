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

    }
}