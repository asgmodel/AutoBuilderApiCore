using AutoGenerator.Data;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using AutoGenerator.Services.Base;
using ApiCore.DyModels.Dso.Requests;
using ApiCore.DyModels.Dso.Responses;
using AutoGenerator.Models;
using ApiCore.DyModels.Dto.Share.Requests;
using ApiCore.DyModels.Dto.Share.Responses;
using ApiCore.Repositorys.Share;
using System.Linq.Expressions;
using ApiCore.Repositorys.Builder;
using System;

namespace ApiCore.Services.Services
{
    public interface ISpaceService<TServiceRequestDso, TServiceResponseDso>
        where TServiceRequestDso : class where TServiceResponseDso : class
    {
    //  Task<TServiceResponseDso> CreateAsync(TServiceRequestDso entity);
    // Task<TServiceResponseDso> GetByIdAsync(Guid id);
    // يمكنك إضافة المزيد من الدوال هنا حسب الحاجة.
    } /////
    public  interface  IUseSpaceService :  ISpaceBuilderRepository < SpaceRequestDso ,  SpaceResponseDso > ,  ISpaceService < SpaceRequestDso ,  SpaceResponseDso > ,  IBaseService { 
    ///
     /////
    } public  class  SpaceService :  BaseService ,  IUseSpaceService 
    ///
     { 
    ///
     private  readonly  ISpaceShareRepository  _builder ;  
    ///
     public  SpaceService ( ISpaceShareRepository  spaceShareRepository ,  IMapper  mapper ,  ILoggerFactory  logger ) 
    ///
     :  base ( mapper ,  logger ) { 
    ///
     _builder  =  spaceShareRepository ;  
    ///
     } 
    ///
     // يمكنك إضافة المزيد من الدوال مثل UpdateAsync أو DeleteAsync إذا كان ذلك مطلوبًا.
    // Additional methods can be added as needed.
    //
    /// <summary>
    /// Method to count the number of entities.
    /// </summary>
     public  Task < int > CountAsync ( ) //
    { // Throw an exception indicating the method is not implemented.
    //
    throw  new  NotImplementedException ( ) ;  //
    } //
    /// <summary>
    /// Method to create a new entity asynchronously.
    /// </summary>
     public  async  Task < SpaceResponseDso > CreateAsync ( SpaceRequestDso  entity ) //
    { // Call the create method in the builder repository.
    //
    var  result  =  await  _builder . CreateAsync ( entity ) ;  // Convert the result to ResponseDso type.
    //
    var  output  =  ( SpaceResponseDso ) result ;  // Return the final result.
    //
    return  output ;  //
    } //
    /// <summary>
    /// Method to create a range of entities asynchronously.
    /// </summary>
     public  Task < IEnumerable < SpaceResponseDso > > CreateRangeAsync ( IEnumerable < SpaceRequestDso > entities ) { //
    throw  new  NotImplementedException ( ) ;  //
    } //
    /// <summary>
    /// Method to delete a specific entity.
    /// </summary>
     public  Task  DeleteAsync ( int  id ) { //
    throw  new  NotImplementedException ( ) ;  //
    } //
    /// <summary>
    /// Method to delete a range of entities based on a condition.
    /// </summary>
     public  Task  DeleteRangeAsync ( Expression < Func < SpaceResponseDso ,  bool > > predicate ) { //
    throw  new  NotImplementedException ( ) ;  //
    } //
    /// <summary>
    /// Method to check if an entity exists based on a condition.
    /// </summary>
     public  Task < bool > ExistsAsync ( Expression < Func < SpaceResponseDso ,  bool > > predicate ) { //
    throw  new  NotImplementedException ( ) ;  //
    } //
    /// <summary>
    /// Method to find an entity based on a condition.
    /// </summary>
     public  Task < SpaceResponseDso ? > FindAsync ( Expression < Func < SpaceResponseDso ,  bool > > predicate ) { //
    throw  new  NotImplementedException ( ) ;  //
    } //
    /// <summary>
    /// Method to retrieve all entities.
    /// </summary>
     public  Task < IEnumerable < SpaceResponseDso > > GetAllAsync ( ) { //
    throw  new  NotImplementedException ( ) ;  //
    } //
    /// <summary>
    /// Method to get an entity by its unique ID.
    /// </summary>
     public  Task < SpaceResponseDso ? > GetByIdAsync ( int  id ) { //
    throw  new  NotImplementedException ( ) ;  //
    } //
    /// <summary>
    /// Method to get data using a specific ID.
    /// </summary>
     public  Task < SpaceResponseDso > getData ( int  id ) { //
    throw  new  NotImplementedException ( ) ;  //
    } //
    /// <summary>
    /// Method to retrieve data as an IQueryable object.
    /// </summary>
     public  IQueryable < SpaceResponseDso > GetQueryable ( ) { //
    throw  new  NotImplementedException ( ) ;  //
    } //
    /// <summary>
    /// Method to save changes to the database.
    /// </summary>
     public  Task  SaveChangesAsync ( ) { //
    throw  new  NotImplementedException ( ) ;  //
    } //
    /// <summary>
    /// Method to update a specific entity.
    /// </summary>
     public  Task < SpaceResponseDso > UpdateAsync ( SpaceRequestDso  entity ) { //
    throw  new  NotImplementedException ( ) ;  //
    } //
    }

}