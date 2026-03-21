using Entities.Elements.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Device
{
    public class BaseDeviceDTO : IBaseDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Device type is required")]
        public virtual EDeviceType Type { get; set; }

        [Required(ErrorMessage = "Model is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Model must be between 1 and 50 characters")]
        [RegularExpression(@"^[a-zA-Z0-9\s\-_]+$", ErrorMessage = "Model can only contain letters, numbers, spaces, hyphens and underscores")]
        public virtual string Model { get; set; }

        [StringLength(30, ErrorMessage = "Brand cannot exceed 30 characters")]
        [RegularExpression(@"^[a-zA-Z0-9\s\-&]+$", ErrorMessage = "Brand can only contain letters, numbers, spaces, hyphens and ampersand")]
        public virtual string Brand { get; set; }

        [StringLength(50, ErrorMessage = "Serial number cannot exceed 50 characters")]
        [RegularExpression(@"^[A-Za-z0-9\-]+$", ErrorMessage = "Serial number can only contain letters, numbers and hyphens")]
        public virtual string SerialNumber { get; set; }
    }
}
