using AutoMapper;
using BLL.DTO;
using BLL.Services.Interfaces;
using DAL.UnitOfWork;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public abstract class AbstractService<TEntity, TDto>(IUnitOfWork unitOfWork, IMapper mapper) where TEntity : AbstractEntity where TDto : IBaseDTO
    {
        protected readonly IUnitOfWork _unitOfWork = unitOfWork;
        protected readonly IMapper _mapper = mapper;

        public virtual Task CreateAsync(TDto entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(TDto entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task<List<TDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
         
        public virtual Task<TDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public virtual void Update(TDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
