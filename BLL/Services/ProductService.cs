using AutoMapper;
using BLL.DTO.Product;
using BLL.Services.Interfaces;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProductService(IUnitOfWork unitOfWork, IMapper mapper) : AbstractService(unitOfWork, mapper), IProductService
    {
        public Task<ProductDTO> AddStock(string newName)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDTO>> GetAllByActiveStatus(bool status)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDTO>> GetAllByAmoutOfStock(int phone, bool isGreater = false)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDTO>> GetAllByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDTO>> GetAllByGreaterPurchasePrice(decimal price)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDTO>> GetAllByLessPurchasePrice(decimal price)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDTO>> GetAllByRangeOfPurchasePrice(decimal startPrice, decimal endPrice)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDTO> GetByBarCode(string name)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDTO> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDTO> SubstractStock(string newName)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDTO> UpdateCategory(string newName)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDTO> UpdateDescription(string newName)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDTO> UpdateName(string newName)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDTO> UpdateSalePrice(string newName)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDTO> UpdateStatus(string newName)
        {
            throw new NotImplementedException();
        }
    }
}
