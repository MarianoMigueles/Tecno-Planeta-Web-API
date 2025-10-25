using DAL.Data;
using DAL.Repository.Interfaces;
using Entities.Users;
using Exeptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public abstract class AbstractRepository<T> : IRepository<T> where T : class
    {
        protected readonly DataContext _context;
        protected readonly DbSet<T> _dbSet;

        protected AbstractRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>() ?? throw new InvalidOperationException($"DbSet<{typeof(T).Name}> not configured");
        }
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

        protected virtual async Task<T> GetSingleAsync(
        Expression<Func<T, bool>> predicate,
        params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            foreach (var include in includes)
                query = query.Include(include);

            return await query.FirstOrDefaultAsync(predicate)
                   ?? throw new EntityNotFoundException($"{typeof(T).Name} not found");
        }

        protected virtual async Task<List<T>> GetListAsync(
            Expression<Func<T, bool>>? predicate = null,
            params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            foreach (var include in includes)
                query = query.Include(include);

            if (predicate != null)
                query = query.Where(predicate);

            return await query.ToListAsync();
        }
    }
}
