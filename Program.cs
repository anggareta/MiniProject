using Microsoft.EntityFrameworkCore;
using MiniProject.API.Data;
using MiniProject.API.Endpoints;
using MiniProject.API.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddRepositories(builder.Configuration);
var app = builder.Build();

app.Services.InitializeDb();

app.MapGet("/", () => "Hello World!");

app.MapCustomerEndpoints();
app.MapPromoEndpoints();
app.MapCustPromoEndpoints();

app.Run();