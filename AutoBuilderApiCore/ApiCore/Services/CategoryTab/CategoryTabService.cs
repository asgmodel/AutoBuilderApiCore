using AutoGenerator.Data;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using AutoGenerator.Services.Base;
using ApiCore.DyModels.Dso.Requests;
using ApiCore.DyModels.Dso.Responses;
using AutoGenerator.Models;
using ApiCore.DyModels.Dto.Share.Requests;
using ApiCore.DyModels.Dto.Share.Responses;
using ApiCore.Repositorys.Share;
using System.Linq.Expressions;
using ApiCore.Repositorys.Builder;
using AutoGenerator.Repositorys.Base;
using System;

namespace ApiCore.Services.Services
{
    public class CategoryTabService : BaseService<CategoryTabRequestDso, CategoryTabResponseDso>, IUseCategoryTabService
    {
        private readonly ICategoryTabShareRepository _builder;
        private readonly ILogger _logger;
        public CategoryTabService(ICategoryTabShareRepository categorytabShareRepository, IMapper mapper, ILoggerFactory logger) : base(mapper, logger)
        {
            _builder = categorytabShareRepository;
            _logger = logger.CreateLogger(typeof(CategoryTabService).FullName);
        }

        public override Task<int> CountAsync()
        {
            try
            {
                _logger.LogInformation("Counting CategoryTab entities...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CountAsync for CategoryTab entities.");
                return Task.FromResult(0);
            }
        }

        public override async Task<CategoryTabResponseDso> CreateAsync(CategoryTabRequestDso entity)
        {
            try
            {
                _logger.LogInformation("Creating new CategoryTab entity...");
                var result = await _builder.CreateAsync(entity);
                var output = (CategoryTabResponseDso)result;
                _logger.LogInformation("Created CategoryTab entity successfully.");
                return output;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating CategoryTab entity.");
                return null;
            }
        }

        public override Task<IEnumerable<CategoryTabResponseDso>> CreateRangeAsync(IEnumerable<CategoryTabRequestDso> entities)
        {
            try
            {
                _logger.LogInformation("Creating a range of CategoryTab entities...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CreateRangeAsync for CategoryTab entities.");
                return Task.FromResult<IEnumerable<CategoryTabResponseDso>>(null);
            }
        }

        public override Task DeleteAsync(string id)
        {
            try
            {
                _logger.LogInformation($"Deleting CategoryTab entity with ID: {id}...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while deleting CategoryTab entity with ID: {id}.");
                return Task.CompletedTask;
            }
        }

        public override Task DeleteRangeAsync(Expression<Func<CategoryTabResponseDso, bool>> predicate)
        {
            try
            {
                _logger.LogInformation("Deleting a range of CategoryTab entities based on condition...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in DeleteRangeAsync for CategoryTab entities.");
                return Task.CompletedTask;
            }
        }

        public override Task<bool> ExistsAsync(Expression<Func<CategoryTabResponseDso, bool>> predicate)
        {
            try
            {
                _logger.LogInformation("Checking existence of CategoryTab entity based on condition...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in ExistsAsync for CategoryTab entity.");
                return Task.FromResult(false);
            }
        }

        public override Task<CategoryTabResponseDso?> FindAsync(Expression<Func<CategoryTabResponseDso, bool>> predicate)
        {
            try
            {
                _logger.LogInformation("Finding CategoryTab entity based on condition...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in FindAsync for CategoryTab entity.");
                return Task.FromResult<CategoryTabResponseDso>(null);
            }
        }

        public override Task<IEnumerable<CategoryTabResponseDso>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("Retrieving all CategoryTab entities...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetAllAsync for CategoryTab entities.");
                return Task.FromResult<IEnumerable<CategoryTabResponseDso>>(null);
            }
        }

        public override Task<CategoryTabResponseDso?> GetByIdAsync(string id)
        {
            try
            {
                _logger.LogInformation($"Retrieving CategoryTab entity with ID: {id}...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in GetByIdAsync for CategoryTab entity with ID: {id}.");
                return Task.FromResult<CategoryTabResponseDso>(null);
            }
        }

        public Task<CategoryTabResponseDso> getData(int id)
        {
            try
            {
                _logger.LogInformation($"Getting data for CategoryTab entity with numeric ID: {id}...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in getData for CategoryTab entity with numeric ID: {id}.");
                return Task.FromResult<CategoryTabResponseDso>(null);
            }
        }

        public override IQueryable<CategoryTabResponseDso> GetQueryable()
        {
            try
            {
                _logger.LogInformation("Retrieving IQueryable<CategoryTabResponseDso> for CategoryTab entities...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetQueryable for CategoryTab entities.");
                return null;
            }
        }

        public Task SaveChangesAsync()
        {
            try
            {
                _logger.LogInformation("Saving changes to the database for CategoryTab entities...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in SaveChangesAsync for CategoryTab entities.");
                return Task.CompletedTask;
            }
        }

        public override Task<CategoryTabResponseDso> UpdateAsync(CategoryTabRequestDso entity)
        {
            try
            {
                _logger.LogInformation("Updating CategoryTab entity...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in UpdateAsync for CategoryTab entity.");
                return Task.FromResult<CategoryTabResponseDso>(null);
            }
        }
    }
}