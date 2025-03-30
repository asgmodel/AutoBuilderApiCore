using AutoMapper;
using Dso.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Services;
using System;
using System.Collections.Generic;
using VM.Invoice;

namespace Controllers.Api
{
    [Route("api/Api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IUseInvoiceService _invoiceService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public InvoiceController(IUseInvoiceService invoiceService, IMapper mapper, ILoggerFactory logger)
        {
            _invoiceService = invoiceService;
            _mapper = mapper;
            _logger = logger.CreateLogger(typeof(InvoiceController).FullName);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateInvoice(InvoiceCreateVM createVM)
        {

            var item = _mapper.Map<InvoiceRequestDso>(createVM);
            _invoiceService.CreateAsync(item);
            return Ok();
        }
    // You can add more actions like PUT, DELETE, etc., depending on the methods in your service interface.
    }
}