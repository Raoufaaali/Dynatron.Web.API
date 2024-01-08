using Dynatron.Web.API.Models;
using Dynatron.Web.API.Services.CustomerLogic;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dynatron.Web.API.Controllers
{

  [ApiController]
  [Route("[controller]")]
  public class CustomersController : Controller
  {

    private readonly ICustomerLogic _customerLogic;
    public CustomersController(ICustomerLogic customerLogic)
    {
      _customerLogic = customerLogic;
    }

    [HttpGet(Name = "Get All Customers")]
    public async Task<IActionResult> GetCustomers()
    {
      var response = await _customerLogic.GetAllCustomerAsync();
      return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Customer>> AddCustomer(Customer customer)
    {
      DataResult result = await _customerLogic.AddCustomerAsync(customer);
      if (result.Error != null && result.Error.IsError)
      {
        return Conflict(result.Error); // in the real world, we will check the error code against global/static values and determine what response code should be 
      }
      return Ok(result.SingleValue);
    }

    [HttpGet]
    [Route("{customerId}")]
    [Description("Get customer by id")]
    public async Task<IActionResult> GetCustomerById(int customerId)
    {
      DataResult result = await _customerLogic.GetCustomerByIdAsync(customerId);
      if (result.Error != null)
      {
        return NotFound();
        
      }
      return Ok(result.SingleValue);
    }


    [HttpPut]
    [Route("{customerId}")]
    public async Task<ActionResult<Customer>> UpdateCustomer([Range(1, int.MaxValue, ErrorMessage = "please provide a valid integer value for the id")] int customerId, [FromBody] Customer customer)
    {
      DataResult result = await _customerLogic.UpdateCustomerByIdAsync(customerId, customer);
      if (result.Error != null && result.Error.IsError)
      {
        return BadRequest(result.Error);
      }
      return NoContent();
    }


    [HttpDelete]
    [Route("{customerId}")]
    [Description("Delete Customer")]
    public async Task<IActionResult> DeleteAsync([Range(1, int.MaxValue, ErrorMessage = "please provide a valid integer value for the id")] int customerId)
    {
      DataResult result = await _customerLogic.DeleteCustomerByIdAsync(customerId);
      if (result.Error != null && result.Error.IsError)
      {
        if (result.Error.ErrorCode == 405)
        {
          return StatusCode(405, result.Error);
        }
        return BadRequest(result.Error);
      }
      return NoContent();
    }




  }
}
