using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobPortal.Models
{
    public class ListAndSearchVM
    {
        public IEnumerable<JobPortal.Models.Job> JobList { get; set; }
        public IEnumerable<SelectListItem> Status { get; set; }
        public string SelectedStatus { get; set; }
    }
}