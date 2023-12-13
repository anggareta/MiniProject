using MiniProject.API.DTOs;
using MiniProject.API.Entities;

namespace MiniProject.API.Endpoints;

public static class CustPromoEndpoints
{
  const string GetCPEndpointName = "GetCustomerPromo";

  public static RouteGroupBuilder MapCustPromoEndpoints(this IEndpointRouteBuilder routes)
  {
    var group = routes.MapGroup("/custpromo").WithParameterValidation();

    group.MapGet("/", async (ICustPromoRepository repository) => (await repository.GetAllAsync()).Select(cp => cp.AsCustPromo()))
      .WithName(GetCPEndpointName);

    group.MapGet("/bypromo/{id}", async (ICustPromoRepository repository, int id) => (await repository.GetCustAsync(id)).Select(cust => cust.AsDTO()));

    group.MapGet("/bycustomer/{id}", async (ICustPromoRepository repository, int id) => (await repository.GetPromoAsync(id)).Select(promo => promo.AsPromoDTO()));

    group.MapPost("/", async (ICustPromoRepository repository, CustPromoRecDTO cp) =>
    {
      await repository.CreateAsync(cp);
      return Results.Created("/custpromo", cp);
    });

    group.MapDelete("/{customer}/{promo}", async (ICustPromoRepository repository, int customer, int promo) =>
    {
      await repository.DeleteAsync(customer, promo);
      return Results.NoContent();
    });

    return group;
  }
}