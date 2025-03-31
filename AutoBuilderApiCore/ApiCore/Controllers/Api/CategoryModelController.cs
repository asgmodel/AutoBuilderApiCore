using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using ApiCore.Services.Services;
using Microsoft.AspNetCore.Mvc;
using ApiCore.DyModels.VM.CategoryModel;
using System.Linq.Expressions;
using ApiCore.DyModels.Dso.Requests;
using System;

namespace ApiCore.Controllers.Api
{
    [Route("api/Api/[controller]")]
    [ApiController]
    public class CategoryModelController : ControllerBase
    {
        private readonly IUseCategoryModelService _categorymodelService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public CategoryModelController(IUseCategoryModelService categorymodelService, IMapper mapper, ILoggerFactory logger)
        {
            _categorymodelService = categorymodelService;
            _mapper = mapper;
            _logger = logger.CreateLogger(typeof(CategoryModelController).FullName);
        }

        // Get all CategoryModels.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryModelOutputVM>>> GetAll()
        {
            var result = await _categorymodelService.GetAllAsync();
            var items = _mapper.Map<List<CategoryModelOutputVM>>(result);
            return Ok(items);
        }

        // Get a CategoryModel by ID.
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryModelInfoVM>> GetById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid CategoryModel ID.");
            var categorymodel = await _categorymodelService.GetByIdAsync(id);
            if (categorymodel == null)
                return NotFound();
            var item = _mapper.Map<CategoryModelInfoVM>(categorymodel);
            return Ok(item);
        }

        //// Find a CategoryModel by a specific predicate.
        //[HttpGet("find")]
        //public async Task<ActionResult<CategoryModelInfoVM>> Find([FromQuery] Expression<Func<CategoryModelOutputVM, bool>> predicate)
        //{
        //     return NotFound();
        //    //var categorymodel = await _categorymodelService.FindAsync(predicate);
        //   // if (categorymodel == null) return NotFound();
        //   // var item = _mapper.Map<CategoryModelInfoVM>(categorymodel);
        //   // return Ok(item);
        //}
        // Create a new CategoryModel.
        [HttpPost]
        public async Task<ActionResult<CategoryModelCreateVM>> Create([FromBody] CategoryModelCreateVM model)
        {
            if (model == null)
                return BadRequest("CategoryModel data is required.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = _mapper.Map<CategoryModelRequestDso>(model);
            var createdCategoryModel = await _categorymodelService.CreateAsync(item);
            var createdItem = _mapper.Map<CategoryModelCreateVM>(createdCategoryModel);
            return CreatedAtAction(nameof(GetById), new { id = 0 }, createdItem);
        }

        // Create multiple CategoryModels.
        [HttpPost("createRange")]
        public async Task<ActionResult<IEnumerable<CategoryModelCreateVM>>> CreateRange([FromBody] IEnumerable<CategoryModelCreateVM> models)
        {
            if (models == null)
                return BadRequest("Data is required.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var items = _mapper.Map<List<CategoryModelRequestDso>>(models);
            var createdCategoryModels = await _categorymodelService.CreateRangeAsync(items);
            var createdItems = _mapper.Map<List<CategoryModelCreateVM>>(createdCategoryModels);
            return CreatedAtAction(nameof(GetAll), createdItems);
        }

        // Update an existing CategoryModel.
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CategoryModelUpdateVM model)
        {
            if (id <= 0 || model == null)
                return BadRequest("Invalid data.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = _mapper.Map<CategoryModelRequestDso>(model);
            var updatedCategoryModel = await _categorymodelService.UpdateAsync(item);
            if (updatedCategoryModel == null)
                return NotFound();
            var updatedItem = _mapper.Map<CategoryModelUpdateVM>(updatedCategoryModel);
            return Ok(updatedItem);
        }

        // Delete a CategoryModel.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid CategoryModel ID.");
            await _categorymodelService.DeleteAsync(id);
            return NoContent();
        }

        //// Delete multiple CategoryModels.
        //[HttpDelete("deleteRange")]
        //public async Task<IActionResult> DeleteRange([FromQuery] Expression<Func<CategoryModelOutputVM, bool>> predicate)
        //{
        //    //await _categorymodelService.DeleteRangeAsync(predicate);
        //    return NoContent();
        //}
        //// Check if a CategoryModel exists based on a predicate.
        //[HttpGet("exists")]
        //public async Task<ActionResult<bool>> Exists([FromQuery] Expression<Func<CategoryModelOutputVM, bool>> predicate)
        //{
        //    //var exists = await _categorymodelService.ExistsAsync(predicate);
        //    return Ok();
        //}
        // Get count of CategoryModels.
        [HttpGet("count")]
        public async Task<ActionResult<int>> Count()
        {
            var count = await _categorymodelService.CountAsync();
            return Ok(count);
        }
    }
}