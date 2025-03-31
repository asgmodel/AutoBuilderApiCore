using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using ApiCore.Services.Services;
using Microsoft.AspNetCore.Mvc;
using ApiCore.DyModels.VM.UserModelAi;
using System.Linq.Expressions;
using ApiCore.DyModels.Dso.Requests;
using System;

namespace ApiCore.Controllers.Api
{
    [Route("api/Api/[controller]")]
    [ApiController]
    public class UserModelAiController : ControllerBase
    {
        private readonly IUseUserModelAiService _usermodelaiService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public UserModelAiController(IUseUserModelAiService usermodelaiService, IMapper mapper, ILoggerFactory logger)
        {
            _usermodelaiService = usermodelaiService;
            _mapper = mapper;
            _logger = logger.CreateLogger(typeof(UserModelAiController).FullName);
        }

        // Get all UserModelAis.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModelAiOutputVM>>> GetAll()
        {
            var result = await _usermodelaiService.GetAllAsync();
            var items = _mapper.Map<List<UserModelAiOutputVM>>(result);
            return Ok(items);
        }

        // Get a UserModelAi by ID.
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModelAiInfoVM>> GetById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid UserModelAi ID.");
            var usermodelai = await _usermodelaiService.GetByIdAsync(id);
            if (usermodelai == null)
                return NotFound();
            var item = _mapper.Map<UserModelAiInfoVM>(usermodelai);
            return Ok(item);
        }

        //// Find a UserModelAi by a specific predicate.
        //[HttpGet("find")]
        //public async Task<ActionResult<UserModelAiInfoVM>> Find([FromQuery] Expression<Func<UserModelAiOutputVM, bool>> predicate)
        //{
        //     return NotFound();
        //    //var usermodelai = await _usermodelaiService.FindAsync(predicate);
        //   // if (usermodelai == null) return NotFound();
        //   // var item = _mapper.Map<UserModelAiInfoVM>(usermodelai);
        //   // return Ok(item);
        //}
        // Create a new UserModelAi.
        [HttpPost]
        public async Task<ActionResult<UserModelAiCreateVM>> Create([FromBody] UserModelAiCreateVM model)
        {
            if (model == null)
                return BadRequest("UserModelAi data is required.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = _mapper.Map<UserModelAiRequestDso>(model);
            var createdUserModelAi = await _usermodelaiService.CreateAsync(item);
            var createdItem = _mapper.Map<UserModelAiCreateVM>(createdUserModelAi);
            return CreatedAtAction(nameof(GetById), new { id = 0 }, createdItem);
        }

        // Create multiple UserModelAis.
        [HttpPost("createRange")]
        public async Task<ActionResult<IEnumerable<UserModelAiCreateVM>>> CreateRange([FromBody] IEnumerable<UserModelAiCreateVM> models)
        {
            if (models == null)
                return BadRequest("Data is required.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var items = _mapper.Map<List<UserModelAiRequestDso>>(models);
            var createdUserModelAis = await _usermodelaiService.CreateRangeAsync(items);
            var createdItems = _mapper.Map<List<UserModelAiCreateVM>>(createdUserModelAis);
            return CreatedAtAction(nameof(GetAll), createdItems);
        }

        // Update an existing UserModelAi.
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UserModelAiUpdateVM model)
        {
            if (id <= 0 || model == null)
                return BadRequest("Invalid data.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = _mapper.Map<UserModelAiRequestDso>(model);
            var updatedUserModelAi = await _usermodelaiService.UpdateAsync(item);
            if (updatedUserModelAi == null)
                return NotFound();
            var updatedItem = _mapper.Map<UserModelAiUpdateVM>(updatedUserModelAi);
            return Ok(updatedItem);
        }

        // Delete a UserModelAi.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid UserModelAi ID.");
            await _usermodelaiService.DeleteAsync(id);
            return NoContent();
        }

        //// Delete multiple UserModelAis.
        //[HttpDelete("deleteRange")]
        //public async Task<IActionResult> DeleteRange([FromQuery] Expression<Func<UserModelAiOutputVM, bool>> predicate)
        //{
        //    //await _usermodelaiService.DeleteRangeAsync(predicate);
        //    return NoContent();
        //}
        //// Check if a UserModelAi exists based on a predicate.
        //[HttpGet("exists")]
        //public async Task<ActionResult<bool>> Exists([FromQuery] Expression<Func<UserModelAiOutputVM, bool>> predicate)
        //{
        //    //var exists = await _usermodelaiService.ExistsAsync(predicate);
        //    return Ok();
        //}
        // Get count of UserModelAis.
        [HttpGet("count")]
        public async Task<ActionResult<int>> Count()
        {
            var count = await _usermodelaiService.CountAsync();
            return Ok(count);
        }
    }
}