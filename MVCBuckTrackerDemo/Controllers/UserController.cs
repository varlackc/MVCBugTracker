using MVCBugTrackerDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLibrary;
using static DataLibrary.BusinessLogic.UserProcessor;
using System.Web.Mvc;

namespace MVCBugTrackerDemo.Controllers
{
    public class UserController : Controller
    {

        //Regular Project View
        public ActionResult UserList()
        {
            //load the data
            var data = LoadUser();
            //create a list of projects
            List<UserModel> users = new List<UserModel>();

            // loop to organize the data in the projects list
            foreach (var row in data)
            {
                users.Add(new UserModel
                {
                    Id = row.Id,
                    UserName = row.UserName,
                    FirstName = row.FirstName,
                    LastName = row.LastName
                });
            }

            return View(users);
        }

        public ActionResult CreateUser()
        {
            UserModel user = new UserModel();
           // bug.BugProjectId = id;

            return View(user);
        }

        [HttpPost]
        public ActionResult CreateUser(UserModel model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = CreateUsers(model.UserName, model.FirstName, model.LastName);

                    //TimeStamp = timeStamp
                //var id = model.BugProjectId;
                return RedirectToAction("UserList");
            }

            ViewBag.Message = "User List";
            return View();
        }


        public ActionResult DeleteUsers(int id)
        {
            DeleteUser(id);
            //return View();
            return RedirectToAction("UserList");
        }
        
        [HttpGet]
        public ActionResult UpdateUser(int id)
        {
            //get the results from the databaase
            var resultModel = LoadOneUser(id);
            //convert the results in a way that the view can understand
            UserModel userModel = new UserModel();

            userModel.Id = resultModel.Id;
            userModel.UserName = resultModel.UserName;
            userModel.FirstName = resultModel.FirstName;
            userModel.LastName = resultModel.LastName;

            return View(userModel);
        }

        [HttpPost]
        public ActionResult UpdateUser(UserModel model)
        {
            if (ModelState.IsValid)
            {
                UpdateUsers(model.Id, model.UserName, model.FirstName, model.LastName);
            }
            //var id = model.BugProjectId;
            return RedirectToAction("UserList"); ;
        }
        //-------------------------------------------

    }
}