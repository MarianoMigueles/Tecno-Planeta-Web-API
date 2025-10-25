using Entities.Elements.ProductFolder;
using Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Interfaces
{
    public interface IProductRepository
    {
        //--------------------------------- GET ------------------------------------------------------
        public Task<List<Product>> GetAllByActiveStatusAsync(bool status);
        public Task<List<Product>> GetAllByAmoutOfStockAsync(int amount, bool isGreater = false);
        public Task<List<Product>> GetAllByCategoryAsync(string category);
        public Task<List<Product>> GetAllByPurchasePriceAsync(decimal price, bool isGreater = false);
        public Task<List<Product>> GetAllByRangeOfPurchasePriceAsync(decimal min, decimal max);
        public Task<Product> GetByBarCodeAsync(string barCode);
        public Task<Product> GetByNameAsync(string name);
        //----------------------------------------------------------------------------------------- <>-

        //--------------------------------- PATCH ------------------------------------------------------
        public Task<Product> AddStockAsync(int productId, int amount);
        public Task<Product> SubstractStockAsync(int productId, int amount);
        public Task<Product> UpdateCategoryAsync(int productId, string newCategory);
        public Task<Product> UpdateDescription(int productId, string newDescription);
        public Task<Product> UpdateNameAsync(int productId, string newName);
        public Task<Product> UpdateSalePriceAsync(int productId, decimal newSalePrice);
        public Task<Product> UpdateStatusAsync(int productId, bool newStatus);
        //----------------------------------------------------------------------------------------- <>
    }
}
