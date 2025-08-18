using Entities.Elements.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Elements.Invoice
{
    public class InvoiceType : AbstractEntity
    {
        public string Type { get; set; }
        public EInvoiceOperation Operation { get; set; }
    }
}
