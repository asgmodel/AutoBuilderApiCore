using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using ApiCore.Services.Services;
using Microsoft.AspNetCore.Mvc;
using ApiCore.DyModels.VM.UserService;
using System.Linq.Expressions;
using ApiCore.DyModels.Dso.Requests;
using System;

namespace ApiCore.Controllers.Api
{
    [Route("api/Api/[controller]")]
    [ApiController]
    public class UserServiceController : ControllerBase
    {
        private readonly IUseUserServiceService _userserviceService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public UserServiceController(IUseUserServiceService userserviceService, IMapper mapper, ILoggerFactory logger)
        {
            _userserviceService = userserviceService;
            _mapper = mapper;
            _logger = logger.CreateLogger(typeof(UserServiceController).FullName);
        }

        // Get all UserServices.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserServiceOutputVM>>> GetAll()
        {
            var result = await _userserviceService.GetAllAsync();
            var items = _mapper.Map<List<UserServiceOutputVM>>(result);
            return Ok(items);
        }

        // Get a UserService by ID.
        [HttpGet("{id}")]
        public async Task<ActionResult<UserServiceInfoVM>> GetById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid UserService ID.");
            var userservice = await _userserviceService.GetByIdAsync(id);
            if (userservice == null)
                return NotFound();
            var item = _mapper.Map<UserServiceInfoVM>(userservice);
            return Ok(item);
        }

        //// Find a UserService by a specific predicate.
        //[HttpGet("find")]
        //public async Task<ActionResult<UserServiceInfoVM>> Find([FromQuery] Expression<Func<UserServiceOutputVM, bool>> predicate)
        //{
        //     return NotFound();
        //    //var userservice = await _userserviceService.FindAsync(predicate);
        //   // if (userservice == null) return NotFound();
        //   // var item = _mapper.Map<UserServiceInfoVM>(userservice);
        //   // return Ok(item);
        //}
        // Create a new UserService.
        [HttpPost]
        public async Task<ActionResult<UserServiceCreateVM>> Create([FromBody] UserServiceCreateVM model)
        {
            if (model == null)
                return BadRequest("UserService data is required.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = _mapper.Map<UserServiceRequestDso>(model);
            var createdUserService = await _userserviceService.CreateAsync(item);
            var createdItem = _mapper.Map<UserServiceCreateVM>(createdUserService);
            return CreatedAtAction(nameof(GetById), new { id = 0 }, createdItem);
        }

        // Create multiple UserServices.
        [HttpPost("createRange")]
        public async Task<ActionResult<IEnumerable<UserServiceCreateVM>>> CreateRange([FromBody] IEnumerable<UserServiceCreateVM> models)
        {
            if (models == null)
                return BadRequest("Data is required.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var items = _mapper.Map<List<UserServiceRequestDso>>(models);
            var createdUserServices = await _userserviceService.CreateRangeAsync(items);
            var createdItems = _mapper.Map<List<UserServiceCreateVM>>(createdUserServices);
            return CreatedAtAction(nameof(GetAll), createdItems);
        }

        // Update an existing UserService.
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UserServiceUpdateVM model)
        {
            if (id <= 0 || model == null)
                return BadRequest("Invalid data.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = _mapper.Map<UserServiceRequestDso>(model);
            var updatedUserService = await _userserviceService.UpdateAsync(item);
            if (updatedUserService == null)
                return NotFound();
            var updatedItem = _mapper.Map<UserServiceUpdateVM>(updatedUserService);
            return Ok(updatedItem);
        }

        // Delete a UserService.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid UserService ID.");
            await _userserviceService.DeleteAsync(id);
            return NoContent();
        }

        //// Delete multiple UserServices.
        //[HttpDelete("deleteRange")]
        //public async Task<IActionResult> DeleteRange([FromQuery] Expression<Func<UserServiceOutputVM, bool>> predicate)
        //{
        //    //await _userserviceService.DeleteRangeAsync(predicate);
        //    return NoContent();
        //}
        //// Check if a UserService exists based on a predicate.
        //[HttpGet("exists")]
        //public async Task<ActionResult<bool>> Exists([FromQuery] Expression<Func<UserServiceOutputVM, bool>> predicate)
        //{
        //    //var exists = await _userserviceService.ExistsAsync(predicate);
        //    return Ok();
        //}
        // Get count of UserServices.
        [HttpGet("count")]
        public async Task<ActionResult<int>> Count()
        {
            var count = await _userserviceService.CountAsync();
            return Ok(count);
        }
    }
}