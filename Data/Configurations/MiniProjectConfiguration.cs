using MiniProject.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MiniProject.API.Data.Configurations;

public class MPConfigurationCP : IEntityTypeConfiguration<CustomerPromo>
{
  public void Configure(EntityTypeBuilder<CustomerPromo> builder)
  {
    builder.HasKey(cp => new { cp.IdCustomer, cp.IdPromo });

    builder.HasOne(cp => cp.Customer)
      .WithMany(c => c.CustomerPromos)
      .HasForeignKey(cp => cp.IdCustomer)
      .OnDelete(DeleteBehavior.Cascade);

    builder.HasOne(cp => cp.Promo)
      .WithMany(p => p.CustomerPromos)
      .HasForeignKey(cp => cp.IdPromo)
      .OnDelete(DeleteBehavior.Cascade);
  }

}

public class MPConfigurationPromo : IEntityTypeConfiguration<Promo>
{
  public void Configure(EntityTypeBuilder<Promo> builder)
  {
    builder.Property(promo => promo.Discount).HasPrecision(5, 2);
  }

}