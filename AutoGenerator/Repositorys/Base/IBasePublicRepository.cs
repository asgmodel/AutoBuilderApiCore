using System.Linq.Expressions;

namespace AutoGenerator.Repositorys.Base
{
    public interface IBasePublicRepository<TRequest, TResponse> 
          where TRequest : class
          where TResponse : class
    {
        Task<IEnumerable<TResponse>> GetAllAsync();
        Task<TResponse?> GetByIdAsync(string id);
        Task<TResponse?> FindAsync(Expression<Func<TResponse, bool>> predicate);
        IQueryable<TResponse> GetQueryable();

        Task<TResponse> CreateAsync(TRequest entity);
        Task<IEnumerable<TResponse>> CreateRangeAsync(IEnumerable<TRequest> entities);

        Task<TResponse> UpdateAsync(TRequest entity);

        Task DeleteAsync(string id);
        Task DeleteRangeAsync(Expression<Func<TResponse, bool>> predicate);

        Task<bool> ExistsAsync(Expression<Func<TResponse, bool>> predicate);
        Task<int> CountAsync();

   

    }



}
