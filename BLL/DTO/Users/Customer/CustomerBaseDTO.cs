using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Users.Customer
{
    public class CustomerBaseDTO
    {
        public required string Name { get; set; }
        public required string Phone { get; set; }
    }
}
