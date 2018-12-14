using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace RSVP.Models
{
    public class DishMetadata
    {
        public int DishID;
        [RegularExpression(@"[A-z]+ [A-z]+", ErrorMessage = "Name must follow [First] [Last] format.")]
        public string PersonName;
        [RegularExpression(@"[0-9]{10}|[0-9]{3}-[0-9]{3}-[0-9]{4}",
            ErrorMessage = "Phone number can be either [xxxxxxxxxx] or [xxx-xxx-xxxx] format.")]
        public string PhoneNumber;
        [Required]
        public string DishName;
        public string DishDescription;
        [Required]
        public string Option;
    }
}