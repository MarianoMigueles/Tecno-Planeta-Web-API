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
        public Task<List<Service>> GetAllByGreaterPrice(decimal price)
        {
            throw new NotImplementedException();
        }

        public Task<List<Service>> GetAllByLessPrice(decimal price)
        {
            throw new NotImplementedException();
        }

        public Task<List<Service>> GetAllByRangeOfPrice(decimal startPrice, decimal endPrice)
        {
            throw new NotImplementedException();
        }

        public Task<Service> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<Service>> GetByPeriotOfEstimatedTime(DateTime startTime, DateTime endTime)
        {
            throw new NotImplementedException();
        }

        public Task<Service> UpdateBasePrice(decimal newPrice)
        {
            throw new NotImplementedException();
        }

        public Task<Service> UpdateDescription(string newDescription)
        {
            throw new NotImplementedException();
        }

        public Task<Service> UpdateEstimatedTime(DateTime newEstimatedTime)
        {
            throw new NotImplementedException();
        }

        public Task<Service> UpdateName(string newName)
        {
            throw new NotImplementedException();
        }
    }
}
