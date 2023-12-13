namespace MiniProject.API.Entities;

public class CustomerPromo
{
  public int IdCustomer { get; set; }
  public int IdPromo { get; set; }
  public virtual Customer? Customer { get; set; }
  public virtual Promo? Promo { get; set; }
}

public class CustPromOut
{
  public int IdCustomer { get; set; }
  public int IdPromo { get; set; }
  public required string CustomerName { get; set; }
  public required string PromoName { get; set; }
}

public class PromoByCust
{
  public int IdPromo { get; set; }
  public required string PromoName { get; set; }
}