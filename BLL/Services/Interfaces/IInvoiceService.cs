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
        public Task<InvoiceResponseDTO> GetByNumberAsync(int number);
        public Task<List<InvoiceResponseDTO>> GetContainsProductIdAsync(int id);
        public Task<List<InvoiceResponseDTO>> GetContainsServiceIdAsync(int id);
        public Task<List<InvoiceResponseDTO>> GetAllByGreaterProductQuantityAsync(int amount);
        public Task<List<InvoiceResponseDTO>> GetAllByLessProductQuantityAsync(int amount);
        public Task<InvoiceResponseDTO> GetByCustomerNameAsync(string name);
        public Task<List<InvoiceResponseDTO>> GetAllByStatusAsync(EInvoiceStatus status);
        public Task<List<InvoiceResponseDTO>> GetAllByOperationTypeAsync(EInvoiceOperation type);
        public Task<List<InvoiceResponseDTO>> GetAllByIssueDateAsync(DateTime date);

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PATCH ------------------------------------------------------
        public Task<InvoiceResponseDTO> UpdateStatusAsync(EInvoiceStatus newStatus);
        //----------------------------------------------------------------------------------------- <>
    }
}
