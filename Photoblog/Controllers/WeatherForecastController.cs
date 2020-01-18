using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhotoblogInfrastructure;

namespace Photoblog.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		// ReSharper disable once UnusedMember.Local
		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		private readonly BlogDbContext _context;
		private readonly ILogger<WeatherForecastController> _logger;

		public WeatherForecastController(ILogger<WeatherForecastController> logger, BlogDbContext context)
		{
			_logger = logger;
			_context = context;
		}

		[HttpGet]
		public IEnumerable<WeatherForecast> Get()
		{
			_logger.Log(logLevel: LogLevel.Trace, "WeatherForecastController-get");

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
