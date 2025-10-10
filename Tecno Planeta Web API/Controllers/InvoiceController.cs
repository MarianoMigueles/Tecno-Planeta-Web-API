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
        public async Task<ActionResult<InvoiceDTO>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<ActionResult<InvoiceDTO>> GetInvoice(
            [FromQuery] string? customerName,
            [FromQuery] int? invoiceNumber)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceDTO>>> GetAll(
            [FromQuery] EInvoiceStatus? status,
            [FromQuery] EInvoiceOperation? operation,
            [FromQuery] DateTime? date)
        {
            throw new NotImplementedException();
        }

        [HttpGet("product/{id:int}")]
        public async Task<ActionResult<IEnumerable<InvoiceDTO>>> GetAllByProductId(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("products")]
        public async Task<ActionResult<List<InvoiceDTO>>> GetAllByContainsProducts(
            [FromQuery] IEnumerable<int?> productsIds)
        {
            throw new NotImplementedException();
        }

        [HttpGet("all/service")]
        public async Task<ActionResult<IEnumerable<InvoiceDTO>>> GetAllByContains(
            [FromQuery] IEnumerable<int?> serviceIds)
        {
            throw new NotImplementedException();
        }

        [HttpGet("all/service-list")]
        public async Task<ActionResult<IEnumerable<InvoiceDTO>>> GetAllByServices([FromQuery] IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        [HttpGet("product-quantity")]
        public async Task<ActionResult<InvoiceDTO>> GetByProductQuantity(
            [FromQuery] int? min,
            [FromQuery] int? max)
        {
            throw new NotImplementedException();
        }

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PATCH ------------------------------------------------------

        [HttpPatch("{id:int}/status")]
        public Task<ActionResult<InvoiceDTO>> UpdateStatus([FromQuery] EInvoiceStatus newStatus)
        {
            throw new NotImplementedException();
        }

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- DELETE ------------------------------------------------------

        [HttpDelete("{id:int}")]
        public Task<ActionResult<InvoiceDTO>> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("number/{number:int}")]
        public Task<ActionResult<InvoiceDTO>> DeleteByNumber(int number)
        {
            throw new NotImplementedException();
        }

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- POST ------------------------------------------------------

        [HttpPost]
        public Task<ActionResult<InvoiceDTO>> Create([FromBody] InvoiceDTO newDevice)
        {
            throw new NotImplementedException();
        }
        //----------------------------------------------------------------------------------------- <>
    }
}
