using System;
using System.Collections.Generic;
using System.Linq;
using InterfaceDB.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebClient.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {

        private readonly BookContext _context;

        public SampleDataController(BookContext context)
        {
            _context = context;
        }

        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }
        [HttpGet("[action]")]
        public IEnumerable<Book> GetBooks()
        {
            return _context.Books;
        }

        [HttpGet("[action]")]
        public string[] GetText()
        {
            var str = new string[] { "124", "234234" }; 
            return str;
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}
