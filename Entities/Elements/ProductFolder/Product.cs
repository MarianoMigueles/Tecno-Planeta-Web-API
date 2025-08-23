using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Elements.ProductFolder
{
    public class Product : AbstractEntity
    {
        public string Name { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal SalePrice { get; set; }
        public int Stock { get; set; }
        public bool IsActive { get; set; }


        public int CategoryId { get; set; }
        public ProductCategory Category { get; set; }

        public int DetailsId { get; set; }
        public ProductDetails Details { get; set; }


        public Product(string name, decimal salePrice, ProductCategory category, ProductDetails details, bool isActive = false, int stock = 0)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Product name is required.", nameof(name));

            if (salePrice < 0)
                throw new ArgumentException("Sale price cannot be negative.", nameof(salePrice));

            Name = name;
            SalePrice = salePrice;
            IsActive = isActive;
            Stock = stock;

            Category = category ?? throw new ArgumentNullException(nameof(category));
            Details = details ?? throw new ArgumentNullException(nameof(details));
        }

        public void EditSalePrice(decimal newPrice)
        {
            // The sale price cannot be less of 0
            if (newPrice < 0)
                throw new NotImplementedException("not implement the specific exeption yet");

            SalePrice = newPrice;
        }
        public void AddStock(int amount)
        {
            if (amount <= 0)
                throw new NotImplementedException("not implement the specific exeption yet");

            Stock += amount;
        }
        public void SubstractStock(int amount)
        {
            throw new NotImplementedException();
        }
    }
}
