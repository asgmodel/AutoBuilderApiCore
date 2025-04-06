using ApiCore.DyModels.Dso.Requests;
using ApiCore.DyModels.Dso.ResponseFilters;
using ApiCore.DyModels.VMs;
using ApiCore.Services.Services;
using AutoGenerator.Conditions;
using AutoGenerator.Helper.Translation;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ApiCore.Validators
{
   


    public enum SpaceValidatorStates
    {
        IsActive,
        IsFull,
        IsValid

    }


    public class SpaceValidator : BaseValidator<SpaceResponseFilterDso, SpaceValidatorStates>, ITValidator
    {
        protected override void InitializeConditions()
        {
            _provider.Register(
                SpaceValidatorStates.IsActive,
                new LambdaCondition<SpaceResponseFilterDso>(
                    nameof(SpaceValidatorStates.IsActive),
                    context => context.IsGlobal == true,
                    "Space is not active"
                )
            );


            

        }
    }
}