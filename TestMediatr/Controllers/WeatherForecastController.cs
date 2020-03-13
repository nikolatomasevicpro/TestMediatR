using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestMediatr.MediatR;
using Newtonsoft;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace TestMediatr.Controllers
{
    [ModelMetadataType(typeof(SampleHandler))]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMediator _mediatr;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMediator mediatr)
        {
            _logger = logger;
            _mediatr = mediatr;
        }

        [HttpGet]
        public async Task<SampleViewModel> Get()
        {
            var query = new SampleQuery { Id = Guid.NewGuid() };

            var settings = new JsonSerializerSettings
            {
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Full,
                TypeNameHandling = TypeNameHandling.All
            };

            var serialized = JsonConvert.SerializeObject(query, settings);

            var deserialized = JsonConvert.DeserializeObject(serialized, settings);

            return await _mediatr.Send(deserialized) as SampleViewModel;
        }


        [HttpPost]
        public async Task<JsonResult> Post()
        {
            StreamReader sr = new StreamReader(Request.Body, Encoding.UTF8);
            var query =  await sr.ReadToEndAsync();
            var settings = new JsonSerializerSettings
            {
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Full,
                TypeNameHandling = TypeNameHandling.All
            };

            return new JsonResult(await _mediatr.Send(JsonConvert.DeserializeObject(query, settings)), settings);
        }
    }
}
