using Entities.Elements.InvoiceFolder;
using Entities.Elements.ProductFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Elements.Invoice
{
    public class InvoiceDetails : AbstractEntity
    {
        public int Quantity => Items.Count;
        public int PercentageDiscount { get; set; }
        public int PercentageTax { get; set; }
        public string Notes { get; set; }
        public List<InvoiceItem> Items { get; set; }
        public int InvoiceId { get; set; }
    }
}
