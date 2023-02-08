using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using JobPortal.Models;



namespace JobPortal.Controllers
{
    public class ApplicantController : Controller
    {
        private AndrewDBEntities _dbContext = new AndrewDBEntities();
        // GET: Applicant
        public ActionResult Index()
        {
            var jobs = _dbContext.Jobs.Include(j => j.User);
            return View(jobs.ToList()); 
        }

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
        
        public ActionResult Apply(SavedJob saved, int? id) 
        {
            User u = _dbContext.Users.FirstOrDefault();
            Job job = _dbContext.Jobs.Find(id);
            saved.UId = u.UId;
            saved.JobId = id;
            
            //saved = _dbContext.SavedJobs.FirstOrDefault(a=>a.UId== user.UId);
            //_dbContext.Entry(saved).State = EntityState.Modified;
            _dbContext.SavedJobs.Add(saved);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Applicant");
        }




    }
}