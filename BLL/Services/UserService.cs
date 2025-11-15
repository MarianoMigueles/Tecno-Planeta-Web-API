using AutoMapper;
using BLL.DTO.Services.Service;
using BLL.DTO;
using BLL.Services.Interfaces;
using DAL.UnitOfWork;
using Entities.Users;
using Entities.Users.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO.Users.User;
using DAL.Repository.Interfaces;

namespace BLL.Services
{
    public class UserService(IUnitOfWork unitOfWork, IMapper mapper) : AbstractService<UserResponseDTO, User, IUserRepository>(unitOfWork, mapper), IUserService
    {
        protected override IUserRepository Repository => _unitOfWork.UserRepository;

        //--------------------------------- GET ------------------------------------------------------

        public async Task<List<UserResponseDTO>> GetAllByRolAsync(EUserRol rol)
        {
            var users = await Repository.GetAllByRolAsync(rol);
            return _mapper.Map<List<UserResponseDTO>>(users);

        }

        public async Task<List<UserResponseDTO>> GetAllBySectorAsync(EUserSector sector)
        {
            var users = await Repository.GetAllBySectorAsync(sector);
            return _mapper.Map<List<UserResponseDTO>>(users);
        }

        public async Task<UserResponseDTO> GetByNameAsync(string name)
        {
            var user = await Repository.GetByNameAsync(name);
            return _mapper.Map<UserResponseDTO>(user);
        }

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PATCH ------------------------------------------------------

        public async Task<UserResponseDTO> UpdateNameAsync(int id, string newName)
        {
            var user = await Repository.UpdateNameAsync(id, newName);
            return _mapper.Map<UserResponseDTO>(user);
        }

        public async Task<UserResponseDTO> UpdatePasswordAsync(int id, string newPassword)
        {
            var user = await Repository.UpdatePasswordAsync(id, newPassword);
            return _mapper.Map<UserResponseDTO>(user);
        }

        public async Task<UserResponseDTO> UpdateRolAsync(int id, EUserRol rol)
        {
            var user = await Repository.UpdateRolAsync(id, rol);
            return _mapper.Map<UserResponseDTO>(user);
        }

        public async Task<UserResponseDTO> UpdateSectorAsync(int id, EUserSector newSector)
        {
            var user = await Repository.UpdateSectorAsync(id, newSector);
            return _mapper.Map<UserResponseDTO>(user);
        }

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- POST ------------------------------------------------------

        public override async Task<UserResponseDTO> CreateAsync(IBaseDTO createDto) => await CommonCreateAsync(createDto);

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- DELETE ------------------------------------------------------

        public override async Task<bool> DeleteAsync(int id) => await CommonDeleteAsync(id);

        //----------------------------------------------------------------------------------------- <>

    }
}
