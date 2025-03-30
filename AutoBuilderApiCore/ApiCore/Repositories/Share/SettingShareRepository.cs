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
    /// Setting interface property for ShareRepository.
    /// </summary>
    public interface ISettingShareRepository : ITShareRepository<SettingRequestShareDto, SettingResponseShareDto>
    //, ISettingBuilderRepository<SettingRequestShareDto, SettingResponseShareDto> 
    //  يمكنك   تزويد  بكل دوال   Ibuilder  هنا   بحيث يمكنك استخدامها في الكلاس الذي سيتم توليده
    {
    // Define methods or properties specific to the share repository interface.
    } 
    /// <summary>
    /// Setting class property for ShareRepository.
    /// </summary>
     public  class  SettingShareRepository //
    :  BaseShareRepository < SettingRequestShareDto ,  SettingResponseShareDto ,  SettingRequestBuildDto ,  SettingResponseBuildDto > ,  //
    ISettingShareRepository //
    { 
    /// <summary>
    /// BuilderRepository 
    /// </summary>
     private  readonly  SettingBuilderRepository  _builder ;  
    /// <summary>
    /// Constructor for SettingShareRepository.
    /// </summary>
     public  SettingShareRepository ( DataContext  dbContext ,  IMapper  mapper ,  ILoggerFactory  logger ) :  base ( mapper ,  logger ) //
    { // Initialize constructor.
    _builder  =  new  SettingBuilderRepository ( dbContext ,  mapper ,  logger . CreateLogger ( typeof ( SettingShareRepository ) . FullName ) ) ;  //
    //
    } //
    // Add additional methods or properties as needed.
    }

}