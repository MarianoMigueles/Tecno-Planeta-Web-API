using BLL.DTO.Device;
using BLL.DTO.Invoice;
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
            var invoice = await service.GetByIdAsync(id);
            return Ok(invoice);
        }

        [HttpGet("by-customer-name/{customerName}")]
        public async Task<ActionResult<InvoiceResponseDTO>> GetByCustomerName([FromQuery] string customerName)
        {
            var invoice = await service.GetByCustomerNameAsync(customerName);
            return Ok(invoice);
        }

        [HttpGet("by-number/{number}")]
        public async Task<ActionResult<InvoiceResponseDTO>> GetByNumber([FromQuery] int number)
        {
            var invoice = await service.GetByNumberAsync(number);
            return Ok(invoice);
        }

        [HttpGet("all/by-status/{status}")]
        public async Task<ActionResult<InvoiceResponseDTO>> GetAllByStatus([FromQuery] EInvoiceStatus status)
        {
            var invoice = await service.GetAllByStatusAsync(status);
            return Ok(invoice);
        }
        [HttpGet("all/by-operation/{operation}")]
        public async Task<ActionResult<InvoiceResponseDTO>> GetAllByOperation([FromQuery] EInvoiceOperation operation)
        {
            var invoice = await service.GetAllByOperationTypeAsync(operation);
            return Ok(invoice);
        }
        [HttpGet("all/by-issue-date/{date}")]
        public async Task<ActionResult<InvoiceResponseDTO>> GetAllByIssueDate([FromQuery] DateTime date)
        {
            var invoice = await service.GetAllByIssueDateAsync(date);
            return Ok(invoice);
        }

        [HttpGet("all/products")]
        public async Task<ActionResult<List<InvoiceResponseDTO>>> GetAllByContainsProducts(
            [FromQuery] List<int> productsIds)
        {
            var invoices = await service.GetContainsProductIdAsync(productsIds);
            return Ok(invoices);
        }

        [HttpGet("all/services")]
        public async Task<ActionResult<IEnumerable<InvoiceResponseDTO>>> GetAllByServices(
            [FromQuery] List<int> serviceIds)
        {
            var invoices = await service.GetContainsServiceIdAsync(serviceIds);
            return Ok(invoices);
        }

        [HttpGet("product-quantity")]
        public async Task<ActionResult<InvoiceResponseDTO>> GetAllByProductQuantity([FromQuery] int min, [FromQuery] int max)
        {
            var invoices = await service.GetAllByProductQuantityAsync(min, max);
            return Ok(invoices);
        }

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- PATCH ------------------------------------------------------

        [HttpPatch("{id:int}/status")]
        public async Task<ActionResult<InvoiceResponseDTO>> UpdateStatus(int id, [FromQuery] EInvoiceStatus newStatus)
        {
            var invoice = await service.UpdateStatusAsync(id, newStatus);
            return Ok(invoice);
        }

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- DELETE ------------------------------------------------------

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await service.DeleteAsync(id);
            return NoContent();
        }

        //----------------------------------------------------------------------------------------- <>

        //--------------------------------- POST ------------------------------------------------------

        [HttpPost]
        public async Task<ActionResult<InvoiceResponseDTO>> Create([FromBody] InvoiceResponseDTO newDevice)
        {
            var invoice =  await service.CreateAsync(newDevice);
            return Ok(invoice);
        }
        //----------------------------------------------------------------------------------------- <>
    }
}
