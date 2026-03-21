using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Users.Customer
{
    public class CustomerBaseDTO : IBaseDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Customer name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s']+$", ErrorMessage = "Name can only contain letters and spaces")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^(\+?1?[-.\s]?)?\(?[2-9]\d{2}\)?[-.\s]?\d{3}[-.\s]?\d{4}$",
            ErrorMessage = "Please enter a valid phone number format (e.g., +1-234-567-8900)")]
        [DataType(DataType.PhoneNumber)]
        public required string Phone { get; set; }
    }
}
