using AutoMapper;
using BLL.DTO.User;
using BLL.Services.Interfaces;
using DAL.UnitOfWork;
using Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CustomerService(IUnitOfWork unitOfWork, IMapper mapper) : AbstractService<Customer, CustomerDTO>(unitOfWork, mapper), ICustomerService
    {
        //--------------------------------- GET ------------------------------------------------------

        public Task<CustomerDTO> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerDTO> GetByPeriotOfTime(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerDTO> GetByPhone(int phone)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerDTO> GetByRegisterDate(DateTime registerTime)
        {
            throw new NotImplementedException();
        }

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PATCH ------------------------------------------------------

        public Task<CustomerDTO> UpdateName(string newName)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerDTO> UpdatePhone(string newPhone)
        {
            throw new NotImplementedException();
        }

        //----------------------------------------------------------------------------------------- <>
    }
}
