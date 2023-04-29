using Api.Infraestructure.DependencyInjection;
using Api.Presentation.Example;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureApi();

var app = builder.Build();

app.ConfigureApi()
   .UseHttpsRedirection();

app.AddRoutes();

app.Run();