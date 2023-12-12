using System.ComponentModel.DataAnnotations;

namespace MiniProject.API.DTOs;

public record CustomerDTO(
  int Id,
  string Name,
  DateTime BirthDate,
  string Address
);

public record CreateCustomerDTO(
  [Required][StringLength(50)] string Name,
  DateTime BirthDate,
  [Required][StringLength(20)] string Address
);

public record UpdateCustomerDTO(
  [Required][StringLength(50)] string Name,
  DateTime BirthDate,
  [Required][StringLength(20)] string Address
);

public record PromoDTO(
  int Id,
  string PromoName
);

public record CreatePromoDTO(
  [Required][StringLength(50)] string PromoName
);

public record UpdatePromoDTO(
  [Required][StringLength(50)] string PromoName
);

public record CustomerPromoDTO(
  int IdCustomer,
  int IdPromo,
  string CustomerName,
  string PromoName
);