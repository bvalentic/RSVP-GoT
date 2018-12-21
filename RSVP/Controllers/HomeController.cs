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

        public ActionResult SaveGuest(Guest guest)
        {
            PartyDBEntities DB = new PartyDBEntities();
            guest.Character = DB.Characters.Find(guest.CharacterID);
            DB.Guests.Add(guest);
            DB.SaveChanges();

            return RedirectToAction("RSVPConfirm", guest);
        }

        public ActionResult RSVPConfirm(Guest guest)
        {
            ViewBag.Message = "Thank you for RSVP-ing, " + guest.FirstName + "!";

            if (guest.AttendanceDate != null)
            {
                ViewBag.ConfirmMessage = "We'll see you at the big party!";
            }
            else
            {
                ViewBag.ConfirmMessage = "Sorry you can't make it! We hope to see you at the next one!";
            }

            return View(guest);
        }

        public ActionResult ViewGuests()
        {
            PartyDBEntities DB = new PartyDBEntities();
            ViewBag.GuestList = DB.Guests.ToList();

            ViewBag.Message = "Because you wanna see if all your friends are coming too";

            return View();
        }

        public ActionResult BringADish()
        {
            ViewBag.Message = "What dish are you bringing?";

            return View();
        }

        public ActionResult SaveDish(Dish dish)
        {
            PartyDBEntities DB = new PartyDBEntities();
            DB.Dishes.Add(dish);
            if (ModelState.IsValid)
            {
                DB.SaveChanges();

                return RedirectToAction("DishConfirm", dish);
            }
            else
            {
                ViewBag.ErrorMessage = "Entry invalid. Please try again.";
                foreach (var item in ModelState.Values)
                {
                    if (item.Errors.Count > 0)
                    {
                        ViewBag.ErrorMessage += "\n" + item.Errors[0].ErrorMessage;
                    }
                }
                return View("BringADish");
            }
            
        }

        public ActionResult DishConfirm(Dish dish)
        {
            ViewBag.Message = "";
            ViewBag.ConfirmMessage = "Great dish! Definitely big party material!";

            return View(dish);
        }

        [Authorize]
        public ActionResult ViewDishes()
        {
            PartyDBEntities DB = new PartyDBEntities();
            ViewBag.DishList = DB.Dishes.ToList();

            ViewBag.Message = "You wouldn't want to bring the same thing as someone else, right?";

            return View();
        }

        public ActionResult EditDish(int dishID)
        {
            PartyDBEntities DB = new PartyDBEntities();
            Dish editDish = DB.Dishes.Find(dishID);

            return View(editDish);
        }

        public ActionResult SaveDishChanges(Dish editDish)
        {
            PartyDBEntities DB = new PartyDBEntities();
            Dish oldDish = DB.Dishes.Find(editDish.DishID);

            if (ModelState.IsValid)
            {
                oldDish.PersonName = editDish.PersonName;
                oldDish.PhoneNumber = editDish.PhoneNumber;
                oldDish.DishName = editDish.DishName;
                oldDish.DishDescription = editDish.DishDescription;
                oldDish.Option = editDish.Option;

                DB.Entry(oldDish).State = System.Data.Entity.EntityState.Modified;
                DB.SaveChanges();

                return RedirectToAction("ViewDishes");
            }
            else
            {
                ViewBag.ErrorMessage = "Entry invalid. Please try again.";
                foreach (var item in ModelState.Values)
                {
                    if (item.Errors.Count > 0)
                    {
                        ViewBag.ErrorMessage += "\n" + item.Errors[0].ErrorMessage;
                    }
                }
                return RedirectToAction("ViewDishes");
            }


        }

        public ActionResult DeleteDish(int dishID)
        {
            PartyDBEntities DB = new PartyDBEntities();
            Dish goneDish = DB.Dishes.Find(dishID);

            DB.Dishes.Remove(goneDish);
            DB.SaveChanges();

            return RedirectToAction("ViewDishes");
        }
    }
}