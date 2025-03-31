using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Services.Services;
using Microsoft.AspNetCore.Mvc;
using VM.ModelGateway;
using System.Linq.Expressions;
using Dso.Requests;
using System;

namespace Controllers.Api
{
    [Route("api/Api/[controller]")]
    [ApiController]
    public class ModelGatewayController : ControllerBase
    {
        private readonly IUseModelGatewayService _modelgatewayService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public ModelGatewayController(IUseModelGatewayService modelgatewayService, IMapper mapper, ILoggerFactory logger)
        {
            _modelgatewayService = modelgatewayService;
            _mapper = mapper;
            _logger = logger.CreateLogger(typeof(ModelGatewayController).FullName);
        }

        // Get all ModelGateways.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModelGatewayOutputVM>>> GetAll()
        {
            var result = await _modelgatewayService.GetAllAsync();
            var items = _mapper.Map<List<ModelGatewayOutputVM>>(result);
            return Ok(items);
        }

        // Get a ModelGateway by ID.
        [HttpGet("{id}")]
        public async Task<ActionResult<ModelGatewayInfoVM>> GetById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid ModelGateway ID.");
            var modelgateway = await _modelgatewayService.GetByIdAsync(id);
            if (modelgateway == null)
                return NotFound();
            var item = _mapper.Map<ModelGatewayInfoVM>(modelgateway);
            return Ok(item);
        }

        //// Find a ModelGateway by a specific predicate.
        //[HttpGet("find")]
        //public async Task<ActionResult<ModelGatewayInfoVM>> Find([FromQuery] Expression<Func<ModelGatewayOutputVM, bool>> predicate)
        //{
        //     return NotFound();
        //    //var modelgateway = await _modelgatewayService.FindAsync(predicate);
        //   // if (modelgateway == null) return NotFound();
        //   // var item = _mapper.Map<ModelGatewayInfoVM>(modelgateway);
        //   // return Ok(item);
        //}
        // Create a new ModelGateway.
        [HttpPost]
        public async Task<ActionResult<ModelGatewayCreateVM>> Create([FromBody] ModelGatewayCreateVM model)
        {
            if (model == null)
                return BadRequest("ModelGateway data is required.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = _mapper.Map<ModelGatewayRequestDso>(model);
            var createdModelGateway = await _modelgatewayService.CreateAsync(item);
            var createdItem = _mapper.Map<ModelGatewayCreateVM>(createdModelGateway);
            return CreatedAtAction(nameof(GetById), new { id = 0 }, createdItem);
        }

        // Create multiple ModelGateways.
        [HttpPost("createRange")]
        public async Task<ActionResult<IEnumerable<ModelGatewayCreateVM>>> CreateRange([FromBody] IEnumerable<ModelGatewayCreateVM> models)
        {
            if (models == null)
                return BadRequest("Data is required.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var items = _mapper.Map<List<ModelGatewayRequestDso>>(models);
            var createdModelGateways = await _modelgatewayService.CreateRangeAsync(items);
            var createdItems = _mapper.Map<List<ModelGatewayCreateVM>>(createdModelGateways);
            return CreatedAtAction(nameof(GetAll), createdItems);
        }

        // Update an existing ModelGateway.
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ModelGatewayUpdateVM model)
        {
            if (id <= 0 || model == null)
                return BadRequest("Invalid data.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = _mapper.Map<ModelGatewayRequestDso>(model);
            var updatedModelGateway = await _modelgatewayService.UpdateAsync(item);
            if (updatedModelGateway == null)
                return NotFound();
            var updatedItem = _mapper.Map<ModelGatewayUpdateVM>(updatedModelGateway);
            return Ok(updatedItem);
        }

        // Delete a ModelGateway.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid ModelGateway ID.");
            await _modelgatewayService.DeleteAsync(id);
            return NoContent();
        }

        //// Delete multiple ModelGateways.
        //[HttpDelete("deleteRange")]
        //public async Task<IActionResult> DeleteRange([FromQuery] Expression<Func<ModelGatewayOutputVM, bool>> predicate)
        //{
        //    //await _modelgatewayService.DeleteRangeAsync(predicate);
        //    return NoContent();
        //}
        //// Check if a ModelGateway exists based on a predicate.
        //[HttpGet("exists")]
        //public async Task<ActionResult<bool>> Exists([FromQuery] Expression<Func<ModelGatewayOutputVM, bool>> predicate)
        //{
        //    //var exists = await _modelgatewayService.ExistsAsync(predicate);
        //    return Ok();
        //}
        // Get count of ModelGateways.
        [HttpGet("count")]
        public async Task<ActionResult<int>> Count()
        {
            var count = await _modelgatewayService.CountAsync();
            return Ok(count);
        }
    }
}