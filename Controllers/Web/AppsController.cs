using Microsoft.AspNetCore.Mvc;
using USTVA.Services;
using USTVA.ViewModels;

namespace USTVA.Controllers.Web
{
    public class AppsController : Controller
    {
        private ILocalDataProvider<AppDetailsViewModel> _dataService;

        public AppsController(ILocalDataProvider<AppDetailsViewModel> dataService)
        {
            _dataService = dataService;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Applications";

            // Until I decide what i want to do!
            return RedirectToAction("MicroApps");
        }

        public IActionResult MicroApps()
        {
            ViewBag.Title = "Micro Applications";

            // abstract to interface.

            var model = _dataService.Get("MicroApps");

            return View(model);
        }

        public IActionResult PersonalProjects()
        {
            ViewBag.Title = "Personal Projects";

            var model = _dataService.Get("PersonalProjects");

            return View(model);
        }

        public IActionResult TrafficViolation()
        {
            return View();
        }
    }
}
