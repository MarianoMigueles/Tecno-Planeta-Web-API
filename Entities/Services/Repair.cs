using Entities.Elements;
using Entities.Services.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Services
{
    public class Repair : AbstractEntity
    {
        [Column(TypeName = "decimal(6,2)")]
        public decimal Cost { get; private set; }
        public DateTime ExitDate { get; set; }
        public DateTime EntryDate { get; set; }
        public ERepairStatus RepairStatus { get; private set; }
        public string Notes { get; set; }


        public int DeviceId { get; set; }
        public Device Device { get; set; }

        public void ChangeRepairStatus(ERepairStatus newStatus)
        {
            throw new NotImplementedException();
        }

        public void EditEntryDate(DateTime newDate)
        {
            throw new NotImplementedException();
        }

        public void EditExitDate(DateTime newDate)
        {
            throw new NotImplementedException();
        }

        public void CancelRepair()
        {
            throw new NotImplementedException();
        }

    }
}
