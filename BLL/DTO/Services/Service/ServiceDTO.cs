using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Services.Service
{
    public class ServiceDTO : IBaseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal BasePrice { get; set; }
        public TimeOnly EstimatedTime { get; set; }
    }
}
