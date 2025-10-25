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
        public InvoiceItem(
            int invoiceId,
            Invoice invoice,
            int? serviceId,
            IBaseService? service,
            int? productId,
            Product? product,
            decimal unitPrice)
        {
            InvoiceId = invoiceId;
            Invoice = invoice;
            UnitPrice = unitPrice;

            if((serviceId.HasValue && service != null) && (productId.HasValue && product != null))
            {
                ServiceId = serviceId;
                Service = service;
                ProductId = productId;
                Product = product;
            } else
            {
                throw new ArgumentException("Could not create an item in the list that is completely empty.");
            }
        }

        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        public int? ServiceId { get; set; } 
        public IBaseService? Service { get; set; }
        public int? ProductId { get; set; }
        public Product? Product { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
