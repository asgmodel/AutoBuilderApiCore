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

        [HttpPost("create")]
        public async Task<IActionResult> CreateInvoice()
        {
            return Ok();
        }
    // You can add more actions like PUT, DELETE, etc., depending on the methods in your service interface.
    }
}