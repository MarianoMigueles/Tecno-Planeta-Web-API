using Entities.Elements.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Invoice
{
    public class UpdateInvoiceDTO
    {
        public EInvoiceStatus Status { get; private set; }
        public string Notes { get; set; }
    }
}
