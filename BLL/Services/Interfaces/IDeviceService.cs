using Entities.Elements.Enums;
using Entities.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO.Device;
using BLL.DTO.Users.Customer;
using BLL.DTO;

namespace BLL.Services.Interfaces
{
    public interface IDeviceService : IService, ICrudService<DeviceResponseDTO>
    {
        //--------------------------------- PATCH ------------------------------------------------------
        public Task<List<DeviceResponseDTO>> GetByCustomerNameAsync(string customerName);
        public Task<List<DeviceResponseDTO>> GetAllByTypeAsync(EDeviceType type);
        public Task<List<DeviceResponseDTO>> GetAllByModelAsync(string model);
        public Task<List<DeviceResponseDTO>> GetAllByBrandAsync(string brand);
        //----------------------------------------------------------------------------------------- <>
    }
}
