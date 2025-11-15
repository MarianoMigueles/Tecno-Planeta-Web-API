using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Users.Customer
{
    public class CustomerCreateDTO : CustomerBaseDTO
    {
        public DateTime RegisterDate => DateTime.UtcNow;
    }
}
