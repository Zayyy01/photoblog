using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using PhotoblogDataAccess;

namespace PhotoBlogDataAccessCLI
{
	class Program
	{
		static void Main(string[] args)
		{

			var config = new ConfigurationBuilder()
				.AddEnvironmentVariables()
				.Build();

			using BlogDbContext context = new BlogDbContext(config.GetConnectionString("BlogDbConnectionString"));

			var images = context.Images.ToList();
			var image = images.First();
			Console.WriteLine(image.Name);
			Console.ReadKey();
		}
	}
}
