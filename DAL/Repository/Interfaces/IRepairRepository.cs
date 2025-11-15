using Entities.Services;
using Entities.Services.Enums;
using Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Interfaces
{
    public interface IRepairRepository : IRepository<Repair>
    {
        //--------------------------------- GET ------------------------------------------------------
        public Task<List<Repair>> GetByCustomerNameAsync(string name);
        public Task<List<Repair>> GetByEntryDateAsync(DateTime entryDate);
        public Task<List<Repair>> GetByPeriodOfEntryDateAsync(DateTime min, DateTime max);
        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PATCH ------------------------------------------------------
        public Task<Repair> CancelRepairAsync(int id);
        public Task<Repair> UpdateCostAsync(int id, decimal newCost);
        public Task<Repair> UpdateNoteAsync(int id, string note);
        public Task<Repair> UpdateStatusAsync(int id, ERepairStatus newStatus);
        public Task<Repair> UpdateEstimatedTime(int id, TimeOnly newEstimatedTime);
        //----------------------------------------------------------------------------------------- <>
    }
}
