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
    /// UserModelAi interface property for ShareRepository.
    /// </summary>
    public interface IUserModelAiShareRepository : ITShareRepository<UserModelAiRequestShareDto, UserModelAiResponseShareDto>
    //, IUserModelAiBuilderRepository<UserModelAiRequestShareDto, UserModelAiResponseShareDto> 
    //  يمكنك   تزويد  بكل دوال   Ibuilder  هنا   بحيث يمكنك استخدامها في الكلاس الذي سيتم توليده
    {
    // Define methods or properties specific to the share repository interface.
    } 
    /// <summary>
    /// UserModelAi class property for ShareRepository.
    /// </summary>
     public  class  UserModelAiShareRepository //
    :  BaseShareRepository < UserModelAiRequestShareDto ,  UserModelAiResponseShareDto ,  UserModelAiRequestBuildDto ,  UserModelAiResponseBuildDto > ,  //
    IUserModelAiShareRepository //
    { 
    /// <summary>
    /// BuilderRepository 
    /// </summary>
     private  readonly  UserModelAiBuilderRepository  _builder ;  
    /// <summary>
    /// Constructor for UserModelAiShareRepository.
    /// </summary>
     public  UserModelAiShareRepository ( DataContext  dbContext ,  IMapper  mapper ,  ILoggerFactory  logger ) :  base ( mapper ,  logger ) //
    { // Initialize constructor.
    _builder  =  new  UserModelAiBuilderRepository ( dbContext ,  mapper ,  logger . CreateLogger ( typeof ( UserModelAiShareRepository ) . FullName ) ) ;  //
    //
    } //
    // Add additional methods or properties as needed.
    }

}