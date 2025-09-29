using AutoMapper;
using BLL.DTO.User;
using BLL.Services.Interfaces;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CustomerService(IUnitOfWork unitOfWork, IMapper mapper) : AbstractService(unitOfWork, mapper), ICustomerService
    {
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

        public Task<CustomerDTO> UpdateName(string newName)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerDTO> UpdatePhone(string newPhone)
        {
            throw new NotImplementedException();
        }
    }
}
