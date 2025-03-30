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
    public class ServiceMethodController : ControllerBase
    {
        private readonly IUseServiceMethodService _servicemethodService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public ServiceMethodController(IUseServiceMethodService servicemethodService, IMapper mapper, ILoggerFactory logger)
        {
            _servicemethodService = servicemethodService;
            _mapper = mapper;
            _logger = logger.CreateLogger(typeof(ServiceMethodController).FullName);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateInvoice()
        {
            return Ok();
        }
    // You can add more actions like PUT, DELETE, etc., depending on the methods in your service interface.
    }
}