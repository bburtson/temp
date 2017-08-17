using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using USTVA.Services;
using USTVA.ViewModels;

namespace USTVA.Controllers.Web
{

    public class HomeController : Controller
    {
        private IIncidentData _incidentData;
        private readonly ILogger<HomeController> _logger;
        private AdminAlert _adminAlert;


        public HomeController(IIncidentData incidentData,
                              ILogger<HomeController> logger,
                              AdminAlert adminAlert)
        {
            _adminAlert = adminAlert;
            _logger = logger;
            _incidentData = incidentData;
        }

        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [Route("[controller]/[action]/{results=10}")]
        public IActionResult Incidents(int results)
        {
            try
            {
                var model = _incidentData.GetAll().Take(results);

                return View(model);
            }
            catch (Exception e)
            {
                return new ObjectResult(e.Message);
            }

        }

        public IActionResult Geolocations()
        {
            var data = _incidentData.GetAll();
            var model = data.Where(p => p.DateTime.Year == 2015)
                            .Select(p => $"{p.Latitude} {p.Longitude}")
                            .Distinct().ToArray();

            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }


        public IActionResult Contact()
        {
            ViewData["Message"] = "E-mail me.";

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Contact(ContactViewModel model)
        {
            // message from future self: Implement e-mail service this is getting out of hand.
            if (ModelState.IsValid)
            {
                await _adminAlert.SendEmailAsync("Brett", "brett@burtson.com", "Message From Contact Page",
                    $"<b>Name: </b> {model.Name}<br />" +
                    $"<b>Email: </b> {model.Email}<br />" +
                    $"<b>Message:</b><br /> {model.Message}");
            }

            return RedirectToAction(nameof(Index));
        }
        public IActionResult FccCertification()
        {
            return View();
        }

        public IActionResult Error()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>();

            _logger.LogError("Error: IExceptionHandlerFeature", exception.Error.Message);

            return View();
        }

    }
}
