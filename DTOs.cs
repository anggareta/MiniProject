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