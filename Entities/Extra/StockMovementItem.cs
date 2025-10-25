using Entities.Elements.ProductFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Extra
{
    public class StockMovementItem : AbstractEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
