using MediatR;
using System.Reflection;
using Utilities.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api
{
	/// <summary>
	/// 
	/// </summary>
	public class Startup : object
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="configuration"></param>
		public Startup(Microsoft.Extensions.Configuration.IConfiguration configuration) : base()
		{
			Configuration = configuration;
		}

		/// <summary>
		/// 
		/// </summary>
		protected Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="services"></param>
		public void ConfigureServices
			(Microsoft.Extensions.DependencyInjection.IServiceCollection services)
		{
			services.AddControllers();

			// **************************************************
			services.AddTransient
				<Microsoft.AspNetCore.Http.IHttpContextAccessor,
				Microsoft.AspNetCore.Http.HttpContextAccessor>();

			services.AddTransient
				(serviceType: typeof(Dtat.Logging.ILogger<>),
				implementationType: typeof(Dtat.Logging.NLogAdapter<>));
			// **************************************************

			// **************************************************
			services.AddTransient<Persistence.DatabaseContext>();
			// **************************************************

			// **************************************************
			// using MediatR;
			//services.AddMediatR(typeof(Startup));

			// using System.Reflection;
			services.AddMediatR(typeof
				(Application.Users.EventHandlers.UserPasswordChangedEventHandler)
				.GetTypeInfo().Assembly);
			// **************************************************

			// **************************************************
			services.AddTransient<Persistence.IUnitOfWork, Persistence.UnitOfWork>();
			// **************************************************

			// **************************************************
			services.AddDbContext<Persistence.DatabaseContext>(options =>
			{
				options.UseSqlServer(Configuration["Database:ConnectionString"]);
			});
			// **************************************************

			// **************************************************
			// **************************************************
			// **************************************************
			services.AddSwaggerGen(current =>
			{
				// **************************************************
				// Set the comments path for the Swagger JSON and UI.
				// File Name: Application.xml
				var xmlFile =
					$"{ System.Reflection.Assembly.GetExecutingAssembly().GetName().Name }.xml";

				var xmlPathName =
					System.IO.Path.Combine(System.AppContext.BaseDirectory, xmlFile);

				current.IncludeXmlComments(filePath: xmlPathName);
				// **************************************************

				current.SwaggerDoc
					(name: "v1",
					info: new Microsoft.OpenApi.Models.OpenApiInfo
					{
						Version = "v1",
						Title = "Application",

						Description = "My Description",

						TermsOfService =
							new System.Uri("https://DTApp.ir/"),

						Contact = new Microsoft.OpenApi.Models.OpenApiContact
						{
							Name = "Dariush Tasdighi",
							Email = "DariushT@GMail.com",
							Url = new System.Uri("https://WebsiteAnalytics.ir"),
						},

						License = new Microsoft.OpenApi.Models.OpenApiLicense
						{
							Name = "Use under MIT",
							Url = new System.Uri("https://blog.georgekosmidis.net/privacy-policy/"),
						},
					});
			});
			// **************************************************
			// **************************************************
			// **************************************************
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="app"></param>
		/// <param name="env"></param>
		public void Configure
			(Microsoft.AspNetCore.Builder.IApplicationBuilder app,
			Microsoft.AspNetCore.Hosting.IWebHostEnvironment env)
		{
			app.UseExceptionHandling();

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();

				// **************************************************
				app.UseSwagger();

				app.UseSwaggerUI(current =>
				{
					current.SwaggerEndpoint("/swagger/v1/swagger.json", "Application v1");
				});
				// **************************************************
			}

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
