using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using ApiCore.Services.Services;
using Microsoft.AspNetCore.Mvc;
using ApiCore.DyModels.VM.EventRequest;
using System.Linq.Expressions;
using ApiCore.DyModels.Dso.Requests;
using System;

namespace ApiCore.Controllers.Api
{
    //[ApiExplorerSettings(GroupName = "ApiCore")]
    [Route("api/ApiCore/Api/[controller]")]
    [ApiController]
    public class EventRequestController : ControllerBase
    {
        private readonly IUseEventRequestService _eventrequestService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public EventRequestController(IUseEventRequestService eventrequestService, IMapper mapper, ILoggerFactory logger)
        {
            _eventrequestService = eventrequestService;
            _mapper = mapper;
            _logger = logger.CreateLogger(typeof(EventRequestController).FullName);
        }

        // Get all EventRequests.
        [HttpGet(Name = "GetEventRequests")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<EventRequestOutputVM>>> GetAll()
        {
            var result = await _eventrequestService.GetAllAsync();
            var items = _mapper.Map<List<EventRequestOutputVM>>(result);
            return Ok(items);
        }

        // Get a EventRequest by ID.
        [HttpGet("{id}", Name = "GetEventRequest")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EventRequestInfoVM>> GetById(string? id)
        {
            if (id == "")
                return BadRequest("Invalid EventRequest ID.");
            var eventrequest = await _eventrequestService.GetByIdAsync(id);
            if (eventrequest == null)
                return NotFound();
            var item = _mapper.Map<EventRequestInfoVM>(eventrequest);
            return Ok(item);
        }

        //// Find a EventRequest by a specific predicate.
        //[HttpGet("find")]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<EventRequestInfoVM>> Find([FromQuery] Expression<Func<EventRequestOutputVM, bool>> predicate)
        //{
        //     return NotFound();
        //    //var eventrequest = await _eventrequestService.FindAsync(predicate);
        //   // if (eventrequest == null) return NotFound();
        //   // var item = _mapper.Map<EventRequestInfoVM>(eventrequest);
        //   // return Ok(item);
        //}
        // Create a new EventRequest.
        [HttpPost(Name = "CreateEventRequest")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EventRequestCreateVM>> Create([FromBody] EventRequestCreateVM model)
        {
            if (model == null)
                return BadRequest("EventRequest data is required.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = _mapper.Map<EventRequestRequestDso>(model);
            var createdEventRequest = await _eventrequestService.CreateAsync(item);
            var createdItem = _mapper.Map<EventRequestCreateVM>(createdEventRequest);
            return CreatedAtAction(nameof(GetById), new { id = 0 }, createdItem);
        }

        // Create multiple EventRequests.
        [HttpPost("createRange")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<EventRequestCreateVM>>> CreateRange([FromBody] IEnumerable<EventRequestCreateVM> models)
        {
            if (models == null)
                return BadRequest("Data is required.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var items = _mapper.Map<List<EventRequestRequestDso>>(models);
            var createdEventRequests = await _eventrequestService.CreateRangeAsync(items);
            var createdItems = _mapper.Map<List<EventRequestCreateVM>>(createdEventRequests);
            return CreatedAtAction(nameof(GetAll), createdItems);
        }

        // Update an existing EventRequest.
        [HttpPut("{id}", Name = "UpdateEventRequest")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] EventRequestUpdateVM model)
        {
            if (id <= 0 || model == null)
                return BadRequest("Invalid data.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = _mapper.Map<EventRequestRequestDso>(model);
            var updatedEventRequest = await _eventrequestService.UpdateAsync(item);
            if (updatedEventRequest == null)
                return NotFound();
            var updatedItem = _mapper.Map<EventRequestUpdateVM>(updatedEventRequest);
            return Ok(updatedItem);
        }

        // Delete a EventRequest.
        [HttpDelete("{id}", Name = "DeleteEventRequest")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == "")
                return BadRequest("Invalid EventRequest ID.");
            await _eventrequestService.DeleteAsync(id);
            return NoContent();
        }

        //// Delete multiple EventRequests.
        //[HttpDelete("deleteRange")]
        //public async Task<IActionResult> DeleteRange([FromQuery] Expression<Func<EventRequestOutputVM, bool>> predicate)
        //{
        //    //await _eventrequestService.DeleteRangeAsync(predicate);
        //    return NoContent();
        //}
        //// Check if a EventRequest exists based on a predicate.
        //[HttpGet("exists")]
        //public async Task<ActionResult<bool>> Exists([FromQuery] Expression<Func<EventRequestOutputVM, bool>> predicate)
        //{
        //    //var exists = await _eventrequestService.ExistsAsync(predicate);
        //    return Ok();
        //}
        // Get count of EventRequests.
        [HttpGet("CountEventRequest")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> Count()
        {
            var count = await _eventrequestService.CountAsync();
            return Ok(count);
        }
    }
}