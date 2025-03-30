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
    /// UserModelAi interface property for BuilderRepository.
    /// </summary>
    public interface IUserModelAiBuilderRepository<TBuildRequestDto, TBuildResponseDto> : IBaseBuilderRepository<TBuildRequestDto, TBuildResponseDto> //
 where TBuildRequestDto : class //
 where TBuildResponseDto : class //
    {
    // Define methods or properties specific to the builder interface.
    } //
    /// <summary>
    /// UserModelAi class property for BuilderRepository.
    /// </summary>
     //
    public  class  UserModelAiBuilderRepository :  BaseBuilderRepository < UserModelAi ,  UserModelAiRequestBuildDto ,  UserModelAiResponseBuildDto > ,  IUserModelAiBuilderRepository < UserModelAiRequestBuildDto ,  UserModelAiResponseBuildDto > { 
    /// <summary>
    /// Constructor for UserModelAiBuilderRepository.
    /// </summary>
     public  UserModelAiBuilderRepository ( DataContext  dbContext ,  IMapper  mapper ,  ILogger  logger ) :  base ( dbContext ,  mapper ,  logger ) // Initialize  constructor.
    { // Initialize necessary fields or call base constructor.
    ///
    /// 
     
    /// 
     } //
    // Add additional methods or properties as needed.
    }

}