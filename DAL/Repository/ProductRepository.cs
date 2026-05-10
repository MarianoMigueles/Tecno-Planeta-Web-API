using DAL.Data;
using DAL.Repository.Interfaces;
using Entities.Elements.ProductFolder;
using Entities.Users;
using Exeptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ProductRepository(DataContext context) : AbstractRepository<Product>(context), IProductRepository
    {

        //--------------------------------- GET ------------------------------------------------------
        public async override Task<Product> GetByIdAsync(int id)
        {
            var result = await _context.Set<Product>().Include(p => p.Category).Include(p => p.Details).FirstOrDefaultAsync(p => p.Id == id);
            return result ?? throw new EntityNotFoundException($"No entity of type {typeof(Product).Name} was found with ID {id}.");
        }
        public async Task<List<Product>> GetAllByActiveStatusAsync(bool status) => await this.GetListAsync(p => p.IsActive.Equals(status));
        public async Task<List<Product>> GetAllByCategoryAsync(string category) => await this.GetListAsync(p => p.Category.Description.Equals(category));
        public async Task<Product> GetByBarCodeAsync(string barCode) => await this.GetSingleAsync(p => p.Details.BarCode.Equals(barCode), p => p.Details);
        public async Task<Product> GetByNameAsync(string name) => await this.GetSingleAsync(p => p.Name.Equals(name));

        public async Task<List<Product>> GetAllByAmoutOfStockAsync(int amount, bool isGreaterThan = false) => await this.GetListAsync(p => isGreaterThan? p.Stock >= amount : p.Stock <= amount, p => p.Details);

        public async Task<List<Product>> GetAllByPurchasePriceAsync(decimal price, bool isGreaterThan = false)
        {
            return await this.GetListAsync(p => isGreaterThan 
                                                ? p.Details.PurchasePrice >= price 
                                                : p.Details.PurchasePrice <= price);
        }

        public async Task<List<Product>> GetAllByRangeOfPurchasePriceAsync(decimal min, decimal max)
        {
            return await this.GetListAsync(p => p.Details.PurchasePrice >= min && p.Details.PurchasePrice <= max);
        }


        //----------------------------------------------------------------------------------------- <>-

        //--------------------------------- PATCH ------------------------------------------------------
        public async Task<Product> AddStockAsync(int productId, int amount)
        {
            var product = await this.GetByIdAsync(productId);
            product.AddStock(amount);
            return product;
        } 

        public async Task<Product> SubstractStockAsync(int productId, int amount)
        {
            var product = await this.GetByIdAsync(productId);
            product.SubstractStock(amount);
            return product;
        }

        public async Task<Product> UpdateCategoryAsync(int productId, string newCategory)
        {
            var product = await this.GetByIdAsync(productId);
            product.Category.Description = newCategory;
            return product;
        }

        public async Task<Product> UpdateDescriptionAsync(int productId, string newDescription)
        {
            var product = await this.GetByIdAsync(productId);
            product.Details.Description = newDescription;
            return product;
        }

        public async Task<Product> UpdateNameAsync(int productId, string newName)
        {
            var product = await this.GetByIdAsync(productId);
            product.Name = newName;
            return product;
        }

        public async Task<Product> UpdateSalePriceAsync(int productId, decimal newSalePrice)
        {
            var product = await this.GetByIdAsync(productId);
            product.EditSalePrice(newSalePrice);
            return product;
        }

        public async Task<Product> UpdateStatusAsync(int productId, bool newStatus)
        {
            var product = await this.GetByIdAsync(productId);
            product.EditStatus(newStatus);
            return product;
        }

        //----------------------------------------------------------------------------------------- <>
    }
}
