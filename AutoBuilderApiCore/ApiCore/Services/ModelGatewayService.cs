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
using System;

namespace Services.Services
{
    public interface IModelGatewayService<TServiceRequestDso, TServiceResponseDso>
        where TServiceRequestDso : class where TServiceResponseDso : class
    {
    //  Task<TServiceResponseDso> CreateAsync(TServiceRequestDso entity);
    // Task<TServiceResponseDso> GetByIdAsync(Guid id);
    // يمكنك إضافة المزيد من الدوال هنا حسب الحاجة.
    } /////
    public  interface  IUseModelGatewayService :  IModelGatewayService < ModelGatewayRequestDso ,  ModelGatewayResponseDso > { 
    ///
     /////
    } public  class  ModelGatewayService :  BaseService ,  IUseModelGatewayService 
    ///
     { 
    ///
     private  readonly  IModelGatewayShareRepository  _modelgatewayShareRepository ;  
    ///
     public  ModelGatewayService ( IModelGatewayShareRepository  modelgatewayShareRepository ,  IMapper  mapper ,  ILoggerFactory  logger ) 
    ///
     :  base ( mapper ,  logger ) { 
    ///
     _modelgatewayShareRepository  =  modelgatewayShareRepository ;  
    ///
     } 
    ///
     // يمكنك إضافة المزيد من الدوال مثل UpdateAsync أو DeleteAsync إذا كان ذلك مطلوبًا.
    }

}