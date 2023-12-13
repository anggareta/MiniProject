using Microsoft.EntityFrameworkCore;
using MiniProject.API.Repositories;

namespace MiniProject.API.Data;

public static class DataExtentions
{
  public static void InitializeDb(this IServiceProvider serviceProvider)
  {
    using var scope = serviceProvider.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<MiniProjectContext>();
    dbContext.Database.Migrate();
  }

  public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
  {
    var connString = configuration.GetConnectionString("MiniStoreContext");
    services.AddSqlServer<MiniProjectContext>(connString)
      .AddScoped<ICustomersRepository, EFCustomersRepository>()
      .AddScoped<IPromoRepository, EFPromoRepository>()
      .AddScoped<ICustPromoRepository, EFCustPromoRepository>();

    return services;
  }
}