using AutoMapper;
using BLL.DTO.Repair;
using BLL.Services.Interfaces;
using DAL.UnitOfWork;
using Entities.Services;
using Entities.Services.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class RepairService(IUnitOfWork unitOfWork, IMapper mapper) : AbstractService<Repair, RepairDTO>(unitOfWork, mapper), IRepairService
    {
        //--------------------------------- GET ------------------------------------------------------

        public Task<List<RepairDTO>> GetByCustomerName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<RepairDTO>> GetByEntryDate(DateTime entryDate)
        {
            throw new NotImplementedException();
        }

        public Task<List<RepairDTO>> GetByPeriodOfEntryDate(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PATCH ------------------------------------------------------

        public Task<RepairDTO> CancelRepair()
        {
            throw new NotImplementedException();
        }

        public Task<RepairDTO> UpdateCost(decimal newCost)
        {
            throw new NotImplementedException();
        }

        public Task<RepairDTO> UpdateNote(string note)
        {
            throw new NotImplementedException();
        }

        public Task<RepairDTO> UpdateStatus(ERepairStatus newStatus)
        {
            throw new NotImplementedException();
        }

        //----------------------------------------------------------------------------------------- <>
    }
}
