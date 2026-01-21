using BLL.DTO;
using BLL.DTO.Product;
using BLL.DTO.Services.Service;
using BLL.DTO.Users.Customer;
using Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IServiceService : IService, ICrudService<ServiceResponseDTO>
    {
        //--------------------------------- GET ------------------------------------------------------
        public Task<ServiceResponseDTO> GetByNameAsync(string name);
        public Task<List<ServiceResponseDTO>> GetAllByPriceRangeAsync(decimal min, decimal max);
        public Task<List<ServiceResponseDTO>> GetByPeriotOfEstimatedTimeAsync(TimeOnly min, TimeOnly max);

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PATCH ------------------------------------------------------
        public Task<ServiceResponseDTO> UpdateNameAsync(int id, string newName);
        public Task<ServiceResponseDTO> UpdateDescriptionAsync(int id, string newDescription);
        public Task<ServiceResponseDTO> UpdateBasePriceAsync(int id, decimal newPrice);
        public Task<ServiceResponseDTO> UpdateEstimatedTimeAsync(int id, TimeOnly newEstimatedTime);
        //----------------------------------------------------------------------------------------- <>
    }
}
