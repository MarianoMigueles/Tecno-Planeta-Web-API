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
        //--------------------------------- GET ------------------------------------------------------

        public async Task<List<Device>> GetAllByBrandAsync(string brand) => await this.GetListAsync(d => d.Brand.Equals(brand));
        public async Task<List<Device>> GetAllByModelAsync(string model) => await this.GetListAsync(d => d.Model.Equals(model));
        public async Task<List<Device>> GetAllByTypeAsync(EDeviceType type) => await this.GetListAsync(d => d.Type.Equals(type));
        public async Task<List<Device>> GetByCustomerNameAsync(string customerName) => await this.GetListAsync(d => d.Owner.Name.Equals(customerName));

        //----------------------------------------------------------------------------------------- <>
    }
}
