using Dynatron.DAL;
using Dynatron.Web.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Dynatron.Web.API.DAL
{
  public class DataRepository : IDataRepository
  {

    private readonly CustomerContext _context;

    public DataRepository(CustomerContext context)
    {
      _context = context;
    }

    public async Task<List<Customer>> GetAllCustomerAsync()
    {
      return await _context.Customers.ToListAsync();
    }

    public async Task<Customer?> GetCustomerByIdAsync(int id)
    {
      return await _context.Customers.FindAsync(id);
    }

    public async Task<bool> UpdateCustomerByIdAsync(int id, Customer updatedCustomer)
    {
     // updatedCustomer.Id = id;
      var existingCustomer = await _context.Customers.FindAsync(id);
      if (existingCustomer == null) {
        return false;
      }

      existingCustomer.FirstName = updatedCustomer.FirstName;
      existingCustomer.LastName = updatedCustomer.LastName;
      existingCustomer.Email = updatedCustomer.Email;
      existingCustomer.UpdatedDate = DateTime.Now;
      await _context.SaveChangesAsync();
      return true;
    }

    public async Task<int> AddCustomerAsync(Customer customer)
    {
      _context.Customers.Add(customer);

      int id = await _context.SaveChangesAsync();
      return id;

    }

    public async Task<bool> DeleteCustomerByIdAsync(int id)
    {
      var customer =  await _context.Customers.FindAsync(id);
      if (customer == null)
      {
        return false;
      }
      _context.Customers.Remove(customer);
      await _context.SaveChangesAsync();
      return true;
    }

    public async Task<int> GetCustmersCountAsync()
    {
      return await _context.Customers.CountAsync();
    }
  }
}
