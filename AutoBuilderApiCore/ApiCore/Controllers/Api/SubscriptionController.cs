using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using ApiCore.Services.Services;
using Microsoft.AspNetCore.Mvc;
using ApiCore.DyModels.VM.Subscription;
using System.Linq.Expressions;
using ApiCore.DyModels.Dso.Requests;
using System;

namespace ApiCore.Controllers.Api
{
    [Route("api/Api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly IUseSubscriptionService _subscriptionService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public SubscriptionController(IUseSubscriptionService subscriptionService, IMapper mapper, ILoggerFactory logger)
        {
            _subscriptionService = subscriptionService;
            _mapper = mapper;
            _logger = logger.CreateLogger(typeof(SubscriptionController).FullName);
        }

        // Get all Subscriptions.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubscriptionOutputVM>>> GetAll()
        {
            var result = await _subscriptionService.GetAllAsync();
            var items = _mapper.Map<List<SubscriptionOutputVM>>(result);
            return Ok(items);
        }

        // Get a Subscription by ID.
        [HttpGet("{id}")]
        public async Task<ActionResult<SubscriptionInfoVM>> GetById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Subscription ID.");
            var subscription = await _subscriptionService.GetByIdAsync(id);
            if (subscription == null)
                return NotFound();
            var item = _mapper.Map<SubscriptionInfoVM>(subscription);
            return Ok(item);
        }

        //// Find a Subscription by a specific predicate.
        //[HttpGet("find")]
        //public async Task<ActionResult<SubscriptionInfoVM>> Find([FromQuery] Expression<Func<SubscriptionOutputVM, bool>> predicate)
        //{
        //     return NotFound();
        //    //var subscription = await _subscriptionService.FindAsync(predicate);
        //   // if (subscription == null) return NotFound();
        //   // var item = _mapper.Map<SubscriptionInfoVM>(subscription);
        //   // return Ok(item);
        //}
        // Create a new Subscription.
        [HttpPost]
        public async Task<ActionResult<SubscriptionCreateVM>> Create([FromBody] SubscriptionCreateVM model)
        {
            if (model == null)
                return BadRequest("Subscription data is required.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = _mapper.Map<SubscriptionRequestDso>(model);
            var createdSubscription = await _subscriptionService.CreateAsync(item);
            var createdItem = _mapper.Map<SubscriptionCreateVM>(createdSubscription);
            return CreatedAtAction(nameof(GetById), new { id = 0 }, createdItem);
        }

        // Create multiple Subscriptions.
        [HttpPost("createRange")]
        public async Task<ActionResult<IEnumerable<SubscriptionCreateVM>>> CreateRange([FromBody] IEnumerable<SubscriptionCreateVM> models)
        {
            if (models == null)
                return BadRequest("Data is required.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var items = _mapper.Map<List<SubscriptionRequestDso>>(models);
            var createdSubscriptions = await _subscriptionService.CreateRangeAsync(items);
            var createdItems = _mapper.Map<List<SubscriptionCreateVM>>(createdSubscriptions);
            return CreatedAtAction(nameof(GetAll), createdItems);
        }

        // Update an existing Subscription.
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SubscriptionUpdateVM model)
        {
            if (id <= 0 || model == null)
                return BadRequest("Invalid data.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = _mapper.Map<SubscriptionRequestDso>(model);
            var updatedSubscription = await _subscriptionService.UpdateAsync(item);
            if (updatedSubscription == null)
                return NotFound();
            var updatedItem = _mapper.Map<SubscriptionUpdateVM>(updatedSubscription);
            return Ok(updatedItem);
        }

        // Delete a Subscription.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Subscription ID.");
            await _subscriptionService.DeleteAsync(id);
            return NoContent();
        }

        //// Delete multiple Subscriptions.
        //[HttpDelete("deleteRange")]
        //public async Task<IActionResult> DeleteRange([FromQuery] Expression<Func<SubscriptionOutputVM, bool>> predicate)
        //{
        //    //await _subscriptionService.DeleteRangeAsync(predicate);
        //    return NoContent();
        //}
        //// Check if a Subscription exists based on a predicate.
        //[HttpGet("exists")]
        //public async Task<ActionResult<bool>> Exists([FromQuery] Expression<Func<SubscriptionOutputVM, bool>> predicate)
        //{
        //    //var exists = await _subscriptionService.ExistsAsync(predicate);
        //    return Ok();
        //}
        // Get count of Subscriptions.
        [HttpGet("count")]
        public async Task<ActionResult<int>> Count()
        {
            var count = await _subscriptionService.CountAsync();
            return Ok(count);
        }
    }
}