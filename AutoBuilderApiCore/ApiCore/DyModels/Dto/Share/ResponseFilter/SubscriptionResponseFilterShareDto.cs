using Microsoft.CodeAnalysis;
using AutoGenerator;
using AutoGenerator.Helper.Translation;
using AutoGenerator.Models;
using ApiCore.DyModels.Dto.Build.ResponseFilters;
using System;

namespace ApiCore.DyModels.Dto.Share.ResponseFilters
{
    public class SubscriptionResponseFilterShareDto : SubscriptionResponseFilterBuildDto, ITShareDto
    {
    }
}