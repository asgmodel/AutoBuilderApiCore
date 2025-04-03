
using AutoGenerator.Repositorys.Base;
using AutoMapper;

using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace AutoGenerator.Services.Base
{
    public interface IBaseService: ITBaseService
    {
    }
    public abstract class BaseService<TServiceRequestDso, TServiceResponseDso> : IBasePublicRepository<TServiceRequestDso, TServiceResponseDso >, IBaseService
      where TServiceRequestDso : class
      where TServiceResponseDso : class
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

        public virtual Task<IEnumerable<TServiceResponseDso>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public virtual Task<TServiceResponseDso?> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<TServiceResponseDso?> FindAsync(Expression<Func<TServiceResponseDso, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual IQueryable<TServiceResponseDso> GetQueryable()
        {
            throw new NotImplementedException();
        }

        public virtual Task<TServiceResponseDso> CreateAsync(TServiceRequestDso entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task<IEnumerable<TServiceResponseDso>> CreateRangeAsync(IEnumerable<TServiceRequestDso> entities)
        {
            throw new NotImplementedException();
        }

        public virtual Task<TServiceResponseDso> UpdateAsync(TServiceRequestDso entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public virtual Task DeleteRangeAsync(Expression<Func<TServiceResponseDso, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> ExistsAsync(Expression<Func<TServiceResponseDso, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }
    }




}
