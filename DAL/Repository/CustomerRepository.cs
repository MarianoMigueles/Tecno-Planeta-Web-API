using DAL.Data;
using DAL.Repository.Interfaces;
using Entities.Users;
using Exeptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class CustomerRepository(DataContext context) : AbstractRepository<Customer>(context), ICustomerRepository
    {
        //--------------------------------- GET ------------------------------------------------------

        public async Task<Customer> GetByNameAsync(string name) => await this.GetSingleAsync(c => c.Equals(name));
        public async Task<Customer> GetByPhoneAsync(int phone) => await this.GetSingleAsync(c => c.Equals(phone));
        public async Task<Customer> GetByRegisterDateAsync(DateTime registerTime) => await this.GetSingleAsync(c => c.Equals(registerTime));
        public async Task<List<Customer>> GetByPeriotOfTimeAsync(DateTime min, DateTime max)
        {
            return await this.GetListAsync(c => c.RegisterDate >= min && c.RegisterDate <= max);
        }

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PATCH ------------------------------------------------------

        public async Task<Customer> UpdateNameAsync(int id, string newName)
        {
            var customer = await this.GetByIdAsync(id);
            customer.Name = newName;
            return customer;
        }

        public async Task<Customer> UpdatePhoneAsync(int id, int newPhone)
        {
            var customer = await this.GetByIdAsync(id);
            customer.Phone = newPhone;
            return customer;
        }

        //----------------------------------------------------------------------------------------- <>
    }
}
