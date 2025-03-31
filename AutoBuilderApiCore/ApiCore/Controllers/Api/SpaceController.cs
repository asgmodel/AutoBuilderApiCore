using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using ApiCore.Services.Services;
using Microsoft.AspNetCore.Mvc;
using ApiCore.DyModels.VM.Space;
using System.Linq.Expressions;
using ApiCore.DyModels.Dso.Requests;
using System;

namespace ApiCore.Controllers.Api
{
    //[ApiExplorerSettings(GroupName = "ApiCore")]
    [Route("api/ApiCore/Api/[controller]")]
    [ApiController]
    public class SpaceController : ControllerBase
    {
        private readonly IUseSpaceService _spaceService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public SpaceController(IUseSpaceService spaceService, IMapper mapper, ILoggerFactory logger)
        {
            _spaceService = spaceService;
            _mapper = mapper;
            _logger = logger.CreateLogger(typeof(SpaceController).FullName);
        }

        // Get all Spaces.
        [HttpGet(Name = "GetSpaces")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<SpaceOutputVM>>> GetAll()
        {
            var result = await _spaceService.GetAllAsync();
            var items = _mapper.Map<List<SpaceOutputVM>>(result);
            return Ok(items);
        }

        // Get a Space by ID.
        [HttpGet("{id}", Name = "GetSpace")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SpaceInfoVM>> GetById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Space ID.");
            var space = await _spaceService.GetByIdAsync(id);
            if (space == null)
                return NotFound();
            var item = _mapper.Map<SpaceInfoVM>(space);
            return Ok(item);
        }

        //// Find a Space by a specific predicate.
        //[HttpGet("find")]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<SpaceInfoVM>> Find([FromQuery] Expression<Func<SpaceOutputVM, bool>> predicate)
        //{
        //     return NotFound();
        //    //var space = await _spaceService.FindAsync(predicate);
        //   // if (space == null) return NotFound();
        //   // var item = _mapper.Map<SpaceInfoVM>(space);
        //   // return Ok(item);
        //}
        // Create a new Space.
        [HttpPost(Name = "CreateSpace")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SpaceCreateVM>> Create([FromBody] SpaceCreateVM model)
        {
            if (model == null)
                return BadRequest("Space data is required.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = _mapper.Map<SpaceRequestDso>(model);
            var createdSpace = await _spaceService.CreateAsync(item);
            var createdItem = _mapper.Map<SpaceCreateVM>(createdSpace);
            return CreatedAtAction(nameof(GetById), new { id = 0 }, createdItem);
        }

        // Create multiple Spaces.
        [HttpPost("createRange")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<SpaceCreateVM>>> CreateRange([FromBody] IEnumerable<SpaceCreateVM> models)
        {
            if (models == null)
                return BadRequest("Data is required.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var items = _mapper.Map<List<SpaceRequestDso>>(models);
            var createdSpaces = await _spaceService.CreateRangeAsync(items);
            var createdItems = _mapper.Map<List<SpaceCreateVM>>(createdSpaces);
            return CreatedAtAction(nameof(GetAll), createdItems);
        }

        // Update an existing Space.
        [HttpPut("{id}", Name = "UpdateSpace")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] SpaceUpdateVM model)
        {
            if (id <= 0 || model == null)
                return BadRequest("Invalid data.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = _mapper.Map<SpaceRequestDso>(model);
            var updatedSpace = await _spaceService.UpdateAsync(item);
            if (updatedSpace == null)
                return NotFound();
            var updatedItem = _mapper.Map<SpaceUpdateVM>(updatedSpace);
            return Ok(updatedItem);
        }

        // Delete a Space.
        [HttpDelete("{id}", Name = "DeleteSpace")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Space ID.");
            await _spaceService.DeleteAsync(id);
            return NoContent();
        }

        //// Delete multiple Spaces.
        //[HttpDelete("deleteRange")]
        //public async Task<IActionResult> DeleteRange([FromQuery] Expression<Func<SpaceOutputVM, bool>> predicate)
        //{
        //    //await _spaceService.DeleteRangeAsync(predicate);
        //    return NoContent();
        //}
        //// Check if a Space exists based on a predicate.
        //[HttpGet("exists")]
        //public async Task<ActionResult<bool>> Exists([FromQuery] Expression<Func<SpaceOutputVM, bool>> predicate)
        //{
        //    //var exists = await _spaceService.ExistsAsync(predicate);
        //    return Ok();
        //}
        // Get count of Spaces.
        [HttpGet("CountSpace")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> Count()
        {
            var count = await _spaceService.CountAsync();
            return Ok(count);
        }
    }
}