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
    public class SpaceService : BaseService<SpaceRequestDso, SpaceResponseDso>, IUseSpaceService
    {
        private readonly ISpaceShareRepository _builder;
        public SpaceService(ISpaceShareRepository buildSpaceShareRepository, IMapper mapper, ILoggerFactory logger) : base(mapper, logger)
        {
            _builder = buildSpaceShareRepository;
        }

        public override Task<int> CountAsync()
        {
            try
            {
                _logger.LogInformation("Counting Space entities...");
                return _builder.CountAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CountAsync for Space entities.");
                return Task.FromResult(0);
            }
        }

        public override async Task<SpaceResponseDso> CreateAsync(SpaceRequestDso entity)
        {
            try
            {
                _logger.LogInformation("Creating new Space entity...");
                var result = await _builder.CreateAsync(entity);
                var output = GetMapper().Map<SpaceResponseDso>(result);
                _logger.LogInformation("Created Space entity successfully.");
                return output;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating Space entity.");
                return null;
            }
        }

        public override Task DeleteAsync(string id)
        {
            try
            {
                _logger.LogInformation($"Deleting Space entity with ID: {id}...");
                return _builder.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while deleting Space entity with ID: {id}.");
                return Task.CompletedTask;
            }
        }

        public override async Task<IEnumerable<SpaceResponseDso>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("Retrieving all Space entities...");
                var results = await _builder.GetAllAsync();
                return GetMapper().Map<IEnumerable<SpaceResponseDso>>(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetAllAsync for Space entities.");
                return null;
            }
        }

        public override async Task<SpaceResponseDso?> GetByIdAsync(string id)
        {
            try
            {
                _logger.LogInformation($"Retrieving Space entity with ID: {id}...");
                var result = await _builder.GetByIdAsync(id);
                var item = GetMapper().Map<SpaceResponseDso>(result);
                _logger.LogInformation("Retrieved Space entity successfully.");
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in GetByIdAsync for Space entity with ID: {id}.");
                return null;
            }
        }

        public override IQueryable<SpaceResponseDso> GetQueryable()
        {
            try
            {
                _logger.LogInformation("Retrieving IQueryable<SpaceResponseDso> for Space entities...");
                var queryable = _builder.GetQueryable();
                var result = GetMapper().ProjectTo<SpaceResponseDso>(queryable);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetQueryable for Space entities.");
                return null;
            }
        }

        public override async Task<SpaceResponseDso> UpdateAsync(SpaceRequestDso entity)
        {
            try
            {
                _logger.LogInformation("Updating Space entity...");
                var result = await _builder.UpdateAsync(entity);
                return GetMapper().Map<SpaceResponseDso>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in UpdateAsync for Space entity.");
                return null;
            }
        }

        public override async Task<bool> ExistsAsync(object value, string name = "Id")
        {
            try
            {
                _logger.LogInformation("Checking if Space exists with {Key}: {Value}", name, value);
                var exists = await _builder.ExistsAsync(value, name);
                if (!exists)
                {
                    _logger.LogWarning("Space not found with {Key}: {Value}", name, value);
                }

                return exists;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while checking existence of Space with {Key}: {Value}", name, value);
                return false;
            }
        }

        public override async Task<PagedResponse<SpaceResponseDso>> GetAllAsync(string[]? includes = null, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                _logger.LogInformation("Fetching all Spaces with pagination: Page {PageNumber}, Size {PageSize}", pageNumber, pageSize);
                var results = (await _builder.GetAllAsync(includes, pageNumber, pageSize));
                var items = GetMapper().Map<List<SpaceResponseDso>>(results.Data);
                return new PagedResponse<SpaceResponseDso>(items, results.PageNumber, results.PageSize, results.TotalPages);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching all Spaces.");
                return new PagedResponse<SpaceResponseDso>(new List<SpaceResponseDso>(), pageNumber, pageSize, 0);
            }
        }

        public override async Task<SpaceResponseDso?> GetByIdAsync(object id)
        {
            try
            {
                _logger.LogInformation("Fetching Space by ID: {Id}", id);
                var result = await _builder.GetByIdAsync(id);
                if (result == null)
                {
                    _logger.LogWarning("Space not found with ID: {Id}", id);
                    return null;
                }

                _logger.LogInformation("Retrieved Space successfully.");
                return GetMapper().Map<SpaceResponseDso>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while retrieving Space by ID: {Id}", id);
                return null;
            }
        }

        public override async Task DeleteAsync(object value, string key = "Id")
        {
            try
            {
                _logger.LogInformation("Deleting Space with {Key}: {Value}", key, value);
                await _builder.DeleteAsync(value, key);
                _logger.LogInformation("Space with {Key}: {Value} deleted successfully.", key, value);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting Space with {Key}: {Value}", key, value);
            }
        }

        public override async Task DeleteRange(List<SpaceRequestDso> entities)
        {
            try
            {
                var builddtos = entities.OfType<SpaceRequestShareDto>().ToList();
                _logger.LogInformation("Deleting {Count} Spaces...", 201);
                await _builder.DeleteRange(builddtos);
                _logger.LogInformation("{Count} Spaces deleted successfully.", 202);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting multiple Spaces.");
            }
        }

        public override async Task<PagedResponse<SpaceResponseDso>> GetAllByAsync(List<FilterCondition> conditions, ParamOptions? options = null)
        {
            try
            {
                _logger.LogInformation("Retrieving all Space entities...");
                var results = await _builder.GetAllAsync();
                var response = await _builder.GetAllByAsync(conditions, options);
                return response.ToResponse(GetMapper().Map<IEnumerable<SpaceResponseDso>>(response.Data));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetAllAsync for Space entities.");
                return null;
            }
        }

        public override async Task<SpaceResponseDso?> GetOneByAsync(List<FilterCondition> conditions, ParamOptions? options = null)
        {
            try
            {
                _logger.LogInformation("Retrieving Space entity...");
                var results = await _builder.GetAllAsync();
                return GetMapper().Map<SpaceResponseDso>(await _builder.GetOneByAsync(conditions, options));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetOneByAsync  for Space entity.");
                return null;
            }
        }
    }
}