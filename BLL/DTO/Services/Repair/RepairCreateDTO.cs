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
    public class RepairCreateDTO : RepairBaseDTO
    {
        [Required(ErrorMessage = "Owner ID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Owner ID must be a positive number")]
        public int OwnerId { get; set; }

        [Required(ErrorMessage = "Owner name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Owner name must be between 2 and 100 characters")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s']+$", ErrorMessage = "Owner name can only contain letters and spaces")]
        public string OwnerName { get; set; }

        [Required(ErrorMessage = "Device model is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Device model must be between 1 and 50 characters")]
        [RegularExpression(@"^[a-zA-Z0-9áéíóúÁÉÍÓÚñÑ\s\-\_]+$", ErrorMessage = "Device model can only contain letters, numbers, spaces, hyphens and underscores")]
        public string DeviceModel { get; set; }

        [Required(ErrorMessage = "Device serial number is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Serial number must be between 3 and 50 characters")]
        [RegularExpression(@"^[a-zA-Z0-9\-\_]+$", ErrorMessage = "Serial number can only contain letters, numbers, hyphens and underscores")]
        public string DeviceSerialNumber { get; set; }
    }
}
