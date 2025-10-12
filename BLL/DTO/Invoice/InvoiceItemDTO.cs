using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Invoice
{
    public class InvoiceItemDTO
    {
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
