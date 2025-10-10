using BLL.DTO.Service;
using Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IServiceService : IService
    {
        //--------------------------------- GET ------------------------------------------------------
        public Task<ServiceDTO> GetByName(string name);
        public Task<List<ServiceDTO>> GetAllByPriceRange(decimal min, decimal max);
        public Task<List<ServiceDTO>> GetByPeriotOfEstimatedTime(DateTime startTime, DateTime endTime);

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PATCH ------------------------------------------------------
        public Task<ServiceDTO> UpdateName(string newName);
        public Task<ServiceDTO> UpdateDescription(string newDescription);
        public Task<ServiceDTO> UpdateBasePrice(decimal newPrice);
        public Task<ServiceDTO> UpdateEstimatedTime(DateTime newEstimatedTime);
        //----------------------------------------------------------------------------------------- <>
    }
}
