using NorthWind.Entities;
using NorthWind.Loggers;
using NorthWind.Mail;
using NorthWind.Sales.Controllers;
using NorthWind.Sales.DTOs;
using NorthWind.Sales.Events;
using NorthWind.Sales.Presenters;
using NorthWind.Sales.Repositories.IoC;
using NorthWind.Sales.UseCases;
using NorthWind.WebExceptionPresenters.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEntityServices()
    .AddLoggers()
    .AddEventHandlers()
    .AddMailService()
    .AddRepositories(builder.Configuration, "NorthWindSales")
    .AddUseCasesServices()
    .AddDTOValidators()
    .AddPresenters()
    .AddNorthWindSalesControllers();

builder.Services.AddControllers(Filters.Register);
builder.Services.AddCors(options =>
{
    options.AddPolicy("default", config =>
    {
        config.AllowAnyMethod();
        config.AllowAnyHeader();
        config.AllowAnyOrigin();
    });
});



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("default");

app.MapControllers();

app.Run();

