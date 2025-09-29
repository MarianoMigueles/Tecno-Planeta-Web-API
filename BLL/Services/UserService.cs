using AutoMapper;
using BLL.DTO.User;
using BLL.Services.Interfaces;
using DAL.UnitOfWork;
using Entities.Users.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService(IUnitOfWork unitOfWork, IMapper mapper) : AbstractService(unitOfWork, mapper), IUserService
    {
        public Task<UserDTO> GetAllByRol(EUserRol rol)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> GetAllBySector(EUserSector sector)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> UpdateName(string newName)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> UpdatePassword(string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> UpdateRol(EUserRol rol)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> UpdateSector(EUserRol rol)
        {
            throw new NotImplementedException();
        }
    }
}
