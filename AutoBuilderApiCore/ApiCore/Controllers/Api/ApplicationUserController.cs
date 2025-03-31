using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Services.Services;
using Microsoft.AspNetCore.Mvc;
using VM.ApplicationUser;
using System.Linq.Expressions;
using Dso.Requests;
using System;

namespace Controllers.Api
{
    [Route("api/Api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private readonly IUseApplicationUserService _applicationuserService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public ApplicationUserController(IUseApplicationUserService applicationuserService, IMapper mapper, ILoggerFactory logger)
        {
            _applicationuserService = applicationuserService;
            _mapper = mapper;
            _logger = logger.CreateLogger(typeof(ApplicationUserController).FullName);
        }

        // Get all ApplicationUsers.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationUserOutputVM>>> GetAll()
        {
            var result = await _applicationuserService.GetAllAsync();
            var items = _mapper.Map<List<ApplicationUserOutputVM>>(result);
            return Ok(items);
        }

        // Get a ApplicationUser by ID.
        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationUserInfoVM>> GetById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid ApplicationUser ID.");
            var applicationuser = await _applicationuserService.GetByIdAsync(id);
            if (applicationuser == null)
                return NotFound();
            var item = _mapper.Map<ApplicationUserInfoVM>(applicationuser);
            return Ok(item);
        }

        //// Find a ApplicationUser by a specific predicate.
        //[HttpGet("find")]
        //public async Task<ActionResult<ApplicationUserInfoVM>> Find([FromQuery] Expression<Func<ApplicationUserOutputVM, bool>> predicate)
        //{
        //     return NotFound();
        //    //var applicationuser = await _applicationuserService.FindAsync(predicate);
        //   // if (applicationuser == null) return NotFound();
        //   // var item = _mapper.Map<ApplicationUserInfoVM>(applicationuser);
        //   // return Ok(item);
        //}
        // Create a new ApplicationUser.
        [HttpPost]
        public async Task<ActionResult<ApplicationUserCreateVM>> Create([FromBody] ApplicationUserCreateVM model)
        {
            if (model == null)
                return BadRequest("ApplicationUser data is required.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = _mapper.Map<ApplicationUserRequestDso>(model);
            var createdApplicationUser = await _applicationuserService.CreateAsync(item);
            var createdItem = _mapper.Map<ApplicationUserCreateVM>(createdApplicationUser);
            return CreatedAtAction(nameof(GetById), new { id = 0 }, createdItem);
        }

        // Create multiple ApplicationUsers.
        [HttpPost("createRange")]
        public async Task<ActionResult<IEnumerable<ApplicationUserCreateVM>>> CreateRange([FromBody] IEnumerable<ApplicationUserCreateVM> models)
        {
            if (models == null)
                return BadRequest("Data is required.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var items = _mapper.Map<List<ApplicationUserRequestDso>>(models);
            var createdApplicationUsers = await _applicationuserService.CreateRangeAsync(items);
            var createdItems = _mapper.Map<List<ApplicationUserCreateVM>>(createdApplicationUsers);
            return CreatedAtAction(nameof(GetAll), createdItems);
        }

        // Update an existing ApplicationUser.
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ApplicationUserUpdateVM model)
        {
            if (id <= 0 || model == null)
                return BadRequest("Invalid data.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = _mapper.Map<ApplicationUserRequestDso>(model);
            var updatedApplicationUser = await _applicationuserService.UpdateAsync(item);
            if (updatedApplicationUser == null)
                return NotFound();
            var updatedItem = _mapper.Map<ApplicationUserUpdateVM>(updatedApplicationUser);
            return Ok(updatedItem);
        }

        // Delete a ApplicationUser.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid ApplicationUser ID.");
            await _applicationuserService.DeleteAsync(id);
            return NoContent();
        }

        //// Delete multiple ApplicationUsers.
        //[HttpDelete("deleteRange")]
        //public async Task<IActionResult> DeleteRange([FromQuery] Expression<Func<ApplicationUserOutputVM, bool>> predicate)
        //{
        //    //await _applicationuserService.DeleteRangeAsync(predicate);
        //    return NoContent();
        //}
        //// Check if a ApplicationUser exists based on a predicate.
        //[HttpGet("exists")]
        //public async Task<ActionResult<bool>> Exists([FromQuery] Expression<Func<ApplicationUserOutputVM, bool>> predicate)
        //{
        //    //var exists = await _applicationuserService.ExistsAsync(predicate);
        //    return Ok();
        //}
        // Get count of ApplicationUsers.
        [HttpGet("count")]
        public async Task<ActionResult<int>> Count()
        {
            var count = await _applicationuserService.CountAsync();
            return Ok(count);
        }
    }
}