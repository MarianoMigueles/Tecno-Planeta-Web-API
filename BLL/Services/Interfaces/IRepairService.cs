using Entities.Services.Enums;
using Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO.Service;

namespace BLL.Services.Interfaces
{
    public interface IRepairService
    {
        //--------------------------------- GET ------------------------------------------------------
        public Task<List<RepairDTO>> GetByCustomerName(string name);
        public Task<List<RepairDTO>> GetByEntryDate(DateTime entryDate);
        public Task<List<RepairDTO>> GetByPeriotOfEntryDate(DateTime startDate, DateTime endDate);

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PUT ------------------------------------------------------
        public Task<RepairDTO> UpdateCost(decimal newCost);
        public Task<RepairDTO> UpdateNote(string note);
        public Task<RepairDTO> UpdateStatus(ERepairStatus newStatus);
        public Task<RepairDTO> CancelRepair();
        //----------------------------------------------------------------------------------------- <>
    }
}
