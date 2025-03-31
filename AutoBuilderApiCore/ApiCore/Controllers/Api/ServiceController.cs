using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Services.Services;
using Microsoft.AspNetCore.Mvc;
using VM.Service;
using System.Linq.Expressions;
using Dso.Requests;
using System;

namespace Controllers.Api
{
    [Route("api/Api/[controller]")]
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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceOutputVM>>> GetAll()
        {
            var result = await _serviceService.GetAllAsync();
            var items = _mapper.Map<List<ServiceOutputVM>>(result);
            return Ok(items);
        }

        // Get a Service by ID.
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceInfoVM>> GetById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Service ID.");
            var service = await _serviceService.GetByIdAsync(id);
            if (service == null)
                return NotFound();
            var item = _mapper.Map<ServiceInfoVM>(service);
            return Ok(item);
        }

        //// Find a Service by a specific predicate.
        //[HttpGet("find")]
        //public async Task<ActionResult<ServiceInfoVM>> Find([FromQuery] Expression<Func<ServiceOutputVM, bool>> predicate)
        //{
        //     return NotFound();
        //    //var service = await _serviceService.FindAsync(predicate);
        //   // if (service == null) return NotFound();
        //   // var item = _mapper.Map<ServiceInfoVM>(service);
        //   // return Ok(item);
        //}
        // Create a new Service.
        [HttpPost]
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
        [HttpPut("{id}")]
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
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
        [HttpGet("count")]
        public async Task<ActionResult<int>> Count()
        {
            var count = await _serviceService.CountAsync();
            return Ok(count);
        }
    }
}