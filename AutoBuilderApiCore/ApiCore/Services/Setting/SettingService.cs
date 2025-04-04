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
    public class SettingService : BaseService<SettingRequestDso, SettingResponseDso>, IUseSettingService
    {
        private readonly ISettingShareRepository _builder;
        public SettingService(ISettingShareRepository buildSettingShareRepository, IMapper mapper, ILoggerFactory logger) : base(mapper, logger)
        {
            _builder = buildSettingShareRepository;
        }

        public override Task<int> CountAsync()
        {
            try
            {
                _logger.LogInformation("Counting Setting entities...");
                return _builder.CountAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CountAsync for Setting entities.");
                return Task.FromResult(0);
            }
        }

        public override async Task<SettingResponseDso> CreateAsync(SettingRequestDso entity)
        {
            try
            {
                _logger.LogInformation("Creating new Setting entity...");
                var result = await _builder.CreateAsync(entity);
                var output = GetMapper().Map<SettingResponseDso>(result);
                _logger.LogInformation("Created Setting entity successfully.");
                return output;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating Setting entity.");
                return null;
            }
        }

        public override Task DeleteAsync(string id)
        {
            try
            {
                _logger.LogInformation($"Deleting Setting entity with ID: {id}...");
                return _builder.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while deleting Setting entity with ID: {id}.");
                return Task.CompletedTask;
            }
        }

        public override async Task<IEnumerable<SettingResponseDso>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("Retrieving all Setting entities...");
                var results = await _builder.GetAllAsync();
                return GetMapper().Map<IEnumerable<SettingResponseDso>>(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetAllAsync for Setting entities.");
                return null;
            }
        }

        public override async Task<SettingResponseDso?> GetByIdAsync(string id)
        {
            try
            {
                _logger.LogInformation($"Retrieving Setting entity with ID: {id}...");
                var result = await _builder.GetByIdAsync(id);
                var item = GetMapper().Map<SettingResponseDso>(result);
                _logger.LogInformation("Retrieved Setting entity successfully.");
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in GetByIdAsync for Setting entity with ID: {id}.");
                return null;
            }
        }

        public override IQueryable<SettingResponseDso> GetQueryable()
        {
            try
            {
                _logger.LogInformation("Retrieving IQueryable<SettingResponseDso> for Setting entities...");
                var queryable = _builder.GetQueryable();
                var result = GetMapper().ProjectTo<SettingResponseDso>(queryable);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetQueryable for Setting entities.");
                return null;
            }
        }

        public override async Task<SettingResponseDso> UpdateAsync(SettingRequestDso entity)
        {
            try
            {
                _logger.LogInformation("Updating Setting entity...");
                var result = await _builder.UpdateAsync(entity);
                return GetMapper().Map<SettingResponseDso>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in UpdateAsync for Setting entity.");
                return null;
            }
        }

        public override async Task<bool> ExistsAsync(object value, string name = "Id")
        {
            try
            {
                _logger.LogInformation("Checking if Setting exists with {Key}: {Value}", name, value);
                var exists = await _builder.ExistsAsync(value, name);
                if (!exists)
                {
                    _logger.LogWarning("Setting not found with {Key}: {Value}", name, value);
                }

                return exists;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while checking existence of Setting with {Key}: {Value}", name, value);
                return false;
            }
        }

        public override async Task<PagedResponse<SettingResponseDso>> GetAllAsync(string[]? includes = null, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                _logger.LogInformation("Fetching all Settings with pagination: Page {PageNumber}, Size {PageSize}", pageNumber, pageSize);
                var results = (await _builder.GetAllAsync(includes, pageNumber, pageSize));
                var items = GetMapper().Map<List<SettingResponseDso>>(results.Data);
                return new PagedResponse<SettingResponseDso>(items, results.PageNumber, results.PageSize, results.TotalPages);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching all Settings.");
                return new PagedResponse<SettingResponseDso>(new List<SettingResponseDso>(), pageNumber, pageSize, 0);
            }
        }

        public override async Task<SettingResponseDso?> GetByIdAsync(object id)
        {
            try
            {
                _logger.LogInformation("Fetching Setting by ID: {Id}", id);
                var result = await _builder.GetByIdAsync(id);
                if (result == null)
                {
                    _logger.LogWarning("Setting not found with ID: {Id}", id);
                    return null;
                }

                _logger.LogInformation("Retrieved Setting successfully.");
                return GetMapper().Map<SettingResponseDso>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while retrieving Setting by ID: {Id}", id);
                return null;
            }
        }

        public override async Task DeleteAsync(object value, string key = "Id")
        {
            try
            {
                _logger.LogInformation("Deleting Setting with {Key}: {Value}", key, value);
                await _builder.DeleteAsync(value, key);
                _logger.LogInformation("Setting with {Key}: {Value} deleted successfully.", key, value);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting Setting with {Key}: {Value}", key, value);
            }
        }

        public override async Task DeleteRange(List<SettingRequestDso> entities)
        {
            try
            {
                var builddtos = entities.OfType<SettingRequestShareDto>().ToList();
                _logger.LogInformation("Deleting {Count} Settings...", 201);
                await _builder.DeleteRange(builddtos);
                _logger.LogInformation("{Count} Settings deleted successfully.", 202);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting multiple Settings.");
            }
        }
    }
}