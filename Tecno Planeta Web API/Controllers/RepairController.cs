using BLL.DTO.Services.Repair;
using BLL.Services.Interfaces;
using Entities.Services.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Tecno_Planeta_Web_API.Controllers
{
    public class RepairController(IRepairService service) : AbstractBaseController<IRepairService>(service)
    {
        //--------------------------------- GET ------------------------------------------------------
        [HttpGet("{id:int}")]
        public async Task<ActionResult<RepairResponseDTO>> GetById(int id)
        {
            var repair = await service.GetByIdAsync(id);
            return Ok(repair);
        }

        [HttpGet("all/by-customer-name/{customerName}")]
        public async Task<ActionResult<IEnumerable<RepairResponseDTO>>> GetAllRepairsByCustomer([FromQuery] string customerName)
        {
            var repairs = await service.GetByCustomerNameAsync(customerName);
            return Ok(repairs);
        }

        [HttpGet("all/by-entry-date/{entryDate}")]
        public async Task<ActionResult<IEnumerable<RepairResponseDTO>>> GetAllRepairsByEntryDate([FromQuery] DateTime entryDate)
        {
            var repairs = await service.GetByEntryDateAsync(entryDate);
            return Ok(repairs);
        }

        [AllowAnonymous]
        [HttpGet("all/by-period")]
        public async Task<ActionResult<IEnumerable<RepairResponseDTO>>> GetAllByPeriodOfTime(
            [FromQuery] DateTime min,
            [FromQuery] DateTime max)
        {
            var repairs = await service.GetByPeriodOfEntryDateAsync(min, max);
            return Ok(repairs);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RepairResponseDTO>>> GetAll()
        {
            var repairs = await service.GetAllAsync();
            return Ok(repairs);
        }

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PATCH ------------------------------------------------------

        [Authorize(policy: "Admin")]
        [HttpPatch("{id:int}/cost")]
        public async Task<ActionResult<RepairResponseDTO>> UpdateCost(int id, [FromBody] decimal newPrice)
        {
            var repair = await service.UpdateCostAsync(id, newPrice);
            return Ok(repair);
        }

        [Authorize(policy: "Admin")]
        [HttpPatch("{id:int}/note")]
        public async Task<ActionResult<RepairResponseDTO>> UpdateNote(int id, [FromBody] string newNote)
        {
            var repair = await service.UpdateNoteAsync(id, newNote);
            return Ok(repair);
        }

        [Authorize(policy: "Admin")]
        [HttpPatch("{id:int}/status")]
        public async Task<ActionResult<RepairResponseDTO>> UpdateStatus(int id, [FromBody] ERepairStatus newStatus)
        {
            var reapair = await service.UpdateStatusAsync(id, newStatus);
            return Ok(reapair);
        }

        [Authorize(policy: "Admin")]
        [HttpPatch("{id:int}/cancel")]
        public async Task<ActionResult<RepairResponseDTO>> CancelRepair(int id)
        {
            var repair = await service.CancelRepairAsync(id);
            return Ok(repair);
        }
        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- DELETE ------------------------------------------------------

        [Authorize(policy: "Admin")]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<RepairResponseDTO>> Delete(int id)
        {
            await service.DeleteAsync(id);
            return NoContent();
        }
        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- POST ------------------------------------------------------

        [Authorize(policy: "Admin")]
        [HttpPost]
        public async Task<ActionResult<RepairResponseDTO>> Create([FromBody] RepairCreateDTO newRepair)
        {
            var repair = await service.CreateAsync(newRepair);
            return Ok(repair);
        }
        //----------------------------------------------------------------------------------------- <>
    }
}
