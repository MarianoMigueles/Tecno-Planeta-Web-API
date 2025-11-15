using Entities.Extra.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Extra
{
    public class StockMovementResponseDTO : IBaseDTO
    {
        public int Id { get; set; }
        public EStockMovementType Type { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }
        public List<StockMovementItemDTO> Items { get; set; }
        public int? InvoiceNumber { get; set; }
    }
}
