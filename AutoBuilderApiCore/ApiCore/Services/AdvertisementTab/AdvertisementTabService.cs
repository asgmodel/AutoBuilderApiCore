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
    public class AdvertisementTabService : BaseService<AdvertisementTabRequestDso, AdvertisementTabResponseDso>, IUseAdvertisementTabService
    {
        private readonly IAdvertisementTabShareRepository _builder;
        public AdvertisementTabService(IAdvertisementTabShareRepository buildAdvertisementTabShareRepository, IMapper mapper, ILoggerFactory logger) : base(mapper, logger)
        {
            _builder = buildAdvertisementTabShareRepository;
        }

        public override Task<int> CountAsync()
        {
            try
            {
                _logger.LogInformation("Counting AdvertisementTab entities...");
                return _builder.CountAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CountAsync for AdvertisementTab entities.");
                return Task.FromResult(0);
            }
        }

        public override async Task<AdvertisementTabResponseDso> CreateAsync(AdvertisementTabRequestDso entity)
        {
            try
            {
                _logger.LogInformation("Creating new AdvertisementTab entity...");
                var result = await _builder.CreateAsync(entity);
                var output = GetMapper().Map<AdvertisementTabResponseDso>(result);
                _logger.LogInformation("Created AdvertisementTab entity successfully.");
                return output;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating AdvertisementTab entity.");
                return null;
            }
        }

        public override Task DeleteAsync(string id)
        {
            try
            {
                _logger.LogInformation($"Deleting AdvertisementTab entity with ID: {id}...");
                return _builder.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while deleting AdvertisementTab entity with ID: {id}.");
                return Task.CompletedTask;
            }
        }

        public override async Task<IEnumerable<AdvertisementTabResponseDso>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("Retrieving all AdvertisementTab entities...");
                var results = await _builder.GetAllAsync();
                return GetMapper().Map<IEnumerable<AdvertisementTabResponseDso>>(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetAllAsync for AdvertisementTab entities.");
                return null;
            }
        }

        public override async Task<AdvertisementTabResponseDso?> GetByIdAsync(string id)
        {
            try
            {
                _logger.LogInformation($"Retrieving AdvertisementTab entity with ID: {id}...");
                var result = await _builder.GetByIdAsync(id);
                var item = GetMapper().Map<AdvertisementTabResponseDso>(result);
                _logger.LogInformation("Retrieved AdvertisementTab entity successfully.");
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in GetByIdAsync for AdvertisementTab entity with ID: {id}.");
                return null;
            }
        }

        public override IQueryable<AdvertisementTabResponseDso> GetQueryable()
        {
            try
            {
                _logger.LogInformation("Retrieving IQueryable<AdvertisementTabResponseDso> for AdvertisementTab entities...");
                var queryable = _builder.GetQueryable();
                var result = GetMapper().ProjectTo<AdvertisementTabResponseDso>(queryable);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetQueryable for AdvertisementTab entities.");
                return null;
            }
        }

        public override async Task<AdvertisementTabResponseDso> UpdateAsync(AdvertisementTabRequestDso entity)
        {
            try
            {
                _logger.LogInformation("Updating AdvertisementTab entity...");
                var result = await _builder.UpdateAsync(entity);
                return GetMapper().Map<AdvertisementTabResponseDso>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in UpdateAsync for AdvertisementTab entity.");
                return null;
            }
        }

        public override async Task<bool> ExistsAsync(object value, string name = "Id")
        {
            try
            {
                _logger.LogInformation("Checking if AdvertisementTab exists with {Key}: {Value}", name, value);
                var exists = await _builder.ExistsAsync(value, name);
                if (!exists)
                {
                    _logger.LogWarning("AdvertisementTab not found with {Key}: {Value}", name, value);
                }

                return exists;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while checking existence of AdvertisementTab with {Key}: {Value}", name, value);
                return false;
            }
        }

        public override async Task<PagedResponse<AdvertisementTabResponseDso>> GetAllAsync(string[]? includes = null, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                _logger.LogInformation("Fetching all AdvertisementTabs with pagination: Page {PageNumber}, Size {PageSize}", pageNumber, pageSize);
                var results = (await _builder.GetAllAsync(includes, pageNumber, pageSize));
                var items = GetMapper().Map<List<AdvertisementTabResponseDso>>(results.Data);
                return new PagedResponse<AdvertisementTabResponseDso>(items, results.PageNumber, results.PageSize, results.TotalPages);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching all AdvertisementTabs.");
                return new PagedResponse<AdvertisementTabResponseDso>(new List<AdvertisementTabResponseDso>(), pageNumber, pageSize, 0);
            }
        }

        public override async Task<AdvertisementTabResponseDso?> GetByIdAsync(object id)
        {
            try
            {
                _logger.LogInformation("Fetching AdvertisementTab by ID: {Id}", id);
                var result = await _builder.GetByIdAsync(id);
                if (result == null)
                {
                    _logger.LogWarning("AdvertisementTab not found with ID: {Id}", id);
                    return null;
                }

                _logger.LogInformation("Retrieved AdvertisementTab successfully.");
                return GetMapper().Map<AdvertisementTabResponseDso>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while retrieving AdvertisementTab by ID: {Id}", id);
                return null;
            }
        }

        public override async Task DeleteAsync(object value, string key = "Id")
        {
            try
            {
                _logger.LogInformation("Deleting AdvertisementTab with {Key}: {Value}", key, value);
                await _builder.DeleteAsync(value, key);
                _logger.LogInformation("AdvertisementTab with {Key}: {Value} deleted successfully.", key, value);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting AdvertisementTab with {Key}: {Value}", key, value);
            }
        }

        public override async Task DeleteRange(List<AdvertisementTabRequestDso> entities)
        {
            try
            {
                var builddtos = entities.OfType<AdvertisementTabRequestShareDto>().ToList();
                _logger.LogInformation("Deleting {Count} AdvertisementTabs...", 201);
                await _builder.DeleteRange(builddtos);
                _logger.LogInformation("{Count} AdvertisementTabs deleted successfully.", 202);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting multiple AdvertisementTabs.");
            }
        }

        public override async Task<PagedResponse<AdvertisementTabResponseDso>> GetAllByAsync(List<FilterCondition> conditions, ParamOptions? options = null)
        {
            try
            {
                _logger.LogInformation("Retrieving all AdvertisementTab entities...");
                var results = await _builder.GetAllAsync();
                var response = await _builder.GetAllByAsync(conditions, options);
                return response.ToResponse(GetMapper().Map<IEnumerable<AdvertisementTabResponseDso>>(response.Data));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetAllAsync for AdvertisementTab entities.");
                return null;
            }
        }

        public override async Task<AdvertisementTabResponseDso?> GetOneByAsync(List<FilterCondition> conditions, ParamOptions? options = null)
        {
            try
            {
                _logger.LogInformation("Retrieving AdvertisementTab entity...");
                var results = await _builder.GetAllAsync();
                return GetMapper().Map<AdvertisementTabResponseDso>(await _builder.GetOneByAsync(conditions, options));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetOneByAsync  for AdvertisementTab entity.");
                return null;
            }
        }
    }
}