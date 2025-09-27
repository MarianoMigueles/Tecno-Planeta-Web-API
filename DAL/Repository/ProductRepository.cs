using DAL.Data;
using DAL.Repository.Interfaces;
using Entities.Elements.ProductFolder;
using Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ProductRepository(DataContext context) : Repository<Product>(context), IProductRepository
    {
        public Task<Product> AddStock(string newName)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetAllByActiveStatus(bool status)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetAllByAmoutOfStock(int phone, bool isGreater = false)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetAllByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetAllByGreaterPurchasePrice(decimal price)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetAllByLessPurchasePrice(decimal price)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetAllByRangeOfPurchasePrice(decimal startPrice, decimal endPrice)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByBarCode(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Product> SubstractStock(string newName)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateCategory(string newName)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateDescription(string newName)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateName(string newName)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateSalePrice(string newName)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateStatus(string newName)
        {
            throw new NotImplementedException();
        }
    }
}
