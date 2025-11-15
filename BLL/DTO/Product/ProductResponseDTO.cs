using Entities.Elements.ProductFolder;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Product
{
    public class ProductResponseDTO : IBaseDTO
    {
        public string Name { get; set; }
        public decimal SalePrice { get; set; }
        public int Stock { get; set; }
        public bool IsActive { get; set; }
        public string CategoryDescription { get; set; }
        public string DetailsDescription { get; set; }
        public decimal PurchasePrice { get; set; }
        public string BarCode { get; set; }
    }
}
