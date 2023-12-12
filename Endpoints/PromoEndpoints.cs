using MiniProject.API.DTOs;
using MiniProject.API.Entities;
using MiniProject.API.Repositories;

namespace MiniProject.API.Endpoints;

public static class PromoEndpoints
{
  const string GetPromoEndpointName = "GetPromo";

  public static RouteGroupBuilder MapPromoEndpoints(this IEndpointRouteBuilder routes)
  {
    var group = routes.MapGroup("/promo").WithParameterValidation();

    group.MapGet("/", async (IPromoRepository repository) => (await repository.GetAllAsync()).Select(promo => promo.AsPromoDTO()));

    group.MapGet("/{id}", async (IPromoRepository repository, int id) =>
    {
      Promo? promo = await repository.GetAsync(id);
      return promo is not null ? Results.Ok(promo.AsPromoDTO()) : Results.NotFound();
    })
    .WithName(GetPromoEndpointName);

    group.MapPost("/", async (IPromoRepository repository, CreatePromoDTO promoDTO) =>
    {
      Promo promo = new()
      {
        PromoName = promoDTO.PromoName,
      };

      await repository.CreateAsync(promo);
      return Results.CreatedAtRoute<Promo>(GetPromoEndpointName, new { id = promo.Id }, promo);
    });

    group.MapPut("/{id}", async (IPromoRepository repository, int id, UpdatePromoDTO updatePromoDTO) =>
    {
      Promo? existingPromo = await repository.GetAsync(id);

      if (existingPromo is null)
      {
        return Results.NotFound();
      }

      existingPromo.PromoName = updatePromoDTO.PromoName;
      await repository.UpdateAsync(existingPromo);
      return Results.NoContent();
    });

    group.MapDelete("/{id}", async (IPromoRepository repository, int id) =>
    {
      Promo? promo = await repository.GetAsync(id);

      if (promo is not null)
      {
        await repository.DeleteAsync(id);
      }

      return Results.NoContent();
    });

    return group;
  }
}