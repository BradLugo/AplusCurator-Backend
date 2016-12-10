using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using AplusCurator.Models;
using Microsoft.EntityFrameworkCore;

namespace AplusCurator
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });


            // Add database services
            var connection = @"Server=(localdb)\mssqllocaldb;Database=APCurator.NewDb;Trusted_Connection=True;";
            services.AddDbContext<InstructorDbContext>(options => options.UseSqlServer(connection));
            services.AddDbContext<StudentDbContext>(options => options.UseSqlServer(connection));
            services.AddDbContext<GuardianDbContext>(options => options.UseSqlServer(connection));
            services.AddDbContext<ContentDbContext>(options => options.UseSqlServer(connection));
            services.AddDbContext<UserDbContext>(options => options.UseSqlServer(connection));

            services.AddMvc()
                    .AddJsonOptions(jsonOptions =>
                    {
                        jsonOptions.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                    });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<InstructorDbContext>().Database.Migrate();
                serviceScope.ServiceProvider.GetService<InstructorDbContext>().EnsureSeedData();
                serviceScope.ServiceProvider.GetService<StudentDbContext>().Database.Migrate();
                serviceScope.ServiceProvider.GetService<StudentDbContext>().EnsureSeedData();
            }

            app.UseCors("CorsPolicy");

            app.UseApplicationInsightsRequestTelemetry();

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseMvc();
        }
    }
}
