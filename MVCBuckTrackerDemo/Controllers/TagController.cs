using MVCBugTrackerDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLibrary;
using static DataLibrary.BusinessLogic.TagsProcessor;
using System.Web.Mvc;

namespace MVCBugTrackerDemo.Controllers
{
    public class TagController : Controller
    {
        //------------ Bug Section ------------------

        //Regular Project View
        public ActionResult TagList()
        {
            var data = LoadTags(); //load the data   
            List<TagsModel> tags = new List<TagsModel>(); //create a list of projects
            foreach (var row in data)// loop to organize the data in the projects list
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
            return View(tag);
        }

        [HttpPost]
        public ActionResult CreateTag(TagsModel model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = CreateTags(model.Id, model.TagDescription, model.TagType, model.TimeStamp);
                return RedirectToAction("TagList");
            }
            ViewBag.Message = "Tag List";
            return View();
        }

        public ActionResult DeleteTag(int id)
        {
            DeleteTags(id);
            return RedirectToAction("TagList");
        }
        
        [HttpGet]
        public ActionResult UpdateTag(int id)
        {
            var resultModel = LoadOneTag(id); //get the results from the databaase
            TagsModel TagsModel = new TagsModel(); //convert the results in a way that the view can understand
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
            return RedirectToAction("TagList"); ;
        }
        //-------------------------------------------
    }
}