using Entities.Elements.ProductFolder;
using Entities.Services;
using Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Interfaces
{
    public interface IServiceRepository : IRepository<Service>
    {
        //--------------------------------- GET ------------------------------------------------------
        public Task<Service> GetByNameAsync(string name);
        public Task<List<Service>> GetAllByRangeOfPriceAsync(decimal min, decimal max);
        public Task<List<Service>> GetAllByPriceAsync(decimal price, bool isGreaterThan = false);
        public Task<List<Service>> GetByPeriotOfEstimatedTimeAsync(TimeOnly min, TimeOnly max);
        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PATCH ------------------------------------------------------
        public Task<Service> UpdateNameAsync(int id, string newName);
        public Task<Service> UpdateDescriptionAsync(int id, string newDescription);
        public Task<Service> UpdateBasePriceAsync(int id, decimal newPrice);
        public Task<Service> UpdateEstimatedTimeAsync(int id, TimeOnly newEstimatedTime);
        //----------------------------------------------------------------------------------------- <>
    }
}
