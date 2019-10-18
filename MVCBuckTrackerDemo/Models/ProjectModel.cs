using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBuckTrackerDemo.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DeadLine { get; set; }
        public int BugId { get; set; }
    }
}