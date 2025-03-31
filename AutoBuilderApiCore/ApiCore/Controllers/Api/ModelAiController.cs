using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using ApiCore.Services.Services;
using Microsoft.AspNetCore.Mvc;
using ApiCore.DyModels.VM.ModelAi;
using System.Linq.Expressions;
using ApiCore.DyModels.Dso.Requests;
using System;

namespace ApiCore.Controllers.Api
{
    [Route("api/Api/[controller]")]
    [ApiController]
    public class ModelAiController : ControllerBase
    {
        private readonly IUseModelAiService _modelaiService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public ModelAiController(IUseModelAiService modelaiService, IMapper mapper, ILoggerFactory logger)
        {
            _modelaiService = modelaiService;
            _mapper = mapper;
            _logger = logger.CreateLogger(typeof(ModelAiController).FullName);
        }

        // Get all ModelAis.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModelAiOutputVM>>> GetAll()
        {
            var result = await _modelaiService.GetAllAsync();
            var items = _mapper.Map<List<ModelAiOutputVM>>(result);
            return Ok(items);
        }

        // Get a ModelAi by ID.
        [HttpGet("{id}")]
        public async Task<ActionResult<ModelAiInfoVM>> GetById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid ModelAi ID.");
            var modelai = await _modelaiService.GetByIdAsync(id);
            if (modelai == null)
                return NotFound();
            var item = _mapper.Map<ModelAiInfoVM>(modelai);
            return Ok(item);
        }

        //// Find a ModelAi by a specific predicate.
        //[HttpGet("find")]
        //public async Task<ActionResult<ModelAiInfoVM>> Find([FromQuery] Expression<Func<ModelAiOutputVM, bool>> predicate)
        //{
        //     return NotFound();
        //    //var modelai = await _modelaiService.FindAsync(predicate);
        //   // if (modelai == null) return NotFound();
        //   // var item = _mapper.Map<ModelAiInfoVM>(modelai);
        //   // return Ok(item);
        //}
        // Create a new ModelAi.
        [HttpPost]
        public async Task<ActionResult<ModelAiCreateVM>> Create([FromBody] ModelAiCreateVM model)
        {
            if (model == null)
                return BadRequest("ModelAi data is required.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = _mapper.Map<ModelAiRequestDso>(model);
            var createdModelAi = await _modelaiService.CreateAsync(item);
            var createdItem = _mapper.Map<ModelAiCreateVM>(createdModelAi);
            return CreatedAtAction(nameof(GetById), new { id = 0 }, createdItem);
        }

        // Create multiple ModelAis.
        [HttpPost("createRange")]
        public async Task<ActionResult<IEnumerable<ModelAiCreateVM>>> CreateRange([FromBody] IEnumerable<ModelAiCreateVM> models)
        {
            if (models == null)
                return BadRequest("Data is required.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var items = _mapper.Map<List<ModelAiRequestDso>>(models);
            var createdModelAis = await _modelaiService.CreateRangeAsync(items);
            var createdItems = _mapper.Map<List<ModelAiCreateVM>>(createdModelAis);
            return CreatedAtAction(nameof(GetAll), createdItems);
        }

        // Update an existing ModelAi.
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ModelAiUpdateVM model)
        {
            if (id <= 0 || model == null)
                return BadRequest("Invalid data.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = _mapper.Map<ModelAiRequestDso>(model);
            var updatedModelAi = await _modelaiService.UpdateAsync(item);
            if (updatedModelAi == null)
                return NotFound();
            var updatedItem = _mapper.Map<ModelAiUpdateVM>(updatedModelAi);
            return Ok(updatedItem);
        }

        // Delete a ModelAi.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid ModelAi ID.");
            await _modelaiService.DeleteAsync(id);
            return NoContent();
        }

        //// Delete multiple ModelAis.
        //[HttpDelete("deleteRange")]
        //public async Task<IActionResult> DeleteRange([FromQuery] Expression<Func<ModelAiOutputVM, bool>> predicate)
        //{
        //    //await _modelaiService.DeleteRangeAsync(predicate);
        //    return NoContent();
        //}
        //// Check if a ModelAi exists based on a predicate.
        //[HttpGet("exists")]
        //public async Task<ActionResult<bool>> Exists([FromQuery] Expression<Func<ModelAiOutputVM, bool>> predicate)
        //{
        //    //var exists = await _modelaiService.ExistsAsync(predicate);
        //    return Ok();
        //}
        // Get count of ModelAis.
        [HttpGet("count")]
        public async Task<ActionResult<int>> Count()
        {
            var count = await _modelaiService.CountAsync();
            return Ok(count);
        }
    }
}