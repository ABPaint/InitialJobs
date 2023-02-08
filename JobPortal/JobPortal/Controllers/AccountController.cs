using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using JobPortal.Models;
using System.Linq;

namespace JobPortal.Controllers
{
    public class AccountController : Controller
    {
        private AndrewDBEntities _dbContext = new AndrewDBEntities();
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel credentials)
        {
            bool userExist = _dbContext.Users.Any(x => x.Email == credentials.Email && x.Password == credentials.Password);

            User u = _dbContext.Users.FirstOrDefault(x => x.Email == credentials.Email && x.Password == credentials.Password);


            if (userExist)
            {
                Session["roleid"] = u.RoleId;

                switch (Session["roleid"])
                {
                    case 1:
                        FormsAuthentication.SetAuthCookie(u.UserName, false);
                        return RedirectToAction("Index", "Applicant");
                    case 2:
                        FormsAuthentication.SetAuthCookie(u.UserName, false);
                        return RedirectToAction("Index", "Recruiter");
                    default:
                        FormsAuthentication.SetAuthCookie(u.UserName, false);
                        return RedirectToAction("Index", "Home");
                }

            }
            ModelState.AddModelError("", "Username or Password is wrong");

            return View();
        }
        [HttpPost]
        public ActionResult Signup(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return RedirectToAction("Login");
        }

        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        public int GetUserRole()
        {
            var user = _dbContext.Users.FirstOrDefault();
            int roler = (int)user.RoleId;
            return roler;
        }
    }
}