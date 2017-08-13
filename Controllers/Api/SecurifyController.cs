using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using USTVA.Controllers.FilterAttributes;

namespace USTVA.Controllers.Api
{
    // I created this controller with the intent to privately use public APIS on codepen and also use my personal webserver
    // to send those api results over an SSL encrypted protocol.. which also allows ease of use for secured sites like codepen
    [Route("[controller]/[action]")]
    public class SecurifyController : Controller
    {
        private readonly IConfigurationRoot _config;

        public SecurifyController(IConfigurationRoot config)
        {
            _config = config;
        }

        [AllowCrossOrigin]
        [HttpGet("{units}/{lat}/{lon}")]
        public async Task<IActionResult> Weather(string units, float lat, float lon)
        {
            string jsonResult;
            // config json contains sensitive data
            var baseUrl = _config.GetSection("ExternalResourceUrls")["OpenWeatherMap"];

            var url = $"{baseUrl}&units={units}&lat={lat}&lon={lon}";

                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(url).ConfigureAwait(false);

                    jsonResult = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                }

            return Ok(jsonResult);
        }

        [AllowCrossOrigin]
        [HttpGet("icon/{icon}")]
        public async Task<IActionResult> Weather(string icon)
        {
            string url = $"http://openweathermap.org/img/w/{icon}.png";

            byte[] byteResult;

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url).ConfigureAwait(false);

                byteResult = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
            }

            return File(byteResult, "application/octet-stream", icon + ".png");
        }
    }
}
