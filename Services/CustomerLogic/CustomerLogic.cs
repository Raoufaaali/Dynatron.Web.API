using Dynatron.DAL;
using Dynatron.Web.API.DAL;
using Dynatron.Web.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;

namespace Dynatron.Web.API.Services.CustomerLogic
{
  public class CustomerLogic : ICustomerLogic
  {
    
    private const int CustomerIdExistsErrorCode = 123;
    private const int NotAllowed = 405;
    private const string CustomerIdExistsAlready = "Customer Id Exists Already";
    private const string CustomerDoesntExistMessage = "Customer doesnt exist";
    private const int CustomerDoesntExistErrorCode = 101;
    private readonly IDataRepository _repo;

    public CustomerLogic(IDataRepository repository)
    {
      _repo = repository;
    }

    public async Task<List<Customer>> GetAllCustomerAsync()
    {
      return await _repo.GetAllCustomerAsync();
    }
    public async Task<DataResult> GetCustomerByIdAsync(int id)
    {
      var result = new DataResult();

      var customer = await _repo.GetCustomerByIdAsync(id);
      if (customer != null)
      {
        result.SingleValue = customer;
        return result;
      }

      else
      {
        result.Error = new Error()
        {
          IsError = false,
          ErrorCode = CustomerDoesntExistErrorCode,
          Message = CustomerDoesntExistMessage,
          ErrorList = new string[] { $"There is no customer with the specified id: {id}" }
        };

      }
      return result;
    }
    public async Task<DataResult> AddCustomerAsync(Customer customer)
    {
      var result = new DataResult();

      var existingCustomer = await _repo.GetCustomerByIdAsync(customer.Id);
      if (existingCustomer != null)
      {
        result.Error = new Error()
        {
          IsError = true,
          ErrorCode = CustomerIdExistsErrorCode,
          Message = CustomerIdExistsAlready,
          ErrorList = new string[] { $"There is already an existing customer with the specified id: {customer.Id}. Either don't pass an Id to create a new customer or send a PUT request to update the existing customer" }
        };
        return result;
      }

      customer.CreatedDate = DateTime.Now;
      customer.UpdatedDate = null;
      int id = await _repo.AddCustomerAsync(customer);
      result.SingleValue = id;
      return result;
    }

    public async Task<DataResult> UpdateCustomerByIdAsync(int id, Customer updatedCustomer)
    {
      var result = new DataResult();
      var isUpdated = await _repo.UpdateCustomerByIdAsync(id, updatedCustomer); // _context.Customers.FindAsync(id);

      if (!isUpdated)
      {
        result.Error = new Error()
        {
          IsError = true,
          ErrorCode = CustomerDoesntExistErrorCode,
          Message = CustomerDoesntExistMessage,
          ErrorList = new string[] { $"There is no customer with the specified id: {id}" }
        };
        return result;
      }

      return result;
    }

    public async Task<DataResult> DeleteCustomerByIdAsync(int id)
    {
      var result = new DataResult();

      var currentTotalCustomers = await _repo.GetCustmersCountAsync();

      if (currentTotalCustomers == 20)
      {
        result.Error = new Error()
        {
          IsError = true,
          ErrorCode = NotAllowed,
          Message = "This call will make the total customers in teh system less than 20",
          ErrorList = new string[] { $"This call will make the total customers in teh system less than 20" }
        };
        return result;

      }

      var isDeleted = await _repo.DeleteCustomerByIdAsync(id);

      if (!isDeleted)
      {
        result.Error = new Error()
        {
          IsError = true,
          ErrorCode = CustomerDoesntExistErrorCode,
          Message = CustomerDoesntExistMessage,
          ErrorList = new string[] { $"There is no customer with the specified id: {id}" }
        };
        return result;
      }
      return result;
    }
  }
}
