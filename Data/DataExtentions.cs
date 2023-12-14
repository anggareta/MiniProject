using Microsoft.EntityFrameworkCore;
using MiniProject.API.Repositories;
using MiniProject.API.Entities;

namespace MiniProject.API.Data;

public static class DataExtentions
{
  public static void InitializeDb(this IServiceProvider serviceProvider)
  {
    using var scope = serviceProvider.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<MiniProjectContext>();
    dbContext.Database.Migrate();
    dbContext.Database.EnsureCreated();

    DataSeeder.SeedData(dbContext);
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

public static class DataSeeder
{
  public static void SeedData(MiniProjectContext context)
  {
    if (!context.TMCustomer.Any())
    {
      context.TMCustomer.AddRange(
        new Customer() { Name = "Ayus", BirthDate = new DateTime(1981, 3, 11), Address = "Pasir Impun" },
        new Customer() { Name = "Icha", BirthDate = new DateTime(1994, 11, 15), Address = "Maleber" },
        new Customer() { Name = "Zeta", BirthDate = new DateTime(2015, 10, 19), Address = "Ks.Tubun" },
        new Customer() { Name = "Kena", BirthDate = new DateTime(2017, 3, 21), Address = "Palmerah" },
        new Customer() { Name = "Deba", BirthDate = new DateTime(2021, 6, 5), Address = "Parung Panjang" }
      );
      context.SaveChanges();
    }

    if (!context.TMPromo.Any())
    {
      context.TMPromo.AddRange(
        new Promo() { PromoName = "Tahun Baru", Discount = 11.26M },
        new Promo() { PromoName = "Hari Raya Idul Fitri", Discount = 13.33M },
        new Promo() { PromoName = "Libur Sekolah", Discount = 8.25M }
      );
      context.SaveChanges();
    }

    if (!context.TTPromo.Any())
    {
      context.TTPromo.AddRange(
        new CustomerPromo() { IdCustomer = 1, IdPromo = 1 },
        new CustomerPromo() { IdCustomer = 1, IdPromo = 2 },
        new CustomerPromo() { IdCustomer = 2, IdPromo = 2 },
        new CustomerPromo() { IdCustomer = 3, IdPromo = 3 },
        new CustomerPromo() { IdCustomer = 4, IdPromo = 3 },
        new CustomerPromo() { IdCustomer = 5, IdPromo = 3 },
        new CustomerPromo() { IdCustomer = 5, IdPromo = 1 },
        new CustomerPromo() { IdCustomer = 5, IdPromo = 2 }
      );
      context.SaveChanges();
    }
  }

}