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

        [HttpPost("create")]
        public async Task<IActionResult> CreateInvoice()
        {
            return Ok();
        }
    // You can add more actions like PUT, DELETE, etc., depending on the methods in your service interface.
    }
}