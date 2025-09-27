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
    public interface IDeviceRepository
    {
        //--------------------------------- GET ------------------------------------------------------
        public Task<List<Device>> GetByCustomerName(string customerName);
        public Task<List<Device>> GetAllByType(EDeviceType type);
        public Task<List<Device>> GetAllByModel(string model);
        public Task<List<Device>> GetAllByBrand(string brand);
        //----------------------------------------------------------------------------------------- <>
    }
}
