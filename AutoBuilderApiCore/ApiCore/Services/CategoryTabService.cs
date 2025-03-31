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
    public interface ICategoryTabService<TServiceRequestDso, TServiceResponseDso>
        where TServiceRequestDso : class where TServiceResponseDso : class
    {
    //  Task<TServiceResponseDso> CreateAsync(TServiceRequestDso entity);
    // Task<TServiceResponseDso> GetByIdAsync(Guid id);
    // يمكنك إضافة المزيد من الدوال هنا حسب الحاجة.
    } /////
    public  interface  IUseCategoryTabService :  ICategoryTabBuilderRepository < CategoryTabRequestDso ,  CategoryTabResponseDso > ,  ICategoryTabService < CategoryTabRequestDso ,  CategoryTabResponseDso > ,  IBaseService { 
    ///
     /////
    } public  class  CategoryTabService :  BaseService ,  IUseCategoryTabService 
    ///
     { 
    ///
     private  readonly  ICategoryTabShareRepository  _builder ;  
    ///
     public  CategoryTabService ( ICategoryTabShareRepository  categorytabShareRepository ,  IMapper  mapper ,  ILoggerFactory  logger ) 
    ///
     :  base ( mapper ,  logger ) { 
    ///
     _builder  =  categorytabShareRepository ;  
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
     public  async  Task < CategoryTabResponseDso > CreateAsync ( CategoryTabRequestDso  entity ) //
    { // Call the create method in the builder repository.
    //
    var  result  =  await  _builder . CreateAsync ( entity ) ;  // Convert the result to ResponseDso type.
    //
    var  output  =  ( CategoryTabResponseDso ) result ;  // Return the final result.
    //
    return  output ;  //
    } //
    /// <summary>
    /// Method to create a range of entities asynchronously.
    /// </summary>
     public  Task < IEnumerable < CategoryTabResponseDso > > CreateRangeAsync ( IEnumerable < CategoryTabRequestDso > entities ) { //
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
     public  Task  DeleteRangeAsync ( Expression < Func < CategoryTabResponseDso ,  bool > > predicate ) { //
    throw  new  NotImplementedException ( ) ;  //
    } //
    /// <summary>
    /// Method to check if an entity exists based on a condition.
    /// </summary>
     public  Task < bool > ExistsAsync ( Expression < Func < CategoryTabResponseDso ,  bool > > predicate ) { //
    throw  new  NotImplementedException ( ) ;  //
    } //
    /// <summary>
    /// Method to find an entity based on a condition.
    /// </summary>
     public  Task < CategoryTabResponseDso ? > FindAsync ( Expression < Func < CategoryTabResponseDso ,  bool > > predicate ) { //
    throw  new  NotImplementedException ( ) ;  //
    } //
    /// <summary>
    /// Method to retrieve all entities.
    /// </summary>
     public  Task < IEnumerable < CategoryTabResponseDso > > GetAllAsync ( ) { //
    throw  new  NotImplementedException ( ) ;  //
    } //
    /// <summary>
    /// Method to get an entity by its unique ID.
    /// </summary>
     public  Task < CategoryTabResponseDso ? > GetByIdAsync ( int  id ) { //
    throw  new  NotImplementedException ( ) ;  //
    } //
    /// <summary>
    /// Method to get data using a specific ID.
    /// </summary>
     public  Task < CategoryTabResponseDso > getData ( int  id ) { //
    throw  new  NotImplementedException ( ) ;  //
    } //
    /// <summary>
    /// Method to retrieve data as an IQueryable object.
    /// </summary>
     public  IQueryable < CategoryTabResponseDso > GetQueryable ( ) { //
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
     public  Task < CategoryTabResponseDso > UpdateAsync ( CategoryTabRequestDso  entity ) { //
    throw  new  NotImplementedException ( ) ;  //
    } //
    }

}