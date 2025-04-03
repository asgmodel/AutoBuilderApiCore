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
    public class AuthorizationSessionService : BaseService<AuthorizationSessionRequestDso, AuthorizationSessionResponseDso>, IUseAuthorizationSessionService
    {
        private readonly IAuthorizationSessionShareRepository _builder;
        private readonly ILogger _logger;
        public AuthorizationSessionService(IAuthorizationSessionShareRepository authorizationsessionShareRepository, IMapper mapper, ILoggerFactory logger) : base(mapper, logger)
        {
            _builder = authorizationsessionShareRepository;
            _logger = logger.CreateLogger(typeof(AuthorizationSessionService).FullName);
        }

        public Task<int> CountAsync()
        {
            try
            {
                _logger.LogInformation("Counting AuthorizationSession entities...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CountAsync for AuthorizationSession entities.");
                return Task.FromResult(0);
            }
        }

        public async Task<AuthorizationSessionResponseDso> CreateAsync(AuthorizationSessionRequestDso entity)
        {
            try
            {
                _logger.LogInformation("Creating new AuthorizationSession entity...");
                var result = await _builder.CreateAsync(entity);
                var output = (AuthorizationSessionResponseDso)result;
                _logger.LogInformation("Created AuthorizationSession entity successfully.");
                return output;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating AuthorizationSession entity.");
                return null;
            }
        }

        public Task<IEnumerable<AuthorizationSessionResponseDso>> CreateRangeAsync(IEnumerable<AuthorizationSessionRequestDso> entities)
        {
            try
            {
                _logger.LogInformation("Creating a range of AuthorizationSession entities...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CreateRangeAsync for AuthorizationSession entities.");
                return Task.FromResult<IEnumerable<AuthorizationSessionResponseDso>>(null);
            }
        }

        public Task DeleteAsync(string id)
        {
            try
            {
                _logger.LogInformation($"Deleting AuthorizationSession entity with ID: {id}...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while deleting AuthorizationSession entity with ID: {id}.");
                return Task.CompletedTask;
            }
        }

        public Task DeleteRangeAsync(Expression<Func<AuthorizationSessionResponseDso, bool>> predicate)
        {
            try
            {
                _logger.LogInformation("Deleting a range of AuthorizationSession entities based on condition...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in DeleteRangeAsync for AuthorizationSession entities.");
                return Task.CompletedTask;
            }
        }

        public Task<bool> ExistsAsync(Expression<Func<AuthorizationSessionResponseDso, bool>> predicate)
        {
            try
            {
                _logger.LogInformation("Checking existence of AuthorizationSession entity based on condition...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in ExistsAsync for AuthorizationSession entity.");
                return Task.FromResult(false);
            }
        }

        public Task<AuthorizationSessionResponseDso?> FindAsync(Expression<Func<AuthorizationSessionResponseDso, bool>> predicate)
        {
            try
            {
                _logger.LogInformation("Finding AuthorizationSession entity based on condition...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in FindAsync for AuthorizationSession entity.");
                return Task.FromResult<AuthorizationSessionResponseDso>(null);
            }
        }

        public Task<IEnumerable<AuthorizationSessionResponseDso>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("Retrieving all AuthorizationSession entities...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetAllAsync for AuthorizationSession entities.");
                return Task.FromResult<IEnumerable<AuthorizationSessionResponseDso>>(null);
            }
        }

        public Task<AuthorizationSessionResponseDso?> GetByIdAsync(string id)
        {
            try
            {
                _logger.LogInformation($"Retrieving AuthorizationSession entity with ID: {id}...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in GetByIdAsync for AuthorizationSession entity with ID: {id}.");
                return Task.FromResult<AuthorizationSessionResponseDso>(null);
            }
        }

        public Task<AuthorizationSessionResponseDso> getData(int id)
        {
            try
            {
                _logger.LogInformation($"Getting data for AuthorizationSession entity with numeric ID: {id}...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in getData for AuthorizationSession entity with numeric ID: {id}.");
                return Task.FromResult<AuthorizationSessionResponseDso>(null);
            }
        }

        public IQueryable<AuthorizationSessionResponseDso> GetQueryable()
        {
            try
            {
                _logger.LogInformation("Retrieving IQueryable<AuthorizationSessionResponseDso> for AuthorizationSession entities...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetQueryable for AuthorizationSession entities.");
                return null;
            }
        }

        public Task SaveChangesAsync()
        {
            try
            {
                _logger.LogInformation("Saving changes to the database for AuthorizationSession entities...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in SaveChangesAsync for AuthorizationSession entities.");
                return Task.CompletedTask;
            }
        }

        public Task<AuthorizationSessionResponseDso> UpdateAsync(AuthorizationSessionRequestDso entity)
        {
            try
            {
                _logger.LogInformation("Updating AuthorizationSession entity...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in UpdateAsync for AuthorizationSession entity.");
                return Task.FromResult<AuthorizationSessionResponseDso>(null);
            }
        }
    }
}