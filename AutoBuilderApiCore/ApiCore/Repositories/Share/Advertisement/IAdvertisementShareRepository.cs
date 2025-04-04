using AutoGenerator.Data;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using AutoGenerator.Repositorys.Builder;
using ApiCore.DyModels.Dto.Build.Requests;
using ApiCore.DyModels.Dto.Build.Responses;
using AutoGenerator.Models;
using ApiCore.DyModels.Dto.Share.Requests;
using ApiCore.DyModels.Dto.Share.Responses;
using ApiCore.Repositorys.Builder;
using AutoGenerator.Repositorys.Share;
using System.Linq.Expressions;
using AutoGenerator.Repositorys.Base;
using AutoGenerator;
using System;

namespace ApiCore.Repositorys.Share
{
    /// <summary>
    /// Advertisement interface for RepositoriesRepository.
    /// </summary>
    public interface IAdvertisementShareRepository : IBaseShareRepository<AdvertisementRequestShareDto, AdvertisementResponseShareDto> //
    , IBasePublicRepository<AdvertisementRequestShareDto, AdvertisementResponseShareDto>
    //  يمكنك  التزويد بكل  دوال   طبقة Builder   ببوابات  الطبقة   هذه نفسها      
    //,IAdvertisementBuilderRepository<AdvertisementRequestShareDto, AdvertisementResponseShareDto>
    {
    // Define methods or properties specific to the share repository interface.
    }
}