using Kwtc.ErrorMonitoring.Api;
using Kwtc.ErrorMonitoring.Api.Configuration;
using Kwtc.ErrorMonitoring.Application;
using Kwtc.ErrorMonitoring.Persistence;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

var builder = WebApplication.CreateBuilder(args);

builder.Services
       .AddApplicationServices()
       .AddPersistenceServices()
       .AddApiServices();

builder.Services
       .AddConfiguredApiVersioning()
       .AddConfiguredSwagger()
       .AddConfiguredControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
    app.UseSwaggerUI(options =>
    {
        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName);
        }
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
