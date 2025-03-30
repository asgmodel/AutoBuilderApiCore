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
    /// Dialect interface property for ShareRepository.
    /// </summary>
    public interface IDialectShareRepository : ITShareRepository<DialectRequestShareDto, DialectResponseShareDto>
    //, IDialectBuilderRepository<DialectRequestShareDto, DialectResponseShareDto> 
    //  يمكنك   تزويد  بكل دوال   Ibuilder  هنا   بحيث يمكنك استخدامها في الكلاس الذي سيتم توليده
    {
    // Define methods or properties specific to the share repository interface.
    } 
    /// <summary>
    /// Dialect class property for ShareRepository.
    /// </summary>
     public  class  DialectShareRepository //
    :  BaseShareRepository < DialectRequestShareDto ,  DialectResponseShareDto ,  DialectRequestBuildDto ,  DialectResponseBuildDto > ,  //
    IDialectShareRepository //
    { 
    /// <summary>
    /// BuilderRepository 
    /// </summary>
     private  readonly  DialectBuilderRepository  _builder ;  
    /// <summary>
    /// Constructor for DialectShareRepository.
    /// </summary>
     public  DialectShareRepository ( DataContext  dbContext ,  IMapper  mapper ,  ILoggerFactory  logger ) :  base ( mapper ,  logger ) //
    { // Initialize constructor.
    _builder  =  new  DialectBuilderRepository ( dbContext ,  mapper ,  logger . CreateLogger ( typeof ( DialectShareRepository ) . FullName ) ) ;  //
    //
    } //
    // Add additional methods or properties as needed.
    }

}