
using Dynatron.Web.API.Models;

namespace Dynatron.Web.API.Services.CustomerLogic
{
  public interface ICustomerLogic
  {     
    Task<List<Customer>> GetAllCustomerAsync();

    Task<DataResult> GetCustomerByIdAsync(int id);

    Task<DataResult> AddCustomerAsync(Customer customer);

    Task<DataResult> UpdateCustomerByIdAsync(int id, Customer updatedCustomer);

    Task<DataResult> DeleteCustomerByIdAsync(int id);
  }
}
