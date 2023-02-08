using JobPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Data.Entity;

namespace JobPortal.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private AndrewDBEntities _dbContext = new AndrewDBEntities();
        [AllowAnonymous]
        
        public ActionResult Index()
        {
            var jobs = _dbContext.Jobs.Include(j => j.User);
            return View(jobs.ToList());
        }
        /*
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                bool isValidUser = _dbContext.Users
                    .Any(u => u.UserName.ToLower() == user.UserName.ToLower()
                    && u.Password == user.Password);

                var user1 = _dbContext.Users.Where(u => u.UserName.ToLower().Equals(user.UserName.ToLower()) && u.Password.Equals(user.Password)).FirstOrDefault();
                
                if (isValidUser)
                {
                    Session["roleid"] = user1.RoleId;

                    switch (Session["roleid"])
                    {
                        case 1:
                            FormsAuthentication.SetAuthCookie(user.UserName, false);
                            return RedirectToAction("Index", "Applicant");
                        case 2:
                            FormsAuthentication.SetAuthCookie(user.UserName, false);
                            return RedirectToAction("Index", "Recruiter");
                        default:
                            FormsAuthentication.SetAuthCookie(user.UserName, false);
                            return RedirectToAction("Index", "Home");
                    }

                }
                return View();
            }
            ModelState.AddModelError("", "Invalid Username or Password");
            return View();
        */
    }

    }
