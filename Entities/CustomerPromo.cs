using System.ComponentModel.DataAnnotations;

namespace MiniProject.API.Entities;

public class CustomerPromo
{
  public int? IdCustomer { get; set; }
  public int? IdPromo { get; set; }
  public virtual Customer? Customer { get; set; }
  public virtual Promo? Promo { get; set; }
}