using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBuckTrackerDemo.Models
{
    public class BugModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        //public DateTime TimeStamp { get; set; }
        public string Status { get; set; }
        //public int CreatedByUserId { get; set; }
        public string Details { get; set; }
        public string PriorityLevel { get; set; }
        //public int UserAssignedId { get; set; }
        public int BugProjectId { get; set; }
    }
}