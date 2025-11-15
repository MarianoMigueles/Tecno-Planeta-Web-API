using AutoMapper;
using BLL.DTO;
using BLL.DTO.Users.Customer;
using BLL.Services.Interfaces;
using DAL.Repository.Interfaces;
using DAL.UnitOfWork;
using Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CustomerService(IUnitOfWork unitOfWork, IMapper mapper) : AbstractService<CustomerResponseDTO, Customer, ICustomerRepository>(unitOfWork, mapper), ICustomerService
    {
        protected override ICustomerRepository Repository => _unitOfWork.CustomerRepository;

        //--------------------------------- GET ------------------------------------------------------

        public async Task<CustomerResponseDTO> GetByNameAsync(string name)
        {
            var customer = await Repository.GetByNameAsync(name);
            return _mapper.Map<CustomerResponseDTO>(customer);
        }

        public async Task<List<CustomerResponseDTO>> GetByPeriodOfTimeAsync(DateTime min, DateTime max)
        {
            var customer = await Repository.GetByPeriodOfTimeAsync(min, max);
            return _mapper.Map<List<CustomerResponseDTO>>(customer);
        }

        public async Task<CustomerResponseDTO> GetByPhoneAsync(int phone)
        {
            var customer = await Repository.GetByPhoneAsync(phone);
            return _mapper.Map<CustomerResponseDTO>(customer);
        }

        public async Task<CustomerResponseDTO> GetByRegisterDateAsync(DateTime registerTime)
        {
            var customer = await Repository.GetByRegisterDateAsync(registerTime);
            return _mapper.Map<CustomerResponseDTO>(customer);
        }

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PATCH ------------------------------------------------------

        public async Task<CustomerResponseDTO> UpdateNameAsync(int id, string newName)
        {
            var customer = await Repository.UpdateNameAsync(id, newName);
            await SaveChangesAsync();
            return _mapper.Map<CustomerResponseDTO>(customer);
        }

        public async Task<CustomerResponseDTO> UpdatePhoneAsync(int id, int newPhone)
        {
            var customer = await Repository.UpdatePhoneAsync(id, newPhone);
            await SaveChangesAsync();
            return _mapper.Map<CustomerResponseDTO>(customer);
        }

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- POST ------------------------------------------------------

        public override async Task<CustomerResponseDTO> CreateAsync(IBaseDTO createDto) => await CommonCreateAsync(createDto);

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- DELETE ------------------------------------------------------

        public override async Task<bool> DeleteAsync(int id) => await CommonDeleteAsync(id);

        //----------------------------------------------------------------------------------------- <>
    }
}
