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
        public async Task<ActionResult<IEnumerable<BaseDeviceDTO>>> GetDevices(
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
        public async Task<ActionResult<BaseDeviceDTO>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BaseDeviceDTO>>> GetAll()
        {
            throw new NotImplementedException();
        }

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- DELETE ------------------------------------------------------

        [HttpDelete("{id:int}")]
        public Task<ActionResult<BaseDeviceDTO>> DeleteById(int id)
        {
            throw new NotImplementedException();
        }
        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- POST ------------------------------------------------------

        [HttpPost]
        public Task<ActionResult<BaseDeviceDTO>> Create([FromBody] BaseDeviceDTO newDevice)
        {
            throw new NotImplementedException();
        }
        //----------------------------------------------------------------------------------------- <>
    }
}
