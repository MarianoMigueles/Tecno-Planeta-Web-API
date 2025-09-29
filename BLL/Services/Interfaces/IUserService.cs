using Entities.Users.Enums;
using Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO.User;

namespace BLL.Services.Interfaces
{
    public interface IUserService
    {
        //--------------------------------- GET ------------------------------------------------------
        public Task<UserDTO> GetByName(string name);
        public Task<UserDTO> GetAllBySector(EUserSector sector);
        public Task<UserDTO> GetAllByRol(EUserRol rol);

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PUT ------------------------------------------------------
        public Task<UserDTO> UpdateName(string newName);
        public Task<UserDTO> UpdatePassword(string newPassword);
        public Task<UserDTO> UpdateRol(EUserRol rol);
        public Task<UserDTO> UpdateSector(EUserRol rol);
        //----------------------------------------------------------------------------------------- <>
    }
}
