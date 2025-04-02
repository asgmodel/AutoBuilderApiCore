using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using ApiCore.Services.Services;
using Microsoft.AspNetCore.Mvc;
using ApiCore.DyModels.VM.TypeModel;
using System.Linq.Expressions;
using ApiCore.DyModels.Dso.Requests;
using System;

namespace ApiCore.Controllers.Api
{
    //[ApiExplorerSettings(GroupName = "ApiCore")]
    [Route("api/ApiCore/Api/[controller]")]
    [ApiController]
    public class TypeModelController : ControllerBase
    {
        private readonly IUseTypeModelService _typemodelService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public TypeModelController(IUseTypeModelService typemodelService, IMapper mapper, ILoggerFactory logger)
        {
            _typemodelService = typemodelService;
            _mapper = mapper;
            _logger = logger.CreateLogger(typeof(TypeModelController).FullName);
        }

        // Get all TypeModels.
        [HttpGet(Name = "GetTypeModels")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<TypeModelOutputVM>>> GetAll()
        {
            var result = await _typemodelService.GetAllAsync();
            var items = _mapper.Map<List<TypeModelOutputVM>>(result);
            return Ok(items);
        }

        // Get a TypeModel by ID.
        [HttpGet("{id}", Name = "GetTypeModel")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypeModelInfoVM>> GetById(string? id)
        {
            if (id == "")
                return BadRequest("Invalid TypeModel ID.");
            var typemodel = await _typemodelService.GetByIdAsync(id);
            if (typemodel == null)
                return NotFound();
            var item = _mapper.Map<TypeModelInfoVM>(typemodel);
            return Ok(item);
        }

        //// Find a TypeModel by a specific predicate.
        //[HttpGet("find")]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<TypeModelInfoVM>> Find([FromQuery] Expression<Func<TypeModelOutputVM, bool>> predicate)
        //{
        //     return NotFound();
        //    //var typemodel = await _typemodelService.FindAsync(predicate);
        //   // if (typemodel == null) return NotFound();
        //   // var item = _mapper.Map<TypeModelInfoVM>(typemodel);
        //   // return Ok(item);
        //}
        // Create a new TypeModel.
        [HttpPost(Name = "CreateTypeModel")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypeModelCreateVM>> Create([FromBody] TypeModelCreateVM model)
        {
            if (model == null)
                return BadRequest("TypeModel data is required.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = _mapper.Map<TypeModelRequestDso>(model);
            var createdTypeModel = await _typemodelService.CreateAsync(item);
            var createdItem = _mapper.Map<TypeModelCreateVM>(createdTypeModel);
            return CreatedAtAction(nameof(GetById), new { id = 0 }, createdItem);
        }

        // Create multiple TypeModels.
        [HttpPost("createRange")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<TypeModelCreateVM>>> CreateRange([FromBody] IEnumerable<TypeModelCreateVM> models)
        {
            if (models == null)
                return BadRequest("Data is required.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var items = _mapper.Map<List<TypeModelRequestDso>>(models);
            var createdTypeModels = await _typemodelService.CreateRangeAsync(items);
            var createdItems = _mapper.Map<List<TypeModelCreateVM>>(createdTypeModels);
            return CreatedAtAction(nameof(GetAll), createdItems);
        }

        // Update an existing TypeModel.
        [HttpPut("{id}", Name = "UpdateTypeModel")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] TypeModelUpdateVM model)
        {
            if (id <= 0 || model == null)
                return BadRequest("Invalid data.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = _mapper.Map<TypeModelRequestDso>(model);
            var updatedTypeModel = await _typemodelService.UpdateAsync(item);
            if (updatedTypeModel == null)
                return NotFound();
            var updatedItem = _mapper.Map<TypeModelUpdateVM>(updatedTypeModel);
            return Ok(updatedItem);
        }

        // Delete a TypeModel.
        [HttpDelete("{id}", Name = "DeleteTypeModel")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == "")
                return BadRequest("Invalid TypeModel ID.");
            await _typemodelService.DeleteAsync(id);
            return NoContent();
        }

        //// Delete multiple TypeModels.
        //[HttpDelete("deleteRange")]
        //public async Task<IActionResult> DeleteRange([FromQuery] Expression<Func<TypeModelOutputVM, bool>> predicate)
        //{
        //    //await _typemodelService.DeleteRangeAsync(predicate);
        //    return NoContent();
        //}
        //// Check if a TypeModel exists based on a predicate.
        //[HttpGet("exists")]
        //public async Task<ActionResult<bool>> Exists([FromQuery] Expression<Func<TypeModelOutputVM, bool>> predicate)
        //{
        //    //var exists = await _typemodelService.ExistsAsync(predicate);
        //    return Ok();
        //}
        // Get count of TypeModels.
        [HttpGet("CountTypeModel")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> Count()
        {
            var count = await _typemodelService.CountAsync();
            return Ok(count);
        }
    }
}