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
    public class AdvertisementService : BaseService<AdvertisementRequestDso, AdvertisementResponseDso>, IUseAdvertisementService
    {
        private readonly IAdvertisementShareRepository _builder;
        public AdvertisementService(IAdvertisementShareRepository buildAdvertisementShareRepository, IMapper mapper, ILoggerFactory logger) : base(mapper, logger)
        {
            _builder = buildAdvertisementShareRepository;
        }

        public override Task<int> CountAsync()
        {
            try
            {
                _logger.LogInformation("Counting Advertisement entities...");
                return _builder.CountAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CountAsync for Advertisement entities.");
                return Task.FromResult(0);
            }
        }

        public override async Task<AdvertisementResponseDso> CreateAsync(AdvertisementRequestDso entity)
        {
            try
            {
                _logger.LogInformation("Creating new Advertisement entity...");
                var result = await _builder.CreateAsync(entity);
                var output = GetMapper().Map<AdvertisementResponseDso>(result);
                _logger.LogInformation("Created Advertisement entity successfully.");
                return output;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating Advertisement entity.");
                return null;
            }
        }

        public override Task DeleteAsync(string id)
        {
            try
            {
                _logger.LogInformation($"Deleting Advertisement entity with ID: {id}...");
                return _builder.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while deleting Advertisement entity with ID: {id}.");
                return Task.CompletedTask;
            }
        }

        public override async Task<IEnumerable<AdvertisementResponseDso>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("Retrieving all Advertisement entities...");
                var results = await _builder.GetAllAsync();
                return GetMapper().Map<IEnumerable<AdvertisementResponseDso>>(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetAllAsync for Advertisement entities.");
                return null;
            }
        }

        public override async Task<AdvertisementResponseDso?> GetByIdAsync(string id)
        {
            try
            {
                _logger.LogInformation($"Retrieving Advertisement entity with ID: {id}...");
                var result = await _builder.GetByIdAsync(id);
                var item = GetMapper().Map<AdvertisementResponseDso>(result);
                _logger.LogInformation("Retrieved Advertisement entity successfully.");
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in GetByIdAsync for Advertisement entity with ID: {id}.");
                return null;
            }
        }

        public override IQueryable<AdvertisementResponseDso> GetQueryable()
        {
            try
            {
                _logger.LogInformation("Retrieving IQueryable<AdvertisementResponseDso> for Advertisement entities...");
                var queryable = _builder.GetQueryable();
                var result = GetMapper().ProjectTo<AdvertisementResponseDso>(queryable);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetQueryable for Advertisement entities.");
                return null;
            }
        }

        public override async Task<AdvertisementResponseDso> UpdateAsync(AdvertisementRequestDso entity)
        {
            try
            {
                _logger.LogInformation("Updating Advertisement entity...");
                var result = await _builder.UpdateAsync(entity);
                return GetMapper().Map<AdvertisementResponseDso>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in UpdateAsync for Advertisement entity.");
                return null;
            }
        }

        public override async Task<bool> ExistsAsync(object value, string name = "Id")
        {
            try
            {
                _logger.LogInformation("Checking if Advertisement exists with {Key}: {Value}", name, value);
                var exists = await _builder.ExistsAsync(value, name);
                if (!exists)
                {
                    _logger.LogWarning("Advertisement not found with {Key}: {Value}", name, value);
                }

                return exists;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while checking existence of Advertisement with {Key}: {Value}", name, value);
                return false;
            }
        }

        public override async Task<PagedResponse<AdvertisementResponseDso>> GetAllAsync(string[]? includes = null, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                _logger.LogInformation("Fetching all Advertisements with pagination: Page {PageNumber}, Size {PageSize}", pageNumber, pageSize);
                var results = (await _builder.GetAllAsync(includes, pageNumber, pageSize));
                var items = GetMapper().Map<List<AdvertisementResponseDso>>(results.Data);
                return new PagedResponse<AdvertisementResponseDso>(items, results.PageNumber, results.PageSize, results.TotalPages);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching all Advertisements.");
                return new PagedResponse<AdvertisementResponseDso>(new List<AdvertisementResponseDso>(), pageNumber, pageSize, 0);
            }
        }

        public override async Task<AdvertisementResponseDso?> GetByIdAsync(object id)
        {
            try
            {
                _logger.LogInformation("Fetching Advertisement by ID: {Id}", id);
                var result = await _builder.GetByIdAsync(id);
                if (result == null)
                {
                    _logger.LogWarning("Advertisement not found with ID: {Id}", id);
                    return null;
                }

                _logger.LogInformation("Retrieved Advertisement successfully.");
                return GetMapper().Map<AdvertisementResponseDso>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while retrieving Advertisement by ID: {Id}", id);
                return null;
            }
        }

        public override async Task DeleteAsync(object value, string key = "Id")
        {
            try
            {
                _logger.LogInformation("Deleting Advertisement with {Key}: {Value}", key, value);
                await _builder.DeleteAsync(value, key);
                _logger.LogInformation("Advertisement with {Key}: {Value} deleted successfully.", key, value);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting Advertisement with {Key}: {Value}", key, value);
            }
        }

        public override async Task DeleteRange(List<AdvertisementRequestDso> entities)
        {
            try
            {
                var builddtos = entities.OfType<AdvertisementRequestShareDto>().ToList();
                _logger.LogInformation("Deleting {Count} Advertisements...", 201);
                await _builder.DeleteRange(builddtos);
                _logger.LogInformation("{Count} Advertisements deleted successfully.", 202);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting multiple Advertisements.");
            }
        }
    }
}