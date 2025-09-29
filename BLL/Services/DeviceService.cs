using AutoMapper;
using BLL.DTO.Device;
using BLL.Services.Interfaces;
using DAL.UnitOfWork;
using Entities.Elements.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DeviceService(IUnitOfWork unitOfWork, IMapper mapper) : AbstractService(unitOfWork, mapper), IDeviceService
    {
        public Task<List<DeviceDTO>> GetAllByBrand(string brand)
        {
            throw new NotImplementedException();
        }

        public Task<List<DeviceDTO>> GetAllByModel(string model)
        {
            throw new NotImplementedException();
        }

        public Task<List<DeviceDTO>> GetAllByType(EDeviceType type)
        {
            throw new NotImplementedException();
        }

        public Task<List<DeviceDTO>> GetByCustomerName(string customerName)
        {
            throw new NotImplementedException();
        }
    }
}
