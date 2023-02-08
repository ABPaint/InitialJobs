using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobPortal.Models
{
    public class IndexVM
    {
        public List<Job> JobsList { get; set; }
        public List<SavedJob> SavedJobList { get; set; }
    }
}