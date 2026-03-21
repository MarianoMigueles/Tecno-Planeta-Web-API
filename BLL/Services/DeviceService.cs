using AutoMapper;
using BLL.DTO;
using BLL.DTO.Device;
using BLL.DTO.Users.Customer;
using BLL.Services.Interfaces;
using DAL.Repository.Interfaces;
using DAL.UnitOfWork;
using Entities.Elements;
using Entities.Elements.Enums;
using Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DeviceService(IUnitOfWork unitOfWork, IMapper mapper) : AbstractService<DeviceResponseDTO, Device, IDeviceRepository>(unitOfWork, mapper), IDeviceService
    {
        protected override IDeviceRepository Repository => _unitOfWork.DeviceRepository;

        //--------------------------------- GET ------------------------------------------------------
        public async Task<List<DeviceResponseDTO>> GetByCustomerNameAsync(string customerName)
        {
            var devices = await Repository.GetByCustomerNameAsync(customerName);
            return _mapper.Map<List<DeviceResponseDTO>>(devices);
        }
        public async Task<List<DeviceResponseDTO>> GetAllByTypeAsync(EDeviceType type)
        {
            var devices = await Repository.GetAllByTypeAsync(type);
            return _mapper.Map<List<DeviceResponseDTO>>(devices);
        }
        public async Task<List<DeviceResponseDTO>> GetAllByModelAsync(string model)
        {
            var devices = await Repository.GetAllByModelAsync(model);
            return _mapper.Map<List<DeviceResponseDTO>>(devices);
        }
        public async Task<List<DeviceResponseDTO>> GetAllByBrandAsync(string brand)
        {
            var devices = await Repository.GetAllByBrandAsync(brand);
            return _mapper.Map<List<DeviceResponseDTO>>(devices);
        }
        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- POST ------------------------------------------------------

        public override async Task<DeviceResponseDTO> CreateAsync(IBaseDTO createDto) => await CommonCreateAsync(createDto);

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- DELETE ------------------------------------------------------

        public override async Task<bool> DeleteAsync(int id) => await CommonDeleteAsync(id);

        //----------------------------------------------------------------------------------------- <>
    }
}
