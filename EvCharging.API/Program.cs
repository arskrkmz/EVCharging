using EvCharging.App.Interviews;
using EvCharging.App.Services;
using EvCharging.Core.Interviews;
using EvCharging.Core.Repositories;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text.Json;

namespace EvCharging.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();

        // Configure swagger documentation details and comments
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Ev Charging API",
                Version = "v1",
                Description = "An API to calculate best charging periods",
               
            });
            // Set the comments path for the Swagger JSON and UI.
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
        });


        builder.Services.AddScoped<IChargeService, ChargeService>();
        builder.Services.AddScoped<IChargeRepository, ChargeRepository>();

        
        var app = builder.Build();

        #region Configure exception handling middleware
        app.UseExceptionHandler(configure =>
        {
            configure.Run(async context =>
            {
                // Set the response status code
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";

                var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                var exception = errorFeature?.Error;

                // Create a response object
                var response = new
                {
                    error = new
                    {
                        message = exception?.Message,
                        stackTrace = exception?.StackTrace
                    }
                };

                // Serialize the response object to JSON
                var jsonResponse = JsonSerializer.Serialize(response);

                // Write the JSON response to the output
                await context.Response.WriteAsync(jsonResponse);
            });
        });

        #endregion

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}
