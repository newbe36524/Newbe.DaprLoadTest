using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Newbe.DaprAspnetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastDaprHttpController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastDaprHttpController> _logger;
        private readonly HttpClient _httpClient;

        public WeatherForecastDaprHttpController(ILogger<WeatherForecastDaprHttpController> logger,
            HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<ContentResult> Get(
            int port,
            string appId,
            string methodName)
        {
            var uri = $"http://localhost:{port}/v1.0/invoke/{appId}/method/{methodName}";
            var content = await _httpClient.GetStringAsync(uri);
            return new ContentResult
            {
                Content = content,
                ContentType = "application/json"
            };
        }
    }
}