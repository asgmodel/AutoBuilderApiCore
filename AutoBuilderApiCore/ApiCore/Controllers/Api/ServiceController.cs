using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using ApiCore.Services.Services;
using Microsoft.AspNetCore.Mvc;
using ApiCore.DyModels.VM.Service;
using System.Linq.Expressions;
using ApiCore.DyModels.Dso.Requests;
using System;

namespace ApiCore.Controllers.Api
{
    //[ApiExplorerSettings(GroupName = "ApiCore")]
    [Route("api/ApiCore/Api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IUseServiceService _serviceService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public ServiceController(IUseServiceService serviceService, IMapper mapper, ILoggerFactory logger)
        {
            _serviceService = serviceService;
            _mapper = mapper;
            _logger = logger.CreateLogger(typeof(ServiceController).FullName);
        }

        // Get all Services.
        [HttpGet(Name = "GetServices")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ServiceOutputVM>>> GetAll()
        {
            var result = await _serviceService.GetAllAsync();
            var items = _mapper.Map<List<ServiceOutputVM>>(result);
            return Ok(items);
        }

        // Get a Service by ID.
        [HttpGet("{id}", Name = "GetService")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ServiceInfoVM>> GetById(string? id)
        {
            if (id == "")
                return BadRequest("Invalid Service ID.");
            var service = await _serviceService.GetByIdAsync(id);
            if (service == null)
                return NotFound();
            var item = _mapper.Map<ServiceInfoVM>(service);
            return Ok(item);
        }

        //// Find a Service by a specific predicate.
        //[HttpGet("find")]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<ServiceInfoVM>> Find([FromQuery] Expression<Func<ServiceOutputVM, bool>> predicate)
        //{
        //     return NotFound();
        //    //var service = await _serviceService.FindAsync(predicate);
        //   // if (service == null) return NotFound();
        //   // var item = _mapper.Map<ServiceInfoVM>(service);
        //   // return Ok(item);
        //}
        // Create a new Service.
        [HttpPost(Name = "CreateService")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ServiceCreateVM>> Create([FromBody] ServiceCreateVM model)
        {
            if (model == null)
                return BadRequest("Service data is required.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = _mapper.Map<ServiceRequestDso>(model);
            var createdService = await _serviceService.CreateAsync(item);
            var createdItem = _mapper.Map<ServiceCreateVM>(createdService);
            return CreatedAtAction(nameof(GetById), new { id = 0 }, createdItem);
        }

        // Create multiple Services.
        [HttpPost("createRange")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ServiceCreateVM>>> CreateRange([FromBody] IEnumerable<ServiceCreateVM> models)
        {
            if (models == null)
                return BadRequest("Data is required.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var items = _mapper.Map<List<ServiceRequestDso>>(models);
            var createdServices = await _serviceService.CreateRangeAsync(items);
            var createdItems = _mapper.Map<List<ServiceCreateVM>>(createdServices);
            return CreatedAtAction(nameof(GetAll), createdItems);
        }

        // Update an existing Service.
        [HttpPut("{id}", Name = "UpdateService")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] ServiceUpdateVM model)
        {
            if (id <= 0 || model == null)
                return BadRequest("Invalid data.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = _mapper.Map<ServiceRequestDso>(model);
            var updatedService = await _serviceService.UpdateAsync(item);
            if (updatedService == null)
                return NotFound();
            var updatedItem = _mapper.Map<ServiceUpdateVM>(updatedService);
            return Ok(updatedItem);
        }

        // Delete a Service.
        [HttpDelete("{id}", Name = "DeleteService")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == "")
                return BadRequest("Invalid Service ID.");
            await _serviceService.DeleteAsync(id);
            return NoContent();
        }

        //// Delete multiple Services.
        //[HttpDelete("deleteRange")]
        //public async Task<IActionResult> DeleteRange([FromQuery] Expression<Func<ServiceOutputVM, bool>> predicate)
        //{
        //    //await _serviceService.DeleteRangeAsync(predicate);
        //    return NoContent();
        //}
        //// Check if a Service exists based on a predicate.
        //[HttpGet("exists")]
        //public async Task<ActionResult<bool>> Exists([FromQuery] Expression<Func<ServiceOutputVM, bool>> predicate)
        //{
        //    //var exists = await _serviceService.ExistsAsync(predicate);
        //    return Ok();
        //}
        // Get count of Services.
        [HttpGet("CountService")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> Count()
        {
            var count = await _serviceService.CountAsync();
            return Ok(count);
        }
    }
}