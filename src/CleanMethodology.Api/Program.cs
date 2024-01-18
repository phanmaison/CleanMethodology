using CleanMethodology.Api;
using CleanMethodology.Application;
using CleanMethodology.Core.Helpers;
using CleanMethodology.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

// Add services to the container.
services
    .UseApi()
    .UseApplication()
    .UseInfrastructure();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseApiEndpoints();

LogHelper.Info("Application Started");

app.Run();