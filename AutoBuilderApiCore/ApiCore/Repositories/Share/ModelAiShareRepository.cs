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
    /// ModelAi interface property for ShareRepository.
    /// </summary>
    public interface IModelAiShareRepository : ITShareRepository<ModelAiRequestShareDto, ModelAiResponseShareDto>
    //, IModelAiBuilderRepository<ModelAiRequestShareDto, ModelAiResponseShareDto> 
    //  يمكنك   تزويد  بكل دوال   Ibuilder  هنا   بحيث يمكنك استخدامها في الكلاس الذي سيتم توليده
    {
    // Define methods or properties specific to the share repository interface.
    } 
    /// <summary>
    /// ModelAi class property for ShareRepository.
    /// </summary>
     public  class  ModelAiShareRepository //
    :  BaseShareRepository < ModelAiRequestShareDto ,  ModelAiResponseShareDto ,  ModelAiRequestBuildDto ,  ModelAiResponseBuildDto > ,  //
    IModelAiShareRepository //
    { 
    /// <summary>
    /// BuilderRepository 
    /// </summary>
     private  readonly  ModelAiBuilderRepository  _builder ;  
    /// <summary>
    /// Constructor for ModelAiShareRepository.
    /// </summary>
     public  ModelAiShareRepository ( DataContext  dbContext ,  IMapper  mapper ,  ILoggerFactory  logger ) :  base ( mapper ,  logger ) //
    { // Initialize constructor.
    _builder  =  new  ModelAiBuilderRepository ( dbContext ,  mapper ,  logger . CreateLogger ( typeof ( ModelAiShareRepository ) . FullName ) ) ;  //
    //
    } //
    // Add additional methods or properties as needed.
    }

}