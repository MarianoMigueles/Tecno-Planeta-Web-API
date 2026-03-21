using Entities.Users.Enums;
using Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Elements.ProductFolder;

namespace DAL.Repository.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        //--------------------------------- GET ------------------------------------------------------
        public Task<Customer> GetByNameAsync(string name);
        public Task<Customer> GetByPhoneAsync(string phone);
        public Task<Customer> GetByRegisterDateAsync(DateTime registerTime);
        public Task<List<Customer>> GetByPeriodOfTimeAsync(DateTime min, DateTime max);

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PATCH ------------------------------------------------------
        public Task<Customer> UpdateNameAsync(int id, string newName);
        public Task<Customer> UpdatePhoneAsync(int id, string newPhone);
        //----------------------------------------------------------------------------------------- <>

    }
}
