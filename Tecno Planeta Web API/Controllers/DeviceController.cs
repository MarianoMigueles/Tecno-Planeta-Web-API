using BLL.DTO.Device;
using BLL.DTO.User;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Tecno_Planeta_Web_API.Controllers
{
    public class DeviceController(IDeviceService service) : AbstractBaseController<IDeviceService>(service)
    {
        //--------------------------------- GET ------------------------------------------------------
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeviceDTO>>> GetDevices(
            [FromQuery] string? customerName,
            [FromQuery] string? type,
            [FromQuery] string? model,
            [FromQuery] string? brand)
        {
            // Lógica: aplicar filtros opcionales
            // Ejemplo: _service.GetFilteredAsync(name, phone, registerDate);
            throw new NotImplementedException();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<DeviceDTO>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeviceDTO>>> GetAll()
        {
            throw new NotImplementedException();
        }

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- DELETE ------------------------------------------------------

        [HttpDelete("{id:int}")]
        public Task<ActionResult<DeviceDTO>> DeleteById(int id)
        {
            throw new NotImplementedException();
        }
        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- POST ------------------------------------------------------

        [HttpPost]
        public Task<ActionResult<DeviceDTO>> Create([FromBody] DeviceDTO newDevice)
        {
            throw new NotImplementedException();
        }
        //----------------------------------------------------------------------------------------- <>
    }
}
