using AutoGenerator.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
namespace AutoGenerator.Repositorys.Base
{
    public class RepositoryException : Exception
    {
        public RepositoryException(string message, Exception innerException)
            : base(message, innerException) { }
    }

    class RepositoryLogger { }
    public interface IBaseRepository<T> where T : class
    {
        long CounItems { get; }
        Task<T> GetByAsync(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IQueryable<T>>? setInclude = null, bool tracked = false);
        Task<T?> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> AttachAsync(T entity);
        Task RemoveAsync(T entity);
        Task RemoveAsync(Expression<Func<T, bool>> predicate);
        Task RemoveRange(List<T> entities);
        Task<int> SaveAsync();
        Task<bool> Exists(Expression<Func<T, bool>> filter);
        IBaseRepository<T> Include(Func<IQueryable<T>, IQueryable<T>> include);
        IBaseRepository<T> Includes(params string[] includes);
        IQueryable<T> GetAll(Expression<Func<T, bool>>? filter = null, string[]? includes = null, int skip = 0, int take = 0, bool isOrdered = false, Expression<Func<T, long>>? order = null);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IQueryable<T>>? include = null, int skip = 0, int take = 0, Expression<Func<T, object>>? order = null);
        Task RemoveAllAsync();
        IQueryable<T> Get(Expression<Func<T, bool>>? expression = null);

        Task<PagedResponse<T>> GetAllAsPaginateAsync(int pageNumber = 1, int pageSize = 10);
        Task<T> GetBy2Async(Expression<Func<T, bool>> filter, string[]? includes = null, bool noTracking = true);
        Task<T?> FindModelAsync(params object[] id);
        Task<int> RemoveRange(IEnumerable<T> entities);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> filter);
        IQueryable<T> GetQueryable(string[]? includes = null, bool noTracking = true);
    }

    public sealed class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DataContext _db;
        private readonly DbSet<T> _dbSet;
        private readonly ILogger _logger;
        public long CounItems { get => _count; }
        private long _count = 0;
        public IQueryable<T> query;

        public DbSet<T> DbSet => _dbSet;

        public BaseRepository(DataContext db, ILogger logger)
        {

            if (!IsAllowCreate())
            {
                throw new InvalidOperationException("Creation of this repository is not allowed for the specified types.");
            }
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _dbSet = _db.Set<T>();
            query = _dbSet.AsQueryable();
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        private static bool IsAllowCreate()
        {
            return typeof(ITModel).IsAssignableFrom(typeof(T));
        }

        public IQueryable<T> Get(Expression<Func<T, bool>>? expression = null)
        {
            if (expression != null) query = query.Where(expression);
            return query;
        }

        public IBaseRepository<T> Include(Func<IQueryable<T>, IQueryable<T>> include)
        {
            query = include(Get());
            return this;

        }

        public IBaseRepository<T> Includes(params string[] includes)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return this;

        }

        public async Task<T> GetByAsync(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IQueryable<T>>? setInclude = null, bool tracked = false)
        {
            try
            {
                if (!tracked) query = query.AsNoTracking();
                if (filter != null) query = query.Where(filter);
                if (setInclude != null) query = setInclude(query);
                return await query.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving entity");
                throw new RepositoryException("Error retrieving entity", ex);
            }
        }

        public async Task<T?> CreateAsync(T entity)
        {
            try
            {
                var item = (await _dbSet.AddAsync(entity)).Entity;
              //  await SaveAsync();
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating entity");
                return null;
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            try
            {
                _db.ChangeTracker.Clear();
                var item = _dbSet.Update(entity).Entity;
                await SaveAsync();
                return item;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError(ex, "Concurrency error during update");
                throw new RepositoryException("Concurrency error during update", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating entity");
                throw new RepositoryException("Error updating entity", ex);
            }
        }

        public async Task<T> AttachAsync(T entity)
        {
            try
            {
                _dbSet.Attach(entity);
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error attaching entity");
                throw new RepositoryException("Error attaching entity", ex);
            }
        }

        public async Task RemoveAsync(T entity)
        {
            try
            {
                if (_db.Entry(entity).State == EntityState.Detached)
                    _dbSet.Attach(entity);
                _dbSet.Remove(entity);
                await SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error removing entity");
                throw new RepositoryException("Error removing entity", ex);
            }
        }

        public async Task RemoveAsync(Expression<Func<T, bool>> predicate)
        {
            try
            {
                await _dbSet.Where(predicate).ExecuteDeleteAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error removing entities");
                throw new RepositoryException("Error removing entities", ex);
            }
        }

        public async Task RemoveAllAsync()
        {
            try
            {
                await _dbSet.ExecuteDeleteAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error removing all entities");
                throw new RepositoryException("Error removing all entities", ex);
            }
        }

        public async Task<int> SaveAsync()
        {
            try
            {
                return await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving changes");
                throw new RepositoryException("Error saving changes", ex);
            }
        }

        public async Task<bool> Exists(Expression<Func<T, bool>> filter)
        {
            try
            {
                return await _dbSet.AnyAsync(filter);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error checking existence");
                throw new RepositoryException("Error checking existence", ex);
            }
        }

        public static IQueryable<T> SetSkipAndTake(IQueryable<T> query, int skip, int take)
        {
            if (skip >= 0) query = query.Skip(skip);
            if (take > 0) query = query.Take(take);
            return query;
        }

        // Handle transactions: to ensure multiple operations are executed as a single unit
        public async Task<bool> ExecuteTransactionAsync(Func<Task<bool>> operation)
        {
            using var transaction = await _db.Database.BeginTransactionAsync();
            try
            {
                bool result = await operation();
                if (result)
                {
                    await transaction.CommitAsync();
                }
                else
                {
                    await transaction.RollbackAsync();
                }
                return result;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, "Error during transaction");
                throw new RepositoryException("Error during transaction", ex);
            }
        }

        public async Task RemoveRange(List<T> entities)
        {
            try
            {
                _dbSet.RemoveRange(entities);
                await SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error removing entity");
                throw new RepositoryException("Error removing entity", ex);
            }
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>>? filter = null, string[]? includes = null, int skip = 0, int take = 0, bool isOrdered = false, Expression<Func<T, long>>? order = null)
        {
            try
            {
                query = query.AsNoTracking();
                if (includes != null) Includes(includes);
                return query;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving entity");
                throw new RepositoryException("Error retrieving entity", ex);
            }
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IQueryable<T>>? include = null, int skip = 0, int take = 0, Expression<Func<T, object>>? order = null)
        {
            try
            {
                query = query.AsNoTracking();
                if (filter != null) query = query.Where(filter);
                if (include != null) Include(include);
                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving entity");
                throw new RepositoryException("Error retrieving entity", ex);
            }
        }

        public async Task<PagedResponse<T>> GetAllAsPaginateAsync(int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                return await query.AsNoTracking()
                    .ToPagedResponseAsync<T>(pageNumber, pageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving entity");
                throw new RepositoryException("Error retrieving entity", ex);
            }
        }

        public async Task<T> GetBy2Async(Expression<Func<T, bool>> filter, string[]? includes = null, bool noTracking = true)
        {
            try
            {
                if (noTracking) query = query.AsNoTracking();
                if (filter != null) query = query.Where(filter);
                if (includes != null) Includes(includes);
                return await query.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving entity");
                throw new RepositoryException("Error retrieving entity", ex);
            }
        }

        public async Task<T?> FindModelAsync(params object[] id)
        {
            var entity = await _dbSet.FindAsync(id);
            return entity;
        }


        public async Task<int> RemoveRange(IEnumerable<T> entities)
        {
            try
            {
                _dbSet.RemoveRange(entities);
                return await SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error removing entity");
                throw new RepositoryException("Error removing entity", ex);
            }
        }

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> filter)
        {
            try
            {
                return await _dbSet.AnyAsync(filter);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error checking existence");
                throw new RepositoryException("Error checking existence", ex);
            }
        }

        public IQueryable<T> GetQueryable(string[]? includes = null, bool noTracking = true)
        {
            try
            {
                if (noTracking) query = query.AsNoTracking();
                if (includes != null) Includes(includes);
                return query;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving entity");
                throw new RepositoryException("Error retrieving entity", ex);
            }
        }
    }

    public static class PagedResponseExtensions
    {
        public static async Task<PagedResponse<T>> ToPagedResponseAsync<T>(
            this IQueryable<T> query,
            int pageNumber,
            int pageSize)
        {
            var totalRecords = await query.CountAsync();
            var data = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResponse<T>(data, pageNumber, pageSize, totalRecords);
        }
    }
}
