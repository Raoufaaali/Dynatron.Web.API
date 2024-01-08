using Dynatron.Web.API.Models;

namespace Dynatron.Web.API.DAL
{
  public interface IDataRepository
  {
    Task<List<Customer>> GetAllCustomerAsync();

    Task<Customer?> GetCustomerByIdAsync(int id);

    Task<int> AddCustomerAsync(Customer customer);

    Task<bool> UpdateCustomerByIdAsync(int id, Customer updatedCustomer);

    Task<bool> DeleteCustomerByIdAsync(int id);

    Task<int> GetCustmersCountAsync();
  }
}
