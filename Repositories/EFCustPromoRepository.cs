using Microsoft.EntityFrameworkCore;
using MiniProject.API.Data;
using MiniProject.API.DTOs;
using MiniProject.API.Entities;

namespace MiniProject.API.Repositories;
public class EFCustPromoRepository : ICustPromoRepository
{
  private readonly ILogger _logger;
  private readonly MiniProjectContext dbContext;

  public EFCustPromoRepository(MiniProjectContext dbContext, ILogger<EFCustPromoRepository> logger)
  {
    this.dbContext = dbContext;
    _logger = logger;
  }

  public async Task<IEnumerable<CustPromOut>> GetAllAsync()
  {
    //return await dbContext.TTPromo.AsNoTracking().ToListAsync();
    var T = dbContext.TTPromo;
    var C = dbContext.TMCustomer;
    var P = dbContext.TMPromo;
    var o = from x in T
            join c in C on x.IdCustomer equals c.Id
            join p in P on x.IdPromo equals p.Id
            select new CustPromOut
            {
              IdCustomer = x.IdCustomer,
              IdPromo = x.IdPromo,
              CustomerName = c.Name,
              PromoName = p.PromoName
            };
    _logger.LogError("masuk");
    return await o.ToListAsync();
  }

  public async Task<CustomerPromo?> GetAsync(CustomerPromo cp)
  {
    var o = from a in dbContext.TTPromo
            where a.IdCustomer == cp.IdCustomer && a.IdPromo == cp.IdPromo
            select new CustomerPromo
            {
              IdCustomer = a.IdCustomer,
              IdPromo = a.IdPromo
            };

    return await o.FirstAsync();
  }

  public async Task<IEnumerable<Customer>> GetCustAsync(int PromoId)
  {
    var C = dbContext.TMCustomer;
    var T = dbContext.TTPromo;
    var o = from c in C
            join x in T on c.Id equals x.IdCustomer
            where x.IdPromo == PromoId
            select new Customer
            {
              Id = c.Id,
              Name = c.Name,
              BirthDate = c.BirthDate,
              Address = c.Address
            };

    return await o.ToListAsync();
  }

  public async Task<IEnumerable<Promo>> GetPromoAsync(int CustomerId)
  {
    var C = dbContext.TMPromo;
    var T = dbContext.TTPromo;
    var o = from c in C
            join x in T on c.Id equals x.IdCustomer
            where x.IdPromo == CustomerId
            select new Promo
            {
              Id = c.Id,
              PromoName = c.PromoName
            };

    return await o.ToListAsync();
  }

  public async Task CreateAsync(CustPromoRecDTO cpr)
  {
    var c = await (from x in dbContext.TMCustomer
                   where x.Id == cpr.IdCustomer
                   select x).FirstOrDefaultAsync();
    var p = await (from x in dbContext.TMPromo
                   where x.Id == cpr.IdPromo
                   select x).FirstOrDefaultAsync();

    if (c is not null && p is not null)
    {
      var o = await (from x in dbContext.TTPromo
                     where x.IdCustomer == cpr.IdCustomer && x.IdPromo == cpr.IdPromo
                     select new CustPromOut
                     {
                       IdCustomer = x.IdCustomer,
                       IdPromo = x.IdPromo,
                       CustomerName = c.Name,
                       PromoName = p.PromoName
                     }).FirstOrDefaultAsync();
      //_logger.LogError("diisi:" + c.Name);
      if (o is null)
      {
        CustomerPromo cp = new()
        {
          IdCustomer = cpr.IdCustomer,
          IdPromo = cpr.IdPromo
        };
        dbContext.TTPromo.Add(cp);
        await dbContext.SaveChangesAsync();
      }
      else
      {
        await Task.CompletedTask;
      }
    }
    else
    {
      await Task.CompletedTask;
    }
  }

  public async Task DeleteAsync(int CustomerId, int PromoId)
  {
    // await (from x in dbContext.TTPromo
    //        where x.IdCustomer == cpr.IdCustomer && x.IdPromo == cpr.IdPromo
    //        select x).ExecuteDeleteAsync();
    await dbContext.TTPromo.Where(cp => cp.IdCustomer == CustomerId).ExecuteDeleteAsync();
  }

}