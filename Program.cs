using MiniProject.API.Data;
using MiniProject.API.Endpoints;
using MiniProject.API.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddScoped<ICustomersRepository, EFCustomersRepository>();
builder.Services.AddScoped<IPromoRepository, EFPromoRepository>();
builder.Services.AddScoped<ICustPromoRepository, EFCustPromoRepository>();

var connString = builder.Configuration.GetConnectionString("MiniStoreContext");
builder.Services.AddSqlServer<MiniProjectContext>(connString);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapCustomerEndpoints();
app.MapPromoEndpoints();
app.MapCustPromoEndpoints();

app.Run();