using BLL.DTO.Product;
using Entities.Elements.ProductFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IProductService : IService
    {
        //--------------------------------- GET ------------------------------------------------------
        public Task<ProductResponseDTO> GetByNameAsync(string name);
        public Task<ProductResponseDTO> GetByBarCodeAsync(string name);
        public Task<List<ProductResponseDTO>> GetAllByRangeOfPurchasePriceAsync(decimal min, decimal max);
        public Task<List<ProductResponseDTO>> GetAllByPurchasePriceAsync(decimal price, bool isGreater = false);
        public Task<List<ProductResponseDTO>> GetAllByActiveStatusAsync(bool status);
        public Task<List<ProductResponseDTO>> GetAllByCategoryAsync(string category);
        public Task<List<ProductResponseDTO>> GetAllByAmoutOfStockAsync(int amount, bool isGreater = false);
        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PATCH ------------------------------------------------------
        public Task<ProductResponseDTO> UpdateNameAsync(int id, string newName);
        public Task<ProductResponseDTO> UpdateSalePriceAsync(int id, decimal newPrice);
        public Task<ProductResponseDTO> AddStockAsync(int id, int amount);
        public Task<ProductResponseDTO> SubstractStockAsync(int id, int amount);
        public Task<ProductResponseDTO> ActivateAsync(int id);
        public Task<ProductResponseDTO> DeactivateAsync(int id);
        public Task<ProductResponseDTO> UpdateCategoryAsync(int id, string newCategory);
        public Task<ProductResponseDTO> UpdateDescriptionAsync(int id, string newDescription);
        //----------------------------------------------------------------------------------------- <>
    }
}
