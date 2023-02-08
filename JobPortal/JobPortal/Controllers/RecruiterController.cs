using JobPortal.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;




namespace JobPortal.Controllers
{
    public class RecruiterController : Controller
    {
        private AndrewDBEntities _dbContext = new AndrewDBEntities();
        // GET: Recruiter
        public ActionResult Index()
        {
            var user = _dbContext.Users;
            return View(user);
        }
        public List<Job> GetJobs()
        {
            List<Job> jobs = new List<Job>();
            return jobs;
        }
        public List<SavedJob> GetSavedJobs()
        {
            List<SavedJob> sJobs = new List<SavedJob>();
            
            return sJobs;
        }

        /*
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = _dbContext.Jobs.Find(id);
           
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }
        */
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var savedJobs = _dbContext.SavedJobs.ToList();
            //var savedJobList = _dbContext.SavedJobs.Where(p => jobs.Any(p2 => p2.ID == p.JobId));
            var jobList = _dbContext.Jobs.Where(p => savedJobs.Any(p2 => p2.JobId == p.ID));
            return View(jobList);
        }

        public ActionResult Create()
        {
            ViewBag.Poster = new SelectList(_dbContext.Users, "UId", "UserName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Type,Location,Company,Experience,Salary,Education,Date,Poster,Category,Description")] Job job, User user)
        {
            if (ModelState.IsValid)
            {
                var user1 = _dbContext.Users.Where(u => u.UserName.ToLower().Equals(user.UserName.ToLower()) && u.Password.Equals(user.Password)).FirstOrDefault();
                job.Poster = (int)Session["Uid"];
                _dbContext.Jobs.Add(job);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Poster = new SelectList(_dbContext.Users, "UId", "UserName", job.Poster);
            return View(job);
        }



    }
}