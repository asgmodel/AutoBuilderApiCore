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
using AutoGenerator.Helper;
using System;

namespace ApiCore.Repositorys.Share
{
    /// <summary>
    /// ModelAi interface for RepositoriesRepository.
    /// </summary>
    public interface IModelAiShareRepository : IBaseShareRepository<ModelAiRequestShareDto, ModelAiResponseShareDto> //
    , IBasePublicRepository<ModelAiRequestShareDto, ModelAiResponseShareDto>
    //  يمكنك  التزويد بكل  دوال   طبقة Builder   ببوابات  الطبقة   هذه نفسها      
    //,IModelAiBuilderRepository<ModelAiRequestShareDto, ModelAiResponseShareDto>
    {
    // Define methods or properties specific to the share repository interface.
    }
}