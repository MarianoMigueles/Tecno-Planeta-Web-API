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
        public Task<Product> GetByName(string name);
        public Task<Product> GetByBarCode(string name);
        public Task<List<Product>> GetAllByRangeOfPurchasePrice(decimal startPrice, decimal endPrice);
        public Task<List<Product>> GetAllByGreaterPurchasePrice(decimal price);
        public Task<List<Product>> GetAllByLessPurchasePrice(decimal price);
        public Task<List<Product>> GetAllByActiveStatus(bool status);
        public Task<List<Product>> GetAllByCategory(string category);
        public Task<List<Product>> GetAllByAmoutOfStock(int phone, bool isGreater = false);
        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PUT ------------------------------------------------------
        public Task<Product> UpdateName(string newName);
        public Task<Product> UpdateSalePrice(string newName);
        public Task<Product> AddStock(string newName);
        public Task<Product> SubstractStock(string newName);
        public Task<Product> UpdateStatus(string newName);
        public Task<Product> UpdateCategory(string newName);
        public Task<Product> UpdateDescription(string newName);
        //----------------------------------------------------------------------------------------- <>
    }
}
