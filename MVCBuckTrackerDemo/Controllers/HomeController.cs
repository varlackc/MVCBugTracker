using MVCBuckTrackerDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLibrary;
using static DataLibrary.BusinessLogic.ProjectProcessor;
using System.Web.Mvc;

namespace MVCBuckTrackerDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

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


        //Add a Project View
        [HttpPost]
        public ActionResult ProjectList(ProjectModel model)
        {
            if (ModelState.IsValid) {
                int recordsCreated = CreateProject(model.Id, 
                    model.Name, model.Description, model.DeadLine);
                return RedirectToAction("Index");
            }

            ViewBag.Message = "Project List";
            return View();
        }

        [HttpPost]
        public ActionResult AddProjectToList(ProjectModel model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = CreateProject(model.Id,
                    model.Name, model.Description, model.DeadLine);
                return RedirectToAction("Index");
            }

            ViewBag.Message = "Project List";
            return View();
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


    }
}