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
    public interface IUserServiceService<TServiceRequestDso, TServiceResponseDso>
        where TServiceRequestDso : class where TServiceResponseDso : class
    {
    //  Task<TServiceResponseDso> CreateAsync(TServiceRequestDso entity);
    // Task<TServiceResponseDso> GetByIdAsync(Guid id);
    // يمكنك إضافة المزيد من الدوال هنا حسب الحاجة.
    } /////
    public  interface  IUseUserServiceService :  IUserServiceService < UserServiceRequestDso ,  UserServiceResponseDso > { 
    ///
     /////
    } public  class  UserServiceService :  BaseService ,  IUseUserServiceService 
    ///
     { 
    ///
     private  readonly  IUserServiceShareRepository  _userserviceShareRepository ;  
    ///
     public  UserServiceService ( IUserServiceShareRepository  userserviceShareRepository ,  IMapper  mapper ,  ILoggerFactory  logger ) 
    ///
     :  base ( mapper ,  logger ) { 
    ///
     _userserviceShareRepository  =  userserviceShareRepository ;  
    ///
     } 
    ///
     // يمكنك إضافة المزيد من الدوال مثل UpdateAsync أو DeleteAsync إذا كان ذلك مطلوبًا.
    }

}