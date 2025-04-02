using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using ApiCore.Services.Services;
using Microsoft.AspNetCore.Mvc;
using ApiCore.DyModels.VM.AdvertisementTab;
using System.Linq.Expressions;
using ApiCore.DyModels.Dso.Requests;
using System;

namespace ApiCore.Controllers.Api
{
    //[ApiExplorerSettings(GroupName = "ApiCore")]
    [Route("api/ApiCore/Api/[controller]")]
    [ApiController]
    public class AdvertisementTabController : ControllerBase
    {
        private readonly IUseAdvertisementTabService _advertisementtabService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public AdvertisementTabController(IUseAdvertisementTabService advertisementtabService, IMapper mapper, ILoggerFactory logger)
        {
            _advertisementtabService = advertisementtabService;
            _mapper = mapper;
            _logger = logger.CreateLogger(typeof(AdvertisementTabController).FullName);
        }

        // Get all AdvertisementTabs.
        [HttpGet(Name = "GetAdvertisementTabs")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<AdvertisementTabOutputVM>>> GetAll()
        {
            var result = await _advertisementtabService.GetAllAsync();
            var items = _mapper.Map<List<AdvertisementTabOutputVM>>(result);
            return Ok(items);
        }

        // Get a AdvertisementTab by ID.
        [HttpGet("{id}", Name = "GetAdvertisementTab")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AdvertisementTabInfoVM>> GetById(string? id)
        {
            if (id == "")
                return BadRequest("Invalid AdvertisementTab ID.");
            var advertisementtab = await _advertisementtabService.GetByIdAsync(id);
            if (advertisementtab == null)
                return NotFound();
            var item = _mapper.Map<AdvertisementTabInfoVM>(advertisementtab);
            return Ok(item);
        }

        //// Find a AdvertisementTab by a specific predicate.
        //[HttpGet("find")]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<AdvertisementTabInfoVM>> Find([FromQuery] Expression<Func<AdvertisementTabOutputVM, bool>> predicate)
        //{
        //     return NotFound();
        //    //var advertisementtab = await _advertisementtabService.FindAsync(predicate);
        //   // if (advertisementtab == null) return NotFound();
        //   // var item = _mapper.Map<AdvertisementTabInfoVM>(advertisementtab);
        //   // return Ok(item);
        //}
        // Create a new AdvertisementTab.
        [HttpPost(Name = "CreateAdvertisementTab")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AdvertisementTabCreateVM>> Create([FromBody] AdvertisementTabCreateVM model)
        {
            if (model == null)
                return BadRequest("AdvertisementTab data is required.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = _mapper.Map<AdvertisementTabRequestDso>(model);
            var createdAdvertisementTab = await _advertisementtabService.CreateAsync(item);
            var createdItem = _mapper.Map<AdvertisementTabCreateVM>(createdAdvertisementTab);
            return CreatedAtAction(nameof(GetById), new { id = 0 }, createdItem);
        }

        // Create multiple AdvertisementTabs.
        [HttpPost("createRange")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<AdvertisementTabCreateVM>>> CreateRange([FromBody] IEnumerable<AdvertisementTabCreateVM> models)
        {
            if (models == null)
                return BadRequest("Data is required.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var items = _mapper.Map<List<AdvertisementTabRequestDso>>(models);
            var createdAdvertisementTabs = await _advertisementtabService.CreateRangeAsync(items);
            var createdItems = _mapper.Map<List<AdvertisementTabCreateVM>>(createdAdvertisementTabs);
            return CreatedAtAction(nameof(GetAll), createdItems);
        }

        // Update an existing AdvertisementTab.
        [HttpPut("{id}", Name = "UpdateAdvertisementTab")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] AdvertisementTabUpdateVM model)
        {
            if (id <= 0 || model == null)
                return BadRequest("Invalid data.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = _mapper.Map<AdvertisementTabRequestDso>(model);
            var updatedAdvertisementTab = await _advertisementtabService.UpdateAsync(item);
            if (updatedAdvertisementTab == null)
                return NotFound();
            var updatedItem = _mapper.Map<AdvertisementTabUpdateVM>(updatedAdvertisementTab);
            return Ok(updatedItem);
        }

        // Delete a AdvertisementTab.
        [HttpDelete("{id}", Name = "DeleteAdvertisementTab")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == "")
                return BadRequest("Invalid AdvertisementTab ID.");
            await _advertisementtabService.DeleteAsync(id);
            return NoContent();
        }

        //// Delete multiple AdvertisementTabs.
        //[HttpDelete("deleteRange")]
        //public async Task<IActionResult> DeleteRange([FromQuery] Expression<Func<AdvertisementTabOutputVM, bool>> predicate)
        //{
        //    //await _advertisementtabService.DeleteRangeAsync(predicate);
        //    return NoContent();
        //}
        //// Check if a AdvertisementTab exists based on a predicate.
        //[HttpGet("exists")]
        //public async Task<ActionResult<bool>> Exists([FromQuery] Expression<Func<AdvertisementTabOutputVM, bool>> predicate)
        //{
        //    //var exists = await _advertisementtabService.ExistsAsync(predicate);
        //    return Ok();
        //}
        // Get count of AdvertisementTabs.
        [HttpGet("CountAdvertisementTab")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> Count()
        {
            var count = await _advertisementtabService.CountAsync();
            return Ok(count);
        }
    }
}