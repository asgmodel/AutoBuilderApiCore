using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using ApiCore.Services.Services;
using Microsoft.AspNetCore.Mvc;
using ApiCore.DyModels.VM.Language;
using System.Linq.Expressions;
using ApiCore.DyModels.Dso.Requests;
using System;

namespace ApiCore.Controllers.Api
{
    //[ApiExplorerSettings(GroupName = "ApiCore")]
    [Route("api/ApiCore/Api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly IUseLanguageService _languageService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public LanguageController(IUseLanguageService languageService, IMapper mapper, ILoggerFactory logger)
        {
            _languageService = languageService;
            _mapper = mapper;
            _logger = logger.CreateLogger(typeof(LanguageController).FullName);
        }

        // Get all Languages.
        [HttpGet(Name = "GetLanguages")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<LanguageOutputVM>>> GetAll()
        {
            var result = await _languageService.GetAllAsync();
            var items = _mapper.Map<List<LanguageOutputVM>>(result);
            return Ok(items);
        }

        // Get a Language by ID.
        [HttpGet("{id}", Name = "GetLanguage")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LanguageInfoVM>> GetById(string? id)
        {
            if (id == "")
                return BadRequest("Invalid Language ID.");
            var language = await _languageService.GetByIdAsync(id);
            if (language == null)
                return NotFound();
            var item = _mapper.Map<LanguageInfoVM>(language);
            return Ok(item);
        }

        //// Find a Language by a specific predicate.
        //[HttpGet("find")]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<LanguageInfoVM>> Find([FromQuery] Expression<Func<LanguageOutputVM, bool>> predicate)
        //{
        //     return NotFound();
        //    //var language = await _languageService.FindAsync(predicate);
        //   // if (language == null) return NotFound();
        //   // var item = _mapper.Map<LanguageInfoVM>(language);
        //   // return Ok(item);
        //}
        // Create a new Language.
        [HttpPost(Name = "CreateLanguage")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LanguageCreateVM>> Create([FromBody] LanguageCreateVM model)
        {
            if (model == null)
                return BadRequest("Language data is required.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = _mapper.Map<LanguageRequestDso>(model);
            var createdLanguage = await _languageService.CreateAsync(item);
            var createdItem = _mapper.Map<LanguageCreateVM>(createdLanguage);
            return CreatedAtAction(nameof(GetById), new { id = 0 }, createdItem);
        }

        // Create multiple Languages.
        [HttpPost("createRange")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<LanguageCreateVM>>> CreateRange([FromBody] IEnumerable<LanguageCreateVM> models)
        {
            if (models == null)
                return BadRequest("Data is required.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var items = _mapper.Map<List<LanguageRequestDso>>(models);
            var createdLanguages = await _languageService.CreateRangeAsync(items);
            var createdItems = _mapper.Map<List<LanguageCreateVM>>(createdLanguages);
            return CreatedAtAction(nameof(GetAll), createdItems);
        }

        // Update an existing Language.
        [HttpPut("{id}", Name = "UpdateLanguage")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] LanguageUpdateVM model)
        {
            if (id <= 0 || model == null)
                return BadRequest("Invalid data.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = _mapper.Map<LanguageRequestDso>(model);
            var updatedLanguage = await _languageService.UpdateAsync(item);
            if (updatedLanguage == null)
                return NotFound();
            var updatedItem = _mapper.Map<LanguageUpdateVM>(updatedLanguage);
            return Ok(updatedItem);
        }

        // Delete a Language.
        [HttpDelete("{id}", Name = "DeleteLanguage")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == "")
                return BadRequest("Invalid Language ID.");
            await _languageService.DeleteAsync(id);
            return NoContent();
        }

        //// Delete multiple Languages.
        //[HttpDelete("deleteRange")]
        //public async Task<IActionResult> DeleteRange([FromQuery] Expression<Func<LanguageOutputVM, bool>> predicate)
        //{
        //    //await _languageService.DeleteRangeAsync(predicate);
        //    return NoContent();
        //}
        //// Check if a Language exists based on a predicate.
        //[HttpGet("exists")]
        //public async Task<ActionResult<bool>> Exists([FromQuery] Expression<Func<LanguageOutputVM, bool>> predicate)
        //{
        //    //var exists = await _languageService.ExistsAsync(predicate);
        //    return Ok();
        //}
        // Get count of Languages.
        [HttpGet("CountLanguage")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> Count()
        {
            var count = await _languageService.CountAsync();
            return Ok(count);
        }
    }
}