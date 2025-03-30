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
    /// CategoryTab interface property for ShareRepository.
    /// </summary>
    public interface ICategoryTabShareRepository : ITShareRepository<CategoryTabRequestShareDto, CategoryTabResponseShareDto>
    //, ICategoryTabBuilderRepository<CategoryTabRequestShareDto, CategoryTabResponseShareDto> 
    //  يمكنك   تزويد  بكل دوال   Ibuilder  هنا   بحيث يمكنك استخدامها في الكلاس الذي سيتم توليده
    {
    // Define methods or properties specific to the share repository interface.
    } 
    /// <summary>
    /// CategoryTab class property for ShareRepository.
    /// </summary>
     public  class  CategoryTabShareRepository //
    :  BaseShareRepository < CategoryTabRequestShareDto ,  CategoryTabResponseShareDto ,  CategoryTabRequestBuildDto ,  CategoryTabResponseBuildDto > ,  //
    ICategoryTabShareRepository //
    { 
    /// <summary>
    /// BuilderRepository 
    /// </summary>
     private  readonly  CategoryTabBuilderRepository  _builder ;  
    /// <summary>
    /// Constructor for CategoryTabShareRepository.
    /// </summary>
     public  CategoryTabShareRepository ( DataContext  dbContext ,  IMapper  mapper ,  ILoggerFactory  logger ) :  base ( mapper ,  logger ) //
    { // Initialize constructor.
    _builder  =  new  CategoryTabBuilderRepository ( dbContext ,  mapper ,  logger . CreateLogger ( typeof ( CategoryTabShareRepository ) . FullName ) ) ;  //
    //
    } //
    // Add additional methods or properties as needed.
    }

}