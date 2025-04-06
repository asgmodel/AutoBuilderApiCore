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
    public class ServiceMethodService : BaseService<ServiceMethodRequestDso, ServiceMethodResponseDso>, IUseServiceMethodService
    {
        private readonly IServiceMethodShareRepository _builder;
        public ServiceMethodService(IServiceMethodShareRepository buildServiceMethodShareRepository, IMapper mapper, ILoggerFactory logger) : base(mapper, logger)
        {
            _builder = buildServiceMethodShareRepository;
        }

        public override Task<int> CountAsync()
        {
            try
            {
                _logger.LogInformation("Counting ServiceMethod entities...");
                return _builder.CountAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CountAsync for ServiceMethod entities.");
                return Task.FromResult(0);
            }
        }

        public override async Task<ServiceMethodResponseDso> CreateAsync(ServiceMethodRequestDso entity)
        {
            try
            {
                _logger.LogInformation("Creating new ServiceMethod entity...");
                var result = await _builder.CreateAsync(entity);
                var output = GetMapper().Map<ServiceMethodResponseDso>(result);
                _logger.LogInformation("Created ServiceMethod entity successfully.");
                return output;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating ServiceMethod entity.");
                return null;
            }
        }

        public override Task DeleteAsync(string id)
        {
            try
            {
                _logger.LogInformation($"Deleting ServiceMethod entity with ID: {id}...");
                return _builder.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while deleting ServiceMethod entity with ID: {id}.");
                return Task.CompletedTask;
            }
        }

        public override async Task<IEnumerable<ServiceMethodResponseDso>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("Retrieving all ServiceMethod entities...");
                var results = await _builder.GetAllAsync();
                return GetMapper().Map<IEnumerable<ServiceMethodResponseDso>>(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetAllAsync for ServiceMethod entities.");
                return null;
            }
        }

        public override async Task<ServiceMethodResponseDso?> GetByIdAsync(string id)
        {
            try
            {
                _logger.LogInformation($"Retrieving ServiceMethod entity with ID: {id}...");
                var result = await _builder.GetByIdAsync(id);
                var item = GetMapper().Map<ServiceMethodResponseDso>(result);
                _logger.LogInformation("Retrieved ServiceMethod entity successfully.");
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in GetByIdAsync for ServiceMethod entity with ID: {id}.");
                return null;
            }
        }

        public override IQueryable<ServiceMethodResponseDso> GetQueryable()
        {
            try
            {
                _logger.LogInformation("Retrieving IQueryable<ServiceMethodResponseDso> for ServiceMethod entities...");
                var queryable = _builder.GetQueryable();
                var result = GetMapper().ProjectTo<ServiceMethodResponseDso>(queryable);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetQueryable for ServiceMethod entities.");
                return null;
            }
        }

        public override async Task<ServiceMethodResponseDso> UpdateAsync(ServiceMethodRequestDso entity)
        {
            try
            {
                _logger.LogInformation("Updating ServiceMethod entity...");
                var result = await _builder.UpdateAsync(entity);
                return GetMapper().Map<ServiceMethodResponseDso>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in UpdateAsync for ServiceMethod entity.");
                return null;
            }
        }

        public override async Task<bool> ExistsAsync(object value, string name = "Id")
        {
            try
            {
                _logger.LogInformation("Checking if ServiceMethod exists with {Key}: {Value}", name, value);
                var exists = await _builder.ExistsAsync(value, name);
                if (!exists)
                {
                    _logger.LogWarning("ServiceMethod not found with {Key}: {Value}", name, value);
                }

                return exists;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while checking existence of ServiceMethod with {Key}: {Value}", name, value);
                return false;
            }
        }

        public override async Task<PagedResponse<ServiceMethodResponseDso>> GetAllAsync(string[]? includes = null, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                _logger.LogInformation("Fetching all ServiceMethods with pagination: Page {PageNumber}, Size {PageSize}", pageNumber, pageSize);
                var results = (await _builder.GetAllAsync(includes, pageNumber, pageSize));
                var items = GetMapper().Map<List<ServiceMethodResponseDso>>(results.Data);
                return new PagedResponse<ServiceMethodResponseDso>(items, results.PageNumber, results.PageSize, results.TotalPages);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching all ServiceMethods.");
                return new PagedResponse<ServiceMethodResponseDso>(new List<ServiceMethodResponseDso>(), pageNumber, pageSize, 0);
            }
        }

        public override async Task<ServiceMethodResponseDso?> GetByIdAsync(object id)
        {
            try
            {
                _logger.LogInformation("Fetching ServiceMethod by ID: {Id}", id);
                var result = await _builder.GetByIdAsync(id);
                if (result == null)
                {
                    _logger.LogWarning("ServiceMethod not found with ID: {Id}", id);
                    return null;
                }

                _logger.LogInformation("Retrieved ServiceMethod successfully.");
                return GetMapper().Map<ServiceMethodResponseDso>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while retrieving ServiceMethod by ID: {Id}", id);
                return null;
            }
        }

        public override async Task DeleteAsync(object value, string key = "Id")
        {
            try
            {
                _logger.LogInformation("Deleting ServiceMethod with {Key}: {Value}", key, value);
                await _builder.DeleteAsync(value, key);
                _logger.LogInformation("ServiceMethod with {Key}: {Value} deleted successfully.", key, value);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting ServiceMethod with {Key}: {Value}", key, value);
            }
        }

        public override async Task DeleteRange(List<ServiceMethodRequestDso> entities)
        {
            try
            {
                var builddtos = entities.OfType<ServiceMethodRequestShareDto>().ToList();
                _logger.LogInformation("Deleting {Count} ServiceMethods...", 201);
                await _builder.DeleteRange(builddtos);
                _logger.LogInformation("{Count} ServiceMethods deleted successfully.", 202);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting multiple ServiceMethods.");
            }
        }

        public override async Task<PagedResponse<ServiceMethodResponseDso>> GetAllByAsync(List<FilterCondition> conditions, ParamOptions? options = null)
        {
            try
            {
                _logger.LogInformation("Retrieving all ServiceMethod entities...");
                var results = await _builder.GetAllAsync();
                var response = await _builder.GetAllByAsync(conditions, options);
                return response.ToResponse(GetMapper().Map<IEnumerable<ServiceMethodResponseDso>>(response.Data));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetAllAsync for ServiceMethod entities.");
                return null;
            }
        }

        public override async Task<ServiceMethodResponseDso?> GetOneByAsync(List<FilterCondition> conditions, ParamOptions? options = null)
        {
            try
            {
                _logger.LogInformation("Retrieving ServiceMethod entity...");
                var results = await _builder.GetAllAsync();
                return GetMapper().Map<ServiceMethodResponseDso>(await _builder.GetOneByAsync(conditions, options));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetOneByAsync  for ServiceMethod entity.");
                return null;
            }
        }
    }
}