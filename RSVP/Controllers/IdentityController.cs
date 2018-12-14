using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using RSVP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RSVP.Controllers
{
    public class IdentityController : Controller
    {

        public UserManager<IdentityUser> UserManager => HttpContext.GetOwinContext().Get<UserManager<IdentityUser>>();

        // GET: Register
        public ActionResult Register()
        {
            return View();
        }

        //POST: Register
        [HttpPost]
        public async Task<ActionResult> Register(RegistrationModel registerGuest)
        {
            if (ModelState.IsValid)
            {
                var IdentityResult = await UserManager.CreateAsync(new IdentityUser(registerGuest.EmailAddress), registerGuest.Password);

                if (IdentityResult.Succeeded)
                {
                    PartyDBEntities DB = new PartyDBEntities();

                    var newGuest = new Guest();

                    newGuest.FirstName = registerGuest.FirstName;
                    newGuest.LastName = registerGuest.LastName;
                    newGuest.AttendanceDate = registerGuest.AttendanceDate;
                    newGuest.EmailAddress = registerGuest.EmailAddress;
                    newGuest.Guest1 = registerGuest.Guest1;

                    DB.Guests.Add(newGuest);
                    DB.SaveChanges();

                    ViewBag.ConfirmMessage = "Thanks for registering, " + User.Identity.Name;
                    return RedirectToAction("Confirm", registerGuest);
                }

                ModelState.AddModelError("", IdentityResult.Errors.FirstOrDefault());

            }

            return View(registerGuest);
        }

        //GET: Login
        public ActionResult Login()
        {
            return View();
        }

        //POST: Login
        [HttpPost]
        public ActionResult Login(LoginModel loginGuest)
        {
            if (ModelState.IsValid)
            {
                var authenticationManager = HttpContext.GetOwinContext().Authentication;

                IdentityUser user = UserManager.Find(loginGuest.EmailAddress, loginGuest.Password);

                if (user != null)
                {
                    var ident = UserManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                    authenticationManager.SignIn(new AuthenticationProperties { IsPersistent = false }, ident);

                    ViewBag.ConfirmMessage = "Thanks for logging in, " + User.Identity.Name;
                    return RedirectToAction("Confirm", user);
                }

                ModelState.AddModelError("", "Invalid login.");
            }

            return View(loginGuest);
        }

        public ActionResult Confirm()
        {
            return View();
        }
    }
}