using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Newbe.DaprAspnetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastDaprGrpcController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastDaprGrpcController> _logger;
        private readonly DaprClient _daprClient;

        public WeatherForecastDaprGrpcController(ILogger<WeatherForecastDaprGrpcController> logger,
            DaprClient daprClient)
        {
            _logger = logger;
            _daprClient = daprClient;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get(
            string appId,
            string methodName)
        {
            var re = await _daprClient.InvokeMethodAsync<IEnumerable<WeatherForecast>>(
                appId,
                methodName, new HttpInvocationOptions
                {
                    Method = HttpMethod.Get
                });
            return re;
        }
    }
}