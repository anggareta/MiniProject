using Microsoft.EntityFrameworkCore;
using MiniProject.API.Data;
using MiniProject.API.Entities;

namespace MiniProject.API.Repositories;

public class EFCustomersRepository : ICustomersRepository
{
  private readonly MiniProjectContext dbContext;

  public EFCustomersRepository(MiniProjectContext dbContext)
  {
    this.dbContext = dbContext;
  }

  public IEnumerable<Customer> GetAll()
  {
    return dbContext.TMCustomer.AsNoTracking().ToList();
  }

  public Customer? Get(int id)
  {
    return dbContext.TMCustomer.Find(id);
  }

  public void Create(Customer cust)
  {
    dbContext.TMCustomer.Add(cust);
    dbContext.SaveChanges();
  }

  public void Update(Customer updatedCustomer)
  {
    dbContext.TMCustomer.Update(updatedCustomer);
    dbContext.SaveChanges();
  }

  public void Delete(int id)
  {
    dbContext.TMCustomer.Where(cust => cust.Id == id).ExecuteDelete();
  }
}