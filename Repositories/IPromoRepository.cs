using MiniProject.API.Entities;

namespace MiniProject.API.Repositories;

public interface IPromoRepository
{
  Task CreateAsync(Promo promo);
  Task DeleteAsync(int id);
  Task<Promo?> GetAsync(int id);
  Task<IEnumerable<Promo>> GetAllAsync();
  Task UpdateAsync(Promo updatedPromo);
}