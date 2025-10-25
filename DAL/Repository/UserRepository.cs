using DAL.Data;
using DAL.Repository.Interfaces;
using Entities.Users;
using Entities.Users.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class UserRepository(DataContext context) : AbstractRepository<User>(context), IUserRepository
    {
        //--------------------------------- GET ------------------------------------------------------

        public async Task<User> GetByName(string name) => await this.GetSingleAsync(u => u.UserName.Equals(name));
        public async Task<List<User>> GetAllBySector(EUserSector sector) => await this.GetListAsync(u => u.Sector.Equals(sector));
        public async Task<User> GetAllByRol(EUserRol rol) => await this.GetSingleAsync(u => u.Rol.Equals(rol));


        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PATCH ------------------------------------------------------

        public async Task<User> UpdateName(int id, string newName)
        {
            var user = await this.GetByIdAsync(id);
            user.UserName = newName;
            return user;
        }
        public async Task<User> UpdatePassword(int id, string newPassword)
        {
            var user = await this.GetByIdAsync(id);
            user.EditPassword(newPassword);
            return user;
        }
        public async Task<User> UpdateRol(int id, EUserRol newRol)
        {
            var user = await this.GetByIdAsync(id);
            user.EditRol(newRol);
            return user;
        }
        public async Task<User> UpdateSector(int id, EUserSector newSector)
        {
            var user = await this.GetByIdAsync(id);
            user.EditSector(newSector);
            return user;
        }

        //----------------------------------------------------------------------------------------- <>
    }
}
