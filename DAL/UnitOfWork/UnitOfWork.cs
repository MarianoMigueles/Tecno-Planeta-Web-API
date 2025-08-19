using DAL.Data;
using DAL.Repository.Interfaces;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICustomerRepository CustomerRepository { get; }
        public IDeviceRepository DeviceRepository { get; }
        public IInvoiceRepository InvoiceRepository { get; }
        public IProductRepository ProductRepository { get; }
        public IRepairRepository RepairRepository { get; }
        public IServiceRepository ServiceRepository { get; }
        public IUserRepository UserRepository { get; }

        private readonly DataContext _context;

        public UnitOfWork
        (
            ICustomerRepository customerRepository,
            IDeviceRepository deviceRepository,
            IInvoiceRepository invoiceRepository,
            IProductRepository productRepository,
            IRepairRepository repairRepository,
            IServiceRepository serviceRepository,
            IUserRepository userRepository,
            DataContext dataContext
        )
        {
            CustomerRepository = customerRepository;
            DeviceRepository = deviceRepository;
            InvoiceRepository = invoiceRepository;
            ProductRepository = productRepository;
            RepairRepository = repairRepository;
            ServiceRepository = serviceRepository;
            UserRepository = userRepository;
            _context = dataContext;
        }

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
