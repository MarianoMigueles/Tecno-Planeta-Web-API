using Entities.Elements.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Invoice
{
    public class InvoiceCreateDTO : IBaseDTO
    {
        public int Id { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Valid customer ID is required")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Invoice status is required")]
        [EnumDataType(typeof(EInvoiceStatus), ErrorMessage = "Invalid invoice status")]
        public EInvoiceStatus Status { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Subtotal cannot be negative")]
        public decimal SubTotal { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Total cannot be negative")]
        public decimal Total { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Valid invoice number is required")]
        public int InvoiceNumber { get; set; }

        [DataType(DataType.Date)]
        [NotFutureDate(ErrorMessage = "Issue date cannot be in the future")]
        public DateTime IssueDate { get; set; }

        [Required(ErrorMessage = "Invoice items are required")]
        [MinLength(1, ErrorMessage = "At least one item is required")]
        public List<InvoiceItemDTO> Items { get; set; }

        [Range(0, 100, ErrorMessage = "Discount must be between 0 and 100 percent")]
        public int PercentageDiscount { get; set; }

        [Range(0, 100, ErrorMessage = "Tax must be between 0 and 100 percent")]
        public int PercentageTax { get; set; }

        [StringLength(500, ErrorMessage = "Notes cannot exceed 500 characters")]
        public string Notes { get; set; }
    }

    public class NotFutureDateAttribute : ValidationAttribute
    {
        public bool IncludeToday { get; set; } = true;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime date)
            {
                var today = DateTime.Today;
                var comparisonDate = IncludeToday ? today : today.AddDays(-1);

                if (date > comparisonDate)
                {
                    var errorMessage = ErrorMessage ??
                        $"Date cannot be after {comparisonDate:yyyy-MM-dd}";

                    return new ValidationResult(errorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}
