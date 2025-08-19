using DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICustomerRepository CustomerRepository { get; }
        IDeviceRepository DeviceRepository { get; }
        IInvoiceRepository InvoiceRepository { get; }
        IProductRepository ProductRepository { get; }   
        IRepairRepository RepairRepository { get; }
        IServiceRepository ServiceRepository { get; }
        IUserRepository UserRepository { get; }

        void Dispose();
        Task<int> Save();
    }
}
