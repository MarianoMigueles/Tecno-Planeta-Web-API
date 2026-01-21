using Entities.Users;
using Entities.Users.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        //--------------------------------- GET ------------------------------------------------------
        public Task<User> GetByNameAsync(string name);
        public Task<User> GetByEmailAsync(string email);
        public Task<List<User>> GetAllBySectorAsync(EUserSector sector);
        public Task<User> GetAllByRolAsync(EUserRol rol);
        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PATCH ------------------------------------------------------
        public Task<User> UpdateNameAsync(int id, string newName);
        public Task<User> UpdatePasswordAsync(int id, string newPassword);
        public Task<User> UpdateRolAsync(int id, EUserRol newRol);
        public Task<User> UpdateSectorAsync(int id, EUserSector newSector);
        //----------------------------------------------------------------------------------------- <>

    }
}
