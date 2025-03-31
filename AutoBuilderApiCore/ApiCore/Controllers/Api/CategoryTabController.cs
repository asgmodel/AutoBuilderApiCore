using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using ApiCore.Services.Services;
using Microsoft.AspNetCore.Mvc;
using ApiCore.DyModels.VM.CategoryTab;
using System.Linq.Expressions;
using ApiCore.DyModels.Dso.Requests;
using System;

namespace ApiCore.Controllers.Api
{
    //[ApiExplorerSettings(GroupName = "ApiCore")]
    [Route("api/ApiCore/Api/[controller]")]
    [ApiController]
    public class CategoryTabController : ControllerBase
    {
        private readonly IUseCategoryTabService _categorytabService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public CategoryTabController(IUseCategoryTabService categorytabService, IMapper mapper, ILoggerFactory logger)
        {
            _categorytabService = categorytabService;
            _mapper = mapper;
            _logger = logger.CreateLogger(typeof(CategoryTabController).FullName);
        }

        // Get all CategoryTabs.
        [HttpGet(Name = "GetCategoryTabs")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<CategoryTabOutputVM>>> GetAll()
        {
            var result = await _categorytabService.GetAllAsync();
            var items = _mapper.Map<List<CategoryTabOutputVM>>(result);
            return Ok(items);
        }

        // Get a CategoryTab by ID.
        [HttpGet("{id}", Name = "GetCategoryTab")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoryTabInfoVM>> GetById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid CategoryTab ID.");
            var categorytab = await _categorytabService.GetByIdAsync(id);
            if (categorytab == null)
                return NotFound();
            var item = _mapper.Map<CategoryTabInfoVM>(categorytab);
            return Ok(item);
        }

        //// Find a CategoryTab by a specific predicate.
        //[HttpGet("find")]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<CategoryTabInfoVM>> Find([FromQuery] Expression<Func<CategoryTabOutputVM, bool>> predicate)
        //{
        //     return NotFound();
        //    //var categorytab = await _categorytabService.FindAsync(predicate);
        //   // if (categorytab == null) return NotFound();
        //   // var item = _mapper.Map<CategoryTabInfoVM>(categorytab);
        //   // return Ok(item);
        //}
        // Create a new CategoryTab.
        [HttpPost(Name = "CreateCategoryTab")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoryTabCreateVM>> Create([FromBody] CategoryTabCreateVM model)
        {
            if (model == null)
                return BadRequest("CategoryTab data is required.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = _mapper.Map<CategoryTabRequestDso>(model);
            var createdCategoryTab = await _categorytabService.CreateAsync(item);
            var createdItem = _mapper.Map<CategoryTabCreateVM>(createdCategoryTab);
            return CreatedAtAction(nameof(GetById), new { id = 0 }, createdItem);
        }

        // Create multiple CategoryTabs.
        [HttpPost("createRange")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<CategoryTabCreateVM>>> CreateRange([FromBody] IEnumerable<CategoryTabCreateVM> models)
        {
            if (models == null)
                return BadRequest("Data is required.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var items = _mapper.Map<List<CategoryTabRequestDso>>(models);
            var createdCategoryTabs = await _categorytabService.CreateRangeAsync(items);
            var createdItems = _mapper.Map<List<CategoryTabCreateVM>>(createdCategoryTabs);
            return CreatedAtAction(nameof(GetAll), createdItems);
        }

        // Update an existing CategoryTab.
        [HttpPut("{id}", Name = "UpdateCategoryTab")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] CategoryTabUpdateVM model)
        {
            if (id <= 0 || model == null)
                return BadRequest("Invalid data.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = _mapper.Map<CategoryTabRequestDso>(model);
            var updatedCategoryTab = await _categorytabService.UpdateAsync(item);
            if (updatedCategoryTab == null)
                return NotFound();
            var updatedItem = _mapper.Map<CategoryTabUpdateVM>(updatedCategoryTab);
            return Ok(updatedItem);
        }

        // Delete a CategoryTab.
        [HttpDelete("{id}", Name = "DeleteCategoryTab")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid CategoryTab ID.");
            await _categorytabService.DeleteAsync(id);
            return NoContent();
        }

        //// Delete multiple CategoryTabs.
        //[HttpDelete("deleteRange")]
        //public async Task<IActionResult> DeleteRange([FromQuery] Expression<Func<CategoryTabOutputVM, bool>> predicate)
        //{
        //    //await _categorytabService.DeleteRangeAsync(predicate);
        //    return NoContent();
        //}
        //// Check if a CategoryTab exists based on a predicate.
        //[HttpGet("exists")]
        //public async Task<ActionResult<bool>> Exists([FromQuery] Expression<Func<CategoryTabOutputVM, bool>> predicate)
        //{
        //    //var exists = await _categorytabService.ExistsAsync(predicate);
        //    return Ok();
        //}
        // Get count of CategoryTabs.
        [HttpGet("CountCategoryTab")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> Count()
        {
            var count = await _categorytabService.CountAsync();
            return Ok(count);
        }
    }
}