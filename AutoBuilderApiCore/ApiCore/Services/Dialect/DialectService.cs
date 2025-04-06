using AutoGenerator;
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
using AutoGenerator.Helper;
using System;

namespace ApiCore.Services.Services
{
    public class DialectService : BaseService<DialectRequestDso, DialectResponseDso>, IUseDialectService
    {
        private readonly IDialectShareRepository _builder;
        public DialectService(IDialectShareRepository buildDialectShareRepository, IMapper mapper, ILoggerFactory logger) : base(mapper, logger)
        {
            _builder = buildDialectShareRepository;
        }

        public override Task<int> CountAsync()
        {
            try
            {
                _logger.LogInformation("Counting Dialect entities...");
                return _builder.CountAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CountAsync for Dialect entities.");
                return Task.FromResult(0);
            }
        }

        public override async Task<DialectResponseDso> CreateAsync(DialectRequestDso entity)
        {
            try
            {
                _logger.LogInformation("Creating new Dialect entity...");
                var result = await _builder.CreateAsync(entity);
                var output = GetMapper().Map<DialectResponseDso>(result);
                _logger.LogInformation("Created Dialect entity successfully.");
                return output;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating Dialect entity.");
                return null;
            }
        }

        public override Task DeleteAsync(string id)
        {
            try
            {
                _logger.LogInformation($"Deleting Dialect entity with ID: {id}...");
                return _builder.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while deleting Dialect entity with ID: {id}.");
                return Task.CompletedTask;
            }
        }

        public override async Task<IEnumerable<DialectResponseDso>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("Retrieving all Dialect entities...");
                var results = await _builder.GetAllAsync();
                return GetMapper().Map<IEnumerable<DialectResponseDso>>(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetAllAsync for Dialect entities.");
                return null;
            }
        }

        public override async Task<DialectResponseDso?> GetByIdAsync(string id)
        {
            try
            {
                _logger.LogInformation($"Retrieving Dialect entity with ID: {id}...");
                var result = await _builder.GetByIdAsync(id);
                var item = GetMapper().Map<DialectResponseDso>(result);
                _logger.LogInformation("Retrieved Dialect entity successfully.");
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in GetByIdAsync for Dialect entity with ID: {id}.");
                return null;
            }
        }

        public override IQueryable<DialectResponseDso> GetQueryable()
        {
            try
            {
                _logger.LogInformation("Retrieving IQueryable<DialectResponseDso> for Dialect entities...");
                var queryable = _builder.GetQueryable();
                var result = GetMapper().ProjectTo<DialectResponseDso>(queryable);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetQueryable for Dialect entities.");
                return null;
            }
        }

        public override async Task<DialectResponseDso> UpdateAsync(DialectRequestDso entity)
        {
            try
            {
                _logger.LogInformation("Updating Dialect entity...");
                var result = await _builder.UpdateAsync(entity);
                return GetMapper().Map<DialectResponseDso>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in UpdateAsync for Dialect entity.");
                return null;
            }
        }

        public override async Task<bool> ExistsAsync(object value, string name = "Id")
        {
            try
            {
                _logger.LogInformation("Checking if Dialect exists with {Key}: {Value}", name, value);
                var exists = await _builder.ExistsAsync(value, name);
                if (!exists)
                {
                    _logger.LogWarning("Dialect not found with {Key}: {Value}", name, value);
                }

                return exists;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while checking existence of Dialect with {Key}: {Value}", name, value);
                return false;
            }
        }

        public override async Task<PagedResponse<DialectResponseDso>> GetAllAsync(string[]? includes = null, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                _logger.LogInformation("Fetching all Dialects with pagination: Page {PageNumber}, Size {PageSize}", pageNumber, pageSize);
                var results = (await _builder.GetAllAsync(includes, pageNumber, pageSize));
                var items = GetMapper().Map<List<DialectResponseDso>>(results.Data);
                return new PagedResponse<DialectResponseDso>(items, results.PageNumber, results.PageSize, results.TotalPages);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching all Dialects.");
                return new PagedResponse<DialectResponseDso>(new List<DialectResponseDso>(), pageNumber, pageSize, 0);
            }
        }

        public override async Task<DialectResponseDso?> GetByIdAsync(object id)
        {
            try
            {
                _logger.LogInformation("Fetching Dialect by ID: {Id}", id);
                var result = await _builder.GetByIdAsync(id);
                if (result == null)
                {
                    _logger.LogWarning("Dialect not found with ID: {Id}", id);
                    return null;
                }

                _logger.LogInformation("Retrieved Dialect successfully.");
                return GetMapper().Map<DialectResponseDso>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while retrieving Dialect by ID: {Id}", id);
                return null;
            }
        }

        public override async Task DeleteAsync(object value, string key = "Id")
        {
            try
            {
                _logger.LogInformation("Deleting Dialect with {Key}: {Value}", key, value);
                await _builder.DeleteAsync(value, key);
                _logger.LogInformation("Dialect with {Key}: {Value} deleted successfully.", key, value);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting Dialect with {Key}: {Value}", key, value);
            }
        }

        public override async Task DeleteRange(List<DialectRequestDso> entities)
        {
            try
            {
                var builddtos = entities.OfType<DialectRequestShareDto>().ToList();
                _logger.LogInformation("Deleting {Count} Dialects...", 201);
                await _builder.DeleteRange(builddtos);
                _logger.LogInformation("{Count} Dialects deleted successfully.", 202);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting multiple Dialects.");
            }
        }

        public override async Task<PagedResponse<DialectResponseDso>> GetAllByAsync(List<FilterCondition> conditions, ParamOptions? options = null)
        {
            try
            {
                _logger.LogInformation("Retrieving all Dialect entities...");
                var results = await _builder.GetAllAsync();
                var response = await _builder.GetAllByAsync(conditions, options);
                return response.ToResponse(GetMapper().Map<IEnumerable<DialectResponseDso>>(response.Data));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetAllAsync for Dialect entities.");
                return null;
            }
        }

        public override async Task<DialectResponseDso?> GetOneByAsync(List<FilterCondition> conditions, ParamOptions? options = null)
        {
            try
            {
                _logger.LogInformation("Retrieving Dialect entity...");
                var results = await _builder.GetAllAsync();
                return GetMapper().Map<DialectResponseDso>(await _builder.GetOneByAsync(conditions, options));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetOneByAsync  for Dialect entity.");
                return null;
            }
        }
    }
}