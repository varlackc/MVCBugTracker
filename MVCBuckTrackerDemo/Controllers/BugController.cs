﻿using MVCBugTrackerDemo.Models;
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
        
        //Regular Project View
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

        public ActionResult ReportBug(int id)
        {
            ViewBag.Message = id;
            BugModel bug = new BugModel();
            bug.BugProjectId = id;
            return View(bug);
        }

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

        public ActionResult DeleteBugs(int id, int bugId)
        {
            DeleteBug(bugId);
            return RedirectToAction("BugList", new { id });
        }
        
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