using Entities.Elements.Enums;
using Entities.Services;
using Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Elements
{
    public class Device : AbstractEntity
    {
        public int OwnerId { get; set; }
        public Customer Owner { get; set; }
        public EDeviceType Type { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }

        public List<Repair> Repairs { get; set; }
    }
}
