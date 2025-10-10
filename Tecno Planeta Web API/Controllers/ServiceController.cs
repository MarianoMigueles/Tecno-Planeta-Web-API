using BLL.DTO.Service;
using BLL.Services.Interfaces;
using Entities.Services.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Tecno_Planeta_Web_API.Controllers
{
    public class ServiceController(IServiceService service) : AbstractBaseController<IServiceService>(service)
    {
        //--------------------------------- GET ------------------------------------------------------
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<ServiceDTO>> GetServiceById([FromQuery] int id)
        {
            throw new NotImplementedException();
        }

        [AllowAnonymous]
        [HttpGet("range")]
        public async Task<ActionResult<IEnumerable<ServiceDTO>>> GetAllByRangeOfPrice(
            [FromQuery] decimal? min,
            [FromQuery] decimal? max)
        {
            throw new NotImplementedException();
        }

        [AllowAnonymous]
        [HttpGet("period")]
        public async Task<ActionResult<IEnumerable<ServiceDTO>>> GetByPeriodOfTime([FromQuery] DateTime? startTime, [FromQuery] DateTime? endTime)
        {
            throw new NotImplementedException();
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceDTO>>> GetAll()
        {
            throw new NotImplementedException();
        }

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PATCH ------------------------------------------------------

        [Authorize(policy: "Admin")]
        [HttpPatch("{id:int}/name")]
        public Task<ActionResult<ServiceDTO>> UpdateName(int id, [FromQuery] string newName)
        {
            throw new NotImplementedException();
        }

        [Authorize(policy: "Admin")]
        [HttpPatch("{id:int}/description")]
        public Task<ActionResult<ServiceDTO>> UpdateDescription(int id, [FromQuery] string newDescription)
        {
            throw new NotImplementedException();
        }

        [Authorize(policy: "Admin")]
        [HttpPatch("{id:int}/price")]
        public Task<ActionResult<ServiceDTO>> UpdateBasePrice(int id, [FromQuery] decimal newPrice)
        {
            throw new NotImplementedException();
        }

        [Authorize(policy: "Admin")]
        [HttpPatch("{id:int}/time")]
        public Task<ActionResult<ServiceDTO>> UpdateEstimatedTime(int id, TimeOnly newEstimatedTime)
        {
            throw new NotImplementedException();
        }
        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- DELETE ------------------------------------------------------

        [Authorize(policy: "Admin")]
        [HttpDelete("{id:int}")]
        public Task<ActionResult<ServiceDTO>> DeleteById(int id)
        {
            throw new NotImplementedException();
        }
        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- POST ------------------------------------------------------

        [Authorize(policy: "Admin")]
        [HttpPost]
        public Task<ActionResult<ServiceDTO>> Create([FromBody] ServiceDTO newService)
        {
            throw new NotImplementedException();
        }
        //----------------------------------------------------------------------------------------- <>
    }
}
