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
        public Task<List<User>> GetAllBySector(EUserSector sector);
        public Task<User> GetAllByRol(EUserRol rol);
        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PATCH ------------------------------------------------------
        public Task<User> UpdateName(int id, string newName);
        public Task<User> UpdatePassword(int id, string newPassword);
        public Task<User> UpdateRol(int id, EUserRol newRol);
        public Task<User> UpdateSector(int id, EUserSector newSector);
        //----------------------------------------------------------------------------------------- <>

    }
}
