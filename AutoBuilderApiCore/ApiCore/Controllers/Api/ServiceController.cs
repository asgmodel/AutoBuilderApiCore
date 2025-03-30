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
    public class ServiceController : ControllerBase
    {
        private readonly IUseServiceService _serviceService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public ServiceController(IUseServiceService serviceService, IMapper mapper, ILoggerFactory logger)
        {
            _serviceService = serviceService;
            _mapper = mapper;
            _logger = logger.CreateLogger(typeof(ServiceController).FullName);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateInvoice()
        {
            return Ok();
        }
    // You can add more actions like PUT, DELETE, etc., depending on the methods in your service interface.
    }
}