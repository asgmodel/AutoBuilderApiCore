using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using ApiCore.Services.Services;
using Microsoft.AspNetCore.Mvc;
using ApiCore.DyModels.VM.ServiceMethod;
using System.Linq.Expressions;
using ApiCore.DyModels.Dso.Requests;
using System;

namespace ApiCore.Controllers.Api
{
    //[ApiExplorerSettings(GroupName = "ApiCore")]
    [Route("api/ApiCore/Api/[controller]")]
    [ApiController]
    public class ServiceMethodController : ControllerBase
    {
        private readonly IUseServiceMethodService _servicemethodService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public ServiceMethodController(IUseServiceMethodService servicemethodService, IMapper mapper, ILoggerFactory logger)
        {
            _servicemethodService = servicemethodService;
            _mapper = mapper;
            _logger = logger.CreateLogger(typeof(ServiceMethodController).FullName);
        }

        // Get all ServiceMethods.
        [HttpGet(Name = "GetServiceMethods")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ServiceMethodOutputVM>>> GetAll()
        {
            var result = await _servicemethodService.GetAllAsync();
            var items = _mapper.Map<List<ServiceMethodOutputVM>>(result);
            return Ok(items);
        }

        // Get a ServiceMethod by ID.
        [HttpGet("{id}", Name = "GetServiceMethod")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ServiceMethodInfoVM>> GetById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid ServiceMethod ID.");
            var servicemethod = await _servicemethodService.GetByIdAsync(id);
            if (servicemethod == null)
                return NotFound();
            var item = _mapper.Map<ServiceMethodInfoVM>(servicemethod);
            return Ok(item);
        }

        //// Find a ServiceMethod by a specific predicate.
        //[HttpGet("find")]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<ServiceMethodInfoVM>> Find([FromQuery] Expression<Func<ServiceMethodOutputVM, bool>> predicate)
        //{
        //     return NotFound();
        //    //var servicemethod = await _servicemethodService.FindAsync(predicate);
        //   // if (servicemethod == null) return NotFound();
        //   // var item = _mapper.Map<ServiceMethodInfoVM>(servicemethod);
        //   // return Ok(item);
        //}
        // Create a new ServiceMethod.
        [HttpPost(Name = "CreateServiceMethod")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ServiceMethodCreateVM>> Create([FromBody] ServiceMethodCreateVM model)
        {
            if (model == null)
                return BadRequest("ServiceMethod data is required.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = _mapper.Map<ServiceMethodRequestDso>(model);
            var createdServiceMethod = await _servicemethodService.CreateAsync(item);
            var createdItem = _mapper.Map<ServiceMethodCreateVM>(createdServiceMethod);
            return CreatedAtAction(nameof(GetById), new { id = 0 }, createdItem);
        }

        // Create multiple ServiceMethods.
        [HttpPost("createRange")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ServiceMethodCreateVM>>> CreateRange([FromBody] IEnumerable<ServiceMethodCreateVM> models)
        {
            if (models == null)
                return BadRequest("Data is required.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var items = _mapper.Map<List<ServiceMethodRequestDso>>(models);
            var createdServiceMethods = await _servicemethodService.CreateRangeAsync(items);
            var createdItems = _mapper.Map<List<ServiceMethodCreateVM>>(createdServiceMethods);
            return CreatedAtAction(nameof(GetAll), createdItems);
        }

        // Update an existing ServiceMethod.
        [HttpPut("{id}", Name = "UpdateServiceMethod")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] ServiceMethodUpdateVM model)
        {
            if (id <= 0 || model == null)
                return BadRequest("Invalid data.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = _mapper.Map<ServiceMethodRequestDso>(model);
            var updatedServiceMethod = await _servicemethodService.UpdateAsync(item);
            if (updatedServiceMethod == null)
                return NotFound();
            var updatedItem = _mapper.Map<ServiceMethodUpdateVM>(updatedServiceMethod);
            return Ok(updatedItem);
        }

        // Delete a ServiceMethod.
        [HttpDelete("{id}", Name = "DeleteServiceMethod")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid ServiceMethod ID.");
            await _servicemethodService.DeleteAsync(id);
            return NoContent();
        }

        //// Delete multiple ServiceMethods.
        //[HttpDelete("deleteRange")]
        //public async Task<IActionResult> DeleteRange([FromQuery] Expression<Func<ServiceMethodOutputVM, bool>> predicate)
        //{
        //    //await _servicemethodService.DeleteRangeAsync(predicate);
        //    return NoContent();
        //}
        //// Check if a ServiceMethod exists based on a predicate.
        //[HttpGet("exists")]
        //public async Task<ActionResult<bool>> Exists([FromQuery] Expression<Func<ServiceMethodOutputVM, bool>> predicate)
        //{
        //    //var exists = await _servicemethodService.ExistsAsync(predicate);
        //    return Ok();
        //}
        // Get count of ServiceMethods.
        [HttpGet("CountServiceMethod")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> Count()
        {
            var count = await _servicemethodService.CountAsync();
            return Ok(count);
        }
    }
}