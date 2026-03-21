using Exeptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public decimal SalePrice { get; private set; }
        public int Stock { get; private set; }
        public bool IsActive { get; private set; }


        public int CategoryId { get; set; }
        public ProductCategory Category { get; set; }

        public int DetailsId { get; set; }
        public ProductDetails Details { get; set; }

        /*
        public Product(string name, decimal salePrice, ProductCategory category, ProductDetails details, bool isActive = false, int stock = 0)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Product name is required.", nameof(name));

            if (salePrice < 0)
                throw new ArgumentException("Sale price can not be negative.", nameof(salePrice));

            Name = name;
            SalePrice = salePrice;
            IsActive = isActive;
            Stock = stock;

            Category = category ?? throw new ArgumentNullException(nameof(category));
            Details = details ?? throw new ArgumentNullException(nameof(details));
        }*/


        public void EditSalePrice(decimal newPrice)
        {
            if (newPrice < 0)
                throw new ValidationException("Sale price can not be less of 0.");

            SalePrice = newPrice;
        }

        public void AddStock(int amount)
        {
            if (amount <= 0)
                throw new ValidationException("Aamount can not be less of 0.");

            Stock += amount;
        }

        public void SubstractStock(int amount)
        {
            if (amount <= 0)
                throw new ValidationException("Amount can not be less of 0.");

            Stock -= amount;
        }

        public void EditStatus(bool newStatus)
        {
            if(newStatus == this.IsActive)
                throw new ValidationException("State is the same to the value already set.");

            IsActive = newStatus;
        }
    }
}
