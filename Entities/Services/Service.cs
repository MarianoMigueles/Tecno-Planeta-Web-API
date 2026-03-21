using Exeptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Services
{
    public class Service : AbstractEntity, IBaseService
    {
        public string Name { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal BasePrice { get; private set; }
        public TimeOnly EstimatedTime { get; private set; }

        public Service(string name,string description, decimal basePrice, TimeOnly estimatedTime)
        {
            Name = name;
            Description = description;
            EditBasePrice(basePrice);
            EditEstimatedTime(estimatedTime);
        }
        public void EditBasePrice(decimal newPrice)
        {
            if (newPrice < 0)
                throw new ValidationException("Price can not be less of 0.");


            BasePrice = newPrice;
        }

        public void EditEstimatedTime(TimeOnly newTime)
        {
            if(EstimatedTime == newTime)
                throw new ValidationException("Time is the same to the value already set.");

            EstimatedTime = newTime;
        }
    }
}
