using BLL.DTO;
using BLL.DTO.Users.Customer;
using Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface ICustomerService : IService
    {
        //--------------------------------- GET ------------------------------------------------------
        public Task<CustomerResponseDTO> GetByIdAsync(int id);
        public Task<List<CustomerResponseDTO>> GetAllAsync();
        public Task<CustomerResponseDTO> GetByNameAsync(string name);
        public Task<CustomerResponseDTO> GetByPhoneAsync(int phone);
        public Task<CustomerResponseDTO> GetByRegisterDateAsync(DateTime registerTime);
        public Task<List<CustomerResponseDTO>> GetByPeriodOfTimeAsync(DateTime min, DateTime max);

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PATCH ------------------------------------------------------
        public Task<CustomerResponseDTO> UpdateNameAsync(int id, string newName);
        public Task<CustomerResponseDTO> UpdatePhoneAsync(int id, int newPhone);
        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- POST ------------------------------------------------------

        public Task<CustomerResponseDTO> CreateAsync(IBaseDTO createDto);

        //----------------------------------------------------------------------------------------- <>
    }
}
