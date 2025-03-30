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
    /// Service interface property for ShareRepository.
    /// </summary>
    public interface IServiceShareRepository : ITShareRepository<ServiceRequestShareDto, ServiceResponseShareDto>
    //, IServiceBuilderRepository<ServiceRequestShareDto, ServiceResponseShareDto> 
    //  يمكنك   تزويد  بكل دوال   Ibuilder  هنا   بحيث يمكنك استخدامها في الكلاس الذي سيتم توليده
    {
    // Define methods or properties specific to the share repository interface.
    } 
    /// <summary>
    /// Service class property for ShareRepository.
    /// </summary>
     public  class  ServiceShareRepository //
    :  BaseShareRepository < ServiceRequestShareDto ,  ServiceResponseShareDto ,  ServiceRequestBuildDto ,  ServiceResponseBuildDto > ,  //
    IServiceShareRepository //
    { 
    /// <summary>
    /// BuilderRepository 
    /// </summary>
     private  readonly  ServiceBuilderRepository  _builder ;  
    /// <summary>
    /// Constructor for ServiceShareRepository.
    /// </summary>
     public  ServiceShareRepository ( DataContext  dbContext ,  IMapper  mapper ,  ILoggerFactory  logger ) :  base ( mapper ,  logger ) //
    { // Initialize constructor.
    _builder  =  new  ServiceBuilderRepository ( dbContext ,  mapper ,  logger . CreateLogger ( typeof ( ServiceShareRepository ) . FullName ) ) ;  //
    //
    } //
    // Add additional methods or properties as needed.
    }

}