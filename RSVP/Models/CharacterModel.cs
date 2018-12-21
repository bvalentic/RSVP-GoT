using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSVP.Models
{
    public class CharacterModel
    {
        public int CharacterID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Allegiances { get; set; }
        public string Books { get; set; }
    }
}