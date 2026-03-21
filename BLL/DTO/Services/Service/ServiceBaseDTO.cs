using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Services.Service
{
    public class ServiceBaseDTO : IBaseDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Service name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Service name must be between 2 and 100 characters")]
        [RegularExpression(@"^[a-zA-Z0-9áéíóúÁÉÍÓÚñÑ\s\-\.,&]+$",
            ErrorMessage = "Service name can only contain letters, numbers, spaces, hyphens, and common punctuation")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Service description is required")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 500 characters")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Base price is required")]
        [Range(0.01, 100000, ErrorMessage = "Base price must be between 0.01 and 100,000")]
        [DataType(DataType.Currency)]
        public decimal BasePrice { get; set; }

        [Required(ErrorMessage = "Estimated time is required")]
        [Range(typeof(TimeOnly), "00:15", "23:59", ErrorMessage = "Estimated time must be between 15 minutes and 24 hours")]
        public TimeOnly EstimatedTime { get; set; }
    }
}
