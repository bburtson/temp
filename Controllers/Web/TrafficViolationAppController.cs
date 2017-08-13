using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace USTVA.Controllers.Web
{
    [Route("app/[controller]")]
    public class TrafficViolationAppController : Controller
    {
        private ILogger<TrafficViolationAppController> _logger;

        public TrafficViolationAppController(ILogger<TrafficViolationAppController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
