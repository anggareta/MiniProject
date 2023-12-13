using MiniProject.API.DTOs;
using MiniProject.API.Entities;

public interface ICustPromoRepository
{
  Task<IEnumerable<CustPromOut>> GetAllAsync();

  Task<CustomerPromo?> GetAsync(CustomerPromo cp);

  Task<IEnumerable<Promo>> GetPromoAsync(int CustomerId);

  Task<IEnumerable<Customer>> GetCustAsync(int PromoId);

  Task CreateAsync(CustPromoRecDTO cp);

  Task DeleteAsync(int CustomerId, int PromoId);
}