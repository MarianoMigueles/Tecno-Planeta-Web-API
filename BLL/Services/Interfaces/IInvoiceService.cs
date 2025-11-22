using BLL.DTO;
using BLL.DTO.Device;
using BLL.DTO.Invoice;
using BLL.DTO.Users.Customer;
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
        public Task<InvoiceResponseDTO> GetByIdAsync(int id);
        public Task<List<InvoiceResponseDTO>> GetAllAsync();
        public Task<InvoiceResponseDTO> GetByNumberAsync(int number);
        public Task<List<InvoiceResponseDTO>> GetContainsProductIdAsync(List<int> ids);
        public Task<List<InvoiceResponseDTO>> GetContainsServiceIdAsync(List<int> ids);
        public Task<InvoiceResponseDTO> GetByCustomerNameAsync(string name);
        public Task<List<InvoiceResponseDTO>> GetAllByStatusAsync(EInvoiceStatus status);
        public Task<List<InvoiceResponseDTO>> GetAllByOperationTypeAsync(EInvoiceOperation type);
        public Task<List<InvoiceResponseDTO>> GetAllByIssueDateAsync(DateTime date);
        public Task<List<InvoiceResponseDTO>> GetAllByProductQuantityAsync(int min, int max);

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PATCH ------------------------------------------------------
        public Task<InvoiceResponseDTO> UpdateStatusAsync(int id, EInvoiceStatus newStatus);
        //----------------------------------------------------------------------------------------- <>
        //--------------------------------- POST ------------------------------------------------------

        public Task<InvoiceResponseDTO> CreateAsync(IBaseDTO createDto);

        //----------------------------------------------------------------------------------------- <>
    }
}
