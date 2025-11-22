using AutoMapper;
using BLL.DTO.Invoice;
using BLL.DTO;
using BLL.DTO.Product;
using BLL.Services.Interfaces;
using DAL.Repository.Interfaces;
using DAL.UnitOfWork;
using Entities.Elements.Enums;
using Entities.Elements.ProductFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProductService(IUnitOfWork unitOfWork, IMapper mapper) : AbstractService<ProductResponseDTO, Product, IProductRepository>(unitOfWork, mapper), IProductService
    {
        protected override IProductRepository Repository => _unitOfWork.ProductRepository;

        //--------------------------------- GET ------------------------------------------------------
        public async Task<List<ProductResponseDTO>> GetAllByActiveStatusAsync(bool status)
        {
            var products = await Repository.GetAllByActiveStatusAsync(status);
            return _mapper.Map<List<ProductResponseDTO>>(products);
        }

        public async Task<List<ProductResponseDTO>> GetAllByAmoutOfStockAsync(int amount, bool isGreater = false)
        {
            var products = await Repository.GetAllByAmoutOfStockAsync(amount, isGreater);
            return _mapper.Map<List<ProductResponseDTO>>(products);
        }

        public async Task<List<ProductResponseDTO>> GetAllByCategoryAsync(string category)
        {
            var products = await Repository.GetAllByCategoryAsync(category);
            return _mapper.Map<List<ProductResponseDTO>>(products);
        }

        public async Task<List<ProductResponseDTO>> GetAllByPurchasePriceAsync(decimal price, bool isGreater = false)
        {
            var products = await Repository.GetAllByPurchasePriceAsync(price);
            return _mapper.Map<List<ProductResponseDTO>>(products);
        }

        public async Task<List<ProductResponseDTO>> GetAllByRangeOfPurchasePriceAsync(decimal min, decimal max)
        {
            var products = await Repository.GetAllByRangeOfPurchasePriceAsync(min, max);
            return _mapper.Map<List<ProductResponseDTO>>(products);
        }

        public async Task<ProductResponseDTO> GetByBarCodeAsync(string name)
        {
            var product = await Repository.GetByBarCodeAsync(name);
            return _mapper.Map<ProductResponseDTO>(product);
        }

        public async Task<ProductResponseDTO> GetByNameAsync(string name)
        {
            var product = await Repository.GetByNameAsync(name);
            return _mapper.Map<ProductResponseDTO>(product);
        }
        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PATCH ------------------------------------------------------

        public async Task<ProductResponseDTO> ActivateAsync(int id)
        {
            var product = await Repository.UpdateStatusAsync(id, true);
            return _mapper.Map<ProductResponseDTO>(product);
        }
        public async Task<ProductResponseDTO> DesactivateAsync(int id)
        {
            var product = await Repository.UpdateStatusAsync(id, false);
            return _mapper.Map<ProductResponseDTO>(product);
        }

        public async Task<ProductResponseDTO> AddStockAsync(int id, int amount)
        {
            var product = await Repository.AddStockAsync(id, amount);
            return _mapper.Map<ProductResponseDTO>(product);
        }

        public async Task<ProductResponseDTO> SubstractStockAsync(int id, int amount)
        {
            var product = await Repository.SubstractStockAsync(id, amount);
            return _mapper.Map<ProductResponseDTO>(product);
        }

        public async Task<ProductResponseDTO> UpdateCategoryAsync(int id, string newCategory)
        {
            var product = await Repository.UpdateCategoryAsync(id, newCategory);
            return _mapper.Map<ProductResponseDTO>(product);
        }

        public async Task<ProductResponseDTO> UpdateDescriptionAsync(int id, string newDescriptio)
        {
            var product = await Repository.UpdateDescriptionAsync(id, newDescriptio);
            return _mapper.Map<ProductResponseDTO>(product);
        }

        public async Task<ProductResponseDTO> UpdateNameAsync(int id, string newName)
        {
            var product = await Repository.UpdateNameAsync(id, newName);
            return _mapper.Map<ProductResponseDTO>(product);
        }

        public async Task<ProductResponseDTO> UpdateSalePriceAsync(int id, decimal newPrice)
        {
            var product = await Repository.UpdateSalePriceAsync(id, newPrice);
            return _mapper.Map<ProductResponseDTO>(product);
        }

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- POST ------------------------------------------------------

        public override async Task<ProductResponseDTO> CreateAsync(IBaseDTO createDto) => await CommonCreateAsync(createDto);

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- DELETE ------------------------------------------------------

        public override async Task<bool> DeleteAsync(int id) => await CommonDeleteAsync(id);

        //----------------------------------------------------------------------------------------- <>
    }
}
