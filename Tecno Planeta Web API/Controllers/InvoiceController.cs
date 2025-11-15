using BLL.DTO.Device;
using BLL.DTO.Invoice;
using BLL.DTO.User;
using BLL.Services.Interfaces;
using Entities.Elements.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Tecno_Planeta_Web_API.Controllers
{
    public class InvoiceController(IInvoiceService service) : AbstractBaseController<IInvoiceService>(service)
    {
        //--------------------------------- GET ------------------------------------------------------
        [HttpGet("{id:int}")]
        public async Task<ActionResult<InvoiceResponseDTO>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<ActionResult<InvoiceResponseDTO>> GetInvoice(
            [FromQuery] string? customerName,
            [FromQuery] int? invoiceNumber)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceResponseDTO>>> GetAll(
            [FromQuery] EInvoiceStatus? status,
            [FromQuery] EInvoiceOperation? operation,
            [FromQuery] DateTime? date)
        {
            throw new NotImplementedException();
        }

        [HttpGet("product/{id:int}")]
        public async Task<ActionResult<IEnumerable<InvoiceResponseDTO>>> GetAllByProductId(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("products")]
        public async Task<ActionResult<List<InvoiceResponseDTO>>> GetAllByContainsProducts(
            [FromQuery] IEnumerable<int?> productsIds)
        {
            throw new NotImplementedException();
        }

        [HttpGet("all/service")]
        public async Task<ActionResult<IEnumerable<InvoiceResponseDTO>>> GetAllByContains(
            [FromQuery] IEnumerable<int?> serviceIds)
        {
            throw new NotImplementedException();
        }

        [HttpGet("all/service-list")]
        public async Task<ActionResult<IEnumerable<InvoiceResponseDTO>>> GetAllByServices([FromQuery] IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        [HttpGet("product-quantity")]
        public async Task<ActionResult<InvoiceResponseDTO>> GetByProductQuantity(
            [FromQuery] int? min,
            [FromQuery] int? max)
        {
            throw new NotImplementedException();
        }

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PATCH ------------------------------------------------------

        [HttpPatch("{id:int}/status")]
        public Task<ActionResult<InvoiceResponseDTO>> UpdateStatus([FromQuery] EInvoiceStatus newStatus)
        {
            throw new NotImplementedException();
        }

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- DELETE ------------------------------------------------------

        [HttpDelete("{id:int}")]
        public Task<ActionResult<InvoiceResponseDTO>> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("number/{number:int}")]
        public Task<ActionResult<InvoiceResponseDTO>> DeleteByNumber(int number)
        {
            throw new NotImplementedException();
        }

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- POST ------------------------------------------------------

        [HttpPost]
        public Task<ActionResult<InvoiceResponseDTO>> Create([FromBody] InvoiceResponseDTO newDevice)
        {
            throw new NotImplementedException();
        }
        //----------------------------------------------------------------------------------------- <>
    }
}
