using RSVP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RSVP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RSVP()
        {
            ViewBag.Message = "Répondez s'il vous plaît:";

            return View();
        }

        public ActionResult RSVPConfirm(Guest guest)
        {
            ViewBag.Message = "Thank you for RSVP-ing, " + guest.FirstName + "!";

            if (guest.Attending)
            {
                ViewBag.ConfirmMessage = "We'll see you at the big party!";
            }
            else
            {
                ViewBag.ConfirmMessage = "Sorry you can't make it! We hope to see you at the next one!";
            }

            return View(guest);
        }

        public ActionResult BringADish()
        {
            ViewBag.Message = "What dish are you bringing?";

            return View();
        }

        public ActionResult DishConfirm(Dish dish)
        {
            return View(dish);
        }
    }
}