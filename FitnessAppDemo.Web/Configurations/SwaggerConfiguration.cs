using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;

namespace FitnessAppDemo.Web.Configurations
{
    public static class SwaggerConfiguration
    {
        public static void Configure(WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(options =>
            {
                // add API information and description
                options.SwaggerDoc("v1.0", new OpenApiInfo
                {
                    Version = "v1.0",
                    Title = "FitnessApp API",
                    Description = "An ASP.NET Core Web API for obtaining the nutritional value of products",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Example Contact",
                        Url = new Uri("https://example.com/contact")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Example License",
                        Url = new Uri("https://example.com/license")
                    }
                });

                // enable Swagger examples
                // install Swashbuckle.AspNetCore.Filters nuget
                // [SwaggerRequestExample] & [SwaggerResponseExample]
                // version < 3.0 like this: c.OperationFilter<ExamplesOperationFilter>(); 
                // version 3.0 like this: c.AddSwaggerExamples(services.BuildServiceProvider());
                // version > 4.0 like this:
                options.ExampleFilters();

                // configure swagger to use generated xml
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });

            // add swagger examples
            builder.Services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());
        }

        public static void UseSwagger(WebApplication app)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1.0/swagger.json", "v1.0");
                options.RoutePrefix = string.Empty;
            });
        }
    }
}
