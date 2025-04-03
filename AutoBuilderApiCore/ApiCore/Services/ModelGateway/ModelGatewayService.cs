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
    public class ModelGatewayService : BaseService<ModelGatewayRequestDso, ModelGatewayResponseDso>, IUseModelGatewayService
    {
        private readonly IModelGatewayShareRepository _builder;
        private readonly ILogger _logger;
        public ModelGatewayService(IModelGatewayShareRepository modelgatewayShareRepository, IMapper mapper, ILoggerFactory logger) : base(mapper, logger)
        {
            _builder = modelgatewayShareRepository;
            _logger = logger.CreateLogger(typeof(ModelGatewayService).FullName);
        }

        public override Task<int> CountAsync()
        {
            try
            {
                _logger.LogInformation("Counting ModelGateway entities...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CountAsync for ModelGateway entities.");
                return Task.FromResult(0);
            }
        }

        public override async Task<ModelGatewayResponseDso> CreateAsync(ModelGatewayRequestDso entity)
        {
            try
            {
                _logger.LogInformation("Creating new ModelGateway entity...");
                var result = await _builder.CreateAsync(entity);
                var output = (ModelGatewayResponseDso)result;
                _logger.LogInformation("Created ModelGateway entity successfully.");
                return output;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating ModelGateway entity.");
                return null;
            }
        }

        public override Task<IEnumerable<ModelGatewayResponseDso>> CreateRangeAsync(IEnumerable<ModelGatewayRequestDso> entities)
        {
            try
            {
                _logger.LogInformation("Creating a range of ModelGateway entities...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CreateRangeAsync for ModelGateway entities.");
                return Task.FromResult<IEnumerable<ModelGatewayResponseDso>>(null);
            }
        }

        public override Task DeleteAsync(string id)
        {
            try
            {
                _logger.LogInformation($"Deleting ModelGateway entity with ID: {id}...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while deleting ModelGateway entity with ID: {id}.");
                return Task.CompletedTask;
            }
        }

        public override Task DeleteRangeAsync(Expression<Func<ModelGatewayResponseDso, bool>> predicate)
        {
            try
            {
                _logger.LogInformation("Deleting a range of ModelGateway entities based on condition...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in DeleteRangeAsync for ModelGateway entities.");
                return Task.CompletedTask;
            }
        }

        public override Task<bool> ExistsAsync(Expression<Func<ModelGatewayResponseDso, bool>> predicate)
        {
            try
            {
                _logger.LogInformation("Checking existence of ModelGateway entity based on condition...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in ExistsAsync for ModelGateway entity.");
                return Task.FromResult(false);
            }
        }

        public override Task<ModelGatewayResponseDso?> FindAsync(Expression<Func<ModelGatewayResponseDso, bool>> predicate)
        {
            try
            {
                _logger.LogInformation("Finding ModelGateway entity based on condition...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in FindAsync for ModelGateway entity.");
                return Task.FromResult<ModelGatewayResponseDso>(null);
            }
        }

        public override Task<IEnumerable<ModelGatewayResponseDso>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("Retrieving all ModelGateway entities...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetAllAsync for ModelGateway entities.");
                return Task.FromResult<IEnumerable<ModelGatewayResponseDso>>(null);
            }
        }

        public override Task<ModelGatewayResponseDso?> GetByIdAsync(string id)
        {
            try
            {
                _logger.LogInformation($"Retrieving ModelGateway entity with ID: {id}...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in GetByIdAsync for ModelGateway entity with ID: {id}.");
                return Task.FromResult<ModelGatewayResponseDso>(null);
            }
        }

        public Task<ModelGatewayResponseDso> getData(int id)
        {
            try
            {
                _logger.LogInformation($"Getting data for ModelGateway entity with numeric ID: {id}...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in getData for ModelGateway entity with numeric ID: {id}.");
                return Task.FromResult<ModelGatewayResponseDso>(null);
            }
        }

        public override IQueryable<ModelGatewayResponseDso> GetQueryable()
        {
            try
            {
                _logger.LogInformation("Retrieving IQueryable<ModelGatewayResponseDso> for ModelGateway entities...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetQueryable for ModelGateway entities.");
                return null;
            }
        }

        public Task SaveChangesAsync()
        {
            try
            {
                _logger.LogInformation("Saving changes to the database for ModelGateway entities...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in SaveChangesAsync for ModelGateway entities.");
                return Task.CompletedTask;
            }
        }

        public override Task<ModelGatewayResponseDso> UpdateAsync(ModelGatewayRequestDso entity)
        {
            try
            {
                _logger.LogInformation("Updating ModelGateway entity...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in UpdateAsync for ModelGateway entity.");
                return Task.FromResult<ModelGatewayResponseDso>(null);
            }
        }
    }
}