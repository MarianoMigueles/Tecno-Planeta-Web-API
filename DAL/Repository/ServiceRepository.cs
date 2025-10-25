using DAL.Data;
using DAL.Repository.Interfaces;
using Entities.Services;
using Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ServiceRepository(DataContext context) : AbstractRepository<Service>(context), IServiceRepository
    {
        //--------------------------------- GET ------------------------------------------------------

        public async Task<Service> GetByNameAsync(string name) => await this.GetSingleAsync(s => s.Name.Equals(name));
        public async Task<List<Service>> GetAllByRangeOfPrice(decimal min, decimal max)
        {
            return await this.GetListAsync(s => s.BasePrice >= min && s.BasePrice <= max);
        }
        public async Task<List<Service>> GetAllByPriceAsync(decimal price, bool isGreaterThan = false)
        {
            return await this.GetListAsync(s => isGreaterThan 
                                                ? s.BasePrice >= price 
                                                : s.BasePrice <= price);
        }
        public async Task<List<Service>> GetByPeriotOfEstimatedTimeAsync(TimeOnly min, TimeOnly max)
        {
            return await this.GetListAsync(s => s.EstimatedTime >= min && s.EstimatedTime <= max);
        }

        public async Task<List<Service>> GetAllByRangeOfPriceAsync(decimal min, decimal max)
        {
            return await this.GetListAsync(s => s.BasePrice >= min && s.BasePrice <= max);
        }

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PATCH ------------------------------------------------------

        public async Task<Service> UpdateNameAsync(int id, string newName)
        {
            var service = await this.GetByIdAsync(id);
            service.Name = newName;
            return service;
        }
        public async Task<Service> UpdateDescriptionAsync(int id, string newDescription)
        {
            var service = await this.GetByIdAsync(id);
            service.Description = newDescription;
            return service;
        }
        public async Task<Service> UpdateBasePriceAsync(int id, decimal newPrice)
        {
            var service = await this.GetByIdAsync(id);
            service.EditBasePrice(newPrice);
            return service;
        }
        public async Task<Service> UpdateEstimatedTimeAsync(int id, TimeOnly newEstimatedTime)
        {
            var service = await this.GetByIdAsync(id);
            service.EditEstimatedTime(newEstimatedTime);
            return service;
        }

        //----------------------------------------------------------------------------------------- <>
    }
}
