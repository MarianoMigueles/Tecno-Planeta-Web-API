using AutoMapper;
using BLL.DTO.Device;
using BLL.DTO;
using BLL.DTO.Invoice;
using BLL.Services.Interfaces;
using DAL.Repository.Interfaces;
using DAL.UnitOfWork;
using Entities.Elements.Enums;
using Entities.Elements.InvoiceFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class InvoiceService(IUnitOfWork unitOfWork, IMapper mapper) : AbstractService<InvoiceResponseDTO, Invoice, IInvoiceRepository>(unitOfWork, mapper), IInvoiceService
    {
        protected override IInvoiceRepository Repository => _unitOfWork.InvoiceRepository;

        //--------------------------------- GET ------------------------------------------------------

        public async Task<List<InvoiceResponseDTO>> GetAllByGreaterProductQuantityAsync(int amount)
        {
            var invoices = await Repository.GetAllByGreaterProductQuantityAsync(amount);
            return _mapper.Map<List<InvoiceResponseDTO>>(invoices);
        }

        public async Task<List<InvoiceResponseDTO>> GetAllByIssueDateAsync(DateTime status)
        {
            var invoices = await Repository.GetAllByIssueDateAsync(status);
            return _mapper.Map<List<InvoiceResponseDTO>>(invoices);
        }

        public async Task<List<InvoiceResponseDTO>> GetAllByLessProductQuantityAsync(int amount)
        {
            var invoices = await Repository.GetAllByLessProductQuantityAsync(amount);
            return _mapper.Map<List<InvoiceResponseDTO>>(invoices);
        }

        public async Task<List<InvoiceResponseDTO>> GetAllByOperationTypeAsync(EInvoiceOperation type)
        {
            var invoices = await Repository.GetAllByOperationTypeAsync(type);
            return _mapper.Map<List<InvoiceResponseDTO>>(invoices);
        }

        public async Task<List<InvoiceResponseDTO>> GetAllByStatusAsync(EInvoiceStatus status)
        {
            var invoices = await Repository.GetAllByStatusAsync(status);
            return _mapper.Map<List<InvoiceResponseDTO>>(invoices);
        }

        public async Task<InvoiceResponseDTO> GetByCustomerNameAsync(string name)
        {
            var invoice = await Repository.GetByCustomerNameAsync(name);
            return _mapper.Map<InvoiceResponseDTO>(invoice);
        }

        public async Task<InvoiceResponseDTO> GetByNumberAsync(int number)
        {
            var invoice = await Repository.GetByNumberAsync(number);
            return _mapper.Map<InvoiceResponseDTO>(invoice);
        }

        public async Task<List<InvoiceResponseDTO>> GetContainsProductIdAsync(int id)
        {
            var invoices = await Repository.GetContainsProductIdAsync(id);
            return _mapper.Map<List<InvoiceResponseDTO>>(invoices);
        }

        public async Task<List<InvoiceResponseDTO>> GetContainsServiceIdAsync(int id)
        {
            var invoices = await Repository.GetContainsServiceIdAsync(id);
            return _mapper.Map<List<InvoiceResponseDTO>>(invoices);
        }

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PATCH ------------------------------------------------------

        public async Task<InvoiceResponseDTO> UpdateStatusAsync(int id, EInvoiceStatus newStatus)
        {
            var invoice = await Repository.UpdateStatusAsync(id, newStatus);
            return _mapper.Map<InvoiceResponseDTO>(invoice);
        }

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- POST ------------------------------------------------------

        public override async Task<InvoiceResponseDTO> CreateAsync(IBaseDTO createDto) => await CommonCreateAsync(createDto);

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- DELETE ------------------------------------------------------

        public override async Task<bool> DeleteAsync(int id) => await CommonDeleteAsync(id);

        //----------------------------------------------------------------------------------------- <>
    }
}
