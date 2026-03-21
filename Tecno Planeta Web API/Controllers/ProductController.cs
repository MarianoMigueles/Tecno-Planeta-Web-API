using BLL.DTO.Invoice;
using BLL.DTO.Product;
using BLL.Services.Interfaces;
using Entities.Elements.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Tecno_Planeta_Web_API.Controllers
{
    public class ProductController(IProductService service) : AbstractBaseController<IProductService>(service)
    {
        //--------------------------------- GET ------------------------------------------------------
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductResponseDTO>> GetById([FromQuery] int id)
        {
            var product = await service.GetByIdAsync(id);
            return Ok(product);
        }

        [HttpGet("by-name/{name}")]
        public async Task<ActionResult<ProductResponseDTO>> GetByName([FromQuery] string name)
        {
            var product = await service.GetByNameAsync(name);
            return Ok(product);
        }

        [HttpGet("by-bar-code/{barCode}")]
        public async Task<ActionResult<ProductResponseDTO>> GetByBarCode([FromQuery] string barCode)
        {
            var product = await service.GetByBarCodeAsync(barCode);
            return Ok(product);
        }

        [HttpGet("all/by-status/{activeStatus}")]
        public async Task<ActionResult<IEnumerable<ProductResponseDTO>>> GetAllByStatus([FromQuery] bool activeStatus)
        {
            var products = await service.GetAllByActiveStatusAsync(activeStatus);
            return Ok(products);
        }

        [HttpGet("all/by-category/{category}")]
        public async Task<ActionResult<IEnumerable<ProductResponseDTO>>> GetAllByCategory([FromQuery] string category)
        {
            var products = await service.GetAllByCategoryAsync(category);
            return Ok(products);
        }

        [HttpGet("range")]
        public async Task<ActionResult<IEnumerable<ProductResponseDTO>>> GetAllByRangeOfPurchasePrice(
            [FromQuery] int minPrice,
            [FromQuery] int maxPrice)
        {
            var products = await service.GetAllByRangeOfPurchasePriceAsync(minPrice, maxPrice);
            return Ok(products);
        }

        [HttpGet("stock")]
        public async Task<ActionResult<IEnumerable<ProductResponseDTO>>> GetAllByAmoutOfStock(
            [FromQuery] int amount,
            [FromQuery] bool isGreater = false)
        {
            var products = await service.GetAllByAmoutOfStockAsync(amount, isGreater);
            return Ok(products);
        }

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PATCH ------------------------------------------------------

        [HttpPatch("{id:int}/name")]
        public async Task<ActionResult<ProductResponseDTO>> UpdateName(int id, [FromQuery] string newName)
        {
            var product = await service.UpdateNameAsync(id, newName);
            return Ok(product);
        }
        [HttpPatch("{id:int}/price")]
        public async Task<ActionResult<ProductResponseDTO>> UpdatePrice(int id, [FromQuery] decimal newPrice)
        {
            var product = await service.UpdateSalePriceAsync(id, newPrice);
            return Ok(product);
        }
        [HttpPatch("{id:int}/category")]
        public async Task<ActionResult<ProductResponseDTO>> UpdateCategory(int id, [FromQuery] string category)
        {
            var product = await service.UpdateCategoryAsync(id, category);
            return Ok(product);
        }
        [HttpPatch("{id:int}/description")]
        public async Task<ActionResult<ProductResponseDTO>> UpdateDescription(int id, [FromQuery] string description)
        {
            var product = await service.UpdateDescriptionAsync(id, description);
            return Ok(product);
        }

        [HttpPatch("{id:int}/status-activate")]
        public async Task<ActionResult<ProductResponseDTO>> ActivateProduct(int id)
        {
            var product = await service.ActivateAsync(id);
            return Ok(product);
        }


        [HttpPatch("{id:int}/status-desactivate")]
        public async Task<ActionResult<ProductResponseDTO>> DesactivateProduct(int id)
        {
            var product = await service.DesactivateAsync(id);
            return Ok(product);
        }

        [HttpPatch("{id:int}/add")]
        public async Task<ActionResult<ProductResponseDTO>> AddStock(int id, [FromQuery] int amount)
        {
            var product = await service.AddStockAsync(id, amount);
            return Ok(product);
        }

        [HttpPatch("{id:int}/substrack")]
        public async Task<ActionResult<ProductResponseDTO>> SubstractStock(int id, [FromQuery] int amount)
        {
            var product = await service.SubstractStockAsync(id, amount);
            return Ok(product);
        }

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- DELETE ------------------------------------------------------

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ProductResponseDTO>> Delete(int id)
        {
            await service.DeleteAsync(id);
            return NoContent();
        }

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- POST ------------------------------------------------------

        [HttpPost]
        public async Task<ActionResult<ProductResponseDTO>> Create([FromBody] ProductCreateDTO newProduct)
        {
            var product = await service.CreateAsync(newProduct);
            return Ok(product);
        }
        //----------------------------------------------------------------------------------------- <>
    }
}
