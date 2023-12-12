using Microsoft.EntityFrameworkCore;
using MiniProject.API.Data;
using MiniProject.API.Entities;

namespace MiniProject.API.Repositories;

public class EFPromoRepository : IPromoRepository
{
  private readonly MiniProjectContext dbContext;

  public EFPromoRepository(MiniProjectContext dbContext)
  {
    this.dbContext = dbContext;
  }

  public async Task<IEnumerable<Promo>> GetAllAsync()
  {
    return await dbContext.TMPromo.AsNoTracking().ToListAsync();
  }

  public async Task<Promo?> GetAsync(int id)
  {
    return await dbContext.TMPromo.FindAsync(id);
  }

  public async Task CreateAsync(Promo promo)
  {
    dbContext.TMPromo.Add(promo);
    await dbContext.SaveChangesAsync();
  }

  public async Task UpdateAsync(Promo updatedPromo)
  {
    dbContext.TMPromo.Update(updatedPromo);
    await dbContext.SaveChangesAsync();
  }

  public async Task DeleteAsync(int id)
  {
    await dbContext.TMPromo.Where(promo => promo.Id == id).ExecuteDeleteAsync();
  }
}
