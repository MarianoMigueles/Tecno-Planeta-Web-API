using AutoMapper;
using BLL.DTO.Product;
using BLL.DTO;
using BLL.DTO.Services.Repair;
using BLL.Services.Interfaces;
using DAL.Repository.Interfaces;
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
    public class RepairService(IUnitOfWork unitOfWork, IMapper mapper) : AbstractService<RepairResponseDTO, Repair, IRepairRepository>(unitOfWork, mapper), IRepairService
    {
        protected override IRepairRepository Repository => _unitOfWork.RepairRepository;

        //--------------------------------- GET ------------------------------------------------------

        public async Task<List<RepairResponseDTO>> GetByCustomerNameAsync(string name)
        {
            var repairs = await Repository.GetByCustomerNameAsync(name);
            return _mapper.Map<List<RepairResponseDTO>>(repairs);
        }

        public async Task<List<RepairResponseDTO>> GetByEntryDateAsync(DateTime entryDate)
        {
            var repairs = await Repository.GetByEntryDateAsync(entryDate);
            return _mapper.Map<List<RepairResponseDTO>>(repairs);
        }

        public async Task<List<RepairResponseDTO>> GetByPeriodOfEntryDateAsync(DateTime min, DateTime max)
        {
            var repairs = await Repository.GetByPeriodOfEntryDateAsync(min, max);
            return _mapper.Map<List<RepairResponseDTO>>(repairs);
        }

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PATCH ------------------------------------------------------

        public async Task<RepairResponseDTO> CancelRepairAsync(int id)
        {
            var repair = await Repository.CancelRepairAsync(id);
            await SaveChangesAsync();
            return _mapper.Map<RepairResponseDTO>(repair);
        }

        public async Task<RepairResponseDTO> UpdateCostAsync(int id, decimal newCost)
        {
            var repair = await Repository.UpdateCostAsync(id, newCost);
            await SaveChangesAsync();
            return _mapper.Map<RepairResponseDTO>(repair);
        }

        public async Task<RepairResponseDTO> UpdateNoteAsync(int id, string note)
        {
            var repair = await Repository.UpdateNoteAsync(id, note);
            await SaveChangesAsync();
            return _mapper.Map<RepairResponseDTO>(repair);
        }

        public async Task<RepairResponseDTO> UpdateStatusAsync(int id, ERepairStatus newStatus)
        {
            var repair = await Repository.UpdateStatusAsync(id, newStatus);
            await SaveChangesAsync();
            return _mapper.Map<RepairResponseDTO>(repair);
        }

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- POST ------------------------------------------------------

        public override async Task<RepairResponseDTO> CreateAsync(IBaseDTO createDto) => await CommonCreateAsync(createDto);

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- DELETE ------------------------------------------------------

        public override async Task<bool> DeleteAsync(int id) => await CommonDeleteAsync(id);

        //----------------------------------------------------------------------------------------- <>
    }
}
