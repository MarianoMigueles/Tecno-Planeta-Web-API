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
    public interface IServiceRepository
    {
        //--------------------------------- GET ------------------------------------------------------
        public Task<Service> GetByName(string name);
        public Task<List<Service>> GetAllByRangeOfPrice(decimal startPrice, decimal endPrice);
        public Task<List<Service>> GetAllByGreaterPrice(decimal price);
        public Task<List<Service>> GetAllByLessPrice(decimal price);
        public Task<List<Service>> GetByPeriotOfEstimatedTime(DateTime startTime, DateTime endTime);

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PUT ------------------------------------------------------
        public Task<Service> UpdateName(string newName);
        public Task<Service> UpdateDescription(string newDescription);
        public Task<Service> UpdateBasePrice(decimal newPrice);
        public Task<Service> UpdateEstimatedTime(DateTime newEstimatedTime);
        //----------------------------------------------------------------------------------------- <>
    }
}
