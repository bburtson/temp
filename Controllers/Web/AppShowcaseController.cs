using Microsoft.AspNetCore.Mvc;

namespace USTVA.Controllers.Web
{
    public class AppShowcaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TrafficViolation()
        {
            ViewData["Heading"] = "Data Visualization";
            return View();
        }

        public IActionResult WorkoutPlanner()
        {
            ViewData["Heading"] = "Identity & Data Administration";
            return View();
        }
    }
}
