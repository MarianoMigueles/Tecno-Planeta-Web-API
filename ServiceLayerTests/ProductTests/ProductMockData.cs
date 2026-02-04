using Entities.Elements.ProductFolder;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayerTests.ProductTests
{
    public static class ProductMockData
    {
        public static List<Product> GetMockProducts()
        {
            var products = new List<Product>();

            // Create categories with required Id
            var components = new ProductCategory { Id = 1, Description = "Computer Components" };
            var laptops = new ProductCategory { Id = 2, Description = "Laptops and Notebooks" };
            var printers = new ProductCategory { Id = 3, Description = "Printers" };
            var services = new ProductCategory { Id = 4, Description = "Technical Services" };
            var phones = new ProductCategory { Id = 5, Description = "Mobile Phones" };
            var security = new ProductCategory { Id = 6, Description = "Security Systems" };
            var accessories = new ProductCategory { Id = 7, Description = "Accessories" };

            // Create product details
            var gpuDetails = new ProductDetails
            {
                Id = 1,
                Description = "NVIDIA RTX 4070 Ti 12GB GDDR6X",
                PurchasePrice = 699.00m,
                BarCode = "GPU001"
            };

            var cpuDetails = new ProductDetails
            {
                Id = 2,
                Description = "Intel Core i7-13700K",
                PurchasePrice = 399.00m,
                BarCode = "CPU001"
            };

            var laptopDetails = new ProductDetails
            {
                Id = 3,
                Description = "Gaming Laptop 16GB RAM, 1TB SSD",
                PurchasePrice = 1299.00m,
                BarCode = "LAP001"
            };

            var printerDetails = new ProductDetails
            {
                Id = 4,
                Description = "Laser Multifunction Printer",
                PurchasePrice = 449.00m,
                BarCode = "IMP001"
            };

            var serviceDetails = new ProductDetails
            {
                Id = 5,
                Description = "Repair Service",
                PurchasePrice = 0.00m,
                BarCode = "SER001"
            };

            var phoneDetails = new ProductDetails
            {
                Id = 6,
                Description = "iPhone 15 Pro Max 256GB",
                PurchasePrice = 1199.00m,
                BarCode = "CEL001"
            };

            var cameraDetails = new ProductDetails
            {
                Id = 7,
                Description = "4K Security Camera",
                PurchasePrice = 159.00m,
                BarCode = "CAM001"
            };

            var mouseDetails = new ProductDetails
            {
                Id = 8,
                Description = "Wireless Gaming Mouse",
                PurchasePrice = 79.00m,
                BarCode = "MOU001"
            };

            // PRODUCT 1: Graphics Card
            var product1 = new Product
            {
                Id = 1,
                CategoryId = components.Id,
                Category = components,
                DetailsId = gpuDetails.Id,
                Details = gpuDetails
            };
            product1.GetType().GetProperty("Name")?.SetValue(product1, "NVIDIA RTX 4070 Ti");
            product1.EditSalePrice(849.99m);
            product1.AddStock(8);
            product1.EditStatus(true);
            products.Add(product1);

            // PRODUCT 2: Processor
            var product2 = new Product
            {
                Id = 2,
                CategoryId = components.Id,
                Category = components,
                DetailsId = cpuDetails.Id,
                Details = cpuDetails
            };
            product2.GetType().GetProperty("Name")?.SetValue(product2, "Intel Core i7-13700K");
            product2.EditSalePrice(489.99m);
            product2.AddStock(15);
            product2.EditStatus(true);
            products.Add(product2);

            // PRODUCT 3: Gaming Laptop
            var product3 = new Product
            {
                Id = 3,
                CategoryId = laptops.Id,
                Category = laptops,
                DetailsId = laptopDetails.Id,
                Details = laptopDetails
            };
            product3.GetType().GetProperty("Name")?.SetValue(product3, "ASUS ROG Strix G16");
            product3.EditSalePrice(1599.99m);
            product3.AddStock(5);
            product3.EditStatus(true);
            products.Add(product3);

            // PRODUCT 4: Printer
            var product4 = new Product
            {
                Id = 4,
                CategoryId = printers.Id,
                Category = printers,
                DetailsId = printerDetails.Id,
                Details = printerDetails
            };
            product4.GetType().GetProperty("Name")?.SetValue(product4, "HP LaserJet Pro MFP");
            product4.EditSalePrice(549.99m);
            product4.AddStock(12);
            product4.EditStatus(true);
            products.Add(product4);

            // PRODUCT 5: PC Repair Service
            var product5 = new Product
            {
                Id = 5,
                CategoryId = services.Id,
                Category = services,
                DetailsId = serviceDetails.Id,
                Details = serviceDetails
            };
            product5.GetType().GetProperty("Name")?.SetValue(product5, "Computer Repair Service");
            product5.EditSalePrice(49.99m);
            product5.EditStatus(true);
            products.Add(product5);

            // PRODUCT 6: Phone Screen Repair Service
            var product6 = new Product
            {
                Id = 6,
                CategoryId = services.Id,
                Category = services,
                DetailsId = serviceDetails.Id,
                Details = serviceDetails
            };
            product6.GetType().GetProperty("Name")?.SetValue(product6, "Phone Screen Repair");
            product6.EditSalePrice(89.99m);
            product6.EditStatus(true);
            products.Add(product6);

            // PRODUCT 7: iPhone
            var product7 = new Product
            {
                Id = 7,
                CategoryId = phones.Id,
                Category = phones,
                DetailsId = phoneDetails.Id,
                Details = phoneDetails
            };
            product7.GetType().GetProperty("Name")?.SetValue(product7, "iPhone 15 Pro Max 256GB");
            product7.EditSalePrice(1399.99m);
            product7.AddStock(7);
            product7.EditStatus(true);
            products.Add(product7);

            // PRODUCT 8: Security Camera
            var product8 = new Product
            {
                Id = 8,
                CategoryId = security.Id,
                Category = security,
                DetailsId = cameraDetails.Id,
                Details = cameraDetails
            };
            product8.GetType().GetProperty("Name")?.SetValue(product8, "TP-Link 4K Security Camera");
            product8.EditSalePrice(199.99m);
            product8.AddStock(25);
            product8.EditStatus(true);
            products.Add(product8);

            // PRODUCT 9: Security System Installation Service
            var product9 = new Product
            {
                Id = 9,
                CategoryId = services.Id,
                Category = services,
                DetailsId = serviceDetails.Id,
                Details = serviceDetails
            };
            product9.GetType().GetProperty("Name")?.SetValue(product9, "Security System Installation");
            product9.EditSalePrice(149.99m);
            product9.EditStatus(true);
            products.Add(product9);

            // PRODUCT 10: Gaming Mouse
            var product10 = new Product
            {
                Id = 10,
                CategoryId = accessories.Id,
                Category = accessories,
                DetailsId = mouseDetails.Id,
                Details = mouseDetails
            };
            product10.GetType().GetProperty("Name")?.SetValue(product10, "Logitech G Pro X Mouse");
            product10.EditSalePrice(129.99m);
            product10.AddStock(30);
            product10.EditStatus(true);
            products.Add(product10);

            // PRODUCT 11: Mechanical Keyboard
            var product11 = new Product
            {
                Id = 11,
                CategoryId = accessories.Id,
                Category = accessories,
                DetailsId = mouseDetails.Id,
                Details = mouseDetails
            };
            product11.GetType().GetProperty("Name")?.SetValue(product11, "Redragon RGB Mechanical Keyboard");
            product11.EditSalePrice(89.99m);
            product11.AddStock(18);
            product11.EditStatus(true);
            products.Add(product11);

            // PRODUCT 12: RAM Memory
            var product12 = new Product
            {
                Id = 12,
                CategoryId = components.Id,
                Category = components,
                DetailsId = cpuDetails.Id,
                Details = cpuDetails
            };
            product12.GetType().GetProperty("Name")?.SetValue(product12, "Corsair 32GB DDR5 RAM");
            product12.EditSalePrice(159.99m);
            product12.AddStock(22);
            product12.EditStatus(true);
            products.Add(product12);

            // PRODUCT 13: NVMe SSD
            var product13 = new Product
            {
                Id = 13,
                CategoryId = components.Id,
                Category = components,
                DetailsId = gpuDetails.Id,
                Details = gpuDetails
            };
            product13.GetType().GetProperty("Name")?.SetValue(product13, "Samsung 980 Pro 2TB SSD");
            product13.EditSalePrice(189.99m);
            product13.AddStock(14);
            product13.EditStatus(true);
            products.Add(product13);

            // PRODUCT 14: Power Supply
            var product14 = new Product
            {
                Id = 14,
                CategoryId = components.Id,
                Category = components,
                DetailsId = cpuDetails.Id,
                Details = cpuDetails
            };
            product14.GetType().GetProperty("Name")?.SetValue(product14, "850W 80 Plus Gold Power Supply");
            product14.EditSalePrice(129.99m);
            product14.AddStock(9);
            product14.EditStatus(true);
            products.Add(product14);

            // PRODUCT 15: Inactive Product (Discontinued)
            var product15 = new Product
            {
                Id = 15,
                CategoryId = components.Id,
                Category = components,
                DetailsId = gpuDetails.Id,
                Details = gpuDetails
            };
            product15.GetType().GetProperty("Name")?.SetValue(product15, "NVIDIA GTX 1660 (Discontinued)");
            product15.EditSalePrice(199.99m);
            product15.AddStock(3);
            product15.EditStatus(true);
            product15.EditStatus(false); // Deactivate
            product15.Details.PurchasePrice = 500m;
            products.Add(product15);

            // PRODUCT 16: Windows Installation Service
            var product16 = new Product
            {
                Id = 16,
                CategoryId = services.Id,
                Category = services,
                DetailsId = serviceDetails.Id,
                Details = serviceDetails
            };
            product16.GetType().GetProperty("Name")?.SetValue(product16, "Windows + Drivers Installation");
            product16.EditSalePrice(29.99m);
            product16.EditStatus(true);
            products.Add(product16);

            // PRODUCT 17: Gaming Monitor
            var product17 = new Product
            {
                Id = 17,
                CategoryId = accessories.Id,
                Category = accessories,
                DetailsId = mouseDetails.Id,
                Details = mouseDetails
            };
            product17.GetType().GetProperty("Name")?.SetValue(product17, "27\" 144Hz Gaming Monitor");
            product17.EditSalePrice(299.99m);
            product17.AddStock(11);
            product17.EditStatus(true);
            products.Add(product17);

            // PRODUCT 18: Samsung Tablet
            var product18 = new Product
            {
                Id = 18,
                CategoryId = phones.Id,
                Category = phones,
                DetailsId = phoneDetails.Id,
                Details = phoneDetails
            };
            product18.GetType().GetProperty("Name")?.SetValue(product18, "Samsung S9+ Tablet 256GB");
            product18.EditSalePrice(899.99m);
            product18.AddStock(6);
            product18.EditStatus(true);
            products.Add(product18);

            // PRODUCT 19: WiFi 6 Router
            var product19 = new Product
            {
                Id = 19,
                CategoryId = accessories.Id,
                Category = accessories,
                DetailsId = mouseDetails.Id,
                Details = mouseDetails
            };
            product19.GetType().GetProperty("Name")?.SetValue(product19, "ASUS AX86U WiFi 6 Router");
            product19.EditSalePrice(229.99m);
            product19.AddStock(13);
            product19.EditStatus(true);
            products.Add(product19);

            // PRODUCT 20: Out of Stock Product
            var product20 = new Product
            {
                Id = 20,
                CategoryId = components.Id,
                Category = components,
                DetailsId = gpuDetails.Id,
                Details = gpuDetails
            };
            product20.GetType().GetProperty("Name")?.SetValue(product20, "NVIDIA RTX 4090 (Temporarily Out of Stock)");
            product20.EditSalePrice(1699.99m);
            // Stock remains 0
            product20.EditStatus(true);
            products.Add(product20);

            // PRODUCT 21: Complete Maintenance Package
            var product21 = new Product
            {
                Id = 21,
                CategoryId = services.Id,
                Category = services,
                DetailsId = serviceDetails.Id,
                Details = serviceDetails
            };
            product21.GetType().GetProperty("Name")?.SetValue(product21, "Complete PC Maintenance Package");
            product21.EditSalePrice(99.99m);
            product21.EditStatus(true);
            products.Add(product21);

            // PRODUCT 22: Gaming Headset
            var product22 = new Product
            {
                Id = 22,
                CategoryId = accessories.Id,
                Category = accessories,
                DetailsId = mouseDetails.Id,
                Details = mouseDetails
            };
            product22.GetType().GetProperty("Name")?.SetValue(product22, "7.1 Surround Gaming Headset");
            product22.EditSalePrice(79.99m);
            product22.AddStock(20);
            product22.EditStatus(true);
            products.Add(product22);

            // PRODUCT 23: Motherboard
            var product23 = new Product
            {
                Id = 23,
                CategoryId = components.Id,
                Category = components,
                DetailsId = cpuDetails.Id,
                Details = cpuDetails
            };
            product23.GetType().GetProperty("Name")?.SetValue(product23, "ASUS Z790 Gaming Motherboard");
            product23.EditSalePrice(279.99m);
            product23.AddStock(7);
            product23.EditStatus(true);
            products.Add(product23);

            // PRODUCT 24: Data Backup Service
            var product24 = new Product
            {
                Id = 24,
                CategoryId = services.Id,
                Category = services,
                DetailsId = serviceDetails.Id,
                Details = serviceDetails
            };
            product24.GetType().GetProperty("Name")?.SetValue(product24, "Data Backup and Recovery Service");
            product24.EditSalePrice(69.99m);
            product24.EditStatus(true);
            products.Add(product24);

            // PRODUCT 25: Complete Security System Kit
            var product25 = new Product
            {
                Id = 25,
                CategoryId = security.Id,
                Category = security,
                DetailsId = cameraDetails.Id,
                Details = cameraDetails
            };
            product25.GetType().GetProperty("Name")?.SetValue(product25, "4 Camera + DVR Security Kit");
            product25.EditSalePrice(499.99m);
            product25.AddStock(4);
            product25.EditStatus(true);
            products.Add(product25);

            return products;
        }

        // Helper method simplified
        private static Product CreateMockProduct(
            int id,
            string name,
            decimal price,
            int stock,
            bool isActive,
            ProductCategory category,
            ProductDetails details)
        {
            var product = new Product
            {
                Id = id,
                CategoryId = category.Id,
                Category = category,
                DetailsId = details.Id,
                Details = details
            };

            product.GetType().GetProperty("Name")?.SetValue(product, name);
            product.EditSalePrice(price);

            if (stock > 0)
            {
                product.AddStock(stock);
            }

            product.EditStatus(isActive);

            return product;
        }

        // Methods to get specific lists
        public static List<Product> GetProductsForStockTest()
            => GetMockProducts().Where(p => GetStock(p) > 0).ToList();

        public static List<Product> GetServices()
            => GetMockProducts().Where(p => p.CategoryId == 4).ToList();

        public static List<Product> GetComponents()
            => GetMockProducts().Where(p => p.CategoryId == 1).ToList();

        public static List<Product> GetActiveProducts()
            => GetMockProducts().Where(p => GetIsActive(p)).ToList();

        public static List<Product> GetInactiveProducts()
            => GetMockProducts().Where(p => !GetIsActive(p)).ToList();

        public static List<Product> GetProductsWithPriceGreaterThan(decimal minPrice)
            => GetMockProducts().Where(p => GetSalePrice(p) > minPrice).ToList();

        public static List<Product> GetLowStockProducts(int limit = 5)
            => GetMockProducts().Where(p => GetStock(p) > 0 && GetStock(p) <= limit).ToList();

        // Helper methods to access private properties
        private static int GetStock(Product product)
            => (int)product.GetType().GetProperty("Stock")?.GetValue(product);

        private static bool GetIsActive(Product product)
            => (bool)product.GetType().GetProperty("IsActive")?.GetValue(product);

        private static decimal GetSalePrice(Product product)
            => (decimal)product.GetType().GetProperty("SalePrice")?.GetValue(product);
    }
}
