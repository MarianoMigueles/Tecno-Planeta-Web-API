using Entities.Users;
using Entities.Users.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Interfaces
{
    public interface IUserRepository
    {
        //--------------------------------- GET ------------------------------------------------------
        public Task<User> GetByName(string name);
        public Task<User> GetAllBySector(EUserSector sector);
        public Task<User> GetAllByRol(EUserRol rol);

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PUT ------------------------------------------------------
        public Task<User> UpdateName(string newName);
        public Task<User> UpdatePassword(string newPassword);
        public Task<User> UpdateRol(EUserRol rol);
        public Task<User> UpdateSector(EUserRol rol);
        //----------------------------------------------------------------------------------------- <>

    }
}
