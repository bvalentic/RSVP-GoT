using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RSVP.Models
{
    public class RegistrationModel
    {
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 8)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        //extra properties for User model

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime AttendanceDate { get; set; }
        public string Guest1 { get; set; }
    }
}