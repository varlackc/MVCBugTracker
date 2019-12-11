/*****************************************************************************
*                Bug Tracking Application
*
*    Created By: Carlos Maxwell Varlack
*
*    Purpose: This application can keep track of issues in projects
*             Bug Trackers are very useful tools to improve software quality
*
*   Version: V0.1 Pre-release 
*   
 ****************************************************************************/

using MVCBugTrackerDemo.Models;
using System.Collections.Generic;
using static DataLibrary.BusinessLogic.TagsProcessor;
using System.Web.Mvc;

namespace MVCBugTrackerDemo.Controllers
{
    public class TagController : Controller
    {
        //------------ Bug Section ------------------

        //Regular Project View

        /// <summary>
        /// Tag List Controller
        /// </summary>
        /// <returns>List Of Tags</returns>
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

        /// <summary>
        /// Create Tag Controller
        /// </summary>
        /// <returns>Create A New Tag</returns>
        public ActionResult CreateTag()
        {
            TagsModel tag = new TagsModel();
            return View(tag);
        }

        /// <summary>
        /// Create Tag Controller (model)
        /// </summary>
        /// <param name="model">Tag Model</param>
        /// <returns>Create A Tag Controller</returns>
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

        /// <summary>
        /// Delete Tag Controller
        /// </summary>
        /// <param name="id">Tag ID</param>
        /// <returns>Delete A Tag By ID</returns>
        public ActionResult DeleteTag(int id)
        {
            DeleteTags(id);
            return RedirectToAction("TagList");
        }
        
        /// <summary>
        /// Update Tag Controller
        /// </summary>
        /// <param name="id">Tag ID</param>
        /// <returns>Update Tag By Tag ID</returns>
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

        /// <summary>
        /// Update Tag Controller (Post)
        /// </summary>
        /// <param name="model">Tag Model</param>
        /// <returns>Update Tag Controller By ID</returns>
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