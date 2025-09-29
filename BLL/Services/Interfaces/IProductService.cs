using BLL.DTO.Product;
using Entities.Elements.ProductFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IProductService
    {
        //--------------------------------- GET ------------------------------------------------------
        public Task<ProductDTO> GetByName(string name);
        public Task<ProductDTO> GetByBarCode(string name);
        public Task<List<ProductDTO>> GetAllByRangeOfPurchasePrice(decimal startPrice, decimal endPrice);
        public Task<List<ProductDTO>> GetAllByGreaterPurchasePrice(decimal price);
        public Task<List<ProductDTO>> GetAllByLessPurchasePrice(decimal price);
        public Task<List<ProductDTO>> GetAllByActiveStatus(bool status);
        public Task<List<ProductDTO>> GetAllByCategory(string category);
        public Task<List<ProductDTO>> GetAllByAmoutOfStock(int phone, bool isGreater = false);
        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PUT ------------------------------------------------------
        public Task<ProductDTO> UpdateName(string newName);
        public Task<ProductDTO> UpdateSalePrice(string newName);
        public Task<ProductDTO> AddStock(string newName);
        public Task<ProductDTO> SubstractStock(string newName);
        public Task<ProductDTO> UpdateStatus(string newName);
        public Task<ProductDTO> UpdateCategory(string newName);
        public Task<ProductDTO> UpdateDescription(string newName);
        //----------------------------------------------------------------------------------------- <>
    }
}
