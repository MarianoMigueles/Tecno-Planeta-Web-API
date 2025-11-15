using Entities.Elements.Enums;
using Entities.Services;
using Entities.Services.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Users.Customer
{
    public class CustomerResponseDTO : CustomerBaseDTO
    {
        public required DateTime RegisterDate { get; set; }
    }
}
