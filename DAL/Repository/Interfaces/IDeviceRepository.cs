using Entities.Elements;
using Entities.Elements.Enums;
using Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Interfaces
{
    public interface IDeviceRepository : IRepository<Device>
    {
        //--------------------------------- GET ------------------------------------------------------
        public Task<List<Device>> GetByCustomerNameAsync(string customerName);
        public Task<List<Device>> GetAllByTypeAsync(EDeviceType type);
        public Task<List<Device>> GetAllByModelAsync(string model);
        public Task<List<Device>> GetAllByBrandAsync(string brand);
        //----------------------------------------------------------------------------------------- <>
    }
}
