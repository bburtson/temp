using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace USTVA.Controllers.Api
{
    [Route("[controller]/[action]")]
    public class CloudController : Controller
    {
        private readonly string _contentPath;

        public CloudController(IConfigurationRoot config)
        {
            _contentPath = config.GetSection("LocalPaths")["JunkDrawer"];
        }

        [HttpGet]
        public async Task<IActionResult> JunkDrawer()
        {
            var fileEntries = await Task.Run(() =>
            {
                return Directory.GetFiles(_contentPath)
                    .Select(s => s.Substring(s.LastIndexOf('\\') + 1));

            }).ConfigureAwait(false);

            return View(fileEntries);
        }

        [HttpGet("{fileName}")]
        public async Task<FileResult> JunkDrawer(string fileName)
        {
            var fileBytes = await Task.Run(() =>
            {
                return System.IO.File.ReadAllBytes($"{_contentPath}{fileName}");

            }).ConfigureAwait(false);

            return File(fileBytes, "application/octet-stream", fileName);
        }
    }
}
