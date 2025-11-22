using BLL.DTO.Device;
using BLL.Services.Interfaces;
using Entities.Elements.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Tecno_Planeta_Web_API.Controllers
{
    public class DeviceController(IDeviceService service) : AbstractBaseController<IDeviceService>(service)
    {
        //--------------------------------- GET ------------------------------------------------------
        [AllowAnonymous]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<DeviceResponseDTO>> GetById(int id)
        {
            var device = await service.GetByIdAsync(id);
            return Ok(device);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeviceResponseDTO>>> GetAll()
        {
            var devices = await service.GetAllAsync();
            return Ok(devices);
        }
        
        [HttpGet("by-customer-name/{customerName}")]
        public async Task<ActionResult<DeviceResponseDTO>> GetByCustomerName([FromQuery] string customerName)
        {
            var device = await service.GetByCustomerNameAsync(customerName);
            return Ok(device);
        }

        [HttpGet("by-type/{type}")]
        public async Task<ActionResult<IEnumerable<DeviceResponseDTO>>> GetAllByType([FromQuery] EDeviceType type)
        {
            var devices = await service.GetAllByTypeAsync(type);
            return Ok(devices);
        }
        [HttpGet("by-model/{model}")]
        public async Task<ActionResult<IEnumerable<DeviceResponseDTO>>> GetAllByModel([FromQuery] string model)
        {
            var devices = await service.GetAllByModelAsync(model);
            return Ok(devices);
        }
        [HttpGet("by-brand/{brand}")]
        public async Task<ActionResult<IEnumerable<DeviceResponseDTO>>> GetAllByBrand([FromQuery] string brand)
        {
            var devices = await service.GetAllByBrandAsync(brand);
            return Ok(devices);
        }

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- DELETE ------------------------------------------------------

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await service.DeleteAsync(id);
            return NoContent();
        }
        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- POST ------------------------------------------------------

        [HttpPost]
        public async Task<ActionResult<DeviceResponseDTO>> Create([FromBody] DeviceCreateDTO newDevice)
        {
            var device = await service.CreateAsync(newDevice);
            return Ok(device);
        }
        //----------------------------------------------------------------------------------------- <>
    }
}
