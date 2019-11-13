using MVCBugTrackerDemo.Models;
using System.Collections.Generic;
using static DataLibrary.BusinessLogic.ProjectProcessor;
using System.Web.Mvc;

namespace MVCBugTrackerDemo.Controllers
{
    public class ProjectController : Controller
    {
        //Regular Project View

        /// <summary>
        /// Project List Controller
        /// </summary>
        /// <returns>List Of Projects</returns>
        public ActionResult ProjectList()
        {
            ViewBag.Message = "Project List From View Bag Message";
            var data = LoadProjects();//load the data
            List<ProjectModel> projects = new List<ProjectModel> ();//create a list of projects
            foreach (var row in data)// loop to organize the data in the projects list
            {
                projects.Add(new ProjectModel {
                    Id = row.Id, 
                    Name = row.Name, 
                    Description = row.Description,
                    DeadLine = row.DeadLine
                });
            }
            return View(projects);
        }

        /// <summary>
        /// Create A New Project
        /// </summary>
        /// <returns>Create A New Project</returns>
        public ActionResult Create()
        {
            ViewBag.Message = "Project List";
            return View();
        }
        
        /// <summary>
        /// Create A New Project (Post)
        /// </summary>
        /// <param name="model">Project Model</param>
        /// <returns>Post A New Created Project</returns>
        [HttpPost]
        public ActionResult Create(ProjectModel model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = CreateProject(model.Id, model.Name, model.Description, model.DeadLine);
                return RedirectToAction("ProjectList");
            }
            ViewBag.Message = "Project List";
            return View();
        }

        /// <summary>
        /// Delete A Project
        /// </summary>
        /// <param name="Id">Project ID</param>
        /// <returns>Delete A Project That Was Specified By ID</returns>
        public ActionResult DeleteProjects(int Id)
        {
            DeleteProject(Id);
            return RedirectToAction("ProjectList");
        }

        /// <summary>
        /// Update Project Controller
        /// </summary>
        /// <param name="id">Project ID</param>
        /// <returns>Update The Project Given By Project ID</returns>
        [HttpGet]
        public ActionResult UpdateProjects(int id)
        {
            var resultModel = LoadOneProject(id); //get the results from the databaase
            ProjectModel projectModel = new ProjectModel(); //convert the results in a way that the view can understand
            projectModel.Id = resultModel.Id;
            projectModel.Name = resultModel.Name;
            projectModel.Description = resultModel.Description;
            projectModel.DeadLine = resultModel.DeadLine;
            return View(projectModel);
        }

        /// <summary>
        /// Update Project Controller (Post)
        /// </summary>
        /// <param name="model">Project Model</param>
        /// <returns>Update The Project ID</returns>
        [HttpPost]
        public ActionResult UpdateProjects(ProjectModel model)
        {
            if (ModelState.IsValid)
            {
                UpdateProject(model.Id, model.Name, model.Description);
            }
            return RedirectToAction("ProjectList"); ;
        }
    }
}