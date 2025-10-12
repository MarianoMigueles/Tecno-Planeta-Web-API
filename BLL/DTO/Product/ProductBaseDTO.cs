using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Product
{
    public class ProductBaseDTO
    {
        public string Name { get; set; }
        public decimal SalePrice { get; set; }
        public int Stock { get; set; }
        public string CategoryDescription { get; set; }
        public string DetailsDescription { get; set; }
        public decimal PurchasePrice { get; set; }
        [MaxLength(50)]
        public string BarCode { get; set; }
    }
}
