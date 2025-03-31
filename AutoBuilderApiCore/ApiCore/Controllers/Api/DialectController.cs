using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using ApiCore.Services.Services;
using Microsoft.AspNetCore.Mvc;
using ApiCore.DyModels.VM.Dialect;
using System.Linq.Expressions;
using ApiCore.DyModels.Dso.Requests;
using System;

namespace ApiCore.Controllers.Api
{
    //[ApiExplorerSettings(GroupName = "ApiCore")]
    [Route("api/ApiCore/Api/[controller]")]
    [ApiController]
    public class DialectController : ControllerBase
    {
        private readonly IUseDialectService _dialectService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public DialectController(IUseDialectService dialectService, IMapper mapper, ILoggerFactory logger)
        {
            _dialectService = dialectService;
            _mapper = mapper;
            _logger = logger.CreateLogger(typeof(DialectController).FullName);
        }

        // Get all Dialects.
        [HttpGet(Name = "GetDialects")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<DialectOutputVM>>> GetAll()
        {
            var result = await _dialectService.GetAllAsync();
            var items = _mapper.Map<List<DialectOutputVM>>(result);
            return Ok(items);
        }

        // Get a Dialect by ID.
        [HttpGet("{id}", Name = "GetDialect")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DialectInfoVM>> GetById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Dialect ID.");
            var dialect = await _dialectService.GetByIdAsync(id);
            if (dialect == null)
                return NotFound();
            var item = _mapper.Map<DialectInfoVM>(dialect);
            return Ok(item);
        }

        //// Find a Dialect by a specific predicate.
        //[HttpGet("find")]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<DialectInfoVM>> Find([FromQuery] Expression<Func<DialectOutputVM, bool>> predicate)
        //{
        //     return NotFound();
        //    //var dialect = await _dialectService.FindAsync(predicate);
        //   // if (dialect == null) return NotFound();
        //   // var item = _mapper.Map<DialectInfoVM>(dialect);
        //   // return Ok(item);
        //}
        // Create a new Dialect.
        [HttpPost(Name = "CreateDialect")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DialectCreateVM>> Create([FromBody] DialectCreateVM model)
        {
            if (model == null)
                return BadRequest("Dialect data is required.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = _mapper.Map<DialectRequestDso>(model);
            var createdDialect = await _dialectService.CreateAsync(item);
            var createdItem = _mapper.Map<DialectCreateVM>(createdDialect);
            return CreatedAtAction(nameof(GetById), new { id = 0 }, createdItem);
        }

        // Create multiple Dialects.
        [HttpPost("createRange")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<DialectCreateVM>>> CreateRange([FromBody] IEnumerable<DialectCreateVM> models)
        {
            if (models == null)
                return BadRequest("Data is required.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var items = _mapper.Map<List<DialectRequestDso>>(models);
            var createdDialects = await _dialectService.CreateRangeAsync(items);
            var createdItems = _mapper.Map<List<DialectCreateVM>>(createdDialects);
            return CreatedAtAction(nameof(GetAll), createdItems);
        }

        // Update an existing Dialect.
        [HttpPut("{id}", Name = "UpdateDialect")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] DialectUpdateVM model)
        {
            if (id <= 0 || model == null)
                return BadRequest("Invalid data.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = _mapper.Map<DialectRequestDso>(model);
            var updatedDialect = await _dialectService.UpdateAsync(item);
            if (updatedDialect == null)
                return NotFound();
            var updatedItem = _mapper.Map<DialectUpdateVM>(updatedDialect);
            return Ok(updatedItem);
        }

        // Delete a Dialect.
        [HttpDelete("{id}", Name = "DeleteDialect")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Dialect ID.");
            await _dialectService.DeleteAsync(id);
            return NoContent();
        }

        //// Delete multiple Dialects.
        //[HttpDelete("deleteRange")]
        //public async Task<IActionResult> DeleteRange([FromQuery] Expression<Func<DialectOutputVM, bool>> predicate)
        //{
        //    //await _dialectService.DeleteRangeAsync(predicate);
        //    return NoContent();
        //}
        //// Check if a Dialect exists based on a predicate.
        //[HttpGet("exists")]
        //public async Task<ActionResult<bool>> Exists([FromQuery] Expression<Func<DialectOutputVM, bool>> predicate)
        //{
        //    //var exists = await _dialectService.ExistsAsync(predicate);
        //    return Ok();
        //}
        // Get count of Dialects.
        [HttpGet("CountDialect")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> Count()
        {
            var count = await _dialectService.CountAsync();
            return Ok(count);
        }
    }
}