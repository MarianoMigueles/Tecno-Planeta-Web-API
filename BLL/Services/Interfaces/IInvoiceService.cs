using BLL.DTO.Invoice;
using Entities.Elements.Enums;
using Entities.Elements.InvoiceFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IInvoiceService : IService
    {
        //--------------------------------- GET ------------------------------------------------------
        public Task<InvoiceDTO> GetByNumber(int number);
        public Task<List<InvoiceDTO>> GetContainsProductId(int id);
        public Task<List<InvoiceDTO>> GetContainsServiceId(int id);
        public Task<List<InvoiceDTO>> GetAllByGreaterProductQuantity(int amount);
        public Task<List<InvoiceDTO>> GetAllByLessProductQuantity(int amount);
        public Task<InvoiceDTO> GetByCustomerName(string name);
        public Task<List<InvoiceDTO>> GetAllByStatus(EInvoiceStatus status);
        public Task<List<InvoiceDTO>> GetAllByOperationType(EInvoiceOperation type);
        public Task<List<InvoiceDTO>> GetAllByIssueDate(DateTime date);

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PATCH ------------------------------------------------------
        public Task<InvoiceDTO> UpdateStatus(EInvoiceStatus newStatus);
        //----------------------------------------------------------------------------------------- <>
    }
}
