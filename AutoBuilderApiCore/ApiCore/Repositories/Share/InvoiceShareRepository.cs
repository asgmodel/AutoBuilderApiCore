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
    /// Invoice interface property for ShareRepository.
    /// </summary>
    public interface IInvoiceShareRepository : ITShareRepository<InvoiceRequestShareDto, InvoiceResponseShareDto>
    //, IInvoiceBuilderRepository<InvoiceRequestShareDto, InvoiceResponseShareDto> 
    //  يمكنك   تزويد  بكل دوال   Ibuilder  هنا   بحيث يمكنك استخدامها في الكلاس الذي سيتم توليده
    {
    // Define methods or properties specific to the share repository interface.
    } 
    /// <summary>
    /// Invoice class property for ShareRepository.
    /// </summary>
     public  class  InvoiceShareRepository //
    :  BaseShareRepository < InvoiceRequestShareDto ,  InvoiceResponseShareDto ,  InvoiceRequestBuildDto ,  InvoiceResponseBuildDto > ,  //
    IInvoiceShareRepository //
    { 
    /// <summary>
    /// BuilderRepository 
    /// </summary>
     private  readonly  InvoiceBuilderRepository  _builder ;  
    /// <summary>
    /// Constructor for InvoiceShareRepository.
    /// </summary>
     public  InvoiceShareRepository ( DataContext  dbContext ,  IMapper  mapper ,  ILoggerFactory  logger ) :  base ( mapper ,  logger ) //
    { // Initialize constructor.
    _builder  =  new  InvoiceBuilderRepository ( dbContext ,  mapper ,  logger . CreateLogger ( typeof ( InvoiceShareRepository ) . FullName ) ) ;  //
    //
    } //
    // Add additional methods or properties as needed.
    }

}