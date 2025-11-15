using Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Interfaces
{
    public interface ILogInRepository
    {
        public Task<User> LogInAsync(string userName, string password);
    }
}
