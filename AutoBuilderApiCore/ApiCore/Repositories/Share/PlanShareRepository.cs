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
    /// Plan interface property for ShareRepository.
    /// </summary>
    public interface IPlanShareRepository : ITShareRepository<PlanRequestShareDto, PlanResponseShareDto>
    //, IPlanBuilderRepository<PlanRequestShareDto, PlanResponseShareDto> 
    //  يمكنك   تزويد  بكل دوال   Ibuilder  هنا   بحيث يمكنك استخدامها في الكلاس الذي سيتم توليده
    {
    // Define methods or properties specific to the share repository interface.
    } 
    /// <summary>
    /// Plan class property for ShareRepository.
    /// </summary>
     public  class  PlanShareRepository //
    :  BaseShareRepository < PlanRequestShareDto ,  PlanResponseShareDto ,  PlanRequestBuildDto ,  PlanResponseBuildDto > ,  //
    IPlanShareRepository //
    { 
    /// <summary>
    /// BuilderRepository 
    /// </summary>
     private  readonly  PlanBuilderRepository  _builder ;  
    /// <summary>
    /// Constructor for PlanShareRepository.
    /// </summary>
     public  PlanShareRepository ( DataContext  dbContext ,  IMapper  mapper ,  ILoggerFactory  logger ) :  base ( mapper ,  logger ) //
    { // Initialize constructor.
    _builder  =  new  PlanBuilderRepository ( dbContext ,  mapper ,  logger . CreateLogger ( typeof ( PlanShareRepository ) . FullName ) ) ;  //
    //
    } //
    // Add additional methods or properties as needed.
    }

}