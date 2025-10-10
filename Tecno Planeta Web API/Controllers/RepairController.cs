using BLL.DTO.Repair;
using BLL.Services.Interfaces;
using Entities.Services.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Tecno_Planeta_Web_API.Controllers
{
    public class RepairController(IRepairService service) : AbstractBaseController<IRepairService>(service)
    {
        //--------------------------------- GET ------------------------------------------------------
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<RepairDTO>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RepairDTO>>> GetRepairs(
            [FromQuery] string? customerName,
            [FromQuery] DateTime? entryDate)
        {
            // Lógica: aplicar filtros opcionales
            // Ejemplo: _service.GetFilteredAsync(name, phone, registerDate);
            throw new NotImplementedException();
        }

        [AllowAnonymous]
        [HttpGet("period")]
        public async Task<ActionResult<IEnumerable<RepairDTO>>> GetByPeriodOfTime(
            [FromQuery] DateTime? min,
            [FromQuery] DateTime? max)
        {
            throw new NotImplementedException();
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RepairDTO>>> GetAll()
        {
            throw new NotImplementedException();
        }

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PATCH ------------------------------------------------------

        [Authorize(policy: "Admin")]
        [HttpPatch("{id:int}/cost")]
        public Task<ActionResult<RepairDTO>> UpdateCost(int id, [FromBody] string newPrice)
        {
            throw new NotImplementedException();
        }

        [Authorize(policy: "Admin")]
        [HttpPatch("{id:int}/note")]
        public Task<ActionResult<RepairDTO>> UpdateNote(int id, [FromBody] string newNote)
        {
            throw new NotImplementedException();
        }

        [Authorize(policy: "Admin")]
        [HttpPatch("{id:int}/status")]
        public Task<ActionResult<RepairDTO>> UpdateStatus(int id, [FromBody] ERepairStatus newStatus)
        {
            throw new NotImplementedException();
        }

        [Authorize(policy: "Admin")]
        [HttpPatch("{id:int}/cancel")]
        public Task<ActionResult<RepairDTO>> CancelRepair(int id)
        {
            throw new NotImplementedException();
        }
        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- DELETE ------------------------------------------------------

        [Authorize(policy: "Admin")]
        [HttpDelete("{id:int}")]
        public Task<ActionResult<RepairDTO>> DeleteById(int id)
        {
            throw new NotImplementedException();
        }
        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- POST ------------------------------------------------------

        [Authorize(policy: "Admin")]
        [HttpPost]
        public Task<ActionResult<RepairDTO>> Create([FromBody] RepairDTO newRepair)
        {
            throw new NotImplementedException();
        }
        //----------------------------------------------------------------------------------------- <>
    }
}
