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
        public required int Phone { get; set; }
        public DateTime RegisterDate { get; set; }


        public int RepairId { get; set; }
        public Repair Repair { get; set; }
    }
}
