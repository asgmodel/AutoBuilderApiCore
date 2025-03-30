using AutoGenerator.Data;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using AutoGenerator.Repositorys.Builder;
using Dto.Build.Requests;
using Dto.Build.Responses;
using AutoGenerator.Models;
using Dto.Share.Requests;
using Dto.Share.Responses;
using Repositorys.Builder;
using AutoGenerator.Repositorys.Share;
using System;

namespace Repositorys.Share
{
    /// <summary>
    /// Payment interface property for ShareRepository.
    /// </summary>
    public interface IPaymentShareRepository : ITShareRepository<PaymentRequestShareDto, PaymentResponseShareDto>
    //, IPaymentBuilderRepository<PaymentRequestShareDto, PaymentResponseShareDto> 
    //  يمكنك   تزويد  بكل دوال   Ibuilder  هنا   بحيث يمكنك استخدامها في الكلاس الذي سيتم توليده
    {
    // Define methods or properties specific to the share repository interface.
    } 
    /// <summary>
    /// Payment class property for ShareRepository.
    /// </summary>
     public  class  PaymentShareRepository //
    :  BaseShareRepository < PaymentRequestShareDto ,  PaymentResponseShareDto ,  PaymentRequestBuildDto ,  PaymentResponseBuildDto > ,  //
    IPaymentShareRepository //
    { 
    /// <summary>
    /// BuilderRepository 
    /// </summary>
     private  readonly  PaymentBuilderRepository  _builder ;  
    /// <summary>
    /// Constructor for PaymentShareRepository.
    /// </summary>
     public  PaymentShareRepository ( DataContext  dbContext ,  IMapper  mapper ,  ILoggerFactory  logger ) :  base ( mapper ,  logger ) //
    { // Initialize constructor.
    _builder  =  new  PaymentBuilderRepository ( dbContext ,  mapper ,  logger . CreateLogger ( typeof ( PaymentShareRepository ) . FullName ) ) ;  //
    //
    } //
    // Add additional methods or properties as needed.
    }

}