using Entities.Elements;
using Entities.Services.Enums;
using Exeptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Services
{
    public class Repair : AbstractEntity, IBaseService
    {
        [Column(TypeName = "decimal(6,2)")]
        public decimal Cost { get; private set; }
        public DateTime ExitDate { get; set; }
        public DateTime EntryDate => DateTime.UtcNow;
        public ERepairStatus RepairStatus { get; private set; }
        public string Notes { get; set; }
        public int DeviceId { get; set; }
        public Device Device { get; set; }
        string IBaseService.Name => typeof(Repair).Name;
        public TimeOnly EstimatedTime { get; private set; }

        public void ChangeRepairStatus(ERepairStatus newStatus)
        {
            if (this.RepairStatus == ERepairStatus.COMPLETE)
                throw new ValidationException("Status can not be chaged if the repair was completed");

            if (newStatus == this.RepairStatus)
                throw new ValidationException("State is the same to the value already set.");

            this.RepairStatus = newStatus;
        }

        public void EditExitDate(DateTime newDate)
        {
            if (newDate < DateTime.Now)
                throw new ValidationException("Date cannot be older than the current one.");

            this.ExitDate = newDate;
        }

        public void CancelRepair()
        {
            EditExitDate(DateTime.Now);
            ChangeRepairStatus(ERepairStatus.CANCELED);
        }

        public void UpdateCost(decimal newCost)
        {
            if (newCost < 0)
                throw new ValidationException("Cost can not be less of 0.");

            this.Cost = newCost;
        }

        public void EditEstimatedTime(TimeOnly newTime)
        {
            if (EstimatedTime == newTime)
                throw new ValidationException("Time is the same to the value already set.");

            EstimatedTime = newTime;
        }
    }
}
