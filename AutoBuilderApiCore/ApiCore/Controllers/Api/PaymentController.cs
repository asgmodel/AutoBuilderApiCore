using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using ApiCore.Services.Services;
using Microsoft.AspNetCore.Mvc;
using ApiCore.DyModels.VM.Payment;
using System.Linq.Expressions;
using ApiCore.DyModels.Dso.Requests;
using System;

namespace ApiCore.Controllers.Api
{
    [Route("api/Api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IUsePaymentService _paymentService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public PaymentController(IUsePaymentService paymentService, IMapper mapper, ILoggerFactory logger)
        {
            _paymentService = paymentService;
            _mapper = mapper;
            _logger = logger.CreateLogger(typeof(PaymentController).FullName);
        }

        // Get all Payments.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentOutputVM>>> GetAll()
        {
            var result = await _paymentService.GetAllAsync();
            var items = _mapper.Map<List<PaymentOutputVM>>(result);
            return Ok(items);
        }

        // Get a Payment by ID.
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentInfoVM>> GetById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Payment ID.");
            var payment = await _paymentService.GetByIdAsync(id);
            if (payment == null)
                return NotFound();
            var item = _mapper.Map<PaymentInfoVM>(payment);
            return Ok(item);
        }

        //// Find a Payment by a specific predicate.
        //[HttpGet("find")]
        //public async Task<ActionResult<PaymentInfoVM>> Find([FromQuery] Expression<Func<PaymentOutputVM, bool>> predicate)
        //{
        //     return NotFound();
        //    //var payment = await _paymentService.FindAsync(predicate);
        //   // if (payment == null) return NotFound();
        //   // var item = _mapper.Map<PaymentInfoVM>(payment);
        //   // return Ok(item);
        //}
        // Create a new Payment.
        [HttpPost]
        public async Task<ActionResult<PaymentCreateVM>> Create([FromBody] PaymentCreateVM model)
        {
            if (model == null)
                return BadRequest("Payment data is required.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = _mapper.Map<PaymentRequestDso>(model);
            var createdPayment = await _paymentService.CreateAsync(item);
            var createdItem = _mapper.Map<PaymentCreateVM>(createdPayment);
            return CreatedAtAction(nameof(GetById), new { id = 0 }, createdItem);
        }

        // Create multiple Payments.
        [HttpPost("createRange")]
        public async Task<ActionResult<IEnumerable<PaymentCreateVM>>> CreateRange([FromBody] IEnumerable<PaymentCreateVM> models)
        {
            if (models == null)
                return BadRequest("Data is required.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var items = _mapper.Map<List<PaymentRequestDso>>(models);
            var createdPayments = await _paymentService.CreateRangeAsync(items);
            var createdItems = _mapper.Map<List<PaymentCreateVM>>(createdPayments);
            return CreatedAtAction(nameof(GetAll), createdItems);
        }

        // Update an existing Payment.
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PaymentUpdateVM model)
        {
            if (id <= 0 || model == null)
                return BadRequest("Invalid data.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = _mapper.Map<PaymentRequestDso>(model);
            var updatedPayment = await _paymentService.UpdateAsync(item);
            if (updatedPayment == null)
                return NotFound();
            var updatedItem = _mapper.Map<PaymentUpdateVM>(updatedPayment);
            return Ok(updatedItem);
        }

        // Delete a Payment.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Payment ID.");
            await _paymentService.DeleteAsync(id);
            return NoContent();
        }

        //// Delete multiple Payments.
        //[HttpDelete("deleteRange")]
        //public async Task<IActionResult> DeleteRange([FromQuery] Expression<Func<PaymentOutputVM, bool>> predicate)
        //{
        //    //await _paymentService.DeleteRangeAsync(predicate);
        //    return NoContent();
        //}
        //// Check if a Payment exists based on a predicate.
        //[HttpGet("exists")]
        //public async Task<ActionResult<bool>> Exists([FromQuery] Expression<Func<PaymentOutputVM, bool>> predicate)
        //{
        //    //var exists = await _paymentService.ExistsAsync(predicate);
        //    return Ok();
        //}
        // Get count of Payments.
        [HttpGet("count")]
        public async Task<ActionResult<int>> Count()
        {
            var count = await _paymentService.CountAsync();
            return Ok(count);
        }
    }
}