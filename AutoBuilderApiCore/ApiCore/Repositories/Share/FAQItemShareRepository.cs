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
    /// FAQItem interface property for ShareRepository.
    /// </summary>
    public interface IFAQItemShareRepository : ITShareRepository<FAQItemRequestShareDto, FAQItemResponseShareDto>
    //, IFAQItemBuilderRepository<FAQItemRequestShareDto, FAQItemResponseShareDto> 
    //  يمكنك   تزويد  بكل دوال   Ibuilder  هنا   بحيث يمكنك استخدامها في الكلاس الذي سيتم توليده
    {
    // Define methods or properties specific to the share repository interface.
    } 
    /// <summary>
    /// FAQItem class property for ShareRepository.
    /// </summary>
     public  class  FAQItemShareRepository //
    :  BaseShareRepository < FAQItemRequestShareDto ,  FAQItemResponseShareDto ,  FAQItemRequestBuildDto ,  FAQItemResponseBuildDto > ,  //
    IFAQItemShareRepository //
    { 
    /// <summary>
    /// BuilderRepository 
    /// </summary>
     private  readonly  FAQItemBuilderRepository  _builder ;  
    /// <summary>
    /// Constructor for FAQItemShareRepository.
    /// </summary>
     public  FAQItemShareRepository ( DataContext  dbContext ,  IMapper  mapper ,  ILoggerFactory  logger ) :  base ( mapper ,  logger ) //
    { // Initialize constructor.
    _builder  =  new  FAQItemBuilderRepository ( dbContext ,  mapper ,  logger . CreateLogger ( typeof ( FAQItemShareRepository ) . FullName ) ) ;  //
    //
    } //
    // Add additional methods or properties as needed.
    }

}