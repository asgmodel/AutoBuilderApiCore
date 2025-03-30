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
using AutoGenerator;

namespace Services.Services
{
    public interface IInvoiceService<TServiceRequestDso, TServiceResponseDso>
        where TServiceRequestDso : class where TServiceResponseDso : class
    {
      Task<TServiceResponseDso> CreateAsync(TServiceRequestDso entity);
    // Task<TServiceResponseDso> GetByIdAsync(Guid id);
    // يمكنك إضافة المزيد من الدوال هنا حسب الحاجة.
    } /////
    public  interface  IUseInvoiceService :  IInvoiceService < InvoiceRequestDso ,  InvoiceResponseDso >, ITBaseService
    { 
    ///
     /////
    } public  class  InvoiceService :  BaseService ,  IUseInvoiceService 
    ///
     { 
    ///
     private  readonly  IInvoiceShareRepository  _invoiceShareRepository ;  
    ///
     public  InvoiceService ( IInvoiceShareRepository  invoiceShareRepository ,  IMapper  mapper ,  ILoggerFactory  logger ) 
    ///
     :  base ( mapper ,  logger ) { 
    ///
     _invoiceShareRepository  =  invoiceShareRepository ;  
    ///
     }

        public Task<InvoiceResponseDso> CreateAsync(InvoiceRequestDso entity)
        {
            throw new NotImplementedException();
        }

        ///
        // يمكنك إضافة المزيد من الدوال مثل UpdateAsync أو DeleteAsync إذا كان ذلك مطلوبًا.
    }

}