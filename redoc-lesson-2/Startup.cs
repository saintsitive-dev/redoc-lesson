using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
                config.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme { 
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        AuthorizationCode = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri("https://auth.builk.com/v1/api/auth"),
                            TokenUrl = new Uri("https://localhost:5000/connect/token"),
                            RefreshUrl = new Uri("https://localhost:5000/connect/refreshToken"),
                            Scopes = new Dictionary<string, string>
                            {
                                {"v1", "Demo API - full access"}
                            }
                        }
                    }
                });

                var filepath = Path.Combine(AppContext.BaseDirectory, "redoc-lesson-2.xml");
                config.IncludeXmlComments(filepath, includeControllerXmlComments: true);
                
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
