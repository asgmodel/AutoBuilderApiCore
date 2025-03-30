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
    public class UserModelAiController : ControllerBase
    {
        private readonly IUseUserModelAiService _usermodelaiService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public UserModelAiController(IUseUserModelAiService usermodelaiService, IMapper mapper, ILoggerFactory logger)
        {
            _usermodelaiService = usermodelaiService;
            _mapper = mapper;
            _logger = logger.CreateLogger(typeof(UserModelAiController).FullName);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateInvoice()
        {
            return Ok();
        }
    // You can add more actions like PUT, DELETE, etc., depending on the methods in your service interface.
    }
}