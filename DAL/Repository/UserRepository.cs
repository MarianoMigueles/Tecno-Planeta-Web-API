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
    public class UserRepository(DataContext context) : Repository<User>(context), IUserRepository
    {
        public Task<User> GetAllByRol(EUserRol rol)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetAllBySector(EUserSector sector)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateName(string newName)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdatePassword(string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateRol(EUserRol rol)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateSector(EUserRol rol)
        {
            throw new NotImplementedException();
        }
    }
}
