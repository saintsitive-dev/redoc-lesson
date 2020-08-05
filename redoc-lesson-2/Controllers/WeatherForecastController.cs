using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace redoc_lesson_2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <remarks>ดึงข้อมูลสภาพอากาศ</remarks>
        /// <returns>ลิสของวันที่และสภาพอากาศ</returns>
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="weatherForecast"></param>
        /// <returns>HTTP Status Code</returns>
        /// <response code="200">Successfully saved</response>
        /// <response code="500">Bad Request</response>
        [HttpPut]
        public IActionResult Put(int id, WeatherForecast weatherForecast)
        {

            try
            {
                //successfully updated
                return Ok();
            }
            catch(Exception e) {
                //fail
                return BadRequest();
            }
            
        }
    }
}
