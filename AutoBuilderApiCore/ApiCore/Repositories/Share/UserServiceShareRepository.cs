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
    /// UserService interface property for ShareRepository.
    /// </summary>
    public interface IUserServiceShareRepository : ITShareRepository<UserServiceRequestShareDto, UserServiceResponseShareDto>
    //, IUserServiceBuilderRepository<UserServiceRequestShareDto, UserServiceResponseShareDto> 
    //  يمكنك   تزويد  بكل دوال   Ibuilder  هنا   بحيث يمكنك استخدامها في الكلاس الذي سيتم توليده
    {
    // Define methods or properties specific to the share repository interface.
    } 
    /// <summary>
    /// UserService class property for ShareRepository.
    /// </summary>
     public  class  UserServiceShareRepository //
    :  BaseShareRepository < UserServiceRequestShareDto ,  UserServiceResponseShareDto ,  UserServiceRequestBuildDto ,  UserServiceResponseBuildDto > ,  //
    IUserServiceShareRepository //
    { 
    /// <summary>
    /// BuilderRepository 
    /// </summary>
     private  readonly  UserServiceBuilderRepository  _builder ;  
    /// <summary>
    /// Constructor for UserServiceShareRepository.
    /// </summary>
     public  UserServiceShareRepository ( DataContext  dbContext ,  IMapper  mapper ,  ILoggerFactory  logger ) :  base ( mapper ,  logger ) //
    { // Initialize constructor.
    _builder  =  new  UserServiceBuilderRepository ( dbContext ,  mapper ,  logger . CreateLogger ( typeof ( UserServiceShareRepository ) . FullName ) ) ;  //
    //
    } //
    // Add additional methods or properties as needed.
    }

}