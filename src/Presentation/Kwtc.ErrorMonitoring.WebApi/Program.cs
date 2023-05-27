using Kwtc.ErrorMonitoring.Api;
using Kwtc.ErrorMonitoring.Application;
using Kwtc.ErrorMonitoring.Persistence;
using Kwtc.ErrorMonitoring.WebApi.Groups.Event;
using Kwtc.ErrorMonitoring.WebApi.Groups.Report;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

var builder = WebApplication.CreateBuilder(args);

builder.Services
       .AddApplicationServices()
       .AddPersistenceServices()
       .AddApiServices();

builder.Services.AddAuthentication();

var app = builder.Build();

// Configure the HTTP request pipeline.
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

app.UseAuthentication();

// TODO: move to static mapper class 
app.MapGroup("/events")
   .MapEventGroup();

app.MapGroup("/report")
   .MapReportGroup();

app.Run();
