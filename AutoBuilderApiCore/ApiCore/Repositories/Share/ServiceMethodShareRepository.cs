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
    /// ServiceMethod interface property for ShareRepository.
    /// </summary>
    public interface IServiceMethodShareRepository : ITShareRepository<ServiceMethodRequestShareDto, ServiceMethodResponseShareDto>
    //, IServiceMethodBuilderRepository<ServiceMethodRequestShareDto, ServiceMethodResponseShareDto> 
    //  يمكنك   تزويد  بكل دوال   Ibuilder  هنا   بحيث يمكنك استخدامها في الكلاس الذي سيتم توليده
    {
    // Define methods or properties specific to the share repository interface.
    } 
    /// <summary>
    /// ServiceMethod class property for ShareRepository.
    /// </summary>
     public  class  ServiceMethodShareRepository //
    :  BaseShareRepository < ServiceMethodRequestShareDto ,  ServiceMethodResponseShareDto ,  ServiceMethodRequestBuildDto ,  ServiceMethodResponseBuildDto > ,  //
    IServiceMethodShareRepository //
    { 
    /// <summary>
    /// BuilderRepository 
    /// </summary>
     private  readonly  ServiceMethodBuilderRepository  _builder ;  
    /// <summary>
    /// Constructor for ServiceMethodShareRepository.
    /// </summary>
     public  ServiceMethodShareRepository ( DataContext  dbContext ,  IMapper  mapper ,  ILoggerFactory  logger ) :  base ( mapper ,  logger ) //
    { // Initialize constructor.
    _builder  =  new  ServiceMethodBuilderRepository ( dbContext ,  mapper ,  logger . CreateLogger ( typeof ( ServiceMethodShareRepository ) . FullName ) ) ;  //
    //
    } //
    // Add additional methods or properties as needed.
    }

}