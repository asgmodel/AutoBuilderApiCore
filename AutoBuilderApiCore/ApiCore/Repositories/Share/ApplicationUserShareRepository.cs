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
    /// ApplicationUser interface property for ShareRepository.
    /// </summary>
    public interface IApplicationUserShareRepository : ITShareRepository<ApplicationUserRequestShareDto, ApplicationUserResponseShareDto>
    //, IApplicationUserBuilderRepository<ApplicationUserRequestShareDto, ApplicationUserResponseShareDto> 
    //  يمكنك   تزويد  بكل دوال   Ibuilder  هنا   بحيث يمكنك استخدامها في الكلاس الذي سيتم توليده
    {
    // Define methods or properties specific to the share repository interface.
    } 
    /// <summary>
    /// ApplicationUser class property for ShareRepository.
    /// </summary>
     public  class  ApplicationUserShareRepository //
    :  BaseShareRepository < ApplicationUserRequestShareDto ,  ApplicationUserResponseShareDto ,  ApplicationUserRequestBuildDto ,  ApplicationUserResponseBuildDto > ,  //
    IApplicationUserShareRepository //
    { 
    /// <summary>
    /// BuilderRepository 
    /// </summary>
     private  readonly  ApplicationUserBuilderRepository  _builder ;  
    /// <summary>
    /// Constructor for ApplicationUserShareRepository.
    /// </summary>
     public  ApplicationUserShareRepository ( DataContext  dbContext ,  IMapper  mapper ,  ILoggerFactory  logger ) :  base ( mapper ,  logger ) //
    { // Initialize constructor.
    _builder  =  new  ApplicationUserBuilderRepository ( dbContext ,  mapper ,  logger . CreateLogger ( typeof ( ApplicationUserShareRepository ) . FullName ) ) ;  //
    //
    } //
    // Add additional methods or properties as needed.
    }

}