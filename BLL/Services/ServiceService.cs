using AutoMapper;
using BLL.DTO.Service;
using BLL.Services.Interfaces;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ServiceService(IUnitOfWork unitOfWork, IMapper mapper) : AbstractService(unitOfWork, mapper), IServiceService
    {
        public Task<List<ServiceDTO>> GetAllByGreaterPrice(decimal price)
        {
            throw new NotImplementedException();
        }

        public Task<List<ServiceDTO>> GetAllByLessPrice(decimal price)
        {
            throw new NotImplementedException();
        }

        public Task<List<ServiceDTO>> GetAllByRangeOfPrice(decimal startPrice, decimal endPrice)
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
    }
}
