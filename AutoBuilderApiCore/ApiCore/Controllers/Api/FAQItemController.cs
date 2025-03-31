using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Services.Services;
using Microsoft.AspNetCore.Mvc;
using VM.FAQItem;
using System.Linq.Expressions;
using Dso.Requests;
using System;

namespace Controllers.Api
{
    [Route("api/Api/[controller]")]
    [ApiController]
    public class FAQItemController : ControllerBase
    {
        private readonly IUseFAQItemService _faqitemService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public FAQItemController(IUseFAQItemService faqitemService, IMapper mapper, ILoggerFactory logger)
        {
            _faqitemService = faqitemService;
            _mapper = mapper;
            _logger = logger.CreateLogger(typeof(FAQItemController).FullName);
        }

        // Get all FAQItems.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FAQItemOutputVM>>> GetAll()
        {
            var result = await _faqitemService.GetAllAsync();
            var items = _mapper.Map<List<FAQItemOutputVM>>(result);
            return Ok(items);
        }

        // Get a FAQItem by ID.
        [HttpGet("{id}")]
        public async Task<ActionResult<FAQItemInfoVM>> GetById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid FAQItem ID.");
            var faqitem = await _faqitemService.GetByIdAsync(id);
            if (faqitem == null)
                return NotFound();
            var item = _mapper.Map<FAQItemInfoVM>(faqitem);
            return Ok(item);
        }

        //// Find a FAQItem by a specific predicate.
        //[HttpGet("find")]
        //public async Task<ActionResult<FAQItemInfoVM>> Find([FromQuery] Expression<Func<FAQItemOutputVM, bool>> predicate)
        //{
        //     return NotFound();
        //    //var faqitem = await _faqitemService.FindAsync(predicate);
        //   // if (faqitem == null) return NotFound();
        //   // var item = _mapper.Map<FAQItemInfoVM>(faqitem);
        //   // return Ok(item);
        //}
        // Create a new FAQItem.
        [HttpPost]
        public async Task<ActionResult<FAQItemCreateVM>> Create([FromBody] FAQItemCreateVM model)
        {
            if (model == null)
                return BadRequest("FAQItem data is required.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = _mapper.Map<FAQItemRequestDso>(model);
            var createdFAQItem = await _faqitemService.CreateAsync(item);
            var createdItem = _mapper.Map<FAQItemCreateVM>(createdFAQItem);
            return CreatedAtAction(nameof(GetById), new { id = 0 }, createdItem);
        }

        // Create multiple FAQItems.
        [HttpPost("createRange")]
        public async Task<ActionResult<IEnumerable<FAQItemCreateVM>>> CreateRange([FromBody] IEnumerable<FAQItemCreateVM> models)
        {
            if (models == null)
                return BadRequest("Data is required.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var items = _mapper.Map<List<FAQItemRequestDso>>(models);
            var createdFAQItems = await _faqitemService.CreateRangeAsync(items);
            var createdItems = _mapper.Map<List<FAQItemCreateVM>>(createdFAQItems);
            return CreatedAtAction(nameof(GetAll), createdItems);
        }

        // Update an existing FAQItem.
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] FAQItemUpdateVM model)
        {
            if (id <= 0 || model == null)
                return BadRequest("Invalid data.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = _mapper.Map<FAQItemRequestDso>(model);
            var updatedFAQItem = await _faqitemService.UpdateAsync(item);
            if (updatedFAQItem == null)
                return NotFound();
            var updatedItem = _mapper.Map<FAQItemUpdateVM>(updatedFAQItem);
            return Ok(updatedItem);
        }

        // Delete a FAQItem.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid FAQItem ID.");
            await _faqitemService.DeleteAsync(id);
            return NoContent();
        }

        //// Delete multiple FAQItems.
        //[HttpDelete("deleteRange")]
        //public async Task<IActionResult> DeleteRange([FromQuery] Expression<Func<FAQItemOutputVM, bool>> predicate)
        //{
        //    //await _faqitemService.DeleteRangeAsync(predicate);
        //    return NoContent();
        //}
        //// Check if a FAQItem exists based on a predicate.
        //[HttpGet("exists")]
        //public async Task<ActionResult<bool>> Exists([FromQuery] Expression<Func<FAQItemOutputVM, bool>> predicate)
        //{
        //    //var exists = await _faqitemService.ExistsAsync(predicate);
        //    return Ok();
        //}
        // Get count of FAQItems.
        [HttpGet("count")]
        public async Task<ActionResult<int>> Count()
        {
            var count = await _faqitemService.CountAsync();
            return Ok(count);
        }
    }
}