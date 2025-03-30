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
    /// Language interface property for ShareRepository.
    /// </summary>
    public interface ILanguageShareRepository : ITShareRepository<LanguageRequestShareDto, LanguageResponseShareDto>
    //, ILanguageBuilderRepository<LanguageRequestShareDto, LanguageResponseShareDto> 
    //  يمكنك   تزويد  بكل دوال   Ibuilder  هنا   بحيث يمكنك استخدامها في الكلاس الذي سيتم توليده
    {
    // Define methods or properties specific to the share repository interface.
    } 
    /// <summary>
    /// Language class property for ShareRepository.
    /// </summary>
     public  class  LanguageShareRepository //
    :  BaseShareRepository < LanguageRequestShareDto ,  LanguageResponseShareDto ,  LanguageRequestBuildDto ,  LanguageResponseBuildDto > ,  //
    ILanguageShareRepository //
    { 
    /// <summary>
    /// BuilderRepository 
    /// </summary>
     private  readonly  LanguageBuilderRepository  _builder ;  
    /// <summary>
    /// Constructor for LanguageShareRepository.
    /// </summary>
     public  LanguageShareRepository ( DataContext  dbContext ,  IMapper  mapper ,  ILoggerFactory  logger ) :  base ( mapper ,  logger ) //
    { // Initialize constructor.
    _builder  =  new  LanguageBuilderRepository ( dbContext ,  mapper ,  logger . CreateLogger ( typeof ( LanguageShareRepository ) . FullName ) ) ;  //
    //
    } //
    // Add additional methods or properties as needed.
    }

}