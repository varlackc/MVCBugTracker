using MVCBugTrackerDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLibrary;
using static DataLibrary.BusinessLogic.BugProcessor;

using System.Web.Mvc;

namespace MVCBugTrackerDemo.Controllers
{
    
    public class BugController : Controller
    {
        //------------ Bug Section ------------------
        
        /// <summary>
        /// Bug List Controller 
        /// </summary>
        /// <param name="id">Project Id</param>
        /// <returns>List Of Bugs Related To The Project ID</returns>
        public ActionResult BugList(int id)
        {
            var data = LoadBugs(id); //load the data                              
            List<BugModel> bugs = new List<BugModel>(); //create a list of projects
            foreach (var row in data) // loop to organize the data in the projects list
            {
                    bugs.Add(new BugModel
                    {
                        Id = row.Id,
                        Description = row.Description,
                        Status = row.Status,
                        Details = row.Details,
                        PriorityLevel = row.PriorityLevel,
                        BugProjectId = row.BugProjectId
                    });
             }
            ViewBag.message = id;
            return View(bugs);
        }

        /// <summary>
        /// List Of All Bugs Controller
        /// </summary>
        /// <returns>List Of All Bugs</returns>
        public ActionResult CompleteBugList()
        {
            int id = -1;
            var data = LoadBugs(id); //load the data
            List<BugModel> bugs = new List<BugModel>(); //create a list of projects
            foreach (var row in data) // loop to organize the data in the projects list
            {
                bugs.Add(new BugModel
                {
                    Id = row.Id,
                    Description = row.Description,
                    Status = row.Status,
                    Details = row.Details,
                    PriorityLevel = row.PriorityLevel,
                    BugProjectId = row.BugProjectId
                });
            }
            ViewBag.message = id;
            return View(bugs);
        }

        /// <summary>
        /// Report Bug Controller
        /// </summary>
        /// <param name="id">Project Id</param>
        /// <returns>Create New Bug After Inserting Project Id</returns>
        public ActionResult ReportBug(int id)
        {
            ViewBag.Message = id;
            BugModel bug = new BugModel();
            bug.BugProjectId = id;
            return View(bug);
        }

        /// <summary>
        /// Report Bug Controller
        /// </summary>
        /// <param name="model"> Bug Model </param>
        /// <returns>Create A New Bug</returns>
        [HttpPost]
        public ActionResult ReportBug(BugModel model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = CreateBug(model.Id, model.Description, model.Status, model.Details,
                                               model.PriorityLevel, model.BugProjectId);
                var id = model.BugProjectId;
                return RedirectToAction("BugList", new { id});
            }
            ViewBag.Message = "Bug List";
            return View();
        }

        /// <summary>
        /// Delete Bug
        /// </summary>
        /// <param name="id">Project ID</param>
        /// <param name="bugId">Bug ID</param>
        /// <returns>Delete The Bug</returns>
        public ActionResult DeleteBugs(int id, int bugId)
        {
            DeleteBug(bugId);
            return RedirectToAction("BugList", new { id });
        }
        
        /// <summary>
        /// Update Bug Controller
        /// </summary>
        /// <param name="id">Bug ID</param>
        /// <returns>Update The Bug Given By The Bug ID</returns>
        [HttpGet]
        public ActionResult UpdateBugs(int id)
        {
            var resultModel = LoadOneBug(id);//get the results from the database
            BugModel bugModel = new BugModel();
            //convert the results in a way that the view can understand
            bugModel.Id = resultModel.Id;
            bugModel.Description = resultModel.Description;
            bugModel.Status = resultModel.Status;
            bugModel.Details = resultModel.Details;
            bugModel.PriorityLevel = resultModel.PriorityLevel;
            bugModel.BugProjectId = resultModel.BugProjectId;
            return View(bugModel);
        }

        /// <summary>
        /// Update Bug Controller (Post)
        /// </summary>
        /// <param name="model">Bug Model</param>
        /// <returns>Update Bug</returns>
        [HttpPost]
        public ActionResult UpdateBugs(BugModel model)
        {
            if (ModelState.IsValid)
            {
                UpdateBug(model.Id, model.Description,
                          model.Status, model.Details, model.PriorityLevel, model.BugProjectId);
            }
            var id = model.BugProjectId;
            return RedirectToAction("BugList", new { id }); ;
        }
        //-------------------------------------------
    }
}