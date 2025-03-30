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
    public class PaymentController : ControllerBase
    {
        private readonly IUsePaymentService _paymentService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public PaymentController(IUsePaymentService paymentService, IMapper mapper, ILoggerFactory logger)
        {
            _paymentService = paymentService;
            _mapper = mapper;
            _logger = logger.CreateLogger(typeof(PaymentController).FullName);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateInvoice()
        {
            return Ok();
        }
    // You can add more actions like PUT, DELETE, etc., depending on the methods in your service interface.
    }
}