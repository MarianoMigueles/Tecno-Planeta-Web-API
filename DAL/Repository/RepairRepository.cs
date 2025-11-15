using DAL.Data;
using DAL.Repository.Interfaces;
using Entities.Services;
using Entities.Services.Enums;
using Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class RepairRepository(DataContext context) : AbstractRepository<Repair>(context), IRepairRepository
    {
        //--------------------------------- GET ------------------------------------------------------

        public async Task<List<Repair>> GetByCustomerNameAsync(string name) => await GetListAsync(r => r.Device.Owner.Name.Equals(name));
        public async Task<List<Repair>> GetByEntryDateAsync(DateTime entryDate) => await GetListAsync(r => r.EntryDate.Equals(entryDate));
        public async Task<List<Repair>> GetByPeriodOfEntryDateAsync(DateTime min, DateTime max)
        {
            return await GetListAsync(r => r.EntryDate >= min && r.EntryDate <= max);
        }

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PATCH ------------------------------------------------------

        public async Task<Repair> CancelRepairAsync(int id)
        {
            var repair = await this.GetByIdAsync(id);
            repair.CancelRepair();
            return repair;
        }

        public async Task<Repair> UpdateCostAsync(int id, decimal newCost)
        {
            var repair = await this.GetByIdAsync(id);
            repair.UpdateCost(newCost);
            return repair;
        }

        public async Task<Repair> UpdateNoteAsync(int id, string note)
        {
            var repair = await this.GetByIdAsync(id);
            repair.Notes = note;
            return repair;
        }

        public async Task<Repair> UpdateStatusAsync(int id, ERepairStatus newStatus)
        {
            var repair = await this.GetByIdAsync(id);
            repair.ChangeRepairStatus(newStatus);
            return repair;
        }

        public async Task<Repair> UpdateEstimatedTime(int id, TimeOnly newEstimatedTime)
        {
            var repair = await this.GetByIdAsync(id);
            repair.EditEstimatedTime(newEstimatedTime);
            return repair;
        }
        //----------------------------------------------------------------------------------------- <>
    }
}
