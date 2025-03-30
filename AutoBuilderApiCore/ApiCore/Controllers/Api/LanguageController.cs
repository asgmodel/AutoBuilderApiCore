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
    public class LanguageController : ControllerBase
    {
        private readonly IUseLanguageService _languageService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public LanguageController(IUseLanguageService languageService, IMapper mapper, ILoggerFactory logger)
        {
            _languageService = languageService;
            _mapper = mapper;
            _logger = logger.CreateLogger(typeof(LanguageController).FullName);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateInvoice()
        {
            return Ok();
        }
    // You can add more actions like PUT, DELETE, etc., depending on the methods in your service interface.
    }
}