using AutoMapper;
using BLL.DTO.Invoice;
using BLL.Services.Interfaces;
using DAL.UnitOfWork;
using Entities.Elements.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class InvoiceService(IUnitOfWork unitOfWork, IMapper mapper) : AbstractService(unitOfWork, mapper), IInvoiceService
    {
        public Task<List<InvoiceDTO>> GetAllByGreaterProductQuantity(int amount)
        {
            throw new NotImplementedException();
        }

        public Task<List<InvoiceDTO>> GetAllByIssueDate(DateTime status)
        {
            throw new NotImplementedException();
        }

        public Task<List<InvoiceDTO>> GetAllByLessProductQuantity(int amount)
        {
            throw new NotImplementedException();
        }

        public Task<List<InvoiceDTO>> GetAllByOperationType(EInvoiceOperation type)
        {
            throw new NotImplementedException();
        }

        public Task<List<InvoiceDTO>> GetAllByStatus(EInvoiceStatus status)
        {
            throw new NotImplementedException();
        }

        public Task<InvoiceDTO> GetByCustomerName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<InvoiceDTO> GetByNumber(int number)
        {
            throw new NotImplementedException();
        }

        public Task<List<InvoiceDTO>> GetContainsProductId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<InvoiceDTO>> GetContainsServiceId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<InvoiceDTO> UpdateStatus(EInvoiceStatus newStatus)
        {
            throw new NotImplementedException();
        }
    }
}
