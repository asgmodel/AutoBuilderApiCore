using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using ApiCore.Services.Services;
using Microsoft.AspNetCore.Mvc;
using ApiCore.DyModels.VM.Setting;
using System.Linq.Expressions;
using ApiCore.DyModels.Dso.Requests;
using System;

namespace ApiCore.Controllers.Api
{
    //[ApiExplorerSettings(GroupName = "ApiCore")]
    [Route("api/ApiCore/Api/[controller]")]
    [ApiController]
    public class SettingController : ControllerBase
    {
        private readonly IUseSettingService _settingService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public SettingController(IUseSettingService settingService, IMapper mapper, ILoggerFactory logger)
        {
            _settingService = settingService;
            _mapper = mapper;
            _logger = logger.CreateLogger(typeof(SettingController).FullName);
        }

        // Get all Settings.
        [HttpGet(Name = "GetSettings")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<SettingOutputVM>>> GetAll()
        {
            var result = await _settingService.GetAllAsync();
            var items = _mapper.Map<List<SettingOutputVM>>(result);
            return Ok(items);
        }

        // Get a Setting by ID.
        [HttpGet("{id}", Name = "GetSetting")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SettingInfoVM>> GetById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Setting ID.");
            var setting = await _settingService.GetByIdAsync(id);
            if (setting == null)
                return NotFound();
            var item = _mapper.Map<SettingInfoVM>(setting);
            return Ok(item);
        }

        //// Find a Setting by a specific predicate.
        //[HttpGet("find")]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<SettingInfoVM>> Find([FromQuery] Expression<Func<SettingOutputVM, bool>> predicate)
        //{
        //     return NotFound();
        //    //var setting = await _settingService.FindAsync(predicate);
        //   // if (setting == null) return NotFound();
        //   // var item = _mapper.Map<SettingInfoVM>(setting);
        //   // return Ok(item);
        //}
        // Create a new Setting.
        [HttpPost(Name = "CreateSetting")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SettingCreateVM>> Create([FromBody] SettingCreateVM model)
        {
            if (model == null)
                return BadRequest("Setting data is required.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = _mapper.Map<SettingRequestDso>(model);
            var createdSetting = await _settingService.CreateAsync(item);
            var createdItem = _mapper.Map<SettingCreateVM>(createdSetting);
            return CreatedAtAction(nameof(GetById), new { id = 0 }, createdItem);
        }

        // Create multiple Settings.
        [HttpPost("createRange")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<SettingCreateVM>>> CreateRange([FromBody] IEnumerable<SettingCreateVM> models)
        {
            if (models == null)
                return BadRequest("Data is required.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var items = _mapper.Map<List<SettingRequestDso>>(models);
            var createdSettings = await _settingService.CreateRangeAsync(items);
            var createdItems = _mapper.Map<List<SettingCreateVM>>(createdSettings);
            return CreatedAtAction(nameof(GetAll), createdItems);
        }

        // Update an existing Setting.
        [HttpPut("{id}", Name = "UpdateSetting")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] SettingUpdateVM model)
        {
            if (id <= 0 || model == null)
                return BadRequest("Invalid data.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = _mapper.Map<SettingRequestDso>(model);
            var updatedSetting = await _settingService.UpdateAsync(item);
            if (updatedSetting == null)
                return NotFound();
            var updatedItem = _mapper.Map<SettingUpdateVM>(updatedSetting);
            return Ok(updatedItem);
        }

        // Delete a Setting.
        [HttpDelete("{id}", Name = "DeleteSetting")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Setting ID.");
            await _settingService.DeleteAsync(id);
            return NoContent();
        }

        //// Delete multiple Settings.
        //[HttpDelete("deleteRange")]
        //public async Task<IActionResult> DeleteRange([FromQuery] Expression<Func<SettingOutputVM, bool>> predicate)
        //{
        //    //await _settingService.DeleteRangeAsync(predicate);
        //    return NoContent();
        //}
        //// Check if a Setting exists based on a predicate.
        //[HttpGet("exists")]
        //public async Task<ActionResult<bool>> Exists([FromQuery] Expression<Func<SettingOutputVM, bool>> predicate)
        //{
        //    //var exists = await _settingService.ExistsAsync(predicate);
        //    return Ok();
        //}
        // Get count of Settings.
        [HttpGet("CountSetting")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> Count()
        {
            var count = await _settingService.CountAsync();
            return Ok(count);
        }
    }
}