using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhotoblogDataAccess;

namespace Photoblog.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		private BlogDbContext _context;
		private readonly ILogger<WeatherForecastController> _logger;

		public WeatherForecastController(ILogger<WeatherForecastController> logger, BlogDbContext context)
		{
			_logger = logger;
			_context = context;
		}

		[HttpGet]
		public IEnumerable<WeatherForecast> Get()
		{
			var img = _context.Images.ToList().First();

			var rng = new Random();
			return Enumerable.Range(1, 5).Select(index => new WeatherForecast
			{
				Date = DateTime.Now.AddDays(index),
				TemperatureC = rng.Next(-20, 55),
				Summary = img.Name + rng.Next(0,100) //Summaries[rng.Next(Summaries.Length)]
			})
			.ToArray();
		}
	}
}
