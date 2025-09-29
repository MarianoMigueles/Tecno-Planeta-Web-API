using BLL.DTO.User;
using Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface ICustomerService
    {
        //--------------------------------- GET ------------------------------------------------------
        public Task<CustomerDTO> GetByName(string name);
        public Task<CustomerDTO> GetByPhone(int phone);
        public Task<CustomerDTO> GetByRegisterDate(DateTime registerTime);
        public Task<CustomerDTO> GetByPeriotOfTime(DateTime startDate, DateTime endDate);

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PUT ------------------------------------------------------
        public Task<CustomerDTO> UpdateName(string newName);
        public Task<CustomerDTO> UpdatePhone(string newPhone);
        //----------------------------------------------------------------------------------------- <>
    }
}
