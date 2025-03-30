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
    /// CategoryModel interface property for ShareRepository.
    /// </summary>
    public interface ICategoryModelShareRepository : ITShareRepository<CategoryModelRequestShareDto, CategoryModelResponseShareDto>
    //, ICategoryModelBuilderRepository<CategoryModelRequestShareDto, CategoryModelResponseShareDto> 
    //  يمكنك   تزويد  بكل دوال   Ibuilder  هنا   بحيث يمكنك استخدامها في الكلاس الذي سيتم توليده
    {
    // Define methods or properties specific to the share repository interface.
    } 
    /// <summary>
    /// CategoryModel class property for ShareRepository.
    /// </summary>
     public  class  CategoryModelShareRepository //
    :  BaseShareRepository < CategoryModelRequestShareDto ,  CategoryModelResponseShareDto ,  CategoryModelRequestBuildDto ,  CategoryModelResponseBuildDto > ,  //
    ICategoryModelShareRepository //
    { 
    /// <summary>
    /// BuilderRepository 
    /// </summary>
     private  readonly  CategoryModelBuilderRepository  _builder ;  
    /// <summary>
    /// Constructor for CategoryModelShareRepository.
    /// </summary>
     public  CategoryModelShareRepository ( DataContext  dbContext ,  IMapper  mapper ,  ILoggerFactory  logger ) :  base ( mapper ,  logger ) //
    { // Initialize constructor.
    _builder  =  new  CategoryModelBuilderRepository ( dbContext ,  mapper ,  logger . CreateLogger ( typeof ( CategoryModelShareRepository ) . FullName ) ) ;  //
    //
    } //
    // Add additional methods or properties as needed.
    }

}