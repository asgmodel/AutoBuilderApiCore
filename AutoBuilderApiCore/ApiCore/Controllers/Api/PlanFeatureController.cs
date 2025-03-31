using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Services.Services;
using Microsoft.AspNetCore.Mvc;
using VM.PlanFeature;
using System.Linq.Expressions;
using Dso.Requests;
using System;

namespace Controllers.Api
{
    [Route("api/Api/[controller]")]
    [ApiController]
    public class PlanFeatureController : ControllerBase
    {
        private readonly IUsePlanFeatureService _planfeatureService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public PlanFeatureController(IUsePlanFeatureService planfeatureService, IMapper mapper, ILoggerFactory logger)
        {
            _planfeatureService = planfeatureService;
            _mapper = mapper;
            _logger = logger.CreateLogger(typeof(PlanFeatureController).FullName);
        }

        // Get all PlanFeatures.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlanFeatureOutputVM>>> GetAll()
        {
            var result = await _planfeatureService.GetAllAsync();
            var items = _mapper.Map<List<PlanFeatureOutputVM>>(result);
            return Ok(items);
        }

        // Get a PlanFeature by ID.
        [HttpGet("{id}")]
        public async Task<ActionResult<PlanFeatureInfoVM>> GetById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid PlanFeature ID.");
            var planfeature = await _planfeatureService.GetByIdAsync(id);
            if (planfeature == null)
                return NotFound();
            var item = _mapper.Map<PlanFeatureInfoVM>(planfeature);
            return Ok(item);
        }

        //// Find a PlanFeature by a specific predicate.
        //[HttpGet("find")]
        //public async Task<ActionResult<PlanFeatureInfoVM>> Find([FromQuery] Expression<Func<PlanFeatureOutputVM, bool>> predicate)
        //{
        //     return NotFound();
        //    //var planfeature = await _planfeatureService.FindAsync(predicate);
        //   // if (planfeature == null) return NotFound();
        //   // var item = _mapper.Map<PlanFeatureInfoVM>(planfeature);
        //   // return Ok(item);
        //}
        // Create a new PlanFeature.
        [HttpPost]
        public async Task<ActionResult<PlanFeatureCreateVM>> Create([FromBody] PlanFeatureCreateVM model)
        {
            if (model == null)
                return BadRequest("PlanFeature data is required.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = _mapper.Map<PlanFeatureRequestDso>(model);
            var createdPlanFeature = await _planfeatureService.CreateAsync(item);
            var createdItem = _mapper.Map<PlanFeatureCreateVM>(createdPlanFeature);
            return CreatedAtAction(nameof(GetById), new { id = 0 }, createdItem);
        }

        // Create multiple PlanFeatures.
        [HttpPost("createRange")]
        public async Task<ActionResult<IEnumerable<PlanFeatureCreateVM>>> CreateRange([FromBody] IEnumerable<PlanFeatureCreateVM> models)
        {
            if (models == null)
                return BadRequest("Data is required.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var items = _mapper.Map<List<PlanFeatureRequestDso>>(models);
            var createdPlanFeatures = await _planfeatureService.CreateRangeAsync(items);
            var createdItems = _mapper.Map<List<PlanFeatureCreateVM>>(createdPlanFeatures);
            return CreatedAtAction(nameof(GetAll), createdItems);
        }

        // Update an existing PlanFeature.
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PlanFeatureUpdateVM model)
        {
            if (id <= 0 || model == null)
                return BadRequest("Invalid data.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = _mapper.Map<PlanFeatureRequestDso>(model);
            var updatedPlanFeature = await _planfeatureService.UpdateAsync(item);
            if (updatedPlanFeature == null)
                return NotFound();
            var updatedItem = _mapper.Map<PlanFeatureUpdateVM>(updatedPlanFeature);
            return Ok(updatedItem);
        }

        // Delete a PlanFeature.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid PlanFeature ID.");
            await _planfeatureService.DeleteAsync(id);
            return NoContent();
        }

        //// Delete multiple PlanFeatures.
        //[HttpDelete("deleteRange")]
        //public async Task<IActionResult> DeleteRange([FromQuery] Expression<Func<PlanFeatureOutputVM, bool>> predicate)
        //{
        //    //await _planfeatureService.DeleteRangeAsync(predicate);
        //    return NoContent();
        //}
        //// Check if a PlanFeature exists based on a predicate.
        //[HttpGet("exists")]
        //public async Task<ActionResult<bool>> Exists([FromQuery] Expression<Func<PlanFeatureOutputVM, bool>> predicate)
        //{
        //    //var exists = await _planfeatureService.ExistsAsync(predicate);
        //    return Ok();
        //}
        // Get count of PlanFeatures.
        [HttpGet("count")]
        public async Task<ActionResult<int>> Count()
        {
            var count = await _planfeatureService.CountAsync();
            return Ok(count);
        }
    }
}