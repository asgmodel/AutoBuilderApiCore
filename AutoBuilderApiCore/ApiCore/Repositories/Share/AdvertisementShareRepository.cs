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
    /// Advertisement interface property for ShareRepository.
    /// </summary>
    public interface IAdvertisementShareRepository : ITShareRepository<AdvertisementRequestShareDto, AdvertisementResponseShareDto>
    //, IAdvertisementBuilderRepository<AdvertisementRequestShareDto, AdvertisementResponseShareDto> 
    //  يمكنك   تزويد  بكل دوال   Ibuilder  هنا   بحيث يمكنك استخدامها في الكلاس الذي سيتم توليده
    {
    // Define methods or properties specific to the share repository interface.
    } 
    /// <summary>
    /// Advertisement class property for ShareRepository.
    /// </summary>
     public  class  AdvertisementShareRepository //
    :  BaseShareRepository < AdvertisementRequestShareDto ,  AdvertisementResponseShareDto ,  AdvertisementRequestBuildDto ,  AdvertisementResponseBuildDto > ,  //
    IAdvertisementShareRepository //
    { 
    /// <summary>
    /// BuilderRepository 
    /// </summary>
     private  readonly  AdvertisementBuilderRepository  _builder ;  
    /// <summary>
    /// Constructor for AdvertisementShareRepository.
    /// </summary>
     public  AdvertisementShareRepository ( DataContext  dbContext ,  IMapper  mapper ,  ILoggerFactory  logger ) :  base ( mapper ,  logger ) //
    { // Initialize constructor.
    _builder  =  new  AdvertisementBuilderRepository ( dbContext ,  mapper ,  logger . CreateLogger ( typeof ( AdvertisementShareRepository ) . FullName ) ) ;  //
    //
    } //
    // Add additional methods or properties as needed.
    }

}