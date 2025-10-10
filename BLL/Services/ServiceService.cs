using AutoMapper;
using BLL.DTO.Service;
using BLL.Services.Interfaces;
using DAL.UnitOfWork;
using Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ServiceService(IUnitOfWork unitOfWork, IMapper mapper) : AbstractService<Service, ServiceDTO>(unitOfWork, mapper), IServiceService
    {
        //--------------------------------- GET ------------------------------------------------------

        public Task<List<ServiceDTO>> GetAllByGreaterPrice(decimal price)
        {
            throw new NotImplementedException();
        }

        public Task<List<ServiceDTO>> GetAllByLessPrice(decimal price)
        {
            throw new NotImplementedException();
        }

        public Task<List<ServiceDTO>> GetAllByPriceRange(decimal min, decimal max)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceDTO> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<ServiceDTO>> GetByPeriotOfEstimatedTime(DateTime startTime, DateTime endTime)
        {
            throw new NotImplementedException();
        }

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PATCH ------------------------------------------------------

        public Task<ServiceDTO> UpdateBasePrice(decimal newPrice)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceDTO> UpdateDescription(string newDescription)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceDTO> UpdateEstimatedTime(DateTime newEstimatedTime)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceDTO> UpdateName(string newName)
        {
            throw new NotImplementedException();
        }

        //----------------------------------------------------------------------------------------- <>
    }
}
