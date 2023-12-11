using System.Reflection;
using MiniProject.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace MiniProject.API.Data;

public class MiniProjectContext : DbContext
{
  public MiniProjectContext(DbContextOptions<MiniProjectContext> options) : base(options)
  {
  }

  public DbSet<Customer> Customers => Set<Customer>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }
}