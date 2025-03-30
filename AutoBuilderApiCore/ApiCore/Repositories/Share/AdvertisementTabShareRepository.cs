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
    /// AdvertisementTab interface property for ShareRepository.
    /// </summary>
    public interface IAdvertisementTabShareRepository : ITShareRepository<AdvertisementTabRequestShareDto, AdvertisementTabResponseShareDto>
    //, IAdvertisementTabBuilderRepository<AdvertisementTabRequestShareDto, AdvertisementTabResponseShareDto> 
    //  يمكنك   تزويد  بكل دوال   Ibuilder  هنا   بحيث يمكنك استخدامها في الكلاس الذي سيتم توليده
    {
    // Define methods or properties specific to the share repository interface.
    } 
    /// <summary>
    /// AdvertisementTab class property for ShareRepository.
    /// </summary>
     public  class  AdvertisementTabShareRepository //
    :  BaseShareRepository < AdvertisementTabRequestShareDto ,  AdvertisementTabResponseShareDto ,  AdvertisementTabRequestBuildDto ,  AdvertisementTabResponseBuildDto > ,  //
    IAdvertisementTabShareRepository //
    { 
    /// <summary>
    /// BuilderRepository 
    /// </summary>
     private  readonly  AdvertisementTabBuilderRepository  _builder ;  
    /// <summary>
    /// Constructor for AdvertisementTabShareRepository.
    /// </summary>
     public  AdvertisementTabShareRepository ( DataContext  dbContext ,  IMapper  mapper ,  ILoggerFactory  logger ) :  base ( mapper ,  logger ) //
    { // Initialize constructor.
    _builder  =  new  AdvertisementTabBuilderRepository ( dbContext ,  mapper ,  logger . CreateLogger ( typeof ( AdvertisementTabShareRepository ) . FullName ) ) ;  //
    //
    } //
    // Add additional methods or properties as needed.
    }

}