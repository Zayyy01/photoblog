using System.IO;
using System.Reflection;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Runtime.Loader;
using PhotoblogCore.Interfaces;

namespace Photoblog
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			// Disable Windows Authentication
			services.Configure<IISServerOptions>(o => { o.AutomaticAuthentication = false; });

			services.AddControllersWithViews();
			// In production, the Angular files will be served from this directory
			services.AddSpaStaticFiles(configuration =>
			{
				configuration.RootPath = "ClientApp/dist";
			});
		}

		public void ConfigureContainer(ContainerBuilder builder)
		{

			if(Configuration.GetConnectionString("BlogDbConnectionString") == null) 
				throw new System.ArgumentNullException("BlogDbConnectionString","No Db Connection string provided in the configuration!");
			
			var executingAssembly = Assembly.GetExecutingAssembly();
			var path = executingAssembly.Location.Replace(executingAssembly.ManifestModule.Name, "");
			var infrastructureDllPath = Path.Combine(path, "PhotoblogInfrastructure.dll");


			// https://stackoverflow.com/questions/53989393/is-there-an-alternative-for-buildmanager-getreferencedassemblies-in-asp-net-co
			var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(infrastructureDllPath);

			//Add Db connection
			builder.RegisterAssemblyTypes(assembly)
				.Where(t => t.Name.EndsWith("Context"))
				.WithParameter(new TypedParameter(typeof(string), Configuration.GetConnectionString("BlogDbConnectionString")))
				.As(typeof(IBlogDbContext));
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				//app.UseHsts();
			}

			// TODO Enable it (and UseHsts) when you have a valid certificate
			// https://docs.microsoft.com/en-us/aspnet/core/security/enforcing-ssl?view=aspnetcore-2.1&tabs=visual-studio#require-https 
			//app.UseHttpsRedirection();
			app.UseStaticFiles();
			if (!env.IsDevelopment())
			{
				app.UseSpaStaticFiles();
			}

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller}/{action=Index}/{id?}");
			});

			app.UseSpa(spa =>
			{
				// To learn more about options for serving an Angular SPA from ASP.NET Core,
				// see https://go.microsoft.com/fwlink/?linkid=864501

				spa.Options.SourcePath = "ClientApp";

				if (env.IsDevelopment())
				{
					spa.UseAngularCliServer(npmScript: "start");
				}
			});
		}
	}
}
