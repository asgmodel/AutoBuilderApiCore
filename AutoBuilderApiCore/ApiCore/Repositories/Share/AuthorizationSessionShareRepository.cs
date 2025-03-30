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
    /// AuthorizationSession interface property for ShareRepository.
    /// </summary>
    public interface IAuthorizationSessionShareRepository : ITShareRepository<AuthorizationSessionRequestShareDto, AuthorizationSessionResponseShareDto>
    //, IAuthorizationSessionBuilderRepository<AuthorizationSessionRequestShareDto, AuthorizationSessionResponseShareDto> 
    //  يمكنك   تزويد  بكل دوال   Ibuilder  هنا   بحيث يمكنك استخدامها في الكلاس الذي سيتم توليده
    {
    // Define methods or properties specific to the share repository interface.
    } 
    /// <summary>
    /// AuthorizationSession class property for ShareRepository.
    /// </summary>
     public  class  AuthorizationSessionShareRepository //
    :  BaseShareRepository < AuthorizationSessionRequestShareDto ,  AuthorizationSessionResponseShareDto ,  AuthorizationSessionRequestBuildDto ,  AuthorizationSessionResponseBuildDto > ,  //
    IAuthorizationSessionShareRepository //
    { 
    /// <summary>
    /// BuilderRepository 
    /// </summary>
     private  readonly  AuthorizationSessionBuilderRepository  _builder ;  
    /// <summary>
    /// Constructor for AuthorizationSessionShareRepository.
    /// </summary>
     public  AuthorizationSessionShareRepository ( DataContext  dbContext ,  IMapper  mapper ,  ILoggerFactory  logger ) :  base ( mapper ,  logger ) //
    { // Initialize constructor.
    _builder  =  new  AuthorizationSessionBuilderRepository ( dbContext ,  mapper ,  logger . CreateLogger ( typeof ( AuthorizationSessionShareRepository ) . FullName ) ) ;  //
    //
    } //
    // Add additional methods or properties as needed.
    }

}