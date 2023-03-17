using Kwtc.ErrorMonitoring.Application;
using Kwtc.ErrorMonitoring.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services
       .AddPersistenceServices()
       .AddApplicationServices();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services
       .AddEndpointsApiExplorer()
       .AddSwaggerGen();

var app = builder.Build();

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
