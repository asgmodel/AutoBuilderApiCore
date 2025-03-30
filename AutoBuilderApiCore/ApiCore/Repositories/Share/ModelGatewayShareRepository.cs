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
    /// ModelGateway interface property for ShareRepository.
    /// </summary>
    public interface IModelGatewayShareRepository : ITShareRepository<ModelGatewayRequestShareDto, ModelGatewayResponseShareDto>
    //, IModelGatewayBuilderRepository<ModelGatewayRequestShareDto, ModelGatewayResponseShareDto> 
    //  يمكنك   تزويد  بكل دوال   Ibuilder  هنا   بحيث يمكنك استخدامها في الكلاس الذي سيتم توليده
    {
    // Define methods or properties specific to the share repository interface.
    } 
    /// <summary>
    /// ModelGateway class property for ShareRepository.
    /// </summary>
     public  class  ModelGatewayShareRepository //
    :  BaseShareRepository < ModelGatewayRequestShareDto ,  ModelGatewayResponseShareDto ,  ModelGatewayRequestBuildDto ,  ModelGatewayResponseBuildDto > ,  //
    IModelGatewayShareRepository //
    { 
    /// <summary>
    /// BuilderRepository 
    /// </summary>
     private  readonly  ModelGatewayBuilderRepository  _builder ;  
    /// <summary>
    /// Constructor for ModelGatewayShareRepository.
    /// </summary>
     public  ModelGatewayShareRepository ( DataContext  dbContext ,  IMapper  mapper ,  ILoggerFactory  logger ) :  base ( mapper ,  logger ) //
    { // Initialize constructor.
    _builder  =  new  ModelGatewayBuilderRepository ( dbContext ,  mapper ,  logger . CreateLogger ( typeof ( ModelGatewayShareRepository ) . FullName ) ) ;  //
    //
    } //
    // Add additional methods or properties as needed.
    }

}