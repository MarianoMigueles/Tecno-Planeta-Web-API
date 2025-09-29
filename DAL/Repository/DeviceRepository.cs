using DAL.Data;
using DAL.Repository.Interfaces;
using Entities.Elements;
using Entities.Elements.Enums;
using Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class DeviceRepository(DataContext context) : AbstractRepository<Device>(context), IDeviceRepository
    {
        public Task<List<Device>> GetAllByBrand(string brand)
        {
            throw new NotImplementedException();
        }

        public Task<List<Device>> GetAllByModel(string model)
        {
            throw new NotImplementedException();
        }

        public Task<List<Device>> GetAllByType(EDeviceType type)
        {
            throw new NotImplementedException();
        }

        public Task<List<Device>> GetByCustomerName(string customerName)
        {
            throw new NotImplementedException();
        }
    }
}
