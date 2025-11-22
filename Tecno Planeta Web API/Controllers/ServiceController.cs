using BLL.DTO.Services.Service;
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
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ServiceResponseDTO>> GetServiceById([FromQuery] int id)
        {
            var repair = await service.GetByIdAsync(id);
            return Ok(repair);
        }

        [AllowAnonymous]
        [HttpGet("al/range")]
        public async Task<ActionResult<IEnumerable<ServiceResponseDTO>>> GetAllByRangeOfPrice([FromQuery] decimal min, [FromQuery] decimal max)
        {
            var repairs = await service.GetAllByPriceRangeAsync(min, max);
            return Ok(repairs);
        }

        [AllowAnonymous]
        [HttpGet("all/period")]
        public async Task<ActionResult<IEnumerable<ServiceResponseDTO>>> GetByPeriodOfTime([FromQuery] TimeOnly min, [FromQuery] TimeOnly max)
        {
            var repairs = await service.GetByPeriotOfEstimatedTimeAsync(min, max);
            return Ok(repairs);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceResponseDTO>>> GetAll()
        {
            var repairs = await service.GetAllAsync();
            return Ok(repairs);
        }

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PATCH ------------------------------------------------------

        [Authorize(policy: "Admin")]
        [HttpPatch("{id:int}/name")]
        public async Task<ActionResult<ServiceResponseDTO>> UpdateName(int id, [FromQuery] string newName)
        {
            var repair = await service.UpdateNameAsync(id, newName);
            return Ok(repair);
        }

        [Authorize(policy: "Admin")]
        [HttpPatch("{id:int}/description")]
        public async Task<ActionResult<ServiceResponseDTO>> UpdateDescription(int id, [FromQuery] string newDescription)
        {
            var repair = await service.UpdateDescriptionAsync(id, newDescription);
            return Ok(repair);
        }

        [Authorize(policy: "Admin")]
        [HttpPatch("{id:int}/price")]
        public async Task<ActionResult<ServiceResponseDTO>> UpdateBasePrice(int id, [FromQuery] decimal newPrice)
        {
            var repair = await service.UpdateBasePriceAsync(id, newPrice);
            return Ok(repair);
        }

        [Authorize(policy: "Admin")]
        [HttpPatch("{id:int}/time")]
        public async Task<ActionResult<ServiceResponseDTO>> UpdateEstimatedTime(int id, TimeOnly newEstimatedTime)
        {
            var reapir = await service.UpdateEstimatedTimeAsync(id, newEstimatedTime);
            return Ok(reapir);
        }
        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- DELETE ------------------------------------------------------

        [Authorize(policy: "Admin")]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ServiceResponseDTO>> Delete(int id)
        {
            await service.DeleteAsync(id);
            return NoContent();
        }
        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- POST ------------------------------------------------------

        [Authorize(policy: "Admin")]
        [HttpPost]
        public async Task<ActionResult<ServiceResponseDTO>> Create([FromBody] ServiceCreateDTO newService)
        {
            var repair = await service.CreateAsync(newService);
            return Ok(repair);
        }
        //----------------------------------------------------------------------------------------- <>
    }
}
