using Entities.Elements.Enums;
using Entities.Services.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Services.Repair
{
    public class CreateRepairDTO
    {
        public decimal Cost { get; set; }
        public DateTime ExitDate { get; set; }
        public DateTime EntryDate { get; set; }
        public ERepairStatus RepairStatus { get; set; }
        public string Notes { get; set; }
        public int CustomerId { get; set; }
        public int DeviceId { get; set; }
        public EDeviceType DeviceType { get; set; }
        public string DeviceBrand { get; set; }
        public string DeviceModel { get; set; }
        public string DeviceSerialNumber { get; set; }
    }
}
