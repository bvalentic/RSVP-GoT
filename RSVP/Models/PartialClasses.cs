using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RSVP.Models
{
    public class PartialClasses
    {
        [MetadataType(typeof(DishMetadata))]
        public partial class Dish
        {
        }
    }
}