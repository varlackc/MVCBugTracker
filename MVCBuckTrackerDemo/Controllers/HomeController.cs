using System.Web.Mvc;

namespace MVCBugTrackerDemo.Controllers
{
    
    public class HomeController : Controller
    {
        /// <summary>
        /// Starts The Project List
        /// </summary>
        /// <returns>Project View</returns>
        public ActionResult Index()
        {
            return RedirectToAction("ProjectList", "Project");
        }

        /// <summary>
        /// About Section Controller
        /// </summary>
        /// <returns>About view</returns>
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        /// <summary>
        /// Contact Section Controller
        /// </summary>
        /// <returns>Contact Section View</returns>
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}