using Entities.Elements.Enums;
using Entities.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO.Device;

namespace BLL.Services.Interfaces
{
    public interface IDeviceService
    {
        //--------------------------------- GET ------------------------------------------------------
        public Task<List<DeviceDTO>> GetByCustomerName(string customerName);
        public Task<List<DeviceDTO>> GetAllByType(EDeviceType type);
        public Task<List<DeviceDTO>> GetAllByModel(string model);
        public Task<List<DeviceDTO>> GetAllByBrand(string brand);
        //----------------------------------------------------------------------------------------- <>
    }
}
