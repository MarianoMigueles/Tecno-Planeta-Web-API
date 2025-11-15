using Entities.Elements.Enums;
using Entities.Services.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Services.Repair
{
    public class RepairUpdateDTO : IBaseDTO
    {
        [Range(0, 10000, ErrorMessage = "Cost must be between 0 and 10,000")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Cost must have up to 2 decimal places")]
        public decimal? Cost { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ExitDate { get; set; }

        [Required(ErrorMessage = "Repair status is required for update")]
        [EnumDataType(typeof(ERepairStatus), ErrorMessage = "Invalid repair status")]
        public ERepairStatus RepairStatus { get; set; }

        [StringLength(1000, ErrorMessage = "Notes cannot exceed 1000 characters")]
        public string? Notes { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "Brand must be between 2 and 50 characters")]
        public string? Brand { get; set; }
    }
}
