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
    /// Request interface property for ShareRepository.
    /// </summary>
    public interface IRequestShareRepository : ITShareRepository<RequestRequestShareDto, RequestResponseShareDto>
    //, IRequestBuilderRepository<RequestRequestShareDto, RequestResponseShareDto> 
    //  يمكنك   تزويد  بكل دوال   Ibuilder  هنا   بحيث يمكنك استخدامها في الكلاس الذي سيتم توليده
    {
    // Define methods or properties specific to the share repository interface.
    } 
    /// <summary>
    /// Request class property for ShareRepository.
    /// </summary>
     public  class  RequestShareRepository //
    :  BaseShareRepository < RequestRequestShareDto ,  RequestResponseShareDto ,  RequestRequestBuildDto ,  RequestResponseBuildDto > ,  //
    IRequestShareRepository //
    { 
    /// <summary>
    /// BuilderRepository 
    /// </summary>
     private  readonly  RequestBuilderRepository  _builder ;  
    /// <summary>
    /// Constructor for RequestShareRepository.
    /// </summary>
     public  RequestShareRepository ( DataContext  dbContext ,  IMapper  mapper ,  ILoggerFactory  logger ) :  base ( mapper ,  logger ) //
    { // Initialize constructor.
    _builder  =  new  RequestBuilderRepository ( dbContext ,  mapper ,  logger . CreateLogger ( typeof ( RequestShareRepository ) . FullName ) ) ;  //
    //
    } //
    // Add additional methods or properties as needed.
    }

}