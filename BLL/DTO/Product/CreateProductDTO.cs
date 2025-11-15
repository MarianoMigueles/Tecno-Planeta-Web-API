using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Product
{
    public class CreateProductDTO : ProductBaseDTO
    {
        [Range(0, double.MaxValue, ErrorMessage = "Purchase price cannot be negative")]
        [DataType(DataType.Currency)]
        public decimal PurchasePrice { get; set; }
    }
}
