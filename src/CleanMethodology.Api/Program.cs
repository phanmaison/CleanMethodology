using CleanMethodology.Api.DependencyInjections;
using CleanMethodology.Api.Endpoints;
using CleanMethodology.Application.DependencyInjections;
using CleanMethodology.Core.Helpers;
using CleanMethodology.Infrastructure.DependencyInjections;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

// Add services to the container.
services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen();

services
    .UseApi()
    .UseApplication()
    .UseInfrastructure();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

// minimal endpoints
app.RegisterWeatherForecastEndpoints();

LogHelper.Info("Application Started");

app.Run();