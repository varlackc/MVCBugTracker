using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.ComponentModel;

namespace MVCBuckTrackerDemo.Models
{
    public class ProjectModel
    {

        //Add anotations to determine to enforce rules on data

        public int Id { get; set; }

        [Display(Name = "Project Name")]

        [Required(ErrorMessage = "Must Have A Name")]
        public string Name { get; set; }

        [Display(Name = "Project Description")]
        public string Description { get; set; }

        // [DefaultValue(DateTime.Now)]// setup the default value
        [Display(Name = "Project Dead Line")]
        [Required(ErrorMessage ="Must Have A Dead Line")]
        public DateTime DeadLine { get; set; }// setup the default value

        //public int BugId { get; set; }
    }
}