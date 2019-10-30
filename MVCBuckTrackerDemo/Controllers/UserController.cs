using MVCBuckTrackerDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLibrary;
using static DataLibrary.BusinessLogic.UserProcessor;
using System.Web.Mvc;

namespace MVCBuckTrackerDemo.Controllers
{
    public class UserController : Controller
    {

        //Regular Project View
        public ActionResult UserList()
        {
            //load the data
            var data = LoadUsers();
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

        private object LoadUsers()
        {
            throw new NotImplementedException();
        }

        public ActionResult CreateUser()
        {
            TagsModel tag = new TagsModel();
           // bug.BugProjectId = id;

            return View(tag);
        }

        [HttpPost]
        public ActionResult CreateUser(TagsModel model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = CreateTags(model.Id, model.TagDescription, model.TagType, model.TimeStamp);

                    //TimeStamp = timeStamp
                //var id = model.BugProjectId;
                return RedirectToAction("TagList");
            }

            ViewBag.Message = "Tag List";
            return View();
        }


        public ActionResult DeleteUser(int id)
        {
            DeleteUsers(id);
            //return View();
            return RedirectToAction("TagList");
        }
        
        [HttpGet]
        public ActionResult UpdateUser(int id)
        {
            //get the results from the databaase
            var resultModel = LoadOneUser(id);
            //convert the results in a way that the view can understand
            TagsModel TagsModel = new TagsModel();

            TagsModel.Id = resultModel.Id;
            TagsModel.TagDescription = resultModel.TagDescription;
            TagsModel.TagType = resultModel.TagType;
            return View(TagsModel);
        }

        [HttpPost]
        public ActionResult UpdateUser(TagsModel model)
        {
            if (ModelState.IsValid)
            {
                UpdateTags(model.Id, model.TagDescription, model.TagType, model.TimeStamp);
            }
            //var id = model.BugProjectId;
            return RedirectToAction("TagList"); ;
        }


        //-------------------------------------------

    }
}