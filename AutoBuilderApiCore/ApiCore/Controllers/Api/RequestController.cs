using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using ApiCore.Services.Services;
using Microsoft.AspNetCore.Mvc;
using ApiCore.DyModels.VM.Request;
using System.Linq.Expressions;
using ApiCore.DyModels.Dso.Requests;
using System;

namespace ApiCore.Controllers.Api
{
    [Route("api/Api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IUseRequestService _requestService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public RequestController(IUseRequestService requestService, IMapper mapper, ILoggerFactory logger)
        {
            _requestService = requestService;
            _mapper = mapper;
            _logger = logger.CreateLogger(typeof(RequestController).FullName);
        }

        // Get all Requests.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RequestOutputVM>>> GetAll()
        {
            var result = await _requestService.GetAllAsync();
            var items = _mapper.Map<List<RequestOutputVM>>(result);
            return Ok(items);
        }

        // Get a Request by ID.
        [HttpGet("{id}")]
        public async Task<ActionResult<RequestInfoVM>> GetById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Request ID.");
            var request = await _requestService.GetByIdAsync(id);
            if (request == null)
                return NotFound();
            var item = _mapper.Map<RequestInfoVM>(request);
            return Ok(item);
        }

        //// Find a Request by a specific predicate.
        //[HttpGet("find")]
        //public async Task<ActionResult<RequestInfoVM>> Find([FromQuery] Expression<Func<RequestOutputVM, bool>> predicate)
        //{
        //     return NotFound();
        //    //var request = await _requestService.FindAsync(predicate);
        //   // if (request == null) return NotFound();
        //   // var item = _mapper.Map<RequestInfoVM>(request);
        //   // return Ok(item);
        //}
        // Create a new Request.
        [HttpPost]
        public async Task<ActionResult<RequestCreateVM>> Create([FromBody] RequestCreateVM model)
        {
            if (model == null)
                return BadRequest("Request data is required.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = _mapper.Map<RequestRequestDso>(model);
            var createdRequest = await _requestService.CreateAsync(item);
            var createdItem = _mapper.Map<RequestCreateVM>(createdRequest);
            return CreatedAtAction(nameof(GetById), new { id = 0 }, createdItem);
        }

        // Create multiple Requests.
        [HttpPost("createRange")]
        public async Task<ActionResult<IEnumerable<RequestCreateVM>>> CreateRange([FromBody] IEnumerable<RequestCreateVM> models)
        {
            if (models == null)
                return BadRequest("Data is required.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var items = _mapper.Map<List<RequestRequestDso>>(models);
            var createdRequests = await _requestService.CreateRangeAsync(items);
            var createdItems = _mapper.Map<List<RequestCreateVM>>(createdRequests);
            return CreatedAtAction(nameof(GetAll), createdItems);
        }

        // Update an existing Request.
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RequestUpdateVM model)
        {
            if (id <= 0 || model == null)
                return BadRequest("Invalid data.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = _mapper.Map<RequestRequestDso>(model);
            var updatedRequest = await _requestService.UpdateAsync(item);
            if (updatedRequest == null)
                return NotFound();
            var updatedItem = _mapper.Map<RequestUpdateVM>(updatedRequest);
            return Ok(updatedItem);
        }

        // Delete a Request.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Request ID.");
            await _requestService.DeleteAsync(id);
            return NoContent();
        }

        //// Delete multiple Requests.
        //[HttpDelete("deleteRange")]
        //public async Task<IActionResult> DeleteRange([FromQuery] Expression<Func<RequestOutputVM, bool>> predicate)
        //{
        //    //await _requestService.DeleteRangeAsync(predicate);
        //    return NoContent();
        //}
        //// Check if a Request exists based on a predicate.
        //[HttpGet("exists")]
        //public async Task<ActionResult<bool>> Exists([FromQuery] Expression<Func<RequestOutputVM, bool>> predicate)
        //{
        //    //var exists = await _requestService.ExistsAsync(predicate);
        //    return Ok();
        //}
        // Get count of Requests.
        [HttpGet("count")]
        public async Task<ActionResult<int>> Count()
        {
            var count = await _requestService.CountAsync();
            return Ok(count);
        }
    }
}