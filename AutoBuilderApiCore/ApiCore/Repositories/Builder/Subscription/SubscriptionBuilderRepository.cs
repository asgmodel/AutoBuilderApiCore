using AutoGenerator.Data;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using AutoGenerator.Repositorys.Builder;
using ApiCore.DyModels.Dto.Build.Requests;
using ApiCore.DyModels.Dto.Build.Responses;
using AutoGenerator.Models;
using System;

namespace ApiCore.Repositorys.Builder
{
    /// <summary>
    /// Subscription class property for BuilderRepository.
    /// </summary>
     //
    public class SubscriptionBuilderRepository : BaseBuilderRepository<Subscription, SubscriptionRequestBuildDto, SubscriptionResponseBuildDto>, ISubscriptionBuilderRepository<SubscriptionRequestBuildDto, SubscriptionResponseBuildDto>
    {
        /// <summary>
        /// Constructor for SubscriptionBuilderRepository.
        /// </summary>
        public SubscriptionBuilderRepository(DataContext dbContext, IMapper mapper, ILogger logger) : base(dbContext, mapper, logger) // Initialize  constructor.
        {
        // Initialize necessary fields or call base constructor.
        ///
        /// 
         
        /// 
        }
    //
    // Add additional methods or properties as needed.
    }
}