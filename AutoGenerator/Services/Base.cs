
using AutoMapper;

using Microsoft.Extensions.Logging;


namespace AutoGenerator.Services.Base
{

    public class BaseService :ITBaseService
    {
        protected readonly   IMapper _mapper;

        protected readonly ILogger _logger;

        public BaseService(IMapper mapper, ILoggerFactory logger)
        {
            _mapper = mapper;
            _logger = logger.CreateLogger(typeof(BaseService).FullName);
        }

       
        public IMapper GetMapper()
        {
            return _mapper;
        }
    }

}
