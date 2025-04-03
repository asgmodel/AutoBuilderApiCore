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
    public class SpaceService : BaseService<SpaceRequestDso, SpaceResponseDso>, IUseSpaceService
    {
        private readonly ISpaceShareRepository _builder;
        private readonly ILogger _logger;
        public SpaceService(ISpaceShareRepository spaceShareRepository, IMapper mapper, ILoggerFactory logger) : base(mapper, logger)
        {
            _builder = spaceShareRepository;
            _logger = logger.CreateLogger(typeof(SpaceService).FullName);
        }

        public override Task<int> CountAsync()
        {
            try
            {
                _logger.LogInformation("Counting Space entities...");
                throw new NotImplementedException();
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
                var output = (SpaceResponseDso)result;
                _logger.LogInformation("Created Space entity successfully.");
                return output;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating Space entity.");
                return null;
            }
        }

        public override Task<IEnumerable<SpaceResponseDso>> CreateRangeAsync(IEnumerable<SpaceRequestDso> entities)
        {
            try
            {
                _logger.LogInformation("Creating a range of Space entities...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CreateRangeAsync for Space entities.");
                return Task.FromResult<IEnumerable<SpaceResponseDso>>(null);
            }
        }

        public override Task DeleteAsync(string id)
        {
            try
            {
                _logger.LogInformation($"Deleting Space entity with ID: {id}...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while deleting Space entity with ID: {id}.");
                return Task.CompletedTask;
            }
        }

        public override Task DeleteRangeAsync(Expression<Func<SpaceResponseDso, bool>> predicate)
        {
            try
            {
                _logger.LogInformation("Deleting a range of Space entities based on condition...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in DeleteRangeAsync for Space entities.");
                return Task.CompletedTask;
            }
        }

        public override Task<bool> ExistsAsync(Expression<Func<SpaceResponseDso, bool>> predicate)
        {
            try
            {
                _logger.LogInformation("Checking existence of Space entity based on condition...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in ExistsAsync for Space entity.");
                return Task.FromResult(false);
            }
        }

        public override Task<SpaceResponseDso?> FindAsync(Expression<Func<SpaceResponseDso, bool>> predicate)
        {
            try
            {
                _logger.LogInformation("Finding Space entity based on condition...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in FindAsync for Space entity.");
                return Task.FromResult<SpaceResponseDso>(null);
            }
        }

        public override Task<IEnumerable<SpaceResponseDso>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("Retrieving all Space entities...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetAllAsync for Space entities.");
                return Task.FromResult<IEnumerable<SpaceResponseDso>>(null);
            }
        }

        public override Task<SpaceResponseDso?> GetByIdAsync(string id)
        {
            try
            {
                _logger.LogInformation($"Retrieving Space entity with ID: {id}...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in GetByIdAsync for Space entity with ID: {id}.");
                return Task.FromResult<SpaceResponseDso>(null);
            }
        }

        public Task<SpaceResponseDso> getData(int id)
        {
            try
            {
                _logger.LogInformation($"Getting data for Space entity with numeric ID: {id}...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in getData for Space entity with numeric ID: {id}.");
                return Task.FromResult<SpaceResponseDso>(null);
            }
        }

        public override IQueryable<SpaceResponseDso> GetQueryable()
        {
            try
            {
                _logger.LogInformation("Retrieving IQueryable<SpaceResponseDso> for Space entities...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetQueryable for Space entities.");
                return null;
            }
        }

        public Task SaveChangesAsync()
        {
            try
            {
                _logger.LogInformation("Saving changes to the database for Space entities...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in SaveChangesAsync for Space entities.");
                return Task.CompletedTask;
            }
        }

        public override Task<SpaceResponseDso> UpdateAsync(SpaceRequestDso entity)
        {
            try
            {
                _logger.LogInformation("Updating Space entity...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in UpdateAsync for Space entity.");
                return Task.FromResult<SpaceResponseDso>(null);
            }
        }
    }
}