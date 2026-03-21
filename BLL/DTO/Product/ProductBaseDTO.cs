using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Product
{
    public class ProductBaseDTO : IBaseDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Product name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters")]
        public string Name { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Sale price must be greater than 0")]
        public decimal SalePrice { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Stock cannot be negative")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "Category description is required")]
        [StringLength(50, ErrorMessage = "Category description cannot exceed 50 characters")]
        public string CategoryDescription { get; set; }

        [StringLength(500, ErrorMessage = "Details description cannot exceed 500 characters")]
        public string DetailsDescription { get; set; }

        [MaxLength(50, ErrorMessage = "Barcode cannot exceed 50 characters")]
        [RegularExpression(@"^[A-Za-z0-9\-]+$", ErrorMessage = "Barcode can only contain letters, numbers and hyphens")]
        public string BarCode { get; set; }
    }
}
