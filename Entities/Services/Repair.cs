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
            // The status can't be chaged if the repair was completed
            if (this.RepairStatus == ERepairStatus.COMPLETE)
                throw new NotImplementedException("not implement the specific exeption yet");

            // The status can't be the same status
            if (newStatus == this.RepairStatus)
                throw new NotImplementedException("not implement the specific exeption yet");

            this.RepairStatus = newStatus;
        }

        public void EditExitDate(DateTime newDate)
        {
            // The date cannot be older than the current one
            if (newDate < DateTime.Now)
                throw new NotImplementedException("not implement the specific exeption yet");

            this.ExitDate = newDate;
        }

        public void CancelRepair()
        {
            EditExitDate(DateTime.Now);
            ChangeRepairStatus(ERepairStatus.CANCELED);
        }

    }
}
