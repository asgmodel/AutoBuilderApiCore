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
    /// EventRequest interface property for ShareRepository.
    /// </summary>
    public interface IEventRequestShareRepository : ITShareRepository<EventRequestRequestShareDto, EventRequestResponseShareDto>
    //, IEventRequestBuilderRepository<EventRequestRequestShareDto, EventRequestResponseShareDto> 
    //  يمكنك   تزويد  بكل دوال   Ibuilder  هنا   بحيث يمكنك استخدامها في الكلاس الذي سيتم توليده
    {
    // Define methods or properties specific to the share repository interface.
    } 
    /// <summary>
    /// EventRequest class property for ShareRepository.
    /// </summary>
     public  class  EventRequestShareRepository //
    :  BaseShareRepository < EventRequestRequestShareDto ,  EventRequestResponseShareDto ,  EventRequestRequestBuildDto ,  EventRequestResponseBuildDto > ,  //
    IEventRequestShareRepository //
    { 
    /// <summary>
    /// BuilderRepository 
    /// </summary>
     private  readonly  EventRequestBuilderRepository  _builder ;  
    /// <summary>
    /// Constructor for EventRequestShareRepository.
    /// </summary>
     public  EventRequestShareRepository ( DataContext  dbContext ,  IMapper  mapper ,  ILoggerFactory  logger ) :  base ( mapper ,  logger ) //
    { // Initialize constructor.
    _builder  =  new  EventRequestBuilderRepository ( dbContext ,  mapper ,  logger . CreateLogger ( typeof ( EventRequestShareRepository ) . FullName ) ) ;  //
    //
    } //
    // Add additional methods or properties as needed.
    }

}