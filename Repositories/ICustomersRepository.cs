using MiniProject.API.Entities;

namespace MiniProject.API.Repositories;

public interface ICustomersRepository
{
  void Create(Customer cust);
  void Delete(int id);
  Customer? Get(int id);
  IEnumerable<Customer> GetAll();
  void Update(Customer updatedCustomer);
}
