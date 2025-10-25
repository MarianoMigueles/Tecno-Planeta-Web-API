using Entities.Services.Enums;
using Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Elements.Enums;
using Entities.Elements.InvoiceFolder;
using Entities.Elements.ProductFolder;

namespace DAL.Repository.Interfaces
{
    public interface IInvoiceRepository
    {
        //--------------------------------- GET ------------------------------------------------------
        public Task<Invoice> GetByNumberAsync(int number);
        public Task<List<Invoice>> GetContainsProductIdAsync(int id);
        public Task<List<Invoice>> GetContainsServiceIdAsync(int id);
        public Task<List<Invoice>> GetAllByGreaterProductQuantityAsync(int amount);
        public Task<List<Invoice>> GetAllByLessProductQuantityAsync(int amount);
        public Task<Invoice> GetByCustomerNameAsync(string name);
        public Task<List<Invoice>> GetAllByStatusAsync(EInvoiceStatus status);
        public Task<List<Invoice>> GetAllByOperationTypeAsync(EInvoiceOperation type);
        public Task<List<Invoice>> GetAllByIssueDateAsync(DateTime status);

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PATCH ------------------------------------------------------
        public Task<Invoice> UpdateStatusAsync(int id, EInvoiceStatus newStatus);
        //----------------------------------------------------------------------------------------- <>
    }
}
