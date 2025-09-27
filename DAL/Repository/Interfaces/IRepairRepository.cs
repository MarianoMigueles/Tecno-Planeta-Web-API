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
    public interface IRepairRepository
    {
        //--------------------------------- GET ------------------------------------------------------
        public Task<List<Repair>> GetByCustomerName(string name);
        public Task<List<Repair>> GetByEntryDate(DateTime entryDate);
        public Task<List<Repair>> GetByPeriotOfEntryDate(DateTime startDate, DateTime endDate);

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PUT ------------------------------------------------------
        public Task<Repair> UpdateCost(decimal newCost);
        public Task<Repair> UpdateNote(string note);
        public Task<Repair> UpdateStatus(ERepairStatus newStatus);
        public Task<Repair> CancelRepair();
        //----------------------------------------------------------------------------------------- <>
    }
}
