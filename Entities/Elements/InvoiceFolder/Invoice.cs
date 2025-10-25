using Entities.Elements.Enums;
using Entities.Elements.Invoice;
using Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Elements.InvoiceFolder
{
    public class Invoice : AbstractEntity
    {
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
        public EInvoiceStatus Status { get; private set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public int InvoiceNumber { get; set; }
        public DateTime IssueDate { get; set; }


        public int DetailsId { get; set; }
        public InvoiceDetails Details { get; set; }

        public int TypeId { get; set; }
        public InvoiceType Type { get; set; }


        public void EditStatus(EInvoiceStatus newStatus)
        {
            if(this.Status == EInvoiceStatus.CANCELED || this.Status == EInvoiceStatus.PAID)
                throw new ValidationException("Can not change the status of a canceled or paied invoice.");

            if (newStatus == this.Status)
                throw new ValidationException("Status is the same to the value already set.");

            this.Status = newStatus;
        }
    }
}
