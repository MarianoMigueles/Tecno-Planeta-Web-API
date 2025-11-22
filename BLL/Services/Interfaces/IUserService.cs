using Entities.Users.Enums;
using Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO.Users.User;
using BLL.DTO.Users.Customer;
using BLL.DTO;
using BLL.DTO.Product;

namespace BLL.Services.Interfaces
{
    public interface IUserService : IService
    {
        //--------------------------------- GET ------------------------------------------------------
        public Task<UserResponseDTO> GetByIdAsync(int id);
        public Task<List<UserResponseDTO>> GetAllAsync();
        public Task<UserResponseDTO> GetByNameAsync(string name);
        public Task<List<UserResponseDTO>> GetAllBySectorAsync(EUserSector sector);
        public Task<List<UserResponseDTO>> GetAllByRolAsync(EUserRol rol);

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PATCH ------------------------------------------------------
        public Task<UserResponseDTO> UpdateNameAsync(int id, string newName);
        public Task<UserResponseDTO> UpdatePasswordAsync(int id, string newPassword);
        public Task<UserResponseDTO> UpdateRolAsync(int id, EUserRol newRol);
        public Task<UserResponseDTO> UpdateSectorAsync(int id, EUserSector newSector);
        //----------------------------------------------------------------------------------------- <>
        //--------------------------------- POST ------------------------------------------------------

        public Task<UserResponseDTO> CreateAsync(IBaseDTO createDto);

        //----------------------------------------------------------------------------------------- <>
    }
}
