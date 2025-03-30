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
    /// FAQItem interface property for BuilderRepository.
    /// </summary>
    public interface IFAQItemBuilderRepository<TBuildRequestDto, TBuildResponseDto> : IBaseBuilderRepository<TBuildRequestDto, TBuildResponseDto> //
 where TBuildRequestDto : class //
 where TBuildResponseDto : class //
    {
    // Define methods or properties specific to the builder interface.
    } //
    /// <summary>
    /// FAQItem class property for BuilderRepository.
    /// </summary>
     //
    public  class  FAQItemBuilderRepository :  BaseBuilderRepository < FAQItem ,  FAQItemRequestBuildDto ,  FAQItemResponseBuildDto > ,  IFAQItemBuilderRepository < FAQItemRequestBuildDto ,  FAQItemResponseBuildDto > { 
    /// <summary>
    /// Constructor for FAQItemBuilderRepository.
    /// </summary>
     public  FAQItemBuilderRepository ( DataContext  dbContext ,  IMapper  mapper ,  ILogger  logger ) :  base ( dbContext ,  mapper ,  logger ) // Initialize  constructor.
    { // Initialize necessary fields or call base constructor.
    ///
    /// 
     
    /// 
     } //
    // Add additional methods or properties as needed.
    }

}