using AutoGenerator.Data;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using AutoGenerator.Services.Base;
using Dso.Requests;
using Dso.Responses;
using AutoGenerator.Models;
using Dto.Share.Requests;
using Dto.Share.Responses;
using Repositorys.Share;
using System.Linq.Expressions;
using Repositorys.Builder;
using System;

namespace Services.Services
{
    public interface ICategoryModelService<TServiceRequestDso, TServiceResponseDso>
        where TServiceRequestDso : class where TServiceResponseDso : class
    {
    //  Task<TServiceResponseDso> CreateAsync(TServiceRequestDso entity);
    // Task<TServiceResponseDso> GetByIdAsync(Guid id);
    // يمكنك إضافة المزيد من الدوال هنا حسب الحاجة.
    } /////
    public  interface  IUseCategoryModelService :  ICategoryModelBuilderRepository < CategoryModelRequestDso ,  CategoryModelResponseDso > ,  ICategoryModelService < CategoryModelRequestDso ,  CategoryModelResponseDso > ,  IBaseService { 
    ///
     /////
    } public  class  CategoryModelService :  BaseService ,  IUseCategoryModelService 
    ///
     { 
    ///
     private  readonly  ICategoryModelShareRepository  _builder ;  
    ///
     public  CategoryModelService ( ICategoryModelShareRepository  categorymodelShareRepository ,  IMapper  mapper ,  ILoggerFactory  logger ) 
    ///
     :  base ( mapper ,  logger ) { 
    ///
     _builder  =  categorymodelShareRepository ;  
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
     public  async  Task < CategoryModelResponseDso > CreateAsync ( CategoryModelRequestDso  entity ) //
    { // Call the create method in the builder repository.
    //
    var  result  =  await  _builder . CreateAsync ( entity ) ;  // Convert the result to ResponseDso type.
    //
    var  output  =  ( CategoryModelResponseDso ) result ;  // Return the final result.
    //
    return  output ;  //
    } //
    /// <summary>
    /// Method to create a range of entities asynchronously.
    /// </summary>
     public  Task < IEnumerable < CategoryModelResponseDso > > CreateRangeAsync ( IEnumerable < CategoryModelRequestDso > entities ) { //
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
     public  Task  DeleteRangeAsync ( Expression < Func < CategoryModelResponseDso ,  bool > > predicate ) { //
    throw  new  NotImplementedException ( ) ;  //
    } //
    /// <summary>
    /// Method to check if an entity exists based on a condition.
    /// </summary>
     public  Task < bool > ExistsAsync ( Expression < Func < CategoryModelResponseDso ,  bool > > predicate ) { //
    throw  new  NotImplementedException ( ) ;  //
    } //
    /// <summary>
    /// Method to find an entity based on a condition.
    /// </summary>
     public  Task < CategoryModelResponseDso ? > FindAsync ( Expression < Func < CategoryModelResponseDso ,  bool > > predicate ) { //
    throw  new  NotImplementedException ( ) ;  //
    } //
    /// <summary>
    /// Method to retrieve all entities.
    /// </summary>
     public  Task < IEnumerable < CategoryModelResponseDso > > GetAllAsync ( ) { //
    throw  new  NotImplementedException ( ) ;  //
    } //
    /// <summary>
    /// Method to get an entity by its unique ID.
    /// </summary>
     public  Task < CategoryModelResponseDso ? > GetByIdAsync ( int  id ) { //
    throw  new  NotImplementedException ( ) ;  //
    } //
    /// <summary>
    /// Method to get data using a specific ID.
    /// </summary>
     public  Task < CategoryModelResponseDso > getData ( int  id ) { //
    throw  new  NotImplementedException ( ) ;  //
    } //
    /// <summary>
    /// Method to retrieve data as an IQueryable object.
    /// </summary>
     public  IQueryable < CategoryModelResponseDso > GetQueryable ( ) { //
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
     public  Task < CategoryModelResponseDso > UpdateAsync ( CategoryModelRequestDso  entity ) { //
    throw  new  NotImplementedException ( ) ;  //
    } //
    }

}