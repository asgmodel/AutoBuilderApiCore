using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Services.Services;
using Microsoft.AspNetCore.Mvc;
using VM.Invoice;
using System.Linq.Expressions;
using Dso.Requests;
using System;

namespace Controllers.Api
{
    [Route("api/Api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IUseInvoiceService _invoiceService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public InvoiceController(IUseInvoiceService invoiceService, IMapper mapper, ILoggerFactory logger)
        {
            _invoiceService = invoiceService;
            _mapper = mapper;
            _logger = logger.CreateLogger(typeof(InvoiceController).FullName);
        }

        // Get all Invoices.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceOutputVM>>> GetAll()
        {
            var result = await _invoiceService.GetAllAsync();
            var items = _mapper.Map<List<InvoiceOutputVM>>(result);
            return Ok(items);
        }

        // Get a Invoice by ID.
        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceInfoVM>> GetById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Invoice ID.");
            var invoice = await _invoiceService.GetByIdAsync(id);
            if (invoice == null)
                return NotFound();
            var item = _mapper.Map<InvoiceInfoVM>(invoice);
            return Ok(item);
        }

        //// Find a Invoice by a specific predicate.
        //[HttpGet("find")]
        //public async Task<ActionResult<InvoiceInfoVM>> Find([FromQuery] Expression<Func<InvoiceOutputVM, bool>> predicate)
        //{
        //     return NotFound();
        //    //var invoice = await _invoiceService.FindAsync(predicate);
        //   // if (invoice == null) return NotFound();
        //   // var item = _mapper.Map<InvoiceInfoVM>(invoice);
        //   // return Ok(item);
        //}
        // Create a new Invoice.
        [HttpPost]
        public async Task<ActionResult<InvoiceCreateVM>> Create([FromBody] InvoiceCreateVM model)
        {
            if (model == null)
                return BadRequest("Invoice data is required.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = _mapper.Map<InvoiceRequestDso>(model);
            var createdInvoice = await _invoiceService.CreateAsync(item);
            var createdItem = _mapper.Map<InvoiceCreateVM>(createdInvoice);
            return CreatedAtAction(nameof(GetById), new { id = 0 }, createdItem);
        }

        // Create multiple Invoices.
        [HttpPost("createRange")]
        public async Task<ActionResult<IEnumerable<InvoiceCreateVM>>> CreateRange([FromBody] IEnumerable<InvoiceCreateVM> models)
        {
            if (models == null)
                return BadRequest("Data is required.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var items = _mapper.Map<List<InvoiceRequestDso>>(models);
            var createdInvoices = await _invoiceService.CreateRangeAsync(items);
            var createdItems = _mapper.Map<List<InvoiceCreateVM>>(createdInvoices);
            return CreatedAtAction(nameof(GetAll), createdItems);
        }

        // Update an existing Invoice.
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] InvoiceUpdateVM model)
        {
            if (id <= 0 || model == null)
                return BadRequest("Invalid data.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = _mapper.Map<InvoiceRequestDso>(model);
            var updatedInvoice = await _invoiceService.UpdateAsync(item);
            if (updatedInvoice == null)
                return NotFound();
            var updatedItem = _mapper.Map<InvoiceUpdateVM>(updatedInvoice);
            return Ok(updatedItem);
        }

        // Delete a Invoice.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Invoice ID.");
            await _invoiceService.DeleteAsync(id);
            return NoContent();
        }

        //// Delete multiple Invoices.
        //[HttpDelete("deleteRange")]
        //public async Task<IActionResult> DeleteRange([FromQuery] Expression<Func<InvoiceOutputVM, bool>> predicate)
        //{
        //    //await _invoiceService.DeleteRangeAsync(predicate);
        //    return NoContent();
        //}
        //// Check if a Invoice exists based on a predicate.
        //[HttpGet("exists")]
        //public async Task<ActionResult<bool>> Exists([FromQuery] Expression<Func<InvoiceOutputVM, bool>> predicate)
        //{
        //    //var exists = await _invoiceService.ExistsAsync(predicate);
        //    return Ok();
        //}
        // Get count of Invoices.
        [HttpGet("count")]
        public async Task<ActionResult<int>> Count()
        {
            var count = await _invoiceService.CountAsync();
            return Ok(count);
        }
    }
}