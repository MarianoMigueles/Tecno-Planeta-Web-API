using Entities.Elements.ProductFolder;
using Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Elements.InvoiceFolder
{
    public class InvoiceItem : AbstractEntity
    {
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        public int ServiceId { get; set; } 
        public Service Service { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
