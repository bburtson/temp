using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using USTVA.Services;
using USTVA.ViewModels;

namespace USTVA.Controllers.Api
{
    [Route("api/incident")]
    public class IncidentController : Controller
    {
        private readonly IIncidentData _incidents;
        private ILogger<IncidentController> _logger;

        public IncidentController(IIncidentData incidents,
                                  ILogger<IncidentController> logger)
        {
            _logger = logger;
            _incidents = incidents;
        }

        [HttpGet("test")]
        public IActionResult Thing()
        {
            return Ok("Test Method");
        }

        [HttpGet("{id=0}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _incidents.GetByIdAsync(id).ConfigureAwait(false);

            return id == 0 ? Ok("specify ID:  /api/incident/12") : Ok(result);
        }

        [HttpPost("filter")]
        public async Task<IActionResult> LatLngFiltered([FromBody] FilterParams filterParams)
        {
            var filteredIncidents = await _incidents.GetByUserFilterParams(filterParams).ConfigureAwait(false);

            return Ok(filteredIncidents.Select(x => new IncidentLocationViewModel
            {
                Id = x.IncidentId,
                Lat = x.Latitude,
                Lng = x.Longitude
            }));
        }


        [HttpGet("latlng/{year=2017}")]
        public async Task<IActionResult> LatLng(int year)
        {
            try
            {
                var query = await _incidents.GetByYearAsync(year).ConfigureAwait(false);
                var geoLocations = query.Select(i => new IncidentLocationViewModel
                {
                    Id = i.IncidentId,
                    Lat = i.Latitude,
                    Lng = i.Longitude
                }).ToArray();

                return Ok(geoLocations);
            }
            catch (Exception e)
            {
                _logger.LogError("LatLng GET ERROR: " + e.Message, e.StackTrace);
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return new ObjectResult(e.Message);
            }
        }
    }
}
