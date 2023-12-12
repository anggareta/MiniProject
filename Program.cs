using MiniProject.API.Data;
using MiniProject.API.Endpoints;
using MiniProject.API.Entities;
using MiniProject.API.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<ICustomersRepository, EFCustomersRepository>();

var connString = builder.Configuration.GetConnectionString("MiniStoreContext");
builder.Services.AddSqlServer<MiniProjectContext>(connString);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapMiniEndpoints();

app.Run();