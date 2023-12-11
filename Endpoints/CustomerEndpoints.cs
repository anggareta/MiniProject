using MiniProject.API.DTOs;
using MiniProject.API.Entities;
using MiniProject.API.Repositories;

namespace MiniProject.API.Endpoints;

public static class CustomerEndpoints
{
  const string GetCustomerEndpointName = "GetCustomer";

  public static RouteGroupBuilder MapMiniEndpoints(this IEndpointRouteBuilder routes)
  {
    var group = routes.MapGroup("/customer").WithParameterValidation();

    group.MapGet("/", (ICustomersRepository repository) => repository.GetAll().Select(cust => cust.AsDTO()));

    group.MapGet("/{id}", (ICustomersRepository repository, int id) =>
    {
      Customer? cust = repository.Get(id);
      return cust is not null ? Results.Ok(cust.AsDTO()) : Results.NotFound();
    })
    .WithName(GetCustomerEndpointName);

    group.MapPost("/", (ICustomersRepository repository, CreateCustomerDTO custDTO) =>
    {
      Customer cust = new()
      {
        Name = custDTO.Name,
        Address = custDTO.Address,
        BirthDate = custDTO.BirthDate,
      };
      repository.Create(cust);
      return Results.CreatedAtRoute<Customer>(GetCustomerEndpointName, new { id = cust.Id }, cust);
    });

    group.MapPut("/{id}", (ICustomersRepository repository, int id, UpdateCustomerDTO updateCustDTO) =>
    {
      Customer? existingCustomer = repository.Get(id);

      if (existingCustomer is null)
      {
        return Results.NotFound();
      }

      existingCustomer.Name = updateCustDTO.Name;
      existingCustomer.Address = updateCustDTO.Address;
      existingCustomer.BirthDate = updateCustDTO.BirthDate;

      repository.Update(existingCustomer);

      return Results.NoContent();
    });

    group.MapDelete("/{id}", (ICustomersRepository repository, int id) =>
    {
      Customer? cust = repository.Get(id);

      if (cust is not null)
      {
        repository.Delete(id);
      }

      return Results.NoContent();
    });

    return group;
  }
}