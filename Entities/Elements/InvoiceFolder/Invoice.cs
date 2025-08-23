using Entities.Elements.Enums;
using Entities.Elements.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Elements.InvoiceFolder
{
    public class Invoice : AbstractEntity
    {
        public EInvoiceStatus Status { get; private set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime IssueDate { get; set; }


        public int DetailsId { get; set; }
        public InvoiceDetails Details { get; set; }

        public int TypeId { get; set; }
        public InvoiceType Type { get; set; }


        public void EditStatus(EInvoiceStatus newStatus)
        {
            // Can't change the status of a canceled or paied invoice 
            if(this.Status == EInvoiceStatus.CANCELED || this.Status == EInvoiceStatus.PAID)
                throw new NotImplementedException("not implement the specific exeption yet");

            // The status can't be the same status
            if (newStatus == this.Status)
                throw new NotImplementedException("not implement the specific exeption yet");

            this.Status = newStatus;
        }
    }
}
