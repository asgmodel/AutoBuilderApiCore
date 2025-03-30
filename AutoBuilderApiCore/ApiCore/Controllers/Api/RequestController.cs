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
    public class RequestController : ControllerBase
    {
        private readonly IUseRequestService _requestService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public RequestController(IUseRequestService requestService, IMapper mapper, ILoggerFactory logger)
        {
            _requestService = requestService;
            _mapper = mapper;
            _logger = logger.CreateLogger(typeof(RequestController).FullName);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateInvoice()
        {
            return Ok();
        }
    // You can add more actions like PUT, DELETE, etc., depending on the methods in your service interface.
    }
}