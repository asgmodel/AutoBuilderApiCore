
using AutoMapper;

using Microsoft.Extensions.Logging;


namespace AutoGenerator.Services.Base
{
    public interface IBaseService: ITBaseService
    {
    }
    public abstract class BaseService<TServiceRequestDso, TServiceResponseDso> : IBaseService
    {
        private readonly   IMapper _mapper;

        protected readonly ILogger _logger;

        public BaseService(IMapper mapper, ILoggerFactory logger)
        {
            _mapper = mapper;
            if (!IsAllowCreate())
            {
                throw new InvalidOperationException("Creation of this repository is not allowed for the specified types.");
            }
            _logger = logger.CreateLogger(typeof(BaseService<TServiceRequestDso, TServiceResponseDso>).FullName);
        }


        protected IMapper GetMapper()
        {
            return _mapper;
        }

        private static bool IsAllowCreate()
        {
            return 
                   typeof(ITDso).IsAssignableFrom(typeof(TServiceRequestDso)) &&
                   typeof(ITDso).IsAssignableFrom(typeof(TServiceResponseDso));
        }






    }




}
