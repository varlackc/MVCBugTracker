﻿using MVCBugTrackerDemo.Models;
//using System;
using System.Collections.Generic;
//using DataLibrary.BusinessLogic;
using static DataLibrary.BusinessLogic.ProjectProcessor;
using System.Web.Mvc;

namespace MVCBugTrackerDemo.Controllers
{
    public class ProjectController : Controller
    {
        //Regular Project View
        public ActionResult ProjectList()
        {
            ViewBag.Message = "Project List From View Bag Message";

            //load the data
            var data = LoadProjects();
            //create a list of projects
            List<ProjectModel> projects = new List<ProjectModel> ();

            // loop to organize the data in the projects list
            foreach (var row in data)
            {
                projects.Add(new ProjectModel {
                    Id = row.Id, 
                    Name = row.Name, 
                    Description = row.Description,
                    DeadLine = row.DeadLine
                    //BugId = row.BugId

                });
            }

            return View(projects);
        }


        public ActionResult Create()
        {
            ViewBag.Message = "Project List";
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(ProjectModel model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = CreateProject(model.Id,
                    model.Name, model.Description, model.DeadLine);
                return RedirectToAction("ProjectList");
            }

            ViewBag.Message = "Project List";
            return View();
        }

        public ActionResult DeleteProjects(int Id) {

            DeleteProject(Id);
            //return View();
            return RedirectToAction("ProjectList");
        }

        [HttpGet]
        public ActionResult UpdateProjects(int id)
        {
            //get the results from the databaase
            var resultModel = LoadOneProject(id);
            //convert the results in a way that the view can understand
            ProjectModel projectModel = new ProjectModel();
            projectModel.Id = resultModel.Id;
            projectModel.Name = resultModel.Name;
            projectModel.Description = resultModel.Description;
            projectModel.DeadLine = resultModel.DeadLine;
            return View(projectModel);
        }

        [HttpPost]
        public ActionResult UpdateProjects(ProjectModel model)
        {
            if (ModelState.IsValid)
            {
                UpdateProject(model.Id,
                    model.Name, model.Description);
            }

            return RedirectToAction("ProjectList"); ;
        }

    }
}