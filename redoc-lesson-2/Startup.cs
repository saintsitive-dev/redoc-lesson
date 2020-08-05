using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Models;

namespace redoc_lesson_2
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
            services.AddSwaggerGen(config=> {
                config.SwaggerDoc("v1", new OpenApiInfo() { 
                    Title = "Weather Forecast",
                    Extensions = new Dictionary<string, IOpenApiExtension>
                    {
                        {"x-logo", new OpenApiObject
                            {
                                {"url", new OpenApiString("https://jubili.builk.com/dist/asset/images/logo.svg")},
                                { "altText", new OpenApiString("Builk logo")}
                            }
                        }
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseReDoc(config=> {
                config.SpecUrl("/swagger/v1/swagger.json");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
