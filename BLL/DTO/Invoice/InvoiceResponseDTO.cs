using Entities.Elements.Enums;
using Entities.Elements.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Invoice
{
    public class InvoiceResponseDTO : IBaseDTO
    {
        public string CustomerName { get; set; }
        public EInvoiceStatus Status { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public int InvoiceNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public List<InvoiceItemDTO> Items { get; set; }
        public int PercentageDiscount { get; set; }
        public int PercentageTax { get; set; }
        public string Notes { get; set; }
    }
}
