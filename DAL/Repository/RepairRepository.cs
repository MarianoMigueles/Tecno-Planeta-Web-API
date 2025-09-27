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
    public class RepairRepository(DataContext context) : Repository<Repair>(context), IRepairRepository
    {
        public Task<Repair> CancelRepair()
        {
            throw new NotImplementedException();
        }

        public Task<List<Repair>> GetByCustomerName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<Repair>> GetByEntryDate(DateTime entryDate)
        {
            throw new NotImplementedException();
        }

        public Task<List<Repair>> GetByPeriotOfEntryDate(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public Task<Repair> UpdateCost(decimal newCost)
        {
            throw new NotImplementedException();
        }

        public Task<Repair> UpdateNote(string note)
        {
            throw new NotImplementedException();
        }

        public Task<Repair> UpdateStatus(ERepairStatus newStatus)
        {
            throw new NotImplementedException();
        }
    }
}
