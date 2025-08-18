using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Elements.ProductFolder
{
    public class ProductDetails : AbstractEntity
    {
        public string Description { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal PurchasePrice { get; set; }
        public string BarCode { get; set; }
    }
}
