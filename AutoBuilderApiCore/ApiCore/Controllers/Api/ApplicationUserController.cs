using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Services.Services;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("create")]
        public async Task<IActionResult> CreateInvoice()
        {
            return Ok();
        }
    // You can add more actions like PUT, DELETE, etc., depending on the methods in your service interface.
    }
}