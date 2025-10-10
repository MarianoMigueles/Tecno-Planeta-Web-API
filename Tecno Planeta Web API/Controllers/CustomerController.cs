using BLL.DTO.User;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Tecno_Planeta_Web_API.Controllers
{
    [Authorize]
    public class CustomerController(ICustomerService service) : AbstractBaseController<ICustomerService>(service)
    {
        //--------------------------------- GET ------------------------------------------------------
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetCustomer(
            [FromQuery] string name,
            [FromQuery] string phone,
            [FromQuery] DateTime? registerDate)
        {
            // Lógica: aplicar filtros opcionales
            // Ejemplo: _service.GetFilteredAsync(name, phone, registerDate);
            throw new NotImplementedException();
        }

        [AllowAnonymous]
        [HttpGet("periot")]
        public async Task<ActionResult<CustomerDTO>> GetByPeriotOfTime(
            [FromQuery] DateTime startDate, 
            [FromQuery] DateTime endDate)
        {
            throw new NotImplementedException();
        }

        [AllowAnonymous]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CustomerDTO>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetAll()
        {
            throw new NotImplementedException();
        }

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PATCH ------------------------------------------------------

        [Authorize(policy: "Admin")]
        [HttpPatch("{id:int}/name")]
        public Task<ActionResult<CustomerDTO>> UpdateName([FromQuery] string newName)
        {
            throw new NotImplementedException();
        }

        [Authorize(policy: "Admin")]
        [HttpPatch("{id:int}/phone")]
        public Task<ActionResult<CustomerDTO>> UpdatePhone([FromQuery] string newPhone)
        {
            throw new NotImplementedException();
        }
        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- DELETE ------------------------------------------------------

        [Authorize(policy: "Admin")]
        [HttpDelete("{id:int}")]
        public Task<ActionResult<CustomerDTO>> DeleteById(int id)
        {
            throw new NotImplementedException();
        }
        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- POST ------------------------------------------------------

        [Authorize(policy: "Admin")]
        [HttpPost]
        public Task<ActionResult<CustomerDTO>> Create([FromBody] CustomerDTO newCustomer)
        {
            throw new NotImplementedException();
        }
        //----------------------------------------------------------------------------------------- <>
    }
}
