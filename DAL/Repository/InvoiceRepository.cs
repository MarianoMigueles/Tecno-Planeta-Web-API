using DAL.Data;
using DAL.Repository.Interfaces;
using Entities.Elements.Enums;
using Entities.Elements.InvoiceFolder;
using Entities.Elements.ProductFolder;
using Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DAL.Repository
{
    public class InvoiceRepository(DataContext context) : AbstractRepository<Invoice>(context), IInvoiceRepository
    {
        //--------------------------------- GET ------------------------------------------------------
        public async Task<List<Invoice>> GetAllByIssueDateAsync(DateTime date) => await this.GetListAsync(i => i.IssueDate.Equals(date));
        public async Task<List<Invoice>> GetAllByOperationTypeAsync(EInvoiceOperation type) => await this.GetListAsync(i => i.Type.Equals(type));
        public async Task<List<Invoice>> GetAllByStatusAsync(EInvoiceStatus status) => await this.GetListAsync(i => i.Status.Equals(status));
        public async Task<List<Invoice>> GetAllByProductQuantityAsync(int min, int max)
        {
            return await this.GetListAsync(i => i.Details.Items.Count > min && i.Details.Items.Count < max);
        }
        public async Task<Invoice> GetByCustomerNameAsync(string name) => await this.GetSingleAsync(i => i.Customer.Name.Equals(name));
        public async Task<Invoice> GetByNumberAsync(int number) => await this.GetSingleAsync(i => i.InvoiceNumber.Equals(number));
        public async Task<List<Invoice>> GetContainsProductIdAsync(List<int> ids)
        {
            return await this.GetListAsync(i => i.Details.Items.Any(item => ids.Contains(item.ProductId)));
        }
        public async Task<List<Invoice>> GetContainsServiceIdAsync(List<int> ids)
        {
            return await this.GetListAsync(i => i.Details.Items.Any(item => ids.Contains(item.ServiceId)));
        }

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PATCH ------------------------------------------------------

        public async Task<Invoice> UpdateStatusAsync(int id, EInvoiceStatus newStatus)
        {
            var invoice = await this.GetByIdAsync(id);
            invoice.EditStatus(newStatus);
            return invoice;
        }

        //----------------------------------------------------------------------------------------- <>
    }
}
