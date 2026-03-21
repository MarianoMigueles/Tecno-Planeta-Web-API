using Entities.Elements;
using Entities.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Users
{
    public class Customer : AbstractEntity
    {
        public required string Name { get; set; }
        public required string Phone { get; set; }
        public DateTime RegisterDate { get; set; }

        public List<Device> Devices { get; set; }
    }
}
