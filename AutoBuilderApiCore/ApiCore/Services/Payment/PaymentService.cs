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
    public class PaymentService : BaseService<PaymentRequestDso, PaymentResponseDso>, IUsePaymentService
    {
        private readonly IPaymentShareRepository _builder;
        private readonly ILogger _logger;
        public PaymentService(IPaymentShareRepository paymentShareRepository, IMapper mapper, ILoggerFactory logger) : base(mapper, logger)
        {
            _builder = paymentShareRepository;
            _logger = logger.CreateLogger(typeof(PaymentService).FullName);
        }

        public override Task<int> CountAsync()
        {
            try
            {
                _logger.LogInformation("Counting Payment entities...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CountAsync for Payment entities.");
                return Task.FromResult(0);
            }
        }

        public override async Task<PaymentResponseDso> CreateAsync(PaymentRequestDso entity)
        {
            try
            {
                _logger.LogInformation("Creating new Payment entity...");
                var result = await _builder.CreateAsync(entity);
                var output = (PaymentResponseDso)result;
                _logger.LogInformation("Created Payment entity successfully.");
                return output;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating Payment entity.");
                return null;
            }
        }

        public override Task<IEnumerable<PaymentResponseDso>> CreateRangeAsync(IEnumerable<PaymentRequestDso> entities)
        {
            try
            {
                _logger.LogInformation("Creating a range of Payment entities...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CreateRangeAsync for Payment entities.");
                return Task.FromResult<IEnumerable<PaymentResponseDso>>(null);
            }
        }

        public override Task DeleteAsync(string id)
        {
            try
            {
                _logger.LogInformation($"Deleting Payment entity with ID: {id}...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while deleting Payment entity with ID: {id}.");
                return Task.CompletedTask;
            }
        }

        public override Task DeleteRangeAsync(Expression<Func<PaymentResponseDso, bool>> predicate)
        {
            try
            {
                _logger.LogInformation("Deleting a range of Payment entities based on condition...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in DeleteRangeAsync for Payment entities.");
                return Task.CompletedTask;
            }
        }

        public override Task<bool> ExistsAsync(Expression<Func<PaymentResponseDso, bool>> predicate)
        {
            try
            {
                _logger.LogInformation("Checking existence of Payment entity based on condition...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in ExistsAsync for Payment entity.");
                return Task.FromResult(false);
            }
        }

        public override Task<PaymentResponseDso?> FindAsync(Expression<Func<PaymentResponseDso, bool>> predicate)
        {
            try
            {
                _logger.LogInformation("Finding Payment entity based on condition...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in FindAsync for Payment entity.");
                return Task.FromResult<PaymentResponseDso>(null);
            }
        }

        public override Task<IEnumerable<PaymentResponseDso>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("Retrieving all Payment entities...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetAllAsync for Payment entities.");
                return Task.FromResult<IEnumerable<PaymentResponseDso>>(null);
            }
        }

        public override Task<PaymentResponseDso?> GetByIdAsync(string id)
        {
            try
            {
                _logger.LogInformation($"Retrieving Payment entity with ID: {id}...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in GetByIdAsync for Payment entity with ID: {id}.");
                return Task.FromResult<PaymentResponseDso>(null);
            }
        }

        public Task<PaymentResponseDso> getData(int id)
        {
            try
            {
                _logger.LogInformation($"Getting data for Payment entity with numeric ID: {id}...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in getData for Payment entity with numeric ID: {id}.");
                return Task.FromResult<PaymentResponseDso>(null);
            }
        }

        public override IQueryable<PaymentResponseDso> GetQueryable()
        {
            try
            {
                _logger.LogInformation("Retrieving IQueryable<PaymentResponseDso> for Payment entities...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetQueryable for Payment entities.");
                return null;
            }
        }

        public Task SaveChangesAsync()
        {
            try
            {
                _logger.LogInformation("Saving changes to the database for Payment entities...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in SaveChangesAsync for Payment entities.");
                return Task.CompletedTask;
            }
        }

        public override Task<PaymentResponseDso> UpdateAsync(PaymentRequestDso entity)
        {
            try
            {
                _logger.LogInformation("Updating Payment entity...");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in UpdateAsync for Payment entity.");
                return Task.FromResult<PaymentResponseDso>(null);
            }
        }
    }
}