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
    /// ServiceMethod interface property for BuilderRepository.
    /// </summary>
    public interface IServiceMethodBuilderRepository<TBuildRequestDto, TBuildResponseDto> : IBaseBuilderRepository<TBuildRequestDto, TBuildResponseDto> //
 where TBuildRequestDto : class //
 where TBuildResponseDto : class //
    {
    // Define methods or properties specific to the builder interface.
    } //
    /// <summary>
    /// ServiceMethod class property for BuilderRepository.
    /// </summary>
     //
    public  class  ServiceMethodBuilderRepository :  BaseBuilderRepository < ServiceMethod ,  ServiceMethodRequestBuildDto ,  ServiceMethodResponseBuildDto > ,  IServiceMethodBuilderRepository < ServiceMethodRequestBuildDto ,  ServiceMethodResponseBuildDto > { 
    /// <summary>
    /// Constructor for ServiceMethodBuilderRepository.
    /// </summary>
     public  ServiceMethodBuilderRepository ( DataContext  dbContext ,  IMapper  mapper ,  ILogger  logger ) :  base ( dbContext ,  mapper ,  logger ) // Initialize  constructor.
    { // Initialize necessary fields or call base constructor.
    ///
    /// 
     
    /// 
     } //
    // Add additional methods or properties as needed.
    }

}