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
    public class SubscriptionController : ControllerBase
    {
        private readonly IUseSubscriptionService _subscriptionService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public SubscriptionController(IUseSubscriptionService subscriptionService, IMapper mapper, ILoggerFactory logger)
        {
            _subscriptionService = subscriptionService;
            _mapper = mapper;
            _logger = logger.CreateLogger(typeof(SubscriptionController).FullName);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateInvoice()
        {
            return Ok();
        }
    // You can add more actions like PUT, DELETE, etc., depending on the methods in your service interface.
    }
}