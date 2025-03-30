using AutoGenerator.Data;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using AutoGenerator.Repositorys.Builder;
using Dto.Build.Requests;
using Dto.Build.Responses;
using AutoGenerator.Models;
using System;

namespace Repositorys.Builder
{
    /// <summary>
    /// Request interface property for BuilderRepository.
    /// </summary>
    public interface IRequestBuilderRepository<TBuildRequestDto, TBuildResponseDto> : IBaseBuilderRepository<TBuildRequestDto, TBuildResponseDto> //
 where TBuildRequestDto : class //
 where TBuildResponseDto : class //
    {
    // Define methods or properties specific to the builder interface.
    } //
    /// <summary>
    /// Request class property for BuilderRepository.
    /// </summary>
     //
    public  class  RequestBuilderRepository :  BaseBuilderRepository < Request ,  RequestRequestBuildDto ,  RequestResponseBuildDto > ,  IRequestBuilderRepository < RequestRequestBuildDto ,  RequestResponseBuildDto > { 
    /// <summary>
    /// Constructor for RequestBuilderRepository.
    /// </summary>
     public  RequestBuilderRepository ( DataContext  dbContext ,  IMapper  mapper ,  ILogger  logger ) :  base ( dbContext ,  mapper ,  logger ) // Initialize  constructor.
    { // Initialize necessary fields or call base constructor.
    ///
    /// 
     
    /// 
     } //
    // Add additional methods or properties as needed.
    }

}