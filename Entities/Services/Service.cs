using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Services
{
    public class Service : AbstractEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal BasePrice { get; private set; }
        public TimeOnly EstimatedTime { get; private set; }


        public void EditBasePrice(double newPrice)
        {
            throw new NotImplementedException();
        }
    }
}
