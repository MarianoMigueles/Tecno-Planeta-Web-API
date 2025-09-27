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
        public Task<Customer> GetByName(string name);
        public Task<Customer> GetByPhone(int phone);
        public Task<Customer> GetByRegisterDate(DateTime registerTime);
        public Task<Customer> GetByPeriotOfTime(DateTime startDate, DateTime endDate);

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PUT ------------------------------------------------------
        public Task<Customer> UpdateName(string newName);
        public Task<Customer> UpdatePhone(string newPhone);
        //----------------------------------------------------------------------------------------- <>

    }
}
