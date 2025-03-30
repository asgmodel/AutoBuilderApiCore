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
    /// Invoice interface property for BuilderRepository.
    /// </summary>
    public interface IInvoiceBuilderRepository<TBuildRequestDto, TBuildResponseDto> : IBaseBuilderRepository<TBuildRequestDto, TBuildResponseDto> //
 where TBuildRequestDto : class //
 where TBuildResponseDto : class //
    {
    // Define methods or properties specific to the builder interface.
    } //
    /// <summary>
    /// Invoice class property for BuilderRepository.
    /// </summary>
     //
    public  class  InvoiceBuilderRepository :  BaseBuilderRepository < Invoice ,  InvoiceRequestBuildDto ,  InvoiceResponseBuildDto > ,  IInvoiceBuilderRepository < InvoiceRequestBuildDto ,  InvoiceResponseBuildDto > { 
    /// <summary>
    /// Constructor for InvoiceBuilderRepository.
    /// </summary>
     public  InvoiceBuilderRepository ( DataContext  dbContext ,  IMapper  mapper ,  ILogger  logger ) :  base ( dbContext ,  mapper ,  logger ) // Initialize  constructor.
    { // Initialize necessary fields or call base constructor.
    ///
    /// 
     
    /// 
     } //
    // Add additional methods or properties as needed.
    }

}