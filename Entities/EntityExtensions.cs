using MiniProject.API.DTOs;

namespace MiniProject.API.Entities;

public static class EntityExtensions
{
  public static CustomerDTO AsDTO(this Customer cust)
  {
    return new CustomerDTO(
      cust.Id,
      cust.Name,
      cust.BirthDate,
      cust.Address
    );
  }

  public static PromoDTO AsPromoDTO(this Promo promo)
  {
    return new PromoDTO(
      promo.Id,
      promo.PromoName
    );
  }

}