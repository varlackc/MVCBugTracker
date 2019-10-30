using MVCBuckTrackerDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLibrary;
using static DataLibrary.BusinessLogic.TagsProcessor;
using System.Web.Mvc;

namespace MVCBuckTrackerDemo.Controllers
{
    public class UserController : Controller
    {
        //------------ Bug Section ------------------

        //Regular Project View
        public ActionResult TagList()
        {
            //load the data
            var data = LoadTags();
            //create a list of projects
            List<TagsModel> tags = new List<TagsModel>();

            // loop to organize the data in the projects list
            foreach (var row in data)
            {
                tags.Add(new TagsModel
                {
                    Id = row.Id,
                    TagDescription = row.TagDescription,
                    TagType = row.TagType,
                    TimeStamp = row.TimeStamp
                });
            }

            return View(tags);
        }


        public ActionResult CreateTag()
        {
            TagsModel tag = new TagsModel();
           // bug.BugProjectId = id;

            return View(tag);
        }

        [HttpPost]
        public ActionResult CreateTag(TagsModel model)
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


        public ActionResult DeleteTag(int id)
        {
            DeleteTags(id);
            //return View();
            return RedirectToAction("TagList");
        }
        
        [HttpGet]
        public ActionResult UpdateTag(int id)
        {
            //get the results from the databaase
            var resultModel = LoadOneTag(id);
            //convert the results in a way that the view can understand
            TagsModel TagsModel = new TagsModel();

            TagsModel.Id = resultModel.Id;
            TagsModel.TagDescription = resultModel.TagDescription;
            TagsModel.TagType = resultModel.TagType;
            return View(TagsModel);
        }

        [HttpPost]
        public ActionResult UpdateTag(TagsModel model)
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