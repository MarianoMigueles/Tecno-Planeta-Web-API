using BLL.DTO;
using BLL.DTO.Users.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface ICrudService<TResponse> where TResponse : IBaseDTO
    {
        //--------------------------------- GET ------------------------------------------------------
        public Task<TResponse> GetByIdAsync(int id);
        public Task<List<TResponse>> GetAllAsync();
        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- POST ------------------------------------------------------
        public Task<TResponse> CreateAsync(IBaseDTO createDto);
        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- DELETE ------------------------------------------------------
        public Task<bool> DeleteAsync(int id);
        //----------------------------------------------------------------------------------------- <>
    }
}
