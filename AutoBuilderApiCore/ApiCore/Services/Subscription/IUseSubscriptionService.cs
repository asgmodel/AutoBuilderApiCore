using AutoGenerator;
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
using AutoGenerator.Repositorys.Base;
using AutoGenerator.Helper;
using System;

namespace ApiCore.Services.Services
{
    public interface IUseSubscriptionService : ISubscriptionService<SubscriptionRequestDso, SubscriptionResponseDso>, IBaseService//يمكنك  التزويد بكل  دوال   طبقة Builder   ببوابات  الطبقة   هذه نفسها
    //, ISubscriptionBuilderRepository<SubscriptionRequestDso, SubscriptionResponseDso>
    , IBasePublicRepository<SubscriptionRequestDso, SubscriptionResponseDso>
    {
    }
}