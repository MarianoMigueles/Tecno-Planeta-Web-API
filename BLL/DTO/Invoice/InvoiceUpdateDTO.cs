using Entities.Elements.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Invoice
{
    public class InvoiceUpdateDTO : IBaseDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Invoice status is required")]
        [EnumDataType(typeof(EInvoiceStatus), ErrorMessage = "Invalid invoice status")]
        public EInvoiceStatus Status { get; private set; }

        [StringLength(500, ErrorMessage = "Notes cannot exceed 500 characters")]
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }
    }
}
