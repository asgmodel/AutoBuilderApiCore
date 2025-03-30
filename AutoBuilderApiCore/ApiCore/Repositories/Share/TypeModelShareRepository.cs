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
    /// TypeModel interface property for ShareRepository.
    /// </summary>
    public interface ITypeModelShareRepository : ITShareRepository<TypeModelRequestShareDto, TypeModelResponseShareDto>
    //, ITypeModelBuilderRepository<TypeModelRequestShareDto, TypeModelResponseShareDto> 
    //  يمكنك   تزويد  بكل دوال   Ibuilder  هنا   بحيث يمكنك استخدامها في الكلاس الذي سيتم توليده
    {
    // Define methods or properties specific to the share repository interface.
    } 
    /// <summary>
    /// TypeModel class property for ShareRepository.
    /// </summary>
     public  class  TypeModelShareRepository //
    :  BaseShareRepository < TypeModelRequestShareDto ,  TypeModelResponseShareDto ,  TypeModelRequestBuildDto ,  TypeModelResponseBuildDto > ,  //
    ITypeModelShareRepository //
    { 
    /// <summary>
    /// BuilderRepository 
    /// </summary>
     private  readonly  TypeModelBuilderRepository  _builder ;  
    /// <summary>
    /// Constructor for TypeModelShareRepository.
    /// </summary>
     public  TypeModelShareRepository ( DataContext  dbContext ,  IMapper  mapper ,  ILoggerFactory  logger ) :  base ( mapper ,  logger ) //
    { // Initialize constructor.
    _builder  =  new  TypeModelBuilderRepository ( dbContext ,  mapper ,  logger . CreateLogger ( typeof ( TypeModelShareRepository ) . FullName ) ) ;  //
    //
    } //
    // Add additional methods or properties as needed.
    }

}