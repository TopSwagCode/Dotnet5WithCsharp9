using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace LightweightWebApi
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
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/weather/{city}", async context =>
                {
                    var city = (string)context.Request.RouteValues["city"];
                    var weather = new WeatherForecast
                    {
                        Date = DateTime.Now,
                        Summary = $"All good in {city}",
                        TemperatureC = 13
                    };

                    // JSON extension methods for HttpRequest and HttpResponse using the new ReadFromJsonAsync and WriteAsJsonAsync
                    await context.Response.WriteAsJsonAsync(weather);
                })
                .AllowAnonymous();
            });
        }
    }
}
