using Entities.Users.Enums;
using Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        //--------------------------------- GET ------------------------------------------------------
        public Task<Customer> GetByNameAsync(string name);
        public Task<Customer> GetByPhoneAsync(int phone);
        public Task<Customer> GetByRegisterDateAsync(DateTime registerTime);
        public Task<List<Customer>> GetByPeriotOfTimeAsync(DateTime min, DateTime max);

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PUT ------------------------------------------------------
        public Task<Customer> UpdateNameAsync(int id, string newName);
        public Task<Customer> UpdatePhoneAsync(int id, int newPhone);
        //----------------------------------------------------------------------------------------- <>

    }
}
