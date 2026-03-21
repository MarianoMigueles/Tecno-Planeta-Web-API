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
    public interface ICustomerService : IService, ICrudService<CustomerResponseDTO>
    {
        //--------------------------------- GET ------------------------------------------------------
        public Task<CustomerResponseDTO> GetByNameAsync(string name);
        public Task<CustomerResponseDTO> GetByPhoneAsync(string phone);
        public Task<CustomerResponseDTO> GetByRegisterDateAsync(DateTime registerTime);
        public Task<List<CustomerResponseDTO>> GetByPeriodOfTimeAsync(DateTime min, DateTime max);

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PATCH ------------------------------------------------------
        public Task<CustomerResponseDTO> UpdateNameAsync(int id, string newName);
        public Task<CustomerResponseDTO> UpdatePhoneAsync(int id, string newPhone);
        //----------------------------------------------------------------------------------------- <>
    }
}
