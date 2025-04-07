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
   


    public enum SubscriptionValidatorStates
    {
        IsActive,
        IsFull,
        IsValid

    }


    public class SubscriptionValidator : BaseValidator<SubscriptionResponseFilterDso, SubscriptionValidatorStates>, ITValidator
    {
        public SubscriptionValidator(IConditionChecker checker) : base(checker)
        {
        }

        protected override void InitializeConditions()
        {
            _provider.Register(
                SubscriptionValidatorStates.IsActive,
                new LambdaCondition<SubscriptionResponseFilterDso>(
                    nameof(SpaceValidatorStates.IsActive),
                    context => context.AllowedSpaces==10,
                    "Space is not active"
                )
            );


            _provider.Register(
                SubscriptionValidatorStates.IsActive,
                new LambdaCondition<SubscriptionOutputVM>(
                    nameof(SpaceValidatorStates.IsActive),
                    context => context.AllowedSpaces == 10,
                    "Space is not active"
                )
            );



        }
    }
}