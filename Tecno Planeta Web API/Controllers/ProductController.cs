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
        [HttpGet]
        public async Task<ActionResult<ProductDTO>> GetProduct(
            [FromQuery] int? id,
            [FromQuery] string? name,
            [FromQuery] string? barCode)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAll(
            [FromQuery] bool? activeStatus,
            [FromQuery] string? category)
        {
            throw new NotImplementedException();
        }

        [HttpGet("range")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllByRangeOfPurchasePrice(
            [FromQuery] int minPrice,
            [FromQuery] int maxPrice)
        {
            throw new NotImplementedException();
        }

        [HttpGet("stock")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllByAmoutOfStock(
            [FromQuery] int amount,
            [FromQuery] bool isGreater = false)
        {
            throw new NotImplementedException();
        }

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PATCH ------------------------------------------------------

        [HttpPatch("{id:int}")]
        public Task<ActionResult<ProductDTO>> UpdateProduct(
            [FromQuery] string? newName,
            [FromQuery] string? newPrice,
            [FromQuery] string? category,
            [FromQuery] string? description)
        {
            throw new NotImplementedException();
        }

        [HttpPatch("{id:int}/status")]
        public Task<ActionResult<ProductDTO>> UpdateStatus([FromQuery] bool isActive)
        {
            throw new NotImplementedException();
        }

        [HttpPatch("{id:int}/add")]
        public Task<ActionResult<ProductDTO>> AddStock([FromQuery] int amount)
        {
            throw new NotImplementedException();
        }

        [HttpPatch("{id:int}/substrack")]
        public Task<ActionResult<ProductDTO>> SubstractStock([FromQuery] int amount)
        {
            throw new NotImplementedException();
        }

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- DELETE ------------------------------------------------------

        [HttpDelete("{id:int}")]
        public Task<ActionResult<ProductDTO>> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- POST ------------------------------------------------------

        [HttpPost]
        public Task<ActionResult<ProductDTO>> Create([FromBody] ProductDTO newDevice)
        {
            throw new NotImplementedException();
        }
        //----------------------------------------------------------------------------------------- <>
    }
}
