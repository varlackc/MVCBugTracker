using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBugTrackerDemo.Models
{
    public class TagsModel
    {
        public int Id { get; set; }
        public string TagDescription { get; set; }
        public string TagType { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}