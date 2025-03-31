using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using ApiCore.Services.Services;
using Microsoft.AspNetCore.Mvc;
using ApiCore.DyModels.VM.Plan;
using System.Linq.Expressions;
using ApiCore.DyModels.Dso.Requests;
using System;

namespace ApiCore.Controllers.Api
{
    //[ApiExplorerSettings(GroupName = "ApiCore")]
    [Route("api/ApiCore/Api/[controller]")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        private readonly IUsePlanService _planService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public PlanController(IUsePlanService planService, IMapper mapper, ILoggerFactory logger)
        {
            _planService = planService;
            _mapper = mapper;
            _logger = logger.CreateLogger(typeof(PlanController).FullName);
        }

        // Get all Plans.
        [HttpGet(Name = "GetPlans")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<PlanOutputVM>>> GetAll()
        {
            var result = await _planService.GetAllAsync();
            var items = _mapper.Map<List<PlanOutputVM>>(result);
            return Ok(items);
        }

        // Get a Plan by ID.
        [HttpGet("{id}", Name = "GetPlan")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PlanInfoVM>> GetById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Plan ID.");
            var plan = await _planService.GetByIdAsync(id);
            if (plan == null)
                return NotFound();
            var item = _mapper.Map<PlanInfoVM>(plan);
            return Ok(item);
        }

        //// Find a Plan by a specific predicate.
        //[HttpGet("find")]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<PlanInfoVM>> Find([FromQuery] Expression<Func<PlanOutputVM, bool>> predicate)
        //{
        //     return NotFound();
        //    //var plan = await _planService.FindAsync(predicate);
        //   // if (plan == null) return NotFound();
        //   // var item = _mapper.Map<PlanInfoVM>(plan);
        //   // return Ok(item);
        //}
        // Create a new Plan.
        [HttpPost(Name = "CreatePlan")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PlanCreateVM>> Create([FromBody] PlanCreateVM model)
        {
            if (model == null)
                return BadRequest("Plan data is required.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = _mapper.Map<PlanRequestDso>(model);
            var createdPlan = await _planService.CreateAsync(item);
            var createdItem = _mapper.Map<PlanCreateVM>(createdPlan);
            return CreatedAtAction(nameof(GetById), new { id = 0 }, createdItem);
        }

        // Create multiple Plans.
        [HttpPost("createRange")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<PlanCreateVM>>> CreateRange([FromBody] IEnumerable<PlanCreateVM> models)
        {
            if (models == null)
                return BadRequest("Data is required.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var items = _mapper.Map<List<PlanRequestDso>>(models);
            var createdPlans = await _planService.CreateRangeAsync(items);
            var createdItems = _mapper.Map<List<PlanCreateVM>>(createdPlans);
            return CreatedAtAction(nameof(GetAll), createdItems);
        }

        // Update an existing Plan.
        [HttpPut("{id}", Name = "UpdatePlan")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] PlanUpdateVM model)
        {
            if (id <= 0 || model == null)
                return BadRequest("Invalid data.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = _mapper.Map<PlanRequestDso>(model);
            var updatedPlan = await _planService.UpdateAsync(item);
            if (updatedPlan == null)
                return NotFound();
            var updatedItem = _mapper.Map<PlanUpdateVM>(updatedPlan);
            return Ok(updatedItem);
        }

        // Delete a Plan.
        [HttpDelete("{id}", Name = "DeletePlan")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Plan ID.");
            await _planService.DeleteAsync(id);
            return NoContent();
        }

        //// Delete multiple Plans.
        //[HttpDelete("deleteRange")]
        //public async Task<IActionResult> DeleteRange([FromQuery] Expression<Func<PlanOutputVM, bool>> predicate)
        //{
        //    //await _planService.DeleteRangeAsync(predicate);
        //    return NoContent();
        //}
        //// Check if a Plan exists based on a predicate.
        //[HttpGet("exists")]
        //public async Task<ActionResult<bool>> Exists([FromQuery] Expression<Func<PlanOutputVM, bool>> predicate)
        //{
        //    //var exists = await _planService.ExistsAsync(predicate);
        //    return Ok();
        //}
        // Get count of Plans.
        [HttpGet("CountPlan")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> Count()
        {
            var count = await _planService.CountAsync();
            return Ok(count);
        }
    }
}