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
    public class RepairBaseDTO : IBaseDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Repair cost is required")]
        [Range(0, 10000, ErrorMessage = "Cost must be between 0 and 10,000")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Cost must have up to 2 decimal places")]
        [DataType(DataType.Currency)]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Exit date is required")]
        [DataType(DataType.DateTime)]
        public DateTime ExitDate { get; set; }

        [Required(ErrorMessage = "Entry date is required")]
        [DataType(DataType.DateTime)]
        public DateTime EntryDate { get; set; }

        [Required(ErrorMessage = "Repair status is required")]
        [EnumDataType(typeof(ERepairStatus), ErrorMessage = "Invalid repair status")]
        public ERepairStatus RepairStatus { get; set; }

        [StringLength(1000, ErrorMessage = "Notes cannot exceed 1000 characters")]
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

        [Required(ErrorMessage = "Device ID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Device ID must be a positive number")]
        public int DeviceId { get; set; }

        [Required(ErrorMessage = "Device type is required")]
        [EnumDataType(typeof(EDeviceType), ErrorMessage = "Invalid device type")]
        public EDeviceType DeviceType { get; set; }

        [Required(ErrorMessage = "Device brand is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Brand must be between 2 and 50 characters")]
        [RegularExpression(@"^[a-zA-Z0-9áéíóúÁÉÍÓÚñÑ\s\-\&]+$", ErrorMessage = "Brand can only contain letters, numbers, spaces, and hyphens")]
        public string DeviceBrand { get; set; }
    }
}
