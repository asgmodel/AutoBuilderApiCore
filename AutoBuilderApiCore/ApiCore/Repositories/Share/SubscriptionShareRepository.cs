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
    /// Subscription interface property for ShareRepository.
    /// </summary>
    public interface ISubscriptionShareRepository : ITShareRepository<SubscriptionRequestShareDto, SubscriptionResponseShareDto>
    //, ISubscriptionBuilderRepository<SubscriptionRequestShareDto, SubscriptionResponseShareDto> 
    //  يمكنك   تزويد  بكل دوال   Ibuilder  هنا   بحيث يمكنك استخدامها في الكلاس الذي سيتم توليده
    {
    // Define methods or properties specific to the share repository interface.
    } 
    /// <summary>
    /// Subscription class property for ShareRepository.
    /// </summary>
     public  class  SubscriptionShareRepository //
    :  BaseShareRepository < SubscriptionRequestShareDto ,  SubscriptionResponseShareDto ,  SubscriptionRequestBuildDto ,  SubscriptionResponseBuildDto > ,  //
    ISubscriptionShareRepository //
    { 
    /// <summary>
    /// BuilderRepository 
    /// </summary>
     private  readonly  SubscriptionBuilderRepository  _builder ;  
    /// <summary>
    /// Constructor for SubscriptionShareRepository.
    /// </summary>
     public  SubscriptionShareRepository ( DataContext  dbContext ,  IMapper  mapper ,  ILoggerFactory  logger ) :  base ( mapper ,  logger ) //
    { // Initialize constructor.
    _builder  =  new  SubscriptionBuilderRepository ( dbContext ,  mapper ,  logger . CreateLogger ( typeof ( SubscriptionShareRepository ) . FullName ) ) ;  //
    //
    } //
    // Add additional methods or properties as needed.
    }

}