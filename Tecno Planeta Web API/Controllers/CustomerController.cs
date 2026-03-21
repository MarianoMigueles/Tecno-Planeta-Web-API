using BLL.DTO.Users.Customer;
using BLL.Services;
using BLL.Services.Interfaces;
using Entities.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Tecno_Planeta_Web_API.Controllers
{
    [Authorize]
    public class CustomerController(ICustomerService service) : AbstractBaseController<ICustomerService>(service)
    {
        //--------------------------------- GET ------------------------------------------------------
        [HttpGet("by-name/{name}")]
        public async Task<ActionResult<CustomerResponseDTO>> GetByName(string name)
        {
            var customer = await service.GetByNameAsync(name);
            return Ok(customer);
        }

        [HttpGet("by-phone/{phone}")]
        public async Task<ActionResult<CustomerResponseDTO>> GetByPhone(string phone)
        {
            var customer = await service.GetByPhoneAsync(phone);
            return Ok(customer);
        }

        [HttpGet("by-register-date/{registerDate}")]
        public async Task<ActionResult<IEnumerable<CustomerResponseDTO>>> GetByRegisterDate(DateTime registerDate)
        {
            var customers = await service.GetByRegisterDateAsync(registerDate);
            return Ok(customers);
        }

        [AllowAnonymous]
        [HttpGet("periot")]
        public async Task<ActionResult<CustomerResponseDTO>> GetByPeriotOfTime(
            [FromQuery] DateTime startDate, 
            [FromQuery] DateTime endDate)
        {
            var customer = await service.GetByPeriodOfTimeAsync(startDate, endDate);
            return Ok(customer);
        }

        [AllowAnonymous]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CustomerResponseDTO>> GetById(int id)
        {
            var customer = await service.GetByIdAsync(id);
            return Ok(customer);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerResponseDTO>>> GetAll()
        {
            var customers = await service.GetAllAsync();
            return Ok(customers);
        }

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PATCH ------------------------------------------------------

        [Authorize(policy: "Admin")]
        [HttpPatch("{id:int}/name")]
        public async Task<ActionResult<CustomerResponseDTO>> UpdateName(int id, [FromQuery] string newName)
        {
            var customer = await service.UpdateNameAsync(id, newName);
            return Ok(customer);
        }

        [Authorize(policy: "Admin")]
        [HttpPatch("{id:int}/phone")]
        public async Task<ActionResult<CustomerResponseDTO>> UpdatePhone(int id, [FromQuery] string newPhone)
        {
            var customer = await service.UpdatePhoneAsync(id, newPhone);
            return Ok(customer);
        }
        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- DELETE ------------------------------------------------------

        [Authorize(policy: "Admin")]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await service.DeleteAsync(id);
            return NoContent();
        }
        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- POST ------------------------------------------------------

        [Authorize(policy: "Admin")]
        [HttpPost]
        public async Task<ActionResult<CustomerResponseDTO>> Create([FromBody] CustomerCreateDTO newCustomer)
        {
            var customer = await service.CreateAsync(newCustomer);
            return Ok(customer);
        }
        //----------------------------------------------------------------------------------------- <>
    }
}
