using DAL.Data;
using DAL.Repository.Interfaces;
using Entities.Elements.Enums;
using Entities.Elements.InvoiceFolder;
using Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class InvoiceRepository(DataContext context) : Repository<Invoice>(context), IInvoiceRepository
    {
        public Task<List<Invoice>> GetAllByGreaterProductQuantity(int amount)
        {
            throw new NotImplementedException();
        }

        public Task<List<Invoice>> GetAllByIssueDate(DateTime status)
        {
            throw new NotImplementedException();
        }

        public Task<List<Invoice>> GetAllByLessProductQuantity(int amount)
        {
            throw new NotImplementedException();
        }

        public Task<List<Invoice>> GetAllByOperationType(EInvoiceOperation type)
        {
            throw new NotImplementedException();
        }

        public Task<List<Invoice>> GetAllByStatus(EInvoiceStatus status)
        {
            throw new NotImplementedException();
        }

        public Task<Invoice> GetByCustomerName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Invoice> GetByNumber(int number)
        {
            throw new NotImplementedException();
        }

        public Task<List<Invoice>> GetContainsProductId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Invoice>> GetContainsServiceId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Invoice> UpdateStatus(EInvoiceStatus newStatus)
        {
            throw new NotImplementedException();
        }
    }
}
