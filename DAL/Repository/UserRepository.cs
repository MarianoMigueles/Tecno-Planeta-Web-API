using DAL.Data;
using DAL.Repository.Interfaces;
using Entities.Users;
using Entities.Users.Enums;
using Exeptions;
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

        public async Task<User> GetByNameAsync(string name) => await this.GetSingleAsync(u => u.UserName.Equals(name));
        public async Task<List<User>> GetAllBySectorAsync(EUserSector sector) => await this.GetListAsync(u => u.Sector.Equals(sector));
        public async Task<User> GetAllByRolAsync(EUserRol rol) => await this.GetSingleAsync(u => u.Rol.Equals(rol));
        public async Task<User> GetByEmailAsync(string email) => await this.GetSingleAsync(u => u.Email.Equals(email));


        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PATCH ------------------------------------------------------

        public async Task<User> UpdateNameAsync(int id, string newName)
        {
            var user = await this.GetByIdAsync(id);
            user.UserName = newName;
            return user;
        }
        public async Task<User> UpdatePasswordAsync(int id, string newPassword)
        {
            var user = await this.GetByIdAsync(id);
            user.EditPassword(newPassword);
            return user;
        }
        public async Task<User> UpdateRolAsync(int id, EUserRol newRol)
        {
            var user = await this.GetByIdAsync(id);
            user.EditRol(newRol);
            return user;
        }
        public async Task<User> UpdateSectorAsync(int id, EUserSector newSector)
        {
            var user = await this.GetByIdAsync(id);
            user.EditSector(newSector);
            return user;
        }

        //----------------------------------------------------------------------------------------- <>
    }
}
