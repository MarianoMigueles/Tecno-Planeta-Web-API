using Entities.Elements.Enums;
using Entities.Services.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Services.Repair
{
    public class RepairResponseDTO : IBaseDTO
    {
        public decimal Cost { get; set; }
        public DateTime ExitDate { get; set; }
        public DateTime EntryDate { get; set; }
        public ERepairStatus RepairStatus { get; set; }
        public string Notes { get; set; }
        public int DeviceId { get; set; }
        public EDeviceType Type { get; set; }
        public string Brand { get; set; }
    }
}
