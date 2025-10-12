using Entities.Elements.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Device
{
    public class DeviceDTO : IBaseDTO
    {
        [Required]
        public EDeviceType Type { get; set; }
        [Required]
        public string Model { get; set; }
        public string Brand { get; set; }
        public string SerialNumber { get; set; }
    }
}
