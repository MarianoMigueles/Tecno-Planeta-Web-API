using Entities.Services.Enums;
using Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO.Services.Repair;

namespace BLL.Services.Interfaces
{
    public interface IRepairService : IService
    {
        //--------------------------------- GET ------------------------------------------------------
        public Task<List<RepairResponseDTO>> GetByCustomerNameAsync(string name);
        public Task<List<RepairResponseDTO>> GetByEntryDateAsync(DateTime entryDate);
        public Task<List<RepairResponseDTO>> GetByPeriodOfEntryDateAsync(DateTime min, DateTime max);

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PATCH ------------------------------------------------------
        public Task<RepairResponseDTO> UpdateCostAsync(int id, decimal newCost);
        public Task<RepairResponseDTO> UpdateNoteAsync(int id, string note);
        public Task<RepairResponseDTO> UpdateStatusAsync(int id, ERepairStatus newStatus);
        public Task<RepairResponseDTO> CancelRepairAsync(int id);
        //----------------------------------------------------------------------------------------- <>
    }
}
