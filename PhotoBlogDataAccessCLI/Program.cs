using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using PhotoblogInfrastructure;

namespace PhotoBlogDataAccessCLI
{
	public class Program
	{
		public static void Main()
		{

			var config = new ConfigurationBuilder()
				.AddEnvironmentVariables()
				.Build();

			using var context = new BlogDbContext(config.GetConnectionString("BlogDbConnectionString"));

			var images = context.Images.ToList();
			var image = images.First();
			Console.WriteLine(image.Name);
			Console.ReadKey();
		}
	}
}
