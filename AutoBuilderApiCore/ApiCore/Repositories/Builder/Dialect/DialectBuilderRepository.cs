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
    /// Dialect class property for BuilderRepository.
    /// </summary>
     //
    public class DialectBuilderRepository : BaseBuilderRepository<Dialect, DialectRequestBuildDto, DialectResponseBuildDto>, IDialectBuilderRepository<DialectRequestBuildDto, DialectResponseBuildDto>
    {
        /// <summary>
        /// Constructor for DialectBuilderRepository.
        /// </summary>
        public DialectBuilderRepository(DataContext dbContext, IMapper mapper, ILogger logger) : base(dbContext, mapper, logger) // Initialize  constructor.
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