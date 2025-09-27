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
        public Task<Invoice> GetByNumber(int number);
        public Task<List<Invoice>> GetContainsProductId(int id);
        public Task<List<Invoice>> GetContainsServiceId(int id);
        public Task<List<Invoice>> GetAllByGreaterProductQuantity(int amount);
        public Task<List<Invoice>> GetAllByLessProductQuantity(int amount);
        public Task<Invoice> GetByCustomerName(string name);
        public Task<List<Invoice>> GetAllByStatus(EInvoiceStatus status);
        public Task<List<Invoice>> GetAllByOperationType(EInvoiceOperation type);
        public Task<List<Invoice>> GetAllByIssueDate(DateTime status);

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PUT ------------------------------------------------------
        public Task<Invoice> UpdateStatus(EInvoiceStatus newStatus);
        //----------------------------------------------------------------------------------------- <>
    }
}
