using DAL.Data;
using DAL.Repository.Interfaces;
using Exeptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public abstract class AbstractRepository<T>(DataContext context) : IRepository<T> where T : class
    {
        protected readonly DataContext _context = context;

        public virtual async Task CreateAsync(T entity)
        {
            try
            {
                await _context.Set<T>().AddAsync(entity);
            }
            catch (Exception ex)
            {
                throw new DatabaseOperationException($"An unexpected error occurred while creating the entity of type {typeof(T).Name}. Error: {ex.Message}");
            }
        }

        public virtual void Delete(T entity)
        {
            try
            {
                _context.Set<T>().Remove(entity);
            }
            catch (Exception ex)
            {
                throw new DatabaseOperationException($"An unexpected error occurred while deleting the entity of type {typeof(T).Name}. Error: {ex.Message}");
            }
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            try
            {
                return await _context.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new DatabaseOperationException($"Could not retrieve a list of type {typeof(T).Name}. Error: {ex.Message}");
            }
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            var result = await _context.Set<T>().FindAsync(id);
            return result ?? throw new EntityNotFoundException($"No entity of type {typeof(T).Name} was found with ID {id}.");
        }

        public virtual void Update(T entity)
        {
            try
            {
                _context.Set<T>().Update(entity);
            }
            catch (Exception ex)
            {
                throw new DatabaseOperationException($"An unexpected error occurred while updating the entity of type {typeof(T).Name}. Error: {ex.Message}");
            }
        }
    }
}
