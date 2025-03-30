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
    /// Space interface property for ShareRepository.
    /// </summary>
    public interface ISpaceShareRepository : ITShareRepository<SpaceRequestShareDto, SpaceResponseShareDto>
    //, ISpaceBuilderRepository<SpaceRequestShareDto, SpaceResponseShareDto> 
    //  يمكنك   تزويد  بكل دوال   Ibuilder  هنا   بحيث يمكنك استخدامها في الكلاس الذي سيتم توليده
    {
    // Define methods or properties specific to the share repository interface.
    } 
    /// <summary>
    /// Space class property for ShareRepository.
    /// </summary>
     public  class  SpaceShareRepository //
    :  BaseShareRepository < SpaceRequestShareDto ,  SpaceResponseShareDto ,  SpaceRequestBuildDto ,  SpaceResponseBuildDto > ,  //
    ISpaceShareRepository //
    { 
    /// <summary>
    /// BuilderRepository 
    /// </summary>
     private  readonly  SpaceBuilderRepository  _builder ;  
    /// <summary>
    /// Constructor for SpaceShareRepository.
    /// </summary>
     public  SpaceShareRepository ( DataContext  dbContext ,  IMapper  mapper ,  ILoggerFactory  logger ) :  base ( mapper ,  logger ) //
    { // Initialize constructor.
    _builder  =  new  SpaceBuilderRepository ( dbContext ,  mapper ,  logger . CreateLogger ( typeof ( SpaceShareRepository ) . FullName ) ) ;  //
    //
    } //
    // Add additional methods or properties as needed.
    }

}