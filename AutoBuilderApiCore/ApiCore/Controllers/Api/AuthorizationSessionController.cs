using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using ApiCore.Services.Services;
using Microsoft.AspNetCore.Mvc;
using ApiCore.DyModels.VM.AuthorizationSession;
using System.Linq.Expressions;
using ApiCore.DyModels.Dso.Requests;
using System;

namespace ApiCore.Controllers.Api
{
    [Route("api/Api/[controller]")]
    [ApiController]
    public class AuthorizationSessionController : ControllerBase
    {
        private readonly IUseAuthorizationSessionService _authorizationsessionService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public AuthorizationSessionController(IUseAuthorizationSessionService authorizationsessionService, IMapper mapper, ILoggerFactory logger)
        {
            _authorizationsessionService = authorizationsessionService;
            _mapper = mapper;
            _logger = logger.CreateLogger(typeof(AuthorizationSessionController).FullName);
        }

        // Get all AuthorizationSessions.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorizationSessionOutputVM>>> GetAll()
        {
            var result = await _authorizationsessionService.GetAllAsync();
            var items = _mapper.Map<List<AuthorizationSessionOutputVM>>(result);
            return Ok(items);
        }

        // Get a AuthorizationSession by ID.
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorizationSessionInfoVM>> GetById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid AuthorizationSession ID.");
            var authorizationsession = await _authorizationsessionService.GetByIdAsync(id);
            if (authorizationsession == null)
                return NotFound();
            var item = _mapper.Map<AuthorizationSessionInfoVM>(authorizationsession);
            return Ok(item);
        }

        //// Find a AuthorizationSession by a specific predicate.
        //[HttpGet("find")]
        //public async Task<ActionResult<AuthorizationSessionInfoVM>> Find([FromQuery] Expression<Func<AuthorizationSessionOutputVM, bool>> predicate)
        //{
        //     return NotFound();
        //    //var authorizationsession = await _authorizationsessionService.FindAsync(predicate);
        //   // if (authorizationsession == null) return NotFound();
        //   // var item = _mapper.Map<AuthorizationSessionInfoVM>(authorizationsession);
        //   // return Ok(item);
        //}
        // Create a new AuthorizationSession.
        [HttpPost]
        public async Task<ActionResult<AuthorizationSessionCreateVM>> Create([FromBody] AuthorizationSessionCreateVM model)
        {
            if (model == null)
                return BadRequest("AuthorizationSession data is required.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = _mapper.Map<AuthorizationSessionRequestDso>(model);
            var createdAuthorizationSession = await _authorizationsessionService.CreateAsync(item);
            var createdItem = _mapper.Map<AuthorizationSessionCreateVM>(createdAuthorizationSession);
            return CreatedAtAction(nameof(GetById), new { id = 0 }, createdItem);
        }

        // Create multiple AuthorizationSessions.
        [HttpPost("createRange")]
        public async Task<ActionResult<IEnumerable<AuthorizationSessionCreateVM>>> CreateRange([FromBody] IEnumerable<AuthorizationSessionCreateVM> models)
        {
            if (models == null)
                return BadRequest("Data is required.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var items = _mapper.Map<List<AuthorizationSessionRequestDso>>(models);
            var createdAuthorizationSessions = await _authorizationsessionService.CreateRangeAsync(items);
            var createdItems = _mapper.Map<List<AuthorizationSessionCreateVM>>(createdAuthorizationSessions);
            return CreatedAtAction(nameof(GetAll), createdItems);
        }

        // Update an existing AuthorizationSession.
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AuthorizationSessionUpdateVM model)
        {
            if (id <= 0 || model == null)
                return BadRequest("Invalid data.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = _mapper.Map<AuthorizationSessionRequestDso>(model);
            var updatedAuthorizationSession = await _authorizationsessionService.UpdateAsync(item);
            if (updatedAuthorizationSession == null)
                return NotFound();
            var updatedItem = _mapper.Map<AuthorizationSessionUpdateVM>(updatedAuthorizationSession);
            return Ok(updatedItem);
        }

        // Delete a AuthorizationSession.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid AuthorizationSession ID.");
            await _authorizationsessionService.DeleteAsync(id);
            return NoContent();
        }

        //// Delete multiple AuthorizationSessions.
        //[HttpDelete("deleteRange")]
        //public async Task<IActionResult> DeleteRange([FromQuery] Expression<Func<AuthorizationSessionOutputVM, bool>> predicate)
        //{
        //    //await _authorizationsessionService.DeleteRangeAsync(predicate);
        //    return NoContent();
        //}
        //// Check if a AuthorizationSession exists based on a predicate.
        //[HttpGet("exists")]
        //public async Task<ActionResult<bool>> Exists([FromQuery] Expression<Func<AuthorizationSessionOutputVM, bool>> predicate)
        //{
        //    //var exists = await _authorizationsessionService.ExistsAsync(predicate);
        //    return Ok();
        //}
        // Get count of AuthorizationSessions.
        [HttpGet("count")]
        public async Task<ActionResult<int>> Count()
        {
            var count = await _authorizationsessionService.CountAsync();
            return Ok(count);
        }
    }
}