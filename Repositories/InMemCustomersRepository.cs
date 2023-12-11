using MiniProject.API.Entities;

namespace MiniProject.API.Repositories;

public class InMemCustomersRepository : ICustomersRepository
{
  private readonly List<Customer> customer = new()
  {
    new Customer(){
      Id = 1,
      Name = "Ayus",
      BirthDate = new DateTime(1981,3,11),
      Address = "Pasir Impun",
    },
    new Customer(){
      Id = 2,
      Name = "Meisha",
      BirthDate = new DateTime(1994,7,7),
      Address = "Maleber",
    },
    new Customer(){
      Id = 3,
      Name = "Zeta",
      BirthDate = new DateTime(2015,10,15),
      Address = "Parung Panjang",
    }
  };

  public IEnumerable<Customer> GetAll()
  {
    return customer;
  }

  public Customer? Get(int id)
  {
    return customer.Find(cust => cust.Id == id);
  }

  public void Create(Customer cust)
  {
    cust.Id = customer.Max(cust => cust.Id) + 1;
    customer.Add(cust);
  }

  public void Update(Customer updatedCust)
  {
    var index = customer.FindIndex(cust => cust.Id == updatedCust.Id);
    customer[index] = updatedCust;
  }

  public void Delete(int id)
  {
    var index = customer.FindIndex(cust => cust.Id == id);
    customer.RemoveAt(index);
  }
}