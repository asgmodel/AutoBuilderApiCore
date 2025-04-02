using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using ApiCore.Services.Services;
using Microsoft.AspNetCore.Mvc;
using ApiCore.DyModels.VM.Advertisement;
using System.Linq.Expressions;
using ApiCore.DyModels.Dso.Requests;
using System;

namespace ApiCore.Controllers.Api
{
    //[ApiExplorerSettings(GroupName = "ApiCore")]
    [Route("api/ApiCore/Api/[controller]")]
    [ApiController]
    public class AdvertisementController : ControllerBase
    {
        private readonly IUseAdvertisementService _advertisementService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public AdvertisementController(IUseAdvertisementService advertisementService, IMapper mapper, ILoggerFactory logger)
        {
            _advertisementService = advertisementService;
            _mapper = mapper;
            _logger = logger.CreateLogger(typeof(AdvertisementController).FullName);
        }

        // Get all Advertisements.
        [HttpGet(Name = "GetAdvertisements")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<AdvertisementOutputVM>>> GetAll()
        {
            var result = await _advertisementService.GetAllAsync();
            var items = _mapper.Map<List<AdvertisementOutputVM>>(result);
            return Ok(items);
        }

        // Get a Advertisement by ID.
        [HttpGet("{id}", Name = "GetAdvertisement")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AdvertisementInfoVM>> GetById(string? id)
        {
            if (id == "")
                return BadRequest("Invalid Advertisement ID.");
            var advertisement = await _advertisementService.GetByIdAsync(id);
            if (advertisement == null)
                return NotFound();
            var item = _mapper.Map<AdvertisementInfoVM>(advertisement);
            return Ok(item);
        }

        //// Find a Advertisement by a specific predicate.
        //[HttpGet("find")]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<AdvertisementInfoVM>> Find([FromQuery] Expression<Func<AdvertisementOutputVM, bool>> predicate)
        //{
        //     return NotFound();
        //    //var advertisement = await _advertisementService.FindAsync(predicate);
        //   // if (advertisement == null) return NotFound();
        //   // var item = _mapper.Map<AdvertisementInfoVM>(advertisement);
        //   // return Ok(item);
        //}
        // Create a new Advertisement.
        [HttpPost(Name = "CreateAdvertisement")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AdvertisementCreateVM>> Create([FromBody] AdvertisementCreateVM model)
        {
            if (model == null)
                return BadRequest("Advertisement data is required.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = _mapper.Map<AdvertisementRequestDso>(model);
            var createdAdvertisement = await _advertisementService.CreateAsync(item);
            var createdItem = _mapper.Map<AdvertisementCreateVM>(createdAdvertisement);
            return CreatedAtAction(nameof(GetById), new { id = 0 }, createdItem);
        }

        // Create multiple Advertisements.
        [HttpPost("createRange")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<AdvertisementCreateVM>>> CreateRange([FromBody] IEnumerable<AdvertisementCreateVM> models)
        {
            if (models == null)
                return BadRequest("Data is required.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var items = _mapper.Map<List<AdvertisementRequestDso>>(models);
            var createdAdvertisements = await _advertisementService.CreateRangeAsync(items);
            var createdItems = _mapper.Map<List<AdvertisementCreateVM>>(createdAdvertisements);
            return CreatedAtAction(nameof(GetAll), createdItems);
        }

        // Update an existing Advertisement.
        [HttpPut("{id}", Name = "UpdateAdvertisement")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] AdvertisementUpdateVM model)
        {
            if (id <= 0 || model == null)
                return BadRequest("Invalid data.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = _mapper.Map<AdvertisementRequestDso>(model);
            var updatedAdvertisement = await _advertisementService.UpdateAsync(item);
            if (updatedAdvertisement == null)
                return NotFound();
            var updatedItem = _mapper.Map<AdvertisementUpdateVM>(updatedAdvertisement);
            return Ok(updatedItem);
        }

        // Delete a Advertisement.
        [HttpDelete("{id}", Name = "DeleteAdvertisement")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == "")
                return BadRequest("Invalid Advertisement ID.");
            await _advertisementService.DeleteAsync(id);
            return NoContent();
        }

        //// Delete multiple Advertisements.
        //[HttpDelete("deleteRange")]
        //public async Task<IActionResult> DeleteRange([FromQuery] Expression<Func<AdvertisementOutputVM, bool>> predicate)
        //{
        //    //await _advertisementService.DeleteRangeAsync(predicate);
        //    return NoContent();
        //}
        //// Check if a Advertisement exists based on a predicate.
        //[HttpGet("exists")]
        //public async Task<ActionResult<bool>> Exists([FromQuery] Expression<Func<AdvertisementOutputVM, bool>> predicate)
        //{
        //    //var exists = await _advertisementService.ExistsAsync(predicate);
        //    return Ok();
        //}
        // Get count of Advertisements.
        [HttpGet("CountAdvertisement")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> Count()
        {
            var count = await _advertisementService.CountAsync();
            return Ok(count);
        }
    }
}