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
    /// PlanFeature interface property for ShareRepository.
    /// </summary>
    public interface IPlanFeatureShareRepository : ITShareRepository<PlanFeatureRequestShareDto, PlanFeatureResponseShareDto>
    //, IPlanFeatureBuilderRepository<PlanFeatureRequestShareDto, PlanFeatureResponseShareDto> 
    //  يمكنك   تزويد  بكل دوال   Ibuilder  هنا   بحيث يمكنك استخدامها في الكلاس الذي سيتم توليده
    {
    // Define methods or properties specific to the share repository interface.
    } 
    /// <summary>
    /// PlanFeature class property for ShareRepository.
    /// </summary>
     public  class  PlanFeatureShareRepository //
    :  BaseShareRepository < PlanFeatureRequestShareDto ,  PlanFeatureResponseShareDto ,  PlanFeatureRequestBuildDto ,  PlanFeatureResponseBuildDto > ,  //
    IPlanFeatureShareRepository //
    { 
    /// <summary>
    /// BuilderRepository 
    /// </summary>
     private  readonly  PlanFeatureBuilderRepository  _builder ;  
    /// <summary>
    /// Constructor for PlanFeatureShareRepository.
    /// </summary>
     public  PlanFeatureShareRepository ( DataContext  dbContext ,  IMapper  mapper ,  ILoggerFactory  logger ) :  base ( mapper ,  logger ) //
    { // Initialize constructor.
    _builder  =  new  PlanFeatureBuilderRepository ( dbContext ,  mapper ,  logger . CreateLogger ( typeof ( PlanFeatureShareRepository ) . FullName ) ) ;  //
    //
    } //
    // Add additional methods or properties as needed.
    }

}