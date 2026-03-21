using BLL.DTO.Users.Login;
using Entities.Elements;
using Entities.Elements.Enums;
using Entities.Elements.InvoiceFolder;
using Entities.Elements.ProductFolder;
using Entities.Services;
using Entities.Services.Enums;
using Entities.Users;
using Entities.Users.Enums;

namespace ServiceLayerTests
{
    public static class SharedMockData
    {
        // ───── CUSTOMERS ─────
        public static List<Customer> GetMockCustomers() => new()
        {
            new Customer { Id = 1, Name = "Juan Perez",   Phone = "3411234567", RegisterDate = new DateTime(2024, 1, 10) },
            new Customer { Id = 2, Name = "Maria Lopez",  Phone = "3419876543", RegisterDate = new DateTime(2024, 3, 20) },
            new Customer { Id = 3, Name = "Carlos Ruiz",  Phone = "3415551234", RegisterDate = new DateTime(2024, 6, 5)  },
        };

        public static Customer GetSingleCustomer() => GetMockCustomers().First();

        // ───── USERS ─────
        public static List<User> GetMockUsers() => new()
        {
            new User { Id = 1, UserName = "admin_user",  Email = "admin@tecno.com"    },
            new User { Id = 2, UserName = "sales_user",  Email = "sales@tecno.com"    },
            new User { Id = 3, UserName = "repair_user", Email = "repair@tecno.com"   },
        };

        public static User GetSingleUser() => GetMockUsers().First();

        // ───── DEVICES ─────
        public static List<Device> GetMockDevices()
        {
            var owner = GetSingleCustomer();
            return new()
            {
                new Device { Id = 1, Brand = "Samsung",  Model = "Galaxy S23",   Type = EDeviceType.PHONE,    Owner = owner, OwnerId = owner.Id, SerialNumber = "SN001" },
                new Device { Id = 2, Brand = "Dell",     Model = "Inspiron 15",  Type = EDeviceType.NOTEBOOK, Owner = owner, OwnerId = owner.Id, SerialNumber = "SN002" },
                new Device { Id = 3, Brand = "HP",       Model = "LaserJet Pro", Type = EDeviceType.PRINTER,  Owner = owner, OwnerId = owner.Id, SerialNumber = "SN003" },
            };
        }

        public static Device GetSingleDevice() => GetMockDevices().First();

        // ───── REPAIRS ─────
        public static List<Repair> GetMockRepairs()
        {
            var device = GetSingleDevice();
            return new()
            {
                new Repair { Id = 1, DeviceId = device.Id, Device = device, Notes = "Screen broken",      ExitDate = DateTime.UtcNow.AddDays(3)  },
                new Repair { Id = 2, DeviceId = device.Id, Device = device, Notes = "Battery replacement", ExitDate = DateTime.UtcNow.AddDays(1)  },
                new Repair { Id = 3, DeviceId = device.Id, Device = device, Notes = "Paper jam",           ExitDate = DateTime.UtcNow.AddDays(2)  },
            };
        }

        public static Repair GetSingleRepair() => GetMockRepairs().First();

        // ───── SERVICES ─────
        public static List<Service> GetMockServices() => new()
        {
            new Service("PC Cleaning", "Full PC cleaning service",  30m,  new TimeOnly(1, 0) ) { Id = 1},
            new Service("OS Installation", "Windows install and setup", 50m, new TimeOnly(2, 30)) { Id = 2},
            new Service( "Data Recovery", "Hard drive data recovery", 120m, new TimeOnly(4, 0)) { Id = 3}
        };

        public static Service GetSingleService() => GetMockServices().First();

        // ───── AUTH DTOs ─────
        public static LoginRequestDTO GetValidLoginRequest() =>
            new() { Email = "admin@tecno.com", Password = "Admin@1234" };

        public static RegisterRequestDTO GetValidRegisterRequest() =>
            new() { Email = "newuser@tecno.com", Password = "NewUser@1234", UserName = "new_user" };
    }
}
