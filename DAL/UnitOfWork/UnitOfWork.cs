using DAL.Data;
using DAL.Repository.Interfaces;

namespace DAL.UnitOfWork
{
    public class UnitOfWork(
        ICustomerRepository customerRepository,
        IDeviceRepository deviceRepository,
        IInvoiceRepository invoiceRepository,
        IProductRepository productRepository,
        IRepairRepository repairRepository,
        IServiceRepository serviceRepository,
        IUserRepository userRepository,
        DataContext dataContext
        ) : IUnitOfWork
    {
        public ICustomerRepository CustomerRepository { get; } = customerRepository;
        public IDeviceRepository DeviceRepository { get; } = deviceRepository;
        public IInvoiceRepository InvoiceRepository { get; } = invoiceRepository;
        public IProductRepository ProductRepository { get; } = productRepository;
        public IRepairRepository RepairRepository { get; } = repairRepository;
        public IServiceRepository ServiceRepository { get; } = serviceRepository;
        public IUserRepository UserRepository { get; } = userRepository;

        private readonly DataContext _context = dataContext;

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
