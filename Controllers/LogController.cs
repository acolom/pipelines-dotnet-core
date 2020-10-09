using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using pipelines_dotnet_core.Models;

namespace pipelines_dotnet_core.Controllers
{
    public class LogController : Controller
    {
        ILogger<LogController> _logger;
        public LogController( ILogger<LogController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index(string url)
        {
            _logger.LogInformation($"LogController Index executed at {DateTime.UtcNow}");
            return Content("logged");
        }

        public async Task<IActionResult> TestUrl(string url)
        {
            var uri = new Uri(url);
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var message = await httpClient.GetStringAsync(uri);
                    return Content(message);
                }
            }
            catch (Exception ex)
            {
                return Content($@"{uri}
                          {ex.Message}
                          {ex.StackTrace}");
            }
        }
    }
}
