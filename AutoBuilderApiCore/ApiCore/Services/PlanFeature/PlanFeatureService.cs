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
using System;

namespace ApiCore.Services.Services
{
    public class PlanFeatureService : BaseService<PlanFeatureRequestDso, PlanFeatureResponseDso>, IUsePlanFeatureService
    {
        private readonly IPlanFeatureShareRepository _builder;
        public PlanFeatureService(IPlanFeatureShareRepository buildPlanFeatureShareRepository, IMapper mapper, ILoggerFactory logger) : base(mapper, logger)
        {
            _builder = buildPlanFeatureShareRepository;
        }

        public override Task<int> CountAsync()
        {
            try
            {
                _logger.LogInformation("Counting PlanFeature entities...");
                return _builder.CountAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CountAsync for PlanFeature entities.");
                return Task.FromResult(0);
            }
        }

        public override async Task<PlanFeatureResponseDso> CreateAsync(PlanFeatureRequestDso entity)
        {
            try
            {
                _logger.LogInformation("Creating new PlanFeature entity...");
                var result = await _builder.CreateAsync(entity);
                var output = GetMapper().Map<PlanFeatureResponseDso>(result);
                _logger.LogInformation("Created PlanFeature entity successfully.");
                return output;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating PlanFeature entity.");
                return null;
            }
        }

        public override Task DeleteAsync(string id)
        {
            try
            {
                _logger.LogInformation($"Deleting PlanFeature entity with ID: {id}...");
                return _builder.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while deleting PlanFeature entity with ID: {id}.");
                return Task.CompletedTask;
            }
        }

        public override async Task<IEnumerable<PlanFeatureResponseDso>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("Retrieving all PlanFeature entities...");
                var results = await _builder.GetAllAsync();
                return GetMapper().Map<IEnumerable<PlanFeatureResponseDso>>(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetAllAsync for PlanFeature entities.");
                return null;
            }
        }

        public override async Task<PlanFeatureResponseDso?> GetByIdAsync(string id)
        {
            try
            {
                _logger.LogInformation($"Retrieving PlanFeature entity with ID: {id}...");
                var result = await _builder.GetByIdAsync(id);
                var item = GetMapper().Map<PlanFeatureResponseDso>(result);
                _logger.LogInformation("Retrieved PlanFeature entity successfully.");
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in GetByIdAsync for PlanFeature entity with ID: {id}.");
                return null;
            }
        }

        public override IQueryable<PlanFeatureResponseDso> GetQueryable()
        {
            try
            {
                _logger.LogInformation("Retrieving IQueryable<PlanFeatureResponseDso> for PlanFeature entities...");
                var queryable = _builder.GetQueryable();
                var result = GetMapper().ProjectTo<PlanFeatureResponseDso>(queryable);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetQueryable for PlanFeature entities.");
                return null;
            }
        }

        public override async Task<PlanFeatureResponseDso> UpdateAsync(PlanFeatureRequestDso entity)
        {
            try
            {
                _logger.LogInformation("Updating PlanFeature entity...");
                var result = await _builder.UpdateAsync(entity);
                return GetMapper().Map<PlanFeatureResponseDso>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in UpdateAsync for PlanFeature entity.");
                return null;
            }
        }

        public override async Task<bool> ExistsAsync(object value, string name = "Id")
        {
            try
            {
                _logger.LogInformation("Checking if PlanFeature exists with {Key}: {Value}", name, value);
                var exists = await _builder.ExistsAsync(value, name);
                if (!exists)
                {
                    _logger.LogWarning("PlanFeature not found with {Key}: {Value}", name, value);
                }

                return exists;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while checking existence of PlanFeature with {Key}: {Value}", name, value);
                return false;
            }
        }

        public override async Task<PagedResponse<PlanFeatureResponseDso>> GetAllAsync(string[]? includes = null, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                _logger.LogInformation("Fetching all PlanFeatures with pagination: Page {PageNumber}, Size {PageSize}", pageNumber, pageSize);
                var results = (await _builder.GetAllAsync(includes, pageNumber, pageSize));
                var items = GetMapper().Map<List<PlanFeatureResponseDso>>(results.Data);
                return new PagedResponse<PlanFeatureResponseDso>(items, results.PageNumber, results.PageSize, results.TotalPages);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching all PlanFeatures.");
                return new PagedResponse<PlanFeatureResponseDso>(new List<PlanFeatureResponseDso>(), pageNumber, pageSize, 0);
            }
        }

        public override async Task<PlanFeatureResponseDso?> GetByIdAsync(object id)
        {
            try
            {
                _logger.LogInformation("Fetching PlanFeature by ID: {Id}", id);
                var result = await _builder.GetByIdAsync(id);
                if (result == null)
                {
                    _logger.LogWarning("PlanFeature not found with ID: {Id}", id);
                    return null;
                }

                _logger.LogInformation("Retrieved PlanFeature successfully.");
                return GetMapper().Map<PlanFeatureResponseDso>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while retrieving PlanFeature by ID: {Id}", id);
                return null;
            }
        }

        public override async Task DeleteAsync(object value, string key = "Id")
        {
            try
            {
                _logger.LogInformation("Deleting PlanFeature with {Key}: {Value}", key, value);
                await _builder.DeleteAsync(value, key);
                _logger.LogInformation("PlanFeature with {Key}: {Value} deleted successfully.", key, value);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting PlanFeature with {Key}: {Value}", key, value);
            }
        }

        public override async Task DeleteRange(List<PlanFeatureRequestDso> entities)
        {
            try
            {
                var builddtos = entities.OfType<PlanFeatureRequestShareDto>().ToList();
                _logger.LogInformation("Deleting {Count} PlanFeatures...", 201);
                await _builder.DeleteRange(builddtos);
                _logger.LogInformation("{Count} PlanFeatures deleted successfully.", 202);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting multiple PlanFeatures.");
            }
        }
    }
}