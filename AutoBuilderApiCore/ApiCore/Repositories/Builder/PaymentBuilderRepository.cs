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
    /// Payment interface property for BuilderRepository.
    /// </summary>
    public interface IPaymentBuilderRepository<TBuildRequestDto, TBuildResponseDto> : IBaseBuilderRepository<TBuildRequestDto, TBuildResponseDto> //
 where TBuildRequestDto : class //
 where TBuildResponseDto : class //
    {
    // Define methods or properties specific to the builder interface.
    } //
    /// <summary>
    /// Payment class property for BuilderRepository.
    /// </summary>
     //
    public  class  PaymentBuilderRepository :  BaseBuilderRepository < Payment ,  PaymentRequestBuildDto ,  PaymentResponseBuildDto > ,  IPaymentBuilderRepository < PaymentRequestBuildDto ,  PaymentResponseBuildDto > { 
    /// <summary>
    /// Constructor for PaymentBuilderRepository.
    /// </summary>
     public  PaymentBuilderRepository ( DataContext  dbContext ,  IMapper  mapper ,  ILogger  logger ) :  base ( dbContext ,  mapper ,  logger ) // Initialize  constructor.
    { // Initialize necessary fields or call base constructor.
    ///
    /// 
     
    /// 
     } //
    // Add additional methods or properties as needed.
    }

}