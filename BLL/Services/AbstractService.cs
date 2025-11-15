using AutoMapper;
using BLL.DTO;
using BLL.Services.Interfaces;
using DAL.Repository.Interfaces;
using DAL.UnitOfWork;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public abstract class AbstractService<TResponseDTO, TEntity, TRepository>(IUnitOfWork unitOfWork, IMapper mapper) where TResponseDTO : IBaseDTO where TEntity : class where TRepository : IRepository<TEntity> 
    {
        protected readonly IUnitOfWork _unitOfWork = unitOfWork;
        protected readonly IMapper _mapper = mapper;
        protected abstract TRepository Repository { get; }

        public abstract Task<TResponseDTO> CreateAsync(IBaseDTO createDto);
        public abstract Task<bool> DeleteAsync(int id);

        public virtual async Task<TResponseDTO> GetByIdAsync(int id)
        {
            var entity = await Repository.GetByIdAsync(id);
            return _mapper.Map<TResponseDTO>(entity);
        }

        public virtual async Task<List<TResponseDTO>> GetAllAsync()
        {
            var entities = await Repository.GetAllAsync();
            return _mapper.Map<List<TResponseDTO>>(entities);
        }

        public virtual async Task<TResponseDTO> CommonCreateAsync<TCreateDTO>(TCreateDTO createDto)
        {
            var entity = _mapper.Map<TEntity>(createDto);
            await Repository.CreateAsync(entity);
            await this.SaveChangesAsync();
            return _mapper.Map<TResponseDTO>(entity);
        }
        public virtual async Task<bool> CommonDeleteAsync(int id)
        {
            var entity = await Repository.GetByIdAsync(id);
            Repository.Delete(entity);
            return await this.SaveChangesAsync();
        }

        protected virtual async Task<bool> SaveChangesAsync()
        {
            int changes = await _unitOfWork.Save();
            return changes > 0;
        }
    }
}
