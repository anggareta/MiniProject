using System.ComponentModel.DataAnnotations;

namespace MiniProject.API.Entities;

public class Promo
{
  public int Id { get; set; }

  [Required]
  [StringLength(50)]
  public required string PromoName { get; set; }

  [Range(0, 100)]
  public decimal Discount { get; set; }

  public ICollection<CustomerPromo>? CustomerPromos { get; set; }
}