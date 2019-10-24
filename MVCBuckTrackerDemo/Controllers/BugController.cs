using MVCBuckTrackerDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLibrary;
using static DataLibrary.BusinessLogic.BugProcessor;
using System.Web.Mvc;

namespace MVCBuckTrackerDemo.Controllers
{
    public class BugController : Controller
    {
        //------------ Bug Section ------------------

        //Regular Project View
        public ActionResult BugList(int id)
        {
            //load the data
            var data = LoadBugs(id);
            //create a list of projects
            List<BugModel> projects = new List<BugModel>();

            // loop to organize the data in the projects list
            foreach (var row in data)
            {
                projects.Add(new BugModel
                {
                    Id = row.Id,
                    Description = row.Description,
                    Status = row.Status,
                    Details = row.Details,
                    PriorityLevel = row.PriorityLevel,
                    BugProjectId = row.BugProjectId

                });
            }

            return View(projects);
        }

        //-------------------------------------------

    }
}