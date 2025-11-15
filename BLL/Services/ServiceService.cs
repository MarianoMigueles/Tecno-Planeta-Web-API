using AutoMapper;
using BLL.DTO;
using BLL.DTO.Service.Service;
using BLL.DTO.Services.Repair;
using BLL.DTO.Services.Service;
using BLL.Services.Interfaces;
using DAL.Repository.Interfaces;
using DAL.UnitOfWork;
using Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ServiceService(IUnitOfWork unitOfWork, IMapper mapper) : AbstractService<ServiceResponseDTO, Service, IServiceRepository>(unitOfWork, mapper), IServiceService
    {
        protected override IServiceRepository Repository => _unitOfWork.ServiceRepository;

        //--------------------------------- GET ------------------------------------------------------

        public async Task<List<ServiceResponseDTO>> GetAllByPriceRangeAsync(decimal min, decimal max)
        {
            var services = await Repository.GetAllByRangeOfPriceAsync(min, max);
            return _mapper.Map<List<ServiceResponseDTO>>(services);
        }

        public async Task<ServiceResponseDTO> GetByNameAsync(string name)
        {
            var service = await Repository.GetByNameAsync(name);
            return _mapper.Map<ServiceResponseDTO>(service);
        }

        public async Task<List<ServiceResponseDTO>> GetByPeriotOfEstimatedTimeAsync(TimeOnly min, TimeOnly max)
        {
            var services = await Repository.GetByPeriotOfEstimatedTimeAsync(min, max);
            return _mapper.Map<List<ServiceResponseDTO>>(services);
        }

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PATCH ------------------------------------------------------

        public async Task<ServiceResponseDTO> UpdateBasePriceAsync(int id, decimal newPrice)
        {
            var service = await Repository.UpdateBasePriceAsync(id, newPrice);
            return _mapper.Map<ServiceResponseDTO>(service);
        }

        public async Task<ServiceResponseDTO> UpdateDescriptionAsync(int id, string newDescription)
        {
            var service = await Repository.UpdateDescriptionAsync(id, newDescription);
            return _mapper.Map<ServiceResponseDTO>(service);
        }

        public async Task<ServiceResponseDTO> UpdateEstimatedTimeAsync(int id, TimeOnly newEstimatedTime)
        {
            var service = await Repository.UpdateEstimatedTimeAsync(id, newEstimatedTime);
            return _mapper.Map<ServiceResponseDTO>(service);
        }

        public async Task<ServiceResponseDTO> UpdateNameAsync(int id, string newName)
        {
            var service = await Repository.UpdateNameAsync(id, newName);
            return _mapper.Map<ServiceResponseDTO>(service);
        }

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- POST ------------------------------------------------------

        public override async Task<ServiceResponseDTO> CreateAsync(IBaseDTO createDto) => await CommonCreateAsync(createDto);

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- DELETE ------------------------------------------------------

        public override async Task<bool> DeleteAsync(int id) => await CommonDeleteAsync(id);

        //----------------------------------------------------------------------------------------- <>
    }
}
