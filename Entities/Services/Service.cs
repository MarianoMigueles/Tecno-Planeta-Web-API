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
        public TimeOnly EstimatedTime { get; set; }

        public void EditBasePrice(decimal newPrice)
        {
            // The date cannot be less of 0
            if (newPrice < 0)
                throw new NotImplementedException("not implement the specific exeption yet");

            BasePrice = newPrice;
        }
    }
}
