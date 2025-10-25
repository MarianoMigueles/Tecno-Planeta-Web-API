using Entities.Elements.InvoiceFolder;
using Entities.Elements.ProductFolder;
using Entities.Extra.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Extra
{
    public class StockMovement : AbstractEntity
    {
        public EStockMovementType Type { get; set; }
        public int Quantity => Items.Count;
        public DateTime Date { get; set; }
        public string Notes { get; set; }
        public List<StockMovementItem> Items { get; set; }
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
    }
}
