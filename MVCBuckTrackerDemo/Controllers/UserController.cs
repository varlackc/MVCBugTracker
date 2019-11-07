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
            var data = LoadUser(); //load the data
            List<UserModel> users = new List<UserModel>(); //create a list of projects
            foreach (var row in data) // loop to organize the data in the projects list
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
            return View(user);
        }

        [HttpPost]
        public ActionResult CreateUser(UserModel model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = CreateUsers(model.UserName, model.FirstName, model.LastName);
                return RedirectToAction("UserList");
            }
            ViewBag.Message = "User List";
            return View();
        }


        public ActionResult DeleteUsers(int id)
        {
            DeleteUser(id);
            return RedirectToAction("UserList");
        }
        
        [HttpGet]
        public ActionResult UpdateUser(int id)
        {
            var resultModel = LoadOneUser(id); //get the results from the databaase
            UserModel userModel = new UserModel(); //convert the results in a way that the view can understand

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
            return RedirectToAction("UserList"); ;
        }
        //-------------------------------------------
    }
}