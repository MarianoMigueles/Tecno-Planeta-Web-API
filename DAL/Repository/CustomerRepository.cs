using DAL.Data;
using DAL.Repository.Interfaces;
using Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class CustomerRepository(DataContext context) : Repository<Customer>(context), ICustomerRepository
    {
        public Task<Customer> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetByPeriotOfTime(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetByPhone(int phone)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetByRegisterDate(DateTime registerTime)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> UpdateName(string newName)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> UpdatePhone(string newPhone)
        {
            throw new NotImplementedException();
        }
    }
}
