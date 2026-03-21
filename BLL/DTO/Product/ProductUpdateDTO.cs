using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Product
{
    public class ProductUpdateDTO : ProductBaseDTO
    {
        public bool IsActive { get; set; }
        public decimal PurchasePrice { get; set; }
    }
}
